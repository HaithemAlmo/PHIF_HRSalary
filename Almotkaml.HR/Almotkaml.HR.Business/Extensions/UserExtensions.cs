using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class UserExtensions
    {
        public static IEnumerable<UserGridRow> ToGrid(this IEnumerable<User> users)
            => users.Select(u => new UserGridRow()
            {
                UserId = u.UserId,
                UserName = u.UserName,
                Title = u.Title,
                GroupName = u.UserGroup?.Name
            });

        public static IEnumerable<UserListItem> ToList(this IEnumerable<User> users)
           => users.Select(u => new UserListItem()
           {
               UserId = u.UserId,
               Title = u.UserName,
           });
    }
}
