using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class VacationTypeRepository : Repository<VacationType>, IVacationTypeRepository
    {
        private HrDbContext Context { get; }

        internal VacationTypeRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name)
            => Context.VacationTypes.Any(v => v.Name == name);

        public bool NameIsExisted(string name, int idToExcept)
            => Context.VacationTypes.Any(v => v.Name == name && v.VacationTypeId == idToExcept);
    }
}