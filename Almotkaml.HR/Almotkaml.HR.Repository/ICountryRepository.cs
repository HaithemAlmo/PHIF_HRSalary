using Almotkaml.HR.Domain;
using Almotkaml.Repository;

namespace Almotkaml.HR.Repository
{
    public interface ICountryRepository : IRepository<Country>, ICheckNameExisted { }
}