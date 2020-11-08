using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class DiscountSettlementReportBusiness : Business, IDiscountSettlementReportBusiness
    {
        public DiscountSettlementReportBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.DiscountSettlementReport && permission;

        public DiscountSettlementReportModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.DiscountSettlementReport))
                return Null<DiscountSettlementReportModel>(RequestState.NoPermission);

            return new DiscountSettlementReportModel()
            {
                DateFrom = DateTime.Now.Date.FormatToString(),
                DateTo = DateTime.Now.Date.FormatToString(),
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
              //  PremiumList = UnitOfWork.Premiums.GeteDiscount().ToList()
            };
        }

        public void Refresh(DiscountSettlementReportModel model)
        {
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);

            if (employee == null)
                return;
            model.EmployeeName = employee.GetFullName();
        }

        public bool View(DiscountSettlementReportModel model)
        {
            if (!HavePermission())
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryBy(model.EmployeeId, model.DateFrom.ToDateTime()
                , model.DateTo.ToDateTime());

            if (salaries == null)
                return false;

            var grid = new List<DiscountSettlementReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new DiscountSettlementReportGridRow()
                {
                    EmployeeName = salary.Employee?.GetFullName(),
                    Month = salary.MonthDate.Year + "-" + salary.MonthDate.Month,
                    JobNumber = salary.Employee?.JobInfo?.GetJobNumber(),
                    MonthlyInstallment = salary.SalaryPremiums.FirstOrDefault(s => s.SalaryId == salary.SalaryId
                        && s.PremiumId == model.PremiumId)?.Value ?? 0,
                    Rest = salary.SalaryPremiums.Where(s => s.SalaryId == salary.SalaryId
                            && s.PremiumId == model.PremiumId).Sum(s => s.Value),
                    //TotalValue =
                };
                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }
    }
}