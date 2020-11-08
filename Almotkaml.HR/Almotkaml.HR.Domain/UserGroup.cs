using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class UserGroup
    {
        public static UserGroup Existed(int userGroupId, string name, Permission permissions)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(permissions, nameof(permissions));
            Check.MoreThanZero(userGroupId, nameof(userGroupId));

            return new UserGroup()
            {
                UserGroupId = userGroupId,
                Name = name,
                Permissions = permissions,
            };
        }
        public static UserGroup New(string name, Permission permissions)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(permissions, nameof(permissions));

            var group = new UserGroup()
            {
                Name = name,
                Permissions = permissions,
            };


            return group;
        }

        private UserGroup()
        {

        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public int UserGroupId { get; private set; }
        public string Name { get; private set; }
        public Permission Permissions { get; private set; }

        public void Modify(string name, Permission permissions)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(permissions, nameof(permissions));

            Name = name;
            Permissions = permissions;

        }

        public ICollection<User> Users { get; } = new HashSet<User>();
    }
}
