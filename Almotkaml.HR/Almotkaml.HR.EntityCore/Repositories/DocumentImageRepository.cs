using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class DocumentImageRepository : Repository<DocumentImage>, IDocumentImageRepository
    {
        internal DocumentImageRepository(HrDbContext context) : base(context)
        {
            
        }
    }
}