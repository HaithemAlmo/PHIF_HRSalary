using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class UserIndexModel
    {
        public int UserId { get; set; }

        public int UserGroupId { get; set; }
        public IEnumerable<UserGroupListItem> UserGroupList { get; set; } = new HashSet<UserGroupListItem>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public IEnumerable<UserGridRow> UserGrid { get; set; } = new HashSet<UserGridRow>();
    }

    public class UserGridRow
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
    }

    public class UserListItem
    {
        public int UserId { get; set; }
        public string Title { get; set; }
    }
    public class UserCreateModel : IValidatable
    {
        public int CheckPerm { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles),
            Name = nameof(SharedTitles.UserTitle))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles),
            Name = nameof(SharedTitles.UserName))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles),
             Name = nameof(SharedTitles.Password))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles),
             Name = nameof(SharedTitles.ConfirmPassword))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, double.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(HR.Resources.Title.Group))]
        public int UserGroupId { get; set; }
        public IEnumerable<UserGroupListItem> UserGroupList { get; set; }
        public void Validate(ModelState modelState)
        {
            if (Password != ConfirmPassword)
                modelState.AddError(m => this.ConfirmPassword, SharedMessages.PasswordNotMatch);
        }
    }
    public class UserEditModel : IValidatable
    {
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles),
            Name = nameof(SharedTitles.UserTitle))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles),
            Name = nameof(SharedTitles.UserName))]
        public string UserName { get; set; }

        [Display(ResourceType = typeof(SharedTitles),
             Name = nameof(SharedTitles.NewPassword))]
        public string NewPassword { get; set; }

        [Display(ResourceType = typeof(SharedTitles),
             Name = nameof(SharedTitles.ConfirmPassword))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, double.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(HR.Resources.Title.Group))]
        public int UserGroupId { get; set; }
        public IEnumerable<UserGroupListItem> UserGroupList { get; set; }

        [Display(ResourceType = typeof(SharedTitles),
             Name = nameof(SharedTitles.ChangePassword))]
        public bool ChangePassword { get; set; }
        public bool CanSubmit { get; set; }

        public void Validate(ModelState modelState)
        {
            if (!ChangePassword)
                return;

            if (string.IsNullOrWhiteSpace(NewPassword))
                modelState.AddError(
                    m => this.NewPassword,
                    string.Format(SharedMessages.IsRequired, SharedTitles.NewPassword));

            if (NewPassword != ConfirmPassword)
                modelState.AddError(m => this.ConfirmPassword, SharedMessages.PasswordNotMatch);
        }
    }
}
