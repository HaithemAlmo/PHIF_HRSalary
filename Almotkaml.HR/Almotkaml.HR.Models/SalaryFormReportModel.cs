using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class SalaryFormReportModel
    {
        public IEnumerable<SalaryFormReportGridRow> Grid { get; set; } = new HashSet<SalaryFormReportGridRow>();
        public int Month { get; set; }
        public int Year { get; set; }
        public int? DivisionId { get; set; }
        public int? JobId { get; set; }
        public IEnumerable<DivisionListItem> DivisionList { get; set; } = new HashSet<DivisionListItem>();
        public IEnumerable<JobListItem> JobList { get; set; } = new HashSet<JobListItem>();
    }

    public class SalaryFormReportGridRow
    {
        public string JobNumber { get; set; }
        public string Name { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Absence { get; set; }
        public decimal SickVacation { get; set; }
        public decimal WithoutPay { get; set; }
        public decimal Sanction { get; set; }
        public decimal ExtraWork { get; set; }
        public decimal ExtraWorkVacation { get; set; }
        public decimal ExtraWorkConst { get; set; }
        public decimal SituationOnTotal { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal SolidarityFund { get; set; }
        public decimal PrepaidSalaryAndAdvancePremium { get; set; }
        public decimal EmployeeShare { get; set; }
        public decimal CompanyShare { get; set; }
        public decimal SubjectSalary { get; set; }
        public decimal Subject { get; set; }
        public decimal JihadTax { get; set; }
        public decimal ExemptionTax { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal PrepaidSalary { get; set; }
        public decimal SituationOnNet { get; set; }
        public decimal NetSalary { get; set; }
        public decimal StampTax { get; set; }
        public decimal FinalSalary { get; set; }
        public decimal AdvancePremiumInside { get; set; }
        public decimal AdvancePremiumOutside { get; set; }
        public decimal ExtraGeneralValue { get; set; }
        public decimal ExtraValue { get; set; }
        public int CostCenterId { get; set; }
        public string CostCenterName { get; set; }
        public int EmployeeStat { get; set; }
        public int EmployeeId { get; set; }
        public int BankId { get; set; }
        public int BranchId { get; set; }
        public IList<SalaryPremiumListItem> SalaryPremiumList { get; set; } = new List<SalaryPremiumListItem>();
        public IEnumerable<PremiumListItem> PremiumList { get; set; } = new HashSet<PremiumListItem>();
        public decimal AccumulatedValue { get; set; } //المتراكم
  
        public decimal RewindValue { get; set; } //الترجيع
        public decimal Discound { get; set; }
        public decimal AllBouns { get; set; }
    }
}