using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Models
{
    public class StaffingClassificationModel
    {
        public int StaffingClassificationId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),Name = nameof(Title.StaffingClassification))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),  Name = nameof(Title.StaffingType))]
        public int? StaffingTypeId { get; set; }

        public IEnumerable<StaffingTypeListItem> StaffingTypeList { get; set; } = new HashSet<StaffingTypeListItem>();


        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Staffing))]
        public int StaffingId { get; set; }

        public IEnumerable<StaffingListItem> StaffingList { get; set; } = new HashSet<StaffingListItem>();
        public IEnumerable<StaffingClassificationListItem> StaffingClassificationList { get; set; } = new HashSet<StaffingClassificationListItem>();
        public IEnumerable<StaffingClassificationGridRow> StaffingClassificationGrid { get; set; } = new HashSet<StaffingClassificationGridRow>();

        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }

    public class StaffingClassificationGridRow
    {
        public int StaffingClassificationId { get; set; }
        public string Name { get; set; }
        public string StaffingName { get; set; }
        public int StaffingId { get; set; }

    }
    public class StaffingClassificationListItem
    {
        public int StaffingClassificationId { get; set; }
        public string Name { get; set; }
    }

}
