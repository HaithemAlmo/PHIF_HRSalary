using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class QualificationTypeRepository : Repository<QualificationType>, IQualificationTypeRepository
    {
        private HrDbContext Context { get; }

        internal QualificationTypeRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }
        public bool NameIsExisted(string name) => Context.QualificationTypes
          .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.QualificationTypes
            .Any(e => e.Name == name && e.QualificationTypeId != idToExcept);
    }
}