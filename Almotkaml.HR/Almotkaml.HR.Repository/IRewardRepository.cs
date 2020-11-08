using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IRewardRepository : IRepository<Reward>
    {
        IEnumerable<Reward> GetRewardByEmployeeId(int employeeid);
    }
}