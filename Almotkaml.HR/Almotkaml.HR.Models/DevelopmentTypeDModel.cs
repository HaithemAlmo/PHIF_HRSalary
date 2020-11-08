using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class DevelopmentTypeDModel
    {
        public IEnumerable<DevelopmentTypeDGridRow> Grid { get; set; } = new HashSet<DevelopmentTypeDGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int DevelopmentTypeDId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.DevelopmentTypeD))]
        public string Name { get; set; }
        public IEnumerable<DevelopmentTypeCListItem> DevelopmentTypeCList { get; set; } = new HashSet<DevelopmentTypeCListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.DevelopmentTypeC))]
        public int DevelopmentTypeCId { get; set; }
        public IEnumerable<DevelopmentTypeBListItem> DevelopmentTypeBList { get; set; } = new HashSet<DevelopmentTypeBListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.DevelopmentTypeB))]
        public int DevelopmentTypeBId { get; set; }
        public IEnumerable<DevelopmentTypeAListItem> DevelopmentTypeAList { get; set; } = new HashSet<DevelopmentTypeAListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.DevelopmentTypeA))]
        public int DevelopmentTypeAId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.TrainingType))]
        public TrainingType TrainingType { get; set; }

    }
    public class DevelopmentTypeDGridRow
    {
        public int DevelopmentTypeDId { get; set; }
        public string Name { get; set; }
        public string DevelopmentTypeAName { get; set; }
        public string DevelopmentTypeBName { get; set; }
        public string DevelopmentTypeCName { get; set; }
        public TrainingType TrainingType { get; set; }
    }
    public class DevelopmentTypeDListItem
    {
        public int DevelopmentTypeDId { get; set; }
        public string Name { get; set; }
    }
}
