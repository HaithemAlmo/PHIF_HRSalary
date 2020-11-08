using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class ClipboardBankingReportModel
    {
        public IEnumerable<ClipboardBankingReportGridRow> Grid { get; set; } = new HashSet<ClipboardBankingReportGridRow>();
        public int Month { get; set; }
        public int IsLegal { get; set; }

        public int Year { get; set; }
        public int BankId { get; set; }
        public int BankBranchId { get; set; }
        public IEnumerable<BankListItem> BankList { get; set; } = new HashSet<BankListItem>();
        public IEnumerable<BankBranchListItem> BankBranchList { get; set; } = new HashSet<BankBranchListItem>();
    }

    public class ClipboardBankingReportGridRow
    {
        public int BankId { get; set; }

        public string JobNumber { get; set; }
        public string EmployeeName { get; set; }
        public string NationalNumber { get; set; }
        public string BondNumber { get; set; }
        public decimal FinalySalary { get; set; }
        public string BankBranchName { get; set; }
        public int BankBranchId { get; set; }
        public string FinancialNumber { get; set; }
        public string LICJobNumber { get; set; }
    }
}
