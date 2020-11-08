namespace Almotkaml.HR.Reports
{
    public class PensionFundReport
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string EmployeeName { get; set; }
        public string SecurityNumber { get; set; }
        public string Month { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal ExtraGeneralValue { get; set; }
        public decimal Total { get; set; }
        public decimal Reward { get; set; }
    }
}