using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class DevelopmentTypeDRepository : Repository<DevelopmentTypeD>, IDevelopmentTypeDRepository
    {
        private HrDbContext Context { get; }

        internal DevelopmentTypeDRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<DevelopmentTypeD> GetDevelopmentTypeDWithDevelopmentTypeC(int developmentTypeCId)
        {
            return Context.DevelopmentTypeDs
                         .Include(d => d.DevelopmentTypeC)
                         .ThenInclude(d => d.DevelopmentTypeB)
                         .ThenInclude(d => d.DevelopmentTypeA)
                         .Where(d => d.DevelopmentTypeCId == developmentTypeCId);
        }

        public IEnumerable<DevelopmentTypeD> GetDevelopmentTypeDWithDevelopmentTypeC()
        {
            return Context.DevelopmentTypeDs
                .Include(d => d.DevelopmentTypeC)
                .ThenInclude(d => d.DevelopmentTypeB)
                .ThenInclude(d => d.DevelopmentTypeA);
        }

        public bool DevelopmentTypeDExisted(string name, int developmentTypeCId) => Context.DevelopmentTypeDs
            .Any(e => e.Name == name && e.DevelopmentTypeCId == developmentTypeCId);

        public bool DevelopmentTypeDExisted(string name, int developmentTypeCId, int idToExcept) => Context.DevelopmentTypeDs
            .Any(e => e.Name == name && e.DevelopmentTypeDId != idToExcept && e.DevelopmentTypeCId == developmentTypeCId);
    }
}