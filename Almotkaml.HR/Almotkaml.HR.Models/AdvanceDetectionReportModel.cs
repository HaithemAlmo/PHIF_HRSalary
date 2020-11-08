using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class AdvanceDetectionReportModel
    {
        public IEnumerable<AdvanceDetectionReportGridRow> Grid { get; set; } =
            new HashSet<AdvanceDetectionReportGridRow>();

        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }

    public class AdvanceDetectionReportGridRow
    {
        public string JobNumber { get; set; }
        public string EmployeeName { get; set; }
        public int CostCenterId { get; set; }
        public string CostCenterName { get; set; }
        public decimal Value { get; set; }
        public decimal Rest { get; set; }
        public string Date { get; set; }
        public int EmployeeId { get; set; }
        //public string TafKeet { get; set; }
    }
}
