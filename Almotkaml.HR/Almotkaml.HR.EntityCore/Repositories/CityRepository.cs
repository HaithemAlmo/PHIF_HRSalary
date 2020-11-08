using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private HrDbContext Context { get; }

        internal CityRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<City> GetCityWithCountry(int countryId)
        {
            return Context.Cities
                .Include(d => d.Country)
                .Where(d => d.CountryId == countryId);
        }

        public IEnumerable<City> GetCityWithCountry()
        {
            return Context.Cities
                .Include(d => d.Country);
        }

        public bool CityExisted(string name, int countryId) => Context.Cities
            .Any(e => e.Name == name && e.CountryId == countryId);

        public bool CityExisted(string name, int countryId, int idToExcept) => Context.Cities
            .Any(e => e.Name == name && e.CityId != idToExcept && e.CountryId == countryId);


    }
}