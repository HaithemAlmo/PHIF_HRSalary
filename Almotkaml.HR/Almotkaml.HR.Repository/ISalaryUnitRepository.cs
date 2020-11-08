using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface ISalaryUnitRepository : IRepository<SalaryUnit>
    {
        IEnumerable<SalaryUnit> GetBySalayClassification(SalayClassification salayClassification);
    }
}