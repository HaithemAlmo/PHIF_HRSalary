using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface ICityRepository : IRepository<City>
    {
        IEnumerable<City> GetCityWithCountry(int countryId);
        IEnumerable<City> GetCityWithCountry();
        bool CityExisted(string name, int countryId);
        bool CityExisted(string name, int countryId, int idToExcept);
    }
}