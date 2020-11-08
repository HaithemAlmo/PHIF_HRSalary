using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class RewardRepository : Repository<Reward>, IRewardRepository
    {
        private HrDbContext Context { get; }

        internal RewardRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<Reward> GetRewardByEmployeeId(int employeeid)
        {
            return Context.Rewards
                .Include(e => e.Employee)
                .Include(r => r.RewardType)
                .Where(e => e.EmployeeId == employeeid);
        }
    }
}