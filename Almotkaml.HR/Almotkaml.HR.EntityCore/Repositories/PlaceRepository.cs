using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        private HrDbContext Context { get; }

        internal PlaceRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<Place> GetPlaceWithBranch(int branchId)
        {
            return Context.Places
              .Include(p => p.Branch)
              .Where(p => p.BranchId == branchId);
        }

        public IEnumerable<Place> GetPlaceWithBranch()
        {
            return Context.Places
                .Include(b => b.Branch);
        }

        public bool PlaceExisted(string name, int branchId) => Context.Places
            .Any(e => e.Name == name && e.BranchId == branchId);

        public bool PlaceExisted(string name, int branchId, int idToExcept) => Context.Places
            .Any(e => e.Name == name && e.PlaceId == idToExcept && e.BranchId == branchId);
    }
}