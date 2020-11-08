using Almotkaml.Attributes;
using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class UserActivityExtensions
    {
        public static IEnumerable<UserActivityGridrow> ToGrid(this IEnumerable<Activity> inventories)
          => inventories.Select(i => new UserActivityGridrow()
          {
              DateTime = i.DateTime.ToString(),
              ActivityId = i.ActivityId,
              Type = typeof(Notify).GetAttribute<PhraseAttribute>(i.Type)?.Display,
              Title = i.FiredBy_User.UserName
          });
    }
}
