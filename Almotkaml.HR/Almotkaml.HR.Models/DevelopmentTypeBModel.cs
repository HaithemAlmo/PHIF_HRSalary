using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class DevelopmentTypeBModel
    {
        public IEnumerable<DevelopmentTypeBGridRow> Grid { get; set; } = new HashSet<DevelopmentTypeBGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int DevelopmentTypeBId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.DevelopmentTypeB))]
        public string Name { get; set; }
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
    public class DevelopmentTypeBGridRow
    {
        public int DevelopmentTypeBId { get; set; }
        public string Name { get; set; }
        public string DevelopmentTypeAName { get; set; }
        public TrainingType TrainingType { get; set; }
    }
    public class DevelopmentTypeBListItem
    {
        public int DevelopmentTypeBId { get; set; }
        public string Name { get; set; }
    }
}
