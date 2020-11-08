using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IDevelopmentTypeCRepository : IRepository<DevelopmentTypeC>
    {
        IEnumerable<DevelopmentTypeC> GetDevelopmentTypeCWithDevelopmentTypeB(int developmentTypeBId);
        IEnumerable<DevelopmentTypeC> GetDevelopmentTypeCWithDevelopmentTypeB();
        bool DevelopmentTypeCExisted(string name, int developmentTypeBId);
        bool DevelopmentTypeCExisted(string name, int developmentTypeBId, int idToExcept);
    }
}