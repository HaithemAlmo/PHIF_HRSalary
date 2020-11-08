using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        private HrDbContext Context { get; }
        internal ActivityRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }


        public IEnumerable<Activity> GetUserActivities(DateTime fromDate, DateTime toDate, int userId)
        {
            var userActivity = Context.Activities
                .Include(i => i.FiredBy_User)
                .Where(u => u.DateTime >= fromDate && u.DateTime <= toDate);
            if (userId > 0)
                userActivity = userActivity.Where(u => u.FiredBy_UserId == userId);

            return userActivity;

        }
    }
}
