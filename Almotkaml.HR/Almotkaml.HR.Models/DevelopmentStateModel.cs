using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class DevelopmentStateModel
    {
        public IEnumerable<DevelopmentStateGridRow> Grid { get; set; } = new HashSet<DevelopmentStateGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int DevelopmentStateId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DevelopmentState))]
        public string Name { get; set; }
    }

    public class DevelopmentStateGridRow
    {
        public int DevelopmentStateId { get; set; }
        public string Name { get; set; }
    }
    public class DevelopmentStateListItem
    {
        public int DevelopmentStateId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Name))]
        public string Name { get; set; }
    }
}