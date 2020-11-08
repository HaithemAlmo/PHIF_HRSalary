using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class AdjectiveEmployeeRepository : Repository<AdjectiveEmployee>, IAdjectiveEmployeeRepository
    {
        private HrDbContext Context { get; }

        internal AdjectiveEmployeeRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<AdjectiveEmployee> GetAdjectiveEmployeeWithType(int adjectiveEmployeeTypeId)
        {
            return
                Context.AdjectiveEmployees.Include(a => a.AdjectiveEmployeeType)
                    .Where(e => e.AdjectiveEmployeeTypeId == adjectiveEmployeeTypeId);
        }

        public IEnumerable<AdjectiveEmployee> GetAdjectiveEmployeeWithType()
        {
            return Context.AdjectiveEmployees
                .Include(a => a.AdjectiveEmployeeType);
        }

        public bool AdjectiveEmployeeExisted(string name, int employeeWithTypeid, int idToExcept)
        {
            return
                Context.AdjectiveEmployees.Any(
                    a =>
                        a.Name == name && a.AdjectiveEmployeeTypeId == employeeWithTypeid &&
                        a.AdjectiveEmployeeId != idToExcept);
        }

        public bool NameIsExisted(string name) => Context.AdjectiveEmployees
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.AdjectiveEmployees
            .Any(e => e.Name == name && e.AdjectiveEmployeeId != idToExcept);

        public override AdjectiveEmployee Find(object id)
        {
            return Context.AdjectiveEmployees
               .Include(a => a.AdjectiveEmployeeType)
               .FirstOrDefault(a => a.AdjectiveEmployeeId == (int)id);
        }
    }
}