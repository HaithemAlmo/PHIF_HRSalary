using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<Department> GetDepartmentWithCenter(int centerId);
        IEnumerable<Department> GetDepartmentWithCenter();
        bool DepartmentExisted(string name, int centerId);
        bool DepartmentExisted(string name, int centerId, int idToExcept);

    }
}