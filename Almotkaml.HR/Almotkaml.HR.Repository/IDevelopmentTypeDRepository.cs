using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IDevelopmentTypeDRepository : IRepository<DevelopmentTypeD>
    {
        IEnumerable<DevelopmentTypeD> GetDevelopmentTypeDWithDevelopmentTypeC(int developmentTypeCId);
        IEnumerable<DevelopmentTypeD> GetDevelopmentTypeDWithDevelopmentTypeC();
        bool DevelopmentTypeDExisted(string name, int developmentTypeCId);
        bool DevelopmentTypeDExisted(string name, int developmentTypeCId, int idToExcept);
    }
}