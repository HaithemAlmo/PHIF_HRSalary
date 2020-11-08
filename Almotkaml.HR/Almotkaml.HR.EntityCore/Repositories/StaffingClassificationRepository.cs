using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class StaffingClassificationRepository : Repository<StaffingClassification>, IStaffingClassificationRepository
    {
        private HrDbContext Context { get; }

        internal StaffingClassificationRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<StaffingClassification> GetWithStaffings(int staffingId)
        {
            return Context.StaffingClassifications
                .Include(d => d.Staffing)
                .Where(d => d.StaffingId == staffingId);
        }

        public IEnumerable<StaffingClassification> GetWithStaffings()
        {
            return Context.StaffingClassifications
                .Include(d => d.Staffing);
        }

        public bool StaffingClassificationExisted(string name, int staffingId) => Context.StaffingClassifications
             .Any(e => e.Name == name && e.StaffingId == staffingId);

        public override StaffingClassification Find(object id)
           => Context.StaffingClassifications
                .Include(d => d.Staffing)
               .ThenInclude(c => c.StaffingType)
               .FirstOrDefault(d => d.StaffingClassificationId == (int)id);

        //public bool StaffingExisted(string name, int staffingTypeId, int idToExcept) => Context.Staffings
        //    .Any(e => e.Name == name && e.StaffingId != idToExcept && e.StaffingTypeId == staffingTypeId);

        //public IEnumerable<StaffingClassification> GetStaffingType(int staffingId)
        //{
        //    return Context.StaffingClassifications
        //        .Include(d => d.Staffing)
        //        .Where(d => d.StaffingId == staffingId);
        //}


    }
}