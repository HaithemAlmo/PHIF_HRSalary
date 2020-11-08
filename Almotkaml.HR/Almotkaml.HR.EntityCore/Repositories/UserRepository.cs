using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Domain.UserFactory;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private HrDbContext Context { get; }
        internal UserRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public override void Remove(User domain)
        {
            var activities = Context.Activities.Where(a => a.FiredBy_UserId == domain.UserId);
            Context.RemoveRange(activities);
            base.Remove(domain);
        }

        public override void AddRange(IEnumerable<User> domains)
        {
            var users = domains as IList<User> ?? domains.ToList();

            foreach (var user in users)
            {
                user.SetValue(u => u.Password, user.Password.ToMd5());
            }
            base.AddRange(users);
        }

        public User GetByNameAndPassword(string name, string password)
        {
            var encryptedPassword = password?.ToMd5();

            var user = Context.Users
                .Include(u => u.UserGroup)
                .AsNoTracking()
                .Where(u => u.UserName == name && u.Password == encryptedPassword)
                .Select(u => UserBuilder.Existed()
                    .WithUserId(u.UserId)
                    .WithUserName(u.UserName)

                    .WithPassword(u.Password)
                .WithCheckPerm(u.CheckUserPerm)
                    .BelongsToGroup(UserGroup.Existed(u.UserGroupId, u.UserGroup.Name,
                        EF.Property<string>(u.UserGroup,
                            Column(nameof(UserGroup.Permissions))).ToDeserializedObject<Permission>()))
                    .WithTitle(u.Title)
                    .NotifyOn(EF.Property<string>(u, Column(nameof(User.Notify))).ToDeserializedObject<Notify>())
                    .Biuld())
                .FirstOrDefault();

            if (user == null)
                return null;

            Detache(user);

            Context.Attach(user);
            Context.LoggedInUserId = user.UserId;
            return user;
        }

        public IEnumerable<User> GetUsersWithGroups() => Context.Users
            .Include(u => u.UserGroup)
            .Select(u => UserBuilder.Existed()
                .WithUserId(u.UserId)
                .WithUserName(u.UserName)
                .WithPassword(u.Password)
            .WithCheckPerm(u.CheckUserPerm)
                .BelongsToGroup(UserGroup.Existed(u.UserGroupId, u.UserGroup.Name,
                    EF.Property<string>(u.UserGroup,
                        Column(nameof(UserGroup.Permissions))).ToDeserializedObject<Permission>()))
                .WithTitle(u.Title)
                .NotifyOn(
                    EF.Property<string>(u, Column(nameof(User.Notify))).ToDeserializedObject<Notify>())
                .Biuld());

        public IEnumerable<User> GetUsersWithGroups(int userGroupId) => Context.Users
            .Include(u => u.UserGroup)
            .Where(u => u.UserGroupId == userGroupId)
            .Select(u => UserBuilder.Existed()
                .WithUserId(u.UserId)
                .WithUserName(u.UserName)
                .WithPassword(u.Password)
            .WithCheckPerm(u.CheckUserPerm)
                .BelongsToGroup(UserGroup.Existed(u.UserGroupId, u.UserGroup.Name,
                    EF.Property<string>(u.UserGroup,
                        Column(nameof(UserGroup.Permissions))).ToDeserializedObject<Permission>()))
                .WithTitle(u.Title)
                .NotifyOn(
                    EF.Property<string>(u, Column(nameof(User.Notify))).ToDeserializedObject<Notify>())
                .Biuld());

        public IEnumerable<User> GetAllUsersNotifications() => Context.Users
            .Select(u => UserBuilder.Existed()
                .WithUserId(u.UserId)
                .WithUserName(u.UserName)
                .WithPassword(u.Password)
            .WithCheckPerm(u.CheckUserPerm)
                .BelongsToGroup(UserGroup.Existed(u.UserGroupId, u.UserGroup.Name,
                    EF.Property<string>(u.UserGroup,
                        Column(nameof(UserGroup.Permissions))).ToDeserializedObject<Permission>()))
                .WithTitle(u.Title)
                .NotifyOn(
                    EF.Property<string>(u, Column(nameof(User.Notify))).ToDeserializedObject<Notify>())
                .Biuld());

        public bool NameIsExisted(string name) => Context.Users
            .Any(u => u.UserName == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Users
            .Any(u => u.UserName == name && u.UserId != idToExcept);

        public override User Find(object id)
        {
            var user = Context.Users
                .AsNoTracking()
                .Select(u => UserBuilder.Existed()
                    .WithUserId(u.UserId)
                    .WithUserName(u.UserName)
                    .WithPassword(u.Password)
                    .WithCheckPerm(u.CheckUserPerm)
                    .BelongsToGroup(UserGroup.Existed(u.UserGroupId, u.UserGroup.Name,
                        EF.Property<string>(u.UserGroup,
                            Column(nameof(UserGroup.Permissions))).ToDeserializedObject<Permission>()))
                    .WithTitle(u.Title)
                    .NotifyOn(
                        EF.Property<string>(u, Column(nameof(User.Notify))).ToDeserializedObject<Notify>())
                    .Biuld()).FirstOrDefault(u => u.UserId == (int)id);

            if (user == null)
                return null;

            Detache(user);

            Context.Attach(user);
            return user;
        }

        public override IEnumerable<User> GetAll() => Context.Users
            .Select(u => UserBuilder.Existed()
                .WithUserId(u.UserId)
                .WithUserName(u.UserName)
                .WithPassword(u.Password)
            .WithCheckPerm(u.CheckUserPerm)
                .BelongsToGroup(UserGroup.Existed(u.UserGroupId, u.UserGroup.Name,
                    EF.Property<string>(u.UserGroup,
                        Column(nameof(UserGroup.Permissions))).ToDeserializedObject<Permission>()))
                .WithTitle(u.Title)
                .NotifyOn(
                    EF.Property<string>(u, Column(nameof(User.Notify))).ToDeserializedObject<Notify>())
                .Biuld());


        private void Detache(User user)
        {
            var userEntry = Context.ChangeTracker.Entries<User>()
            .FirstOrDefault(e => e.Entity.UserId == user.UserId);

            if (userEntry != null)
                userEntry.State = EntityState.Detached;
        }



        public IEnumerable<User> GetUserPerm(int ID)
        {
            return Context.Users.Where(s => s.UserId == ID);
        }
    }
}
