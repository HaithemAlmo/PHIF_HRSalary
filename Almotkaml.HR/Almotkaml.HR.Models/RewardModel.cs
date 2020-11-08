using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{

    public class RewardModel
    {
        public IEnumerable<RewardGridRow> RewardGrid { get; set; } = new HashSet<RewardGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        public int RewardId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
           ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Date))]
        public string Date { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string EmployeeName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EfficiencyEstimate))]
        public string EfficiencyEstimate { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Value))]
        public string Value { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.RewardType))]
        public int RewardTypeId { get; set; }
        public IEnumerable<RewardTypeListItem> RewardTypeList { get; set; } = new HashSet<RewardTypeListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Note))]
        public string Note { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Employee))]
        public int EmployeeId { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
        public bool CanSubmit { get; set; }
    }

    public class RewardGridRow
    {
        public int RewardId { get; set; }
        public string Date { get; set; }
        public string EfficiencyEstimate { get; set; }
        public string Value { get; set; }
        public int RewardTypeId { get; set; }
        public string RewardTypeName { get; set; }
        public string Note { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }


}
