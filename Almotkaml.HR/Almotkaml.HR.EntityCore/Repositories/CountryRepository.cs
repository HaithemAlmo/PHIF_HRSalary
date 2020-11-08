using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private HrDbContext Context { get; }

        internal CountryRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Countries
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Countries
            .Any(e => e.Name == name && e.CountryId != idToExcept);
    }
}