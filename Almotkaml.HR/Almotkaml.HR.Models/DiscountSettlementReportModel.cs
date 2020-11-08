using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class DiscountSettlementReportModel
    {
        public IEnumerable<DiscountSettlementReportGridRow> Grid { get; set; } =
            new HashSet<DiscountSettlementReportGridRow>();
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
        public IEnumerable<TemEmployeePremiumListItemEE> PremiumList { get; set; } = new HashSet<TemEmployeePremiumListItemEE>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Discount))]
        public int PremiumId { get; set; }
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
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Titel))]
        public string Titel { get; set; }
    }

    public class DiscountSettlementReportGridRow
    {
        public string JobNumber { get; set; }
        public string EmployeeName { get; set; }
        public string Month { get; set; }
        public decimal TotalValue { get; set; }
        public decimal MonthlyInstallment { get; set; }
        public decimal Rest { get; set; }
    }

}