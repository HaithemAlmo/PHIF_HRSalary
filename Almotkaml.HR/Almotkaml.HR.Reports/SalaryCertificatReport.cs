namespace Almotkaml.HR.Reports
{
    public class SalaryCertificatReport
    {
        public decimal premiumValue { get; set; }
        public decimal DiscountValue { get; set; }
        public string premiumName { get; set; }
        public string DiscountName { get; set; }
        public string EmployeeName { get; set; }
        public string NationalNumber { get; set; }
        public string Degree { get; set; }
        public int Boun { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal SocialSecurityFund { get; set; }
        public decimal SolidarityFund { get; set; }
        public decimal JihadTax { get; set; }
        public decimal MawadaFund { get; set; }
        public string AdvancePaymentName { get; set; }
        public decimal AdvancePaymentValue { get; set; }
        public decimal SalaryTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal NetSalary { get; set; }
    }
}