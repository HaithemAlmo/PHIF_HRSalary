using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class SolidarityFundReportModel
    {
        public IEnumerable<SolidarityFundReportGridRow> Grid { get; set; } = new HashSet<SolidarityFundReportGridRow>();
        public int Month { get; set; }
        public int Year { get; set; }
    }

    public class SolidarityFundReportGridRow
    {
        public int BankId { get; set; }
        public int BranchId { get; set; }
        public string JobNumber { get; set; }
        public string Name { get; set; }
        public decimal TotalSalary { get; set; }
        public GuaranteeType GuaranteeType { get; set; }
        public decimal EmployeeShare { get; set; }
        public decimal SolidarityFund { get; set; }
        public decimal CompanyShare { get; set; }
        public decimal ShareSum { get; set; }
        public int CostCenterId { get; set; }
        public string CostCenterName { get; set; }

    }
}