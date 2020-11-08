using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IDevelopmentTypeBRepository : IRepository<DevelopmentTypeB>
    {
        IEnumerable<DevelopmentTypeB> GetDevelopmentTypeBWithDevelopmentTypeA(int developmentTypeAId);
        IEnumerable<DevelopmentTypeB> GetDevelopmentTypeBWithDevelopmentTypeA();
        bool DevelopmentTypeBExisted(string name, int developmentTypeAId);
        bool DevelopmentTypeBExisted(string name, int developmentTypeAId, int idToExcept);
    }
}