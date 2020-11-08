using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class DocumentTypeRepository : Repository<DocumentType>, IDocumentTypeRepository
    {
        private HrDbContext Context { get; }

        internal DocumentTypeRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name)
            => Context.DocumentTypes.Any(d => d.Name == name);

        public bool NameIsExisted(string name, int idToExcept)
            => Context.DocumentTypes.Any(d => d.Name == name && d.DocumentTypeId != idToExcept);
    }
}