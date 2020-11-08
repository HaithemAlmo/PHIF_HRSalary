using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class SalaryCardReportModel
    {
        public IEnumerable<SalaryCardReportGridRow> Grid { get; set; } = new HashSet<SalaryCardReportGridRow>();
        public int Month { get; set; }
        public int Year { get; set; }
        public int EmployeeId { get; set; }
        public IEnumerable<EmployeeListItem> EmployeeList { get; set; } = new HashSet<EmployeeListItem>();
    }

    public class EmployeeListItem
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
    }

    public class SalaryCardReportGridRow
    {
        public int BankBranchId { get; set; }
        public int BankId { get; set; }
        public string JobNumber { get; set; }
        public string Name { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Absence { get; set; }
        public decimal SickVacation { get; set; }
        public decimal WithoutPay { get; set; }
        public decimal Sanction { get; set; }
        public decimal ExtraWork { get; set; }
        public decimal ExtraWorkVacation { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal SolidarityFund { get; set; }
        public decimal EmployeeShare { get; set; }
        public decimal CompanyShare { get; set; }
        public decimal SubjectSalary { get; set; }
        public decimal Subject { get; set; }
        public decimal JihadTax { get; set; }
        public decimal ExemptionTax { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal PrepaidSalary { get; set; }
        public decimal AdvancePremiumInside { get; set; }
        public decimal AdvancePremiumOutside { get; set; }
        public decimal NetSalary { get; set; }
        public decimal StampTax { get; set; }
        public string BounName { get; set; }
        public decimal BounValue { get; set; }
        public string SecurityNumber { get; set; }
        public string FinancialNumber { get; set; }
        public GuaranteeType GuaranteeType { get; set; }
        public decimal ExtraWorkFixed { get; set; }
        public decimal ExtraGeneralValue { get; set; }
        public decimal ExtraValue { get; set; }
        public string BondNumber { get; set; }
        public string EmployeeName { get; set; }
        public string BankBranchName { get; set; }
        public string BankName { get; set; }
        public IList<SalaryPremiumListItem> SalaryPremiumList { get; set; } = new List<SalaryPremiumListItem>();
        public IEnumerable<PremiumListItem> PremiumList { get; set; } = new HashSet<PremiumListItem>();
        public int CostCenterId { get; set; }
        public string CostCenterName { get; set; }
        public decimal RewindValue { get; set; }
        public decimal AccumulatedValue { get; set; }
        public ICollection<AdvanseListItem> AdvanseListItem { get; set; }
    }
}
