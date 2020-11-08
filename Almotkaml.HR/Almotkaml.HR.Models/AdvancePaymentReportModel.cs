using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class AdvancePaymentReportModel
    {
        public IEnumerable<AdvancePaymentReportGridRow> Grid { get; set; } = new HashSet<AdvancePaymentReportGridRow>();
        public int Month { get; set; }
        public int Year { get; set; }
        public int IsAdvanse { get; set; }

    }

    public class AdvancePaymentReportGridRow
    {
        public int BankId { get; set; }
        public int BranchId { get; set; }
        public string JobNumber { get; set; }
        public string Name { get; set; }
        public decimal PrepaidSalary { get; set; }
        public decimal AdvancePaymentInside { get; set; }
        public decimal AdvancePaymentOutside { get; set; }
        public int CostCenterId { get; set; }
        public string CostCenterName { get; set; }
        public decimal AdvancePayment { get; set; }
    }
}