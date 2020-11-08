using Almotkaml.Extensions;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class AdvancePaymentReportBusiness : Business, IAdvancePaymentReportBusiness
    {
        public AdvancePaymentReportBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }
        private bool HavePermission(bool permission = true)
          => ApplicationUser.Permissions.AdvancePaymentReport && permission;

        public AdvancePaymentReportModels Prepare()
        {
            if (!HavePermission())
                return Null<AdvancePaymentReportModels>(RequestState.NoPermission);

            return new AdvancePaymentReportModels()
            {
                DateFrom = DateTime.Now.FormatToString(),
                DateTo = DateTime.Now.FormatToString(),
                DateFromWithEmployee = DateTime.Now.FormatToString(),
                DateToWithEmployee = DateTime.Now.FormatToString(),
                EmployeeSearchGrid = UnitOfWork.Employees.GetAll().ToGrid(),
            };
        }

        public AdvancePaymentReportModels Index(AdvancePaymentReportModels model)
        {
            model.AdvanceDetectionReportModel = new AdvanceDetectionReportModel()
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo

            };
            model.EmployeeAdvanceDetectionReportModel = new EmployeeAdvanceDetectionReportModel()
            {
                DateFrom = model.DateFromWithEmployee,
                DateTo = model.DateToWithEmployee,
                EmployeeId = model.EmployeeId

            };

            return model;
        }


        public void Refresh(AdvancePaymentReportModels model)
        {
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            if (employee == null)
                return;
            model.EmployeeName = employee.GetFullName();
        }

        public bool ViewInside(AdvanceDetectionReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByDate(model.DateFrom.ToDateTime(), model.DateTo.ToDateTime()).ToList();

            if (salaries == null)
                return false;

            var grid = new HashSet<AdvanceDetectionReportGridRow>();

            foreach (var salary in salaries.Where(s => s.AdvancePremiumInside > 0))
            {
                var row = new AdvanceDetectionReportGridRow()
                {
                    EmployeeName = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    CostCenterId = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.CenterId ?? 0,////////
                    CostCenterName = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,///////
                    //Date =,
                    Value = salary.Employee?.AdvancePayments.Where(a => a.IsInside).Sum(a => a.Value) ?? 0,
                    //Rest = ,
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }

        public bool ViewOutside(AdvanceDetectionReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByDate(model.DateFrom.ToDateTime(), model.DateTo.ToDateTime()).ToList();//////////////////////

            if (salaries == null)
                return false;

            var grid = new HashSet<AdvanceDetectionReportGridRow>();

            foreach (var salary in salaries.Where(s => s.AdvancePremiumOutside > 0))
            {
                var row = new AdvanceDetectionReportGridRow()
                {
                    EmployeeName = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    CostCenterId = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.CenterId ?? 0,////////
                    CostCenterName = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,///////
                    Date = salary.MonthDate.FormatToString(),
                    Value = salary.Employee?.AdvancePayments.Where(a => a.IsInside == false).Sum(a => a.Value) ?? 0,
                    Rest = salaries.Where(s => s.AdvancePremiumOutside > 0 && s.EmployeeId == salary.EmployeeId)
                            .Sum(s => s.AdvancePremiumOutside),
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }

        public bool ViewInside(EmployeeAdvanceDetectionReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByEmployeeIdAndDate(model.EmployeeId
                        , model.DateFrom.ToDateTime(), model.DateTo.ToDateTime()).ToList();

            if (salaries == null)
                return false;

            var grid = new HashSet<EmployeeAdvanceDetectionReportGridRow>();

            foreach (var salary in salaries.Where(s => s.AdvancePremiumInside > 0))
            {
                foreach (var advancePayments in salary.Employee.AdvancePayments.Where(a => a.IsInside))
                {
                    var row = new EmployeeAdvanceDetectionReportGridRow()
                    {
                        EmployeeId = salary.EmployeeId,
                        EmployeeName = salary.Employee?.GetFullName(),
                        JobNumber = salary.JobNumber,
                        Value = advancePayments.Value,
                        InstallmentValue = advancePayments.InstallmentValue,
                        DeductionDate = salary.MonthDate.FormatToString(),
                        Rest = salary.Employee.AdvancePayments.Where(a => a.IsInside).Sum(a => a.Value)
                               - salaries.Sum(s => s.AdvancePremiumInside),
                        //Date =,
                    };

                    grid.Add(row);
                }
            }

            model.Grid = grid;

            return true;
        }

        public bool ViewOutside(EmployeeAdvanceDetectionReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByEmployeeIdAndDate(model.EmployeeId
                        , model.DateFrom.ToDateTime(), model.DateTo.ToDateTime()).ToList();///////////////////////

            if (salaries == null)
                return false;

            var grid = new HashSet<EmployeeAdvanceDetectionReportGridRow>();

            foreach (var salary in salaries.Where(s => s.AdvancePremiumOutside > 0))
            {
                foreach (var advancePayments in salary.Employee.AdvancePayments.Where(a => a.IsInside == false))
                {
                    var row = new EmployeeAdvanceDetectionReportGridRow()
                    {
                        EmployeeId = salary.EmployeeId,
                        EmployeeName = salary.Employee?.GetFullName(),
                        JobNumber = salary.JobNumber, ///////
                        Value = advancePayments.Value,
                        InstallmentValue = advancePayments.InstallmentValue,
                        DeductionDate = salary.MonthDate.FormatToString(),
                        Rest = salary.Employee.AdvancePayments.Where(a => a.IsInside == false).Sum(a => a.Value)
                               - salaries.Sum(s => s.AdvancePremiumOutside),
                        //Date =
                    };

                    grid.Add(row);
                }
            }

            model.Grid = grid;

            return true;
        }
    }
}