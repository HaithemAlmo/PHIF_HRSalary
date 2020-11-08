using Almotkaml.Attributes;
using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class SettlementVacationReportModel
    {
        public IEnumerable<SettlementVacationReportGridRow> Grid { get; set; } = new HashSet<SettlementVacationReportGridRow>();
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
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.VacationType))]
        public int VacationTypeId { get; set; }
        public IEnumerable<VacationTypeListItem> VacationTypeList { get; set; } = new HashSet<VacationTypeListItem>();
        public string VacationTypeName { get; set; }
    }

    public class SettlementVacationReportGridRow
    {
        public string JobNumber { get; set; }
        public string Name { get; set; }
        public string Center { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public string Unit { get; set; }
        public string NationalNumber { get; set; }
        public string VacationFrom { get; set; }
        public string VacationTo { get; set; }
    }

}