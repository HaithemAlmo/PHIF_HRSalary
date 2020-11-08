using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class TaxReportModel
    {
        public IEnumerable<TaxReportGridRow> Grid { get; set; } = new HashSet<TaxReportGridRow>();
        public int Month { get; set; }
        public int Year { get; set; }
    }

    public class TaxReportGridRow
    {
        public int BankId { get; set; }
        public int BranchId { get; set; }
        public string JobNumber { get; set; }
        public string Name { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal SubjectSalary { get; set; }
        public decimal Subject { get; set; }
        public decimal JihadTax { get; set; }
        public decimal ExemptionTax { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetSalary { get; set; }
        public decimal StampTax { get; set; }
        public decimal TaxSum { get; set; }
        public int CostCenterId { get; set; }
        public string CostCenterName { get; set; }
    }
}