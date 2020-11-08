using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class DevelopmentTypeBRepository : Repository<DevelopmentTypeB>, IDevelopmentTypeBRepository
    {
        private HrDbContext Context { get; }

        internal DevelopmentTypeBRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<DevelopmentTypeB> GetDevelopmentTypeBWithDevelopmentTypeA(int developmentTypeAId)
        {
            return Context.DevelopmentTypeBs
                .Include(d => d.DevelopmentTypeA)
                .Where(d => d.DevelopmentTypeAId == developmentTypeAId);
        }

        public IEnumerable<DevelopmentTypeB> GetDevelopmentTypeBWithDevelopmentTypeA()
        {
            return Context.DevelopmentTypeBs
                .Include(d => d.DevelopmentTypeA);
        }

        public bool DevelopmentTypeBExisted(string name, int developmentTypeAId) => Context.DevelopmentTypeBs
            .Any(e => e.Name == name && e.DevelopmentTypeAId == developmentTypeAId);

        public bool DevelopmentTypeBExisted(string name, int developmentTypeAId, int idToExcept) => Context.DevelopmentTypeBs
            .Any(e => e.Name == name && e.DevelopmentTypeBId != idToExcept && e.DevelopmentTypeAId == developmentTypeAId);
    }
}