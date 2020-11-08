using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class ClassificationOnSearchingModel
    {
        public IEnumerable<ClassificationOnSearchingGridRow> Grid { get; set; } = new HashSet<ClassificationOnSearchingGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int ClassificationOnSearchingId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.Name))]
        public string Name { get; set; }
    }
    public class ClassificationOnSearchingGridRow
    {
        public int ClassificationOnSearchingId { get; set; }
        public string Name { get; set; }
    }
    public class ClassificationOnSearchingListItem
    {
        public int ClassificationOnSearchingId { get; set; }
        public string Name { get; set; }
    }



}