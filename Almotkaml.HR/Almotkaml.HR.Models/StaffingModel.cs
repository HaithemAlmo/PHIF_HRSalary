using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class StaffingModel
    {
        public IEnumerable<StaffingGridRow> StaffingGrid { get; set; } = new HashSet<StaffingGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int StaffingId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.Staffing))]
        public string Name { get; set; }
        public IEnumerable<StaffingTypeListItem> StaffingTypeList { get; set; } = new HashSet<StaffingTypeListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.StaffingType))]
        public int StaffingTypeId { get; set; }
    }
    public class StaffingGridRow
    {
        public int StaffingId { get; set; }
        public string Name { get; set; }
        public string StaffingTypeName { get; set; }
        public int StaffingTypeId { get; set; }

    }
    public class StaffingListItem
    {
        public int StaffingId { get; set; }
        public string Name { get; set; }
    }


}