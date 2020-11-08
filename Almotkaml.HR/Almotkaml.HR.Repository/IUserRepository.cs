using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IUserRepository : IRepository<User>, ICheckNameExisted
    {
        User GetByNameAndPassword(string name, string password);
        IEnumerable<User> GetUsersWithGroups();
        IEnumerable<User> GetUsersWithGroups(int userGroupId);
        IEnumerable<User> GetAllUsersNotifications();
        IEnumerable<User> GetUserPerm(int ID);

    }
}