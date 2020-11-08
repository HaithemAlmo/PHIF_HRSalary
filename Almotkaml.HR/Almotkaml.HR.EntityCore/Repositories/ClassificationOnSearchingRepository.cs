using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class ClassificationOnSearchingRepository : Repository<ClassificationOnSearching>, IClassificationOnSearchingRepository
    {
        private HrDbContext Context { get; }

        internal ClassificationOnSearchingRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.ClassificationOnSearchings
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.ClassificationOnSearchings
            .Any(e => e.Name == name && e.ClassificationOnSearchingId != idToExcept);
    }
}