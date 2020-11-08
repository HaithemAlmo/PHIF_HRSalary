using Almotkaml.HR.Domain;
using Almotkaml.Repository;

namespace Almotkaml.HR.Repository
{
    public interface IDocumentTypeRepository : IRepository<DocumentType>, ICheckNameExisted
    {

    }
}