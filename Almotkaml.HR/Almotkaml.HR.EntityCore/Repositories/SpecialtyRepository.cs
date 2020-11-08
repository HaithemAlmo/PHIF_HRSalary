using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
    {
        private HrDbContext Context { get; }

        internal SpecialtyRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }
        public bool NameIsExisted(string name) => Context.Specialties
          .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Specialties
            .Any(e => e.Name == name && e.SpecialtyId != idToExcept);
    }
}