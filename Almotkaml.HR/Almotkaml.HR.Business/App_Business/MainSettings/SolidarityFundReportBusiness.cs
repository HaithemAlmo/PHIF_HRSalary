using Almotkaml.HR.Models;
using System.Collections.Generic;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SolidarityFundReportBusiness : Business, ISolidarityFundReportBusiness
    {
        public SolidarityFundReportBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        public SolidarityFundReportModel Prepare()
        {
            return new SolidarityFundReportModel();
        }

        public bool View(SolidarityFundReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByMonth(model.Year, model.Month);

            if (salaries == null)
                return false;

            var grid = new HashSet<SolidarityFundReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new SolidarityFundReportGridRow()
                {
                    Name = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    TotalSalary = salary.TotalSalary(Settings),
                    SolidarityFund = salary.SolidarityFund(Settings),//////////////////
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }
    }
}