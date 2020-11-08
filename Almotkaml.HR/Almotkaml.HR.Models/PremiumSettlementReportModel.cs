using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class PremiumSettlementReportModel
    {
        public IEnumerable<PremiumSettlementReportGridRow> Grid { get; set; } =
            new HashSet<PremiumSettlementReportGridRow>();
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles),
            Name = nameof(SharedTitles.FromDate))]
        public string DateFrom { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles),
            Name = nameof(SharedTitles.ToDate))]
        public string DateTo { get; set; }
    }
    public class PremiumSettlementReportGridRow
    {
        public string EmployeeName { get; set; }
        public string NationalNumber { get; set; }
        public string PremiumName { get; set; }
        public decimal Value { get; set; }
        public string Month { get; set; }
    }

}