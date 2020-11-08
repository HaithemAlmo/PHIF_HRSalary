using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class CurrentSituationRepository : Repository<CurrentSituation>, ICurrentSituationRepository
    {
        private HrDbContext Context { get; }

        internal CurrentSituationRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }
        public bool NameIsExisted(string name) => Context.CurrentSituations
          .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.CurrentSituations
            .Any(e => e.Name == name && e.CurrentSituationId != idToExcept);
    }
}