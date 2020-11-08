namespace Almotkaml.HR.Reports
{
    public class PremiumSettlementReport
    {
        public string EmployeeName { get; set; }
        public string NationalNumber { get; set; }
        public string PremiumName { get; set; }
        public decimal Value { get; set; }
        public string Month { get; set; }
    }
}