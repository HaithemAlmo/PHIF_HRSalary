using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business
{
    public class ApplicationUser : ApplicationUser<Permission, User, LoginModel, IApplicationUser>, IApplicationUser
    {
        public override IApplicationUser AsInterface() => this;
        public Notify Notify { get; private set; }
        public override void Set(User user, LoginModel model)
        {
            Check.NotNull(user, nameof(user));
            Check.NotNull(model, nameof(model));

            Id = user.UserId;
            UserName = user.UserName;
            Title = user.Title;
            Permissions = user.UserGroup.Permissions;
            Notify = user.Notify;
        }
    }
}