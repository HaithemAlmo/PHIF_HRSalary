using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Almotkaml.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories

{
    public class UserGroupRepository : Repository<UserGroup>, IUserGroupRepository
    {
        private HrDbContext Context { get; }

        internal UserGroupRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public override UserGroup Find(object id)
        {
            var userGroup = Context.UserGroups
                .AsNoTracking()
                .Select(g => UserGroup.Existed(g.UserGroupId, g.Name,
                    EF.Property<string>(g,
                        Column(nameof(UserGroup.Permissions))).ToDeserializedObject<Permission>()))
                .FirstOrDefault(g => g.UserGroupId == (int)id);

            if (userGroup == null)
                return null;

            var userGroupEntries = Context.ChangeTracker.Entries<UserGroup>().ToList();

            foreach (var entityEntry in userGroupEntries)
            {
                entityEntry.State = EntityState.Detached;
            }

            Context.Attach(userGroup);

            return userGroup;
        }

        public override IEnumerable<UserGroup> GetAll() => Context.UserGroups
            .Select(g => UserGroup.Existed(g.UserGroupId, g.Name,
                EF.Property<string>(g,
                    Column(nameof(UserGroup.Permissions))).ToDeserializedObject<Permission>()));

        public bool NameIsExisted(string name) => Context.UserGroups
            .Any(u => u.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.UserGroups
            .Any(u => u.Name == name && u.UserGroupId != idToExcept);
    }
}
