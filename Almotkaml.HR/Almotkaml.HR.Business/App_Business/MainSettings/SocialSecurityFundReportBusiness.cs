using Almotkaml.HR.Models;
using System.Collections.Generic;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SocialSecurityFundReportBusiness : Business, ISocialSecurityFundReportBusiness
    {
        public SocialSecurityFundReportBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        public SocialSecurityFundReportModel Prepare()
        {
            return new SocialSecurityFundReportModel();
        }

        public bool View(SocialSecurityFundReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByMonth(model.Year, model.Month);

            if (salaries == null)
                return false;

            var grid = new HashSet<SocialSecurityFundReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new SocialSecurityFundReportGridRow()
                {
                    Name = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    CompanyShare = salary.CompanyShare(Settings),
                    EmployeeShare = salary.EmployeeShare(Settings),
                    GuaranteeType = salary.Employee?.SalaryInfo?.GuaranteeType ?? 0,
                    TotalSalary = salary.TotalSalary(Settings),
                    ShareSum = salary.EmployeeShare(Settings) + salary.CompanyShare(Settings)
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }
    }
}