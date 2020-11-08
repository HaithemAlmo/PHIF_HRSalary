using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.Attributes;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class DelegationIndexModel
    {
        public IEnumerable<DelegationGridRow> DelegationGrid { get; set; } = new HashSet<DelegationGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

    }

    public class DelegationGridRow
    {
        public int DelegationId { get; set; }
        public string Name { get; set; }
        public string JobNumber { get; set; } // الرقم الوظيفي 
        public JobTypeTransfer JobTypeTransfer { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string SideName { get; set; }

    }

    public class DelegationFormModel
    {
        public int DelegationId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobNumber))]
        public string JobNumber { get; set; } // الرقم الوظيفي 


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 3, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobType))]
        public JobTypeTransfer JobTypeTransfer { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateFrom))]
        public string DateFrom { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateTo))]
        public string DateTo { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SideName))]
        public string SideName { get; set; }


        [Display(ResourceType = typeof(Title), Name = nameof(Title.QualificationType))]
        public int? QualificationTypeId { get; set; }
        public IEnumerable<QualificationTypeListItem> QualificationTypeList { get; set; } = new HashSet<QualificationTypeListItem>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.DelegationNumber))]
        public string DelegationNumber { get; set; }

        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionDate))]
        public string DecisionDate { get; set; }

        public bool CanSubmit { get; set; }
    }
}
