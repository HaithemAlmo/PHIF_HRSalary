using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IUnitRepository : IRepository<Unit>
    {
        IEnumerable<Unit> GetUnitWithDivision(int divisionId);
        IEnumerable<Unit> GetUnitWithDivision();
        bool UnitExisted(string name, int divisionId, int idToExcept);
        bool UnitExisted(string name, int divisionId);


    }
}