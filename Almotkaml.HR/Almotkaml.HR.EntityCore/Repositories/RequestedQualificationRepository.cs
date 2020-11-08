using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class RequestedQualificationRepository : Repository<RequestedQualification>, IRequestedQualificationRepository
    {
        private HrDbContext Context { get; }

        internal RequestedQualificationRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.RequestedQualifications
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.RequestedQualifications
            .Any(e => e.Name == name && e.RequestedQualificationId != idToExcept);
    }
}