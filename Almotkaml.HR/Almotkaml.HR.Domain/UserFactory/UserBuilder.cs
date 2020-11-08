namespace Almotkaml.HR.Domain.UserFactory
{
    public class UserBuilder : INameHolder, IPasswordHolder, ICheckPermHolder, IGroupHolder, ITitleHolder, INotifyHolder, IBuild
        , IIdHolder
    {
        public static IIdHolder Existed()
        {
            return new UserBuilder();
        }
        internal UserBuilder() { }
        private User User { get; } = new User();
        public INameHolder WithUserId(int userId)
        {
            Check.MoreThanZero(userId, nameof(userId));
            User.UserId = userId;

            return this;
        }

        public IPasswordHolder WithUserName(string userName)
        {
            Check.NotEmpty(userName, nameof(userName));
            User.UserName = userName;

            return this;
        }

        public ICheckPermHolder WithPassword(string password)
        {
            Check.NotEmpty(password, nameof(password));

            User.Password = password;

            return this;
        }
        public IGroupHolder WithCheckPerm(int CheckPerm)
        {


            User.CheckUserPerm = CheckPerm;

            return this;
        }
        public ITitleHolder BelongsToGroupId(int userGroupId)
        {
            Check.MoreThanZero(userGroupId, nameof(userGroupId));
            User.UserGroupId = userGroupId;

            return this;
        }
        public ITitleHolder BelongsToGroup(UserGroup userGroup)
        {
            Check.NotNull(userGroup, nameof(userGroup));

            User.UserGroup = userGroup;
            User.UserGroupId = userGroup.UserGroupId;

            return this;
        }

        public INotifyHolder WithTitle(string title)
        {
            Check.NotEmpty(title, nameof(title));
            User.Title = title;

            return this;
        }

        public IBuild NotifyOn(Notify notify)
        {
            Check.NotNull(notify, nameof(notify));
            User.Notify = notify;

            return this;
        }

        public User Biuld()
        {
            return User;
        }

    }

}