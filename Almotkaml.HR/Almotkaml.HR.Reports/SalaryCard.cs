namespace Almotkaml.HR.Reports
{
    public class SalaryCard
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
        public decimal EmployeeShare { get; set; }
        public decimal CompanyShare { get; set; }
        public decimal SubjectSalary { get; set; }
        public decimal Subject { get; set; }
        public decimal JihadTax { get; set; }
        public decimal ExemptionTax { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal PrepaidSalaryAndAdvancePremium { get; set; }
        public decimal SituationOnNet { get; set; }
        public decimal NetSalary { get; set; }
        public decimal StampTax { get; set; }
        public string BounName { get; set; }
        public decimal BounValue { get; set; }
        public string SecurityNumber { get; set; }
        public string FinancialNumber { get; set; }
        public GuaranteeType GuaranteeType { get; set; }
        public decimal ExtraWorkFixed { get; set; }

        public string BondNumber { get; set; }
        //public decimal AccumulatedValue { get; set; } //المتراكم
        //public decimal RewindValue { get; set; } //الترجيع
        public string EmployeeName { get; set; }
        public string BankBranchName { get; set; }
        public string BankName { get; set; }
        public int EmployeeId { get; set; }



    }
}
