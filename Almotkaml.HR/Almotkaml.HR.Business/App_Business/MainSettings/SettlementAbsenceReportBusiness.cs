using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SettlementAbsenceReportBusiness : Business, ISettlementAbsenceReportBusiness
    {
        public SettlementAbsenceReportBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.SettlementAbsenceReport && permission;

        public SettlementAbsenceReportModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.SettlementAbsenceReport))
                return Null<SettlementAbsenceReportModel>(RequestState.NoPermission);

            return new SettlementAbsenceReportModel()
            {
                DateFrom = DateTime.Now.Date.FormatToString(),
                DateTo = DateTime.Now.Date.FormatToString(),
            };
        }

        public bool View(SettlementAbsenceReportModel model)
        {
            if (!HavePermission())
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            DateTime Date = model.DateFrom.ToDateTime();
            var GetSalary = UnitOfWork.Salaries.GetSalaryByMonth(Date.Year, Date.Month);

            var absences = UnitOfWork.Absences.GetAbsentEmployeesBy(model.DateFrom.ToDateTime()
                , model.DateTo.ToDateTime(), model.AbsenceType);

            var grid = new List<SettlementAbsenceReportGridRow>();
            var Salary = GetSalary?.Where(p => absences.Any(p2 => p2.EmployeeId == p.EmployeeId));
            foreach (var salary in Salary)
            {
              var datasources = new List<SettlementAbsenceReportGridRow>();
                foreach (var absence in absences.Where(a=>a.EmployeeId == salary.EmployeeId))
                {
                    if (!datasources.Any(d=>d.Name==absence.Employee.GetFullName()))
                    {
                       
                        datasources.Add(new SettlementAbsenceReportGridRow()
                        {
                            Note = absence?.Note,
                            Center = absence.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,
                            Name = absence.Employee?.GetFullName(),
                            NationalNumber = absence.Employee?.SalaryInfo?.FinancialNumber,
                            Unit = absence.Employee?.JobInfo?.Unit?.Name,
                            Division = absence.Employee?.JobInfo?.Unit?.Division?.Name,
                            Department = absence.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,
                            JobNumber = absence.Employee?.JobInfo?.GetJobNumber(),
                            DaysCount = salary?.AbsenceDayEmployee(Date) ?? 0 ,
                            AbsenceValue = salary?.Absence() ?? 0,
                        });
                        grid.AddRange(datasources);
                    }
                }  
            }

           
            model.Grid = grid;

            return true;
        }
    }
}