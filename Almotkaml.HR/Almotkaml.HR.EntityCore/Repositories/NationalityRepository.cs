using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class NationalityRepository : Repository<Nationality>, INationalityRepository
    {
        private HrDbContext Context { get; }

        internal NationalityRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Nationalities.Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Nationalities.Any(e => e.Name == name && e.NationalityId != idToExcept);

    }
}