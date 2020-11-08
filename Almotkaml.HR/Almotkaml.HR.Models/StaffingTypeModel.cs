using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class StaffingTypeModel
    {
        public IEnumerable<StaffingTypeGridRow> StaffingTypeGrid { get; set; } = new HashSet<StaffingTypeGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int StaffingTypeId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
        Name = nameof(Title.StaffingType))]
        public string Name { get; set; }
    }

    public class StaffingTypeGridRow
    {
        public int StaffingTypeId { get; set; }
        public string Name { get; set; }
    }

    public class StaffingTypeListItem
    {
        public int StaffingTypeId { get; set; }
        public string Name { get; set; }
    }


}