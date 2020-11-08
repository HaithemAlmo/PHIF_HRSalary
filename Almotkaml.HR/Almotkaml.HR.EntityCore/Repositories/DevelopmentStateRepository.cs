using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class DevelopmentStateRepository : Repository<DevelopmentState>, IDevelopmentStateRepository
    {
        private HrDbContext Context { get; }

        internal DevelopmentStateRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.DevelopmentStates
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.DevelopmentStates
            .Any(e => e.Name == name && e.DevelopmentStateId != idToExcept);
    }
}