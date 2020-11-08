using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IAdjectiveEmployeeRepository : IRepository<AdjectiveEmployee>
    {
        IEnumerable<AdjectiveEmployee> GetAdjectiveEmployeeWithType(int adjectiveEmployeeTypeId);
        IEnumerable<AdjectiveEmployee> GetAdjectiveEmployeeWithType();
        bool AdjectiveEmployeeExisted(string name, int employeeWithTypeid, int idToExcept);
    }
}