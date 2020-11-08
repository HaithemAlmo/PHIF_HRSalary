using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class SanctionTypeRepository : Repository<SanctionType>, ISanctionTypeRepository
    {
        private HrDbContext Context { get; }

        internal SanctionTypeRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }
        public bool NameIsExisted(string name) => Context.SanctionTypes
          .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.SanctionTypes
            .Any(e => e.Name == name && e.SanctionTypeId != idToExcept);
    }
}