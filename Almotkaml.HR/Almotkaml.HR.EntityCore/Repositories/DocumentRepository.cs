using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        private HrDbContext DbContext { get; }
        internal DocumentRepository(HrDbContext context) : base(context)
        {
            DbContext = context;
        }

        public Document GetDocumentWithImages(int documentId)
            => DbContext.Documents
                .Include(d => d.DocumentType)
                .Include(d => d.Employee)
                .Include(d => d.DocumentImages)
                .FirstOrDefault(d => d.DocumentId == documentId);

        public Document GetDocumentById(int documentId)
            => DbContext.Documents
                .Include(d => d.DocumentType)
                .Include(d => d.Employee)
                .FirstOrDefault(d => d.DocumentId == documentId);

        public int GetMaxNumber(int employeeId)
            => DbContext.Documents.Where(d => d.EmployeeId == employeeId).Max(d => d.Number) + 1;


        public IEnumerable<Document> GetByEmployee(int employeeId)
            => DbContext.Documents
                .Include(d => d.DocumentType)
                .Where(d => d.EmployeeId == employeeId);

        public IEnumerable<Document> GetByEmployee(Employee employee)
            => GetByEmployee(employee.EmployeeId);
    }
}