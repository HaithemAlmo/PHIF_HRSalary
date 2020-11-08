using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        private HrDbContext Context { get; }

        internal JobRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Jobs
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Jobs
            .Any(e => e.Name == name && e.JobId != idToExcept);
    }
}