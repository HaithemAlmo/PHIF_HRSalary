using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class StaffingTypeRepository : Repository<StaffingType>, IStaffingTypeRepository
    {
        private HrDbContext Context { get; }

        internal StaffingTypeRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }
        public bool NameIsExisted(string name) => Context.StaffingTypes
          .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.StaffingTypes
            .Any(e => e.Name == name && e.StaffingTypeId != idToExcept);
    }
}