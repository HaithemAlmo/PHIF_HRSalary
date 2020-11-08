using Almotkaml.Attributes;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class UserActivityModel
    {

        [Date]
        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.FromDate))]
        public string DateFrom { get; set; }
        [Date]
        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.ToDate))]
        public string DateTo { get; set; }

        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.UserTitle))]
        public int? UserId { get; set; }
        public IEnumerable<UserListItem> UserListItems { get; set; } = new HashSet<UserListItem>();
        public IEnumerable<UserActivityGridrow> GridRows { get; set; } = new HashSet<UserActivityGridrow>();
        public bool CanSave { get; set; }
    }

    public class UserActivityGridrow
    {
        public long ActivityId { get; set; }
        public string DateTime { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
