using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IDivisionRepository : IRepository<Division>
    {
        IEnumerable<Division> GetDivisionWithDepartment(int departmentId);
        IEnumerable<Division> GetDivisionWithDepartment();
        bool DivisionExisted(string name, int departmentId);
        bool DivisionExisted(string name, int departmentId, int idToExcept);
    }
}