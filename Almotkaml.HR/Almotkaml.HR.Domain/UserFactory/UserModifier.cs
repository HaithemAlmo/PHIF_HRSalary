namespace Almotkaml.HR.Domain.UserFactory
{
    public class UserModifier
    {
        internal UserModifier(User user)
        {
            User = user;
        }
        private User User { get; }

        public UserModifier UserName(string userName)
        {
            Check.NotEmpty(userName, nameof(userName));
            User.UserName = userName;
            return this;
        }
        public UserModifier Password(string password)
        {
            Check.NotEmpty(password, nameof(password));
            User.Password = password;

            return this;
        }
        public UserModifier GroupId(int userGroupId)
        {
            Check.MoreThanZero(userGroupId, nameof(userGroupId));
            User.UserGroupId = userGroupId;

            return this;
        }
        public UserModifier Group(UserGroup userGroup)
        {
            Check.NotNull(userGroup, nameof(userGroup));

            User.UserGroup = userGroup;
            User.UserGroupId = userGroup.UserGroupId;

            return this;
        }
        public UserModifier Title(string title)
        {
            Check.NotEmpty(title, nameof(title));
            User.Title = title;

            return this;
        }
        public UserModifier NotifyOn(Notify notify)
        {
            Check.NotNull(notify, nameof(notify));
            User.Notify = notify;

            return this;
        }

        public User Confirm()
        {
            return User;
        }
    }
}