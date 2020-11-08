using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class UserGroupIndexModel
    {
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public IEnumerable<UserGroupGridRow> UserGroupGrid { get; set; } = new HashSet<UserGroupGridRow>();
    }

    public class UserGroupGridRow
    {
        public int UserGroupId { get; set; }
        public string Name { get; set; }
    }

    public class UserGroupFormModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Group))]
        public string Name { get; set; }
        public Permission Permissions { get; set; }
        public bool CanSubmit { get; set; }
    }

    public class UserGroupListItem
    {
        public int UserGroupId { get; set; }
        public string Name { get; set; }
    }
}
