using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class CurrentSituationModel
    {
        public IEnumerable<CurrentSituationGridRow> CurrentSituationGrid { get; set; } = new HashSet<CurrentSituationGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int CurrentSituationId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.CurrentSituation))]
        public string Name { get; set; }
    }
    public class CurrentSituationGridRow
    {
        public int CurrentSituationId { get; set; }
        public string Name { get; set; }
    }
    public class CurrentSituationListItem
    {
        public int CurrentSituationId { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }


}