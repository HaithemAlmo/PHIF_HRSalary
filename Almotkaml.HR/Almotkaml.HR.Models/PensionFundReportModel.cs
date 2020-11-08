using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class PensionFundReportModel
    {
        public IEnumerable<PensionFundReportGridRow> Grid { get; set; } =
            new HashSet<PensionFundReportGridRow>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
    }
    public class PensionFundReportGridRow
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