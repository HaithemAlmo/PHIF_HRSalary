using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class EmployeeAdvanceDetectionReportModel
    {
        public IEnumerable<EmployeeAdvanceDetectionReportGridRow> Grid { get; set; } =
            new HashSet<EmployeeAdvanceDetectionReportGridRow>();
        public int EmployeeId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }
    public class EmployeeAdvanceDetectionReportGridRow
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string JobNumber { get; set; }
        public string Date { get; set; }
        public decimal Value { get; set; }
        public decimal Rest { get; set; }
        public decimal InstallmentValue { get; set; }
        public string DeductionDate { get; set; }
    }
}
