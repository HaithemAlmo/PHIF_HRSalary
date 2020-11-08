using Almotkaml.HR.Models;
using System.Collections.Generic;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class TaxReportBusiness : Business, ITaxReportBusiness
    {
        public TaxReportBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        public TaxReportModel Prepare()
        {
            return new TaxReportModel();
        }

        public bool View(TaxReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByMonth(model.Year, model.Month);

            if (salaries == null)
                return false;

            var grid = new HashSet<TaxReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new TaxReportGridRow()
                {
                    Name = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    TotalSalary = salary.TotalSalary(Settings),
                    ExemptionTax = salary.ExemptionTax(Settings),
                    IncomeTax = salary.IncomeTax(Settings),
                    JihadTax = salary.JihadTax(Settings),
                    NetSalary = salary.NetSalary(Settings),
                    StampTax = salary.StampTax(Settings),
                    SubjectSalary = salary.SubjectSalary(Settings),
                    TaxSum = salary.IncomeTax(Settings) + salary.JihadTax(Settings) ///////
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }
    }
}