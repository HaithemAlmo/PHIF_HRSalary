namespace Almotkaml.HR.Reports
{
    public class TaxReport
    {
        public string JobNumber { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal SubjectSalary { get; set; }
        public decimal Subject { get; set; }
        public decimal JihadTax { get; set; }
        public decimal ExemptionTax { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal NetSalary { get; set; }
        public decimal StampTax { get; set; }
        public string CostCenterName { get; set; }
        public int CostCenterId { get; set; }
        public string Tafkeet { get; set; }
    }
}
