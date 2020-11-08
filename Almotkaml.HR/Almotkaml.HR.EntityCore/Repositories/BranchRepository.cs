using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        private HrDbContext Context { get; }

        internal BranchRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Branchs
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Branchs
            .Any(e => e.Name == name && e.BranchId != idToExcept);
    }
}