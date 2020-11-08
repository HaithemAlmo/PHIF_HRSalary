using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Document GetDocumentWithImages(int documentId);
        Document GetDocumentById(int documentId);
        int GetMaxNumber(int employeeId);
        IEnumerable<Document> GetByEmployee(Employee employee);
        IEnumerable<Document> GetByEmployee(int employeeId);
    }
}