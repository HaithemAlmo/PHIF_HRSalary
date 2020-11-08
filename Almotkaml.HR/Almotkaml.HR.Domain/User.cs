using Almotkaml.HR.Domain.UserFactory;
using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class User
    {
        public static INameHolder New()
        {
            return new UserBuilder();
        }

        internal User() { }

        public int UserId { get; internal set; }
        public string Title { get; internal set; }
        public string UserName { get; internal set; }
        public string Password { get; internal set; }
        public int UserGroupId { get; internal set; }
        public int CheckUserPerm { get; internal set; }
        public UserGroup UserGroup { get; internal set; }
        public Notify Notify { get; internal set; }
        public ICollection<Activity> Activities { get; } = new HashSet<Activity>();
        public ICollection<Notification> Notifications { get; internal set; } = new HashSet<Notification>();

        public UserModifier Modify()
        {
            return new UserModifier(this);
        }

    }
}
