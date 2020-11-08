using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class AdvancePaymentReportModels
    {
        //-------------Search
        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateFrom))]
        public string DateFrom { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateTo))]
        public string DateTo { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateFrom))]
        public string DateFromWithEmployee { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateTo))]
        public string DateToWithEmployee { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeSearchGrid = new HashSet<EmployeeGridRow>();

        public string EmployeeName { get; set; }

        public IEnumerable<AdvanceDetectionReportGridRow> FullReportGrid { get; set; } =
        new HashSet<AdvanceDetectionReportGridRow>();

        public IEnumerable<EmployeeAdvanceDetectionReportGridRow> EmployeeGrid { get; set; } =
          new HashSet<EmployeeAdvanceDetectionReportGridRow>();


        public AdvanceDetectionReportModel AdvanceDetectionReportModel { get; set; } = new AdvanceDetectionReportModel();
        public EmployeeAdvanceDetectionReportModel EmployeeAdvanceDetectionReportModel { get; set; }
                        = new EmployeeAdvanceDetectionReportModel();


    }
}
