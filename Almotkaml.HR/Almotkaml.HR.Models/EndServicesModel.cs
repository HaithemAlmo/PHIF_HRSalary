using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class EndServicesIndexModel
    {
        public IEnumerable<EndServicesGridRow> EndServicesGrid { get; set; } = new HashSet<EndServicesGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

    }

    public class EndServicesGridRow
    {
        public int EndServicesId { get; set; }
        public string DecisionDate { get; set; }
        public string DecisionNumber { get; set; }
        public string Cause { get; set; }
        public string Note { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public CauseOfEndService CauseOfEndService { get; set; }

    }

    public class EndServicesFormModel
    {
        public int EndServicesId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionDate))]
        public string DecisionDate { get; set; }


        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string EmployeeName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
     ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionNumber))]
        public string DecisionNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 9, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CauseEndServices))]
        public CauseOfEndService CauseOfEndService { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Notes))]
        public string Cause { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }

        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
        public bool CanSubmit { get; set; }
    }
}
