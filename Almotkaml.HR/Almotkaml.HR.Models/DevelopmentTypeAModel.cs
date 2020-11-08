using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class DevelopmentTypeAModel
    {
        public IEnumerable<DevelopmentTypeAGridRow> Grid { get; set; } = new HashSet<DevelopmentTypeAGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int DevelopmentTypeAId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DevelopmentTypeA))]
        public string Name { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.TrainingType))]
        public TrainingType TrainingType { get; set; }

    }
    public class DevelopmentTypeAGridRow
    {
        public int DevelopmentTypeAId { get; set; }
        public string Name { get; set; }
        public TrainingType TrainingType { get; set; }
    }
    public class DevelopmentTypeAListItem
    {
        public int DevelopmentTypeAId { get; set; }
        public string Name { get; set; }
    }
}
