using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class PremiumSettlementReportBusiness : Business, IPremiumSettlementReportBusiness
    {
        public PremiumSettlementReportBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.PremiumSettlementReport && permission;

        public PremiumSettlementReportModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.PremiumSettlementReport))
                return Null<PremiumSettlementReportModel>(RequestState.NoPermission);

            return new PremiumSettlementReportModel()
            {
                DateFrom = DateTime.Now.Date.FormatToString(),
                DateTo = DateTime.Now.Date.FormatToString(),
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
            };
        }

        public void Refresh(PremiumSettlementReportModel model)
        {
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);

            if (employee == null)
                return;
            model.EmployeeName = employee.GetFullName();
        }

        public bool View(PremiumSettlementReportModel model)
        {
            if (!HavePermission())
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryBy(model.EmployeeId, model.DateFrom.ToDateTime()
                , model.DateTo.ToDateTime());

            if (salaries == null)
                return false;

            //var salaryPremium = salaries.FirstOrDefault().SalaryPremiums;
            var grid = new List<PremiumSettlementReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new PremiumSettlementReportGridRow
                {
                    EmployeeName = salary.Employee?.GetFullName(),
                    Month = salary.MonthDate.Year + "-" + salary.MonthDate.Month,
                    NationalNumber = salary.Employee?.NationalNumber
                };
                foreach (var salaryPremium in salary.SalaryPremiums.Where(s => s.Premium.DiscountOrBoun == DiscountOrBoun.Boun))
                {
                    row.Value = salaryPremium.Value;
                    row.PremiumName = salaryPremium.Premium.Name;
                    grid.Add(row);
                }
            }

            model.Grid = grid;

            return true;
        }
    }
}