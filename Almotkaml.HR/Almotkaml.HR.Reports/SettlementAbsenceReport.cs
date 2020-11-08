namespace Almotkaml.HR.Reports
{
    public class SettlementAbsenceReport
    {
        public string JobNumber { get; set; }
        public string Name { get; set; }
        public string Center { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public string Unit { get; set; }
        public string NationalNumber { get; set; }
        public int DaysCount { get; set; }
        public decimal AbsenceValue { get; set; }
    }
}