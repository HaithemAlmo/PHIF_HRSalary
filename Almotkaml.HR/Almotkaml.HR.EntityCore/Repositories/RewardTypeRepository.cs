using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class RewardTypeRepository : Repository<RewardType>, IRewardTypeRepository
    {
        private HrDbContext Context { get; }

        internal RewardTypeRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }
        public bool NameIsExisted(string name) => Context.RewardTypes
          .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.RewardTypes
            .Any(e => e.Name == name && e.RewardTypeId != idToExcept);
    }
}