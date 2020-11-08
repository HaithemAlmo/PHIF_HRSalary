using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class DelegationRepository : Repository<Delegation>, IDelegationRepository
    {
        private HrDbContext Context { get; }

        internal DelegationRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }
    }
}