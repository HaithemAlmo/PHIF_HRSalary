using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class CenterRepository : Repository<Center>, ICenterRepository
    {
        private HrDbContext Context { get; }

        internal CenterRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Centers
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Centers
            .Any(e => e.Name == name && e.CenterId != idToExcept);

        public int GetCenterNumberBy(int centerId) => Context.Centers
            .FirstOrDefault(c => c.CenterId == centerId)?.CenterNumber ?? 0;
    }
}