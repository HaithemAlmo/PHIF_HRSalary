using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IAdjectiveEmployeeTypeRepository : IRepository<AdjectiveEmployeeType>, ICheckNameExisted
    {
        IEnumerable<AdjectiveEmployeeType> GetAdjectiveEmployeeType();
    }
}