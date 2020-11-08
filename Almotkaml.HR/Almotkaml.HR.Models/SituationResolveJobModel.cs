using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class SituationResolveJobModel
    {
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int SituationResolveJobId { get; set; }

        public string EmployeeName { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionNumber))]
        public string DecisionNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionDate))]
        public string DecisionDate { get; set; }


        [Display(ResourceType = typeof(Title), Name = nameof(Title.DegreeBefor))]
        public int Degree { get; set; }


        [Display(ResourceType = typeof(Title), Name = nameof(Title.BounsBefor))]
        public int Boun { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 15, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DegreeNow))]
        public int DegreeNow { get; set; }
        public string DateDegreeNow { get; set; }
       // [Required(ErrorMessageResourceType = typeof(SharedMessages),
       //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
       // [Range(1, 20, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BounsNow))]
        public int BounNow { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Qualificationbefore))]
        public string Qualificationbefore { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Qualificationafter))]
        public string Qualificationafter { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Note))]
        public string Note { get; set; }


        // [Required(ErrorMessageResourceType = typeof(SharedMessages),
        //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateDegreeLast))]
        public string DateDegreeLast { get; set; }
        public string DateBounLast { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
      ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobNow))]
        public int JobLastId { get; set; }
        public IEnumerable<JobListItem> JobLastList { get; set; } = new HashSet<JobListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
    ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobNow))]
        public int JobNowId { get; set; }
        public IEnumerable<JobListItem> JobNowList { get; set; } = new HashSet<JobListItem>();

        public bool CanSubmit { get; set; }

        public IEnumerable<SituationResolveJobGrid> SituationResolveJobGrid { get; set; } = new HashSet<SituationResolveJobGrid>();
    }

    public class SituationResolveJobGrid
    {
        public int SituationResolveJobId { get; set; }
        public string EmployeeName { get; set; }
        public string DecisionNumber { get; set; }
        public string DecisionDate { get; set; }
        public string DateDegreeLast { get; set; }
        public string DateBounLast { get; set; }
        public int Degree { get; set; }
        public int Boun { get; set; }
        public int DegreeNow { get; set; }
        public int BounNow { get; set; }
        public string JobNowName { get; set; }

    }


}
