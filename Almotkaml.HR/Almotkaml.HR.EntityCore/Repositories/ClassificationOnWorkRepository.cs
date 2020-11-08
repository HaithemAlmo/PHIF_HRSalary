using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class ClassificationOnWorkRepository : Repository<ClassificationOnWork>, IClassificationOnWorkRepository
    {
        private HrDbContext Context { get; }

        internal ClassificationOnWorkRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.ClassificationOnWorks
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.ClassificationOnWorks
            .Any(e => e.Name == name && e.ClassificationOnWorkId != idToExcept);
    }
}