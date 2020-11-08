using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IPremiumRepository : IRepository<Premium>, ICheckNameExisted
    {
        IEnumerable<Premium> GetPremiumsDiscount();
    }
}