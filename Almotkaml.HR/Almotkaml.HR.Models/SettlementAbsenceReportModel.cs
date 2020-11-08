using Almotkaml.Attributes;
using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class SettlementAbsenceReportModel
    {
        public IEnumerable<SettlementAbsenceReportGridRow> Grid { get; set; } = new HashSet<SettlementAbsenceReportGridRow>();
        [Date]
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles),
            Name = nameof(SharedTitles.FromDate))]
        public string DateFrom { get; set; }

        [Date]
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles),
            Name = nameof(SharedTitles.ToDate))]
        public string DateTo { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Absence))]
        public AbsenceType AbsenceType { get; set; }
    }
    public class SettlementAbsenceReportGridRow
    {
        public string Note { get; set; }

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