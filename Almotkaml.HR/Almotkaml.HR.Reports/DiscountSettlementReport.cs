namespace Almotkaml.HR.Reports
{
    public class DiscountSettlementReport
    {
        public string JobNumber { get; set; }
        public string EmployeeName { get; set; }
        public string Month { get; set; }
        public decimal TotalValue { get; set; }
        public decimal MonthlyInstallment { get; set; }
        public decimal Rest { get; set; }
    }
}