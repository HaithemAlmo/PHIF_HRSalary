using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class AdjectiveEmployeeTypeRepository : Repository<AdjectiveEmployeeType>, IAdjectiveEmployeeTypeRepository
    {
        private HrDbContext Context { get; }

        internal AdjectiveEmployeeTypeRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<AdjectiveEmployeeType> GetAdjectiveEmployeeType()
        {
            return Context.AdjectiveEmployeeTypes
                .Include(a => a.AdjectiveEmployees);
        }

        public bool NameIsExisted(string name) => Context.AdjectiveEmployeeTypes
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.AdjectiveEmployeeTypes
            .Any(e => e.Name == name && e.AdjectiveEmployeeTypeId != idToExcept);
    }
}