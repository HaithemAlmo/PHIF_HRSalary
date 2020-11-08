using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class StaffingRepository : Repository<Staffing>, IStaffingRepository
    {
        private HrDbContext Context { get; }

        internal StaffingRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<Staffing> GetStaffingWithStaffingType(int staffingTypeId)
        {
            return Context.Staffings
                .Include(d => d.StaffingType)
                .Where(d => d.StaffingTypeId == staffingTypeId);
        }

        public IEnumerable<Staffing> GetStaffingWithStaffingType()
        {
            return Context.Staffings
                .Include(d => d.StaffingType);
        }

        public bool StaffingExisted(string name, int staffingTypeId) => Context.Staffings
            .Any(e => e.Name == name && e.StaffingTypeId == staffingTypeId);

        public bool StaffingExisted(string name, int staffingTypeId, int idToExcept) => Context.Staffings
            .Any(e => e.Name == name && e.StaffingId != idToExcept && e.StaffingTypeId == staffingTypeId);

        public IEnumerable<StaffingClassification> GetStaffingType(int staffingId)
        {
            return Context.StaffingClassifications
                .Include(d => d.Staffing)
                .Where(d => d.StaffingId == staffingId);
        }
    }
}