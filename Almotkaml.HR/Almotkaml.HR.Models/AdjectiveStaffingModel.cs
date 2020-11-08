using Almotkaml.HR.Models.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class AdjectiveStaffingIndexModel
    {
        public IEnumerable<AdjectiveStaffingGridRow> AdjectiveStaffingGrid { get; set; } = new HashSet<AdjectiveStaffingGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

    }
    public class AdjectiveStaffingGridRow
    {
        public int AdjectiveStaffingId { get; set; }
        public string Name { get; set; }
    }
    public class AdjectiveStaffingListItem
    {
        public int AdjectiveStaffingId { get; set; }
        public string Name { get; set; }
    }

    public class AdjectiveStaffingFormModel
    {
        public int AdjectiveStaffingId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AdjectiveEmployee))]
        public string Name { get; set; }
        public bool CanSubmit { get; set; }
    }
}