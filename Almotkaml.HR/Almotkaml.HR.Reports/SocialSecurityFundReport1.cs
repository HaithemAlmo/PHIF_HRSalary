namespace Almotkaml.HR.Reports
{
    public class SocialSecurityFundReport1
    {
        public string JobNumber { get; set; }
        public string Name { get; set; }
        public decimal TotalSalary { get; set; }
        public GuaranteeType GuaranteeType { get; set; }
        public decimal EmployeeShare { get; set; }
        public decimal CompanyShare { get; set; }
        public decimal ShareSum { get; set; }
        public string CostCenterName { get; set; }
        public int CostCenterId { get; set; }
        public string Tafkeet { get; set; }
        public string SecurityNumber { get; set; }//الرقم الضمان
        public string InstrumentNumber { get; set; }//رقم الصك 
        public string SocialSecurityFundBondNumber { get; set; }//الرقم الضماني
        public string NationalNumber { get; set; }//الرقم الوطني 
    }
}