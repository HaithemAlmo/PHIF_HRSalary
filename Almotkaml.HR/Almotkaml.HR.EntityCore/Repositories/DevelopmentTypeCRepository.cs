using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class DevelopmentTypeCRepository : Repository<DevelopmentTypeC>, IDevelopmentTypeCRepository
    {
        private HrDbContext Context { get; }

        internal DevelopmentTypeCRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<DevelopmentTypeC> GetDevelopmentTypeCWithDevelopmentTypeB(int developmentTypeBId)
        {
            return Context.DevelopmentTypeCs
                         .Include(d => d.DevelopmentTypeB)
                         .ThenInclude(d => d.DevelopmentTypeA)
                         .Where(d => d.DevelopmentTypeBId == developmentTypeBId);
        }

        public IEnumerable<DevelopmentTypeC> GetDevelopmentTypeCWithDevelopmentTypeB()
        {
            return Context.DevelopmentTypeCs
                .Include(d => d.DevelopmentTypeB)
                .ThenInclude(d => d.DevelopmentTypeA);
        }

        public bool DevelopmentTypeCExisted(string name, int developmentTypeBId) => Context.DevelopmentTypeCs
            .Any(e => e.Name == name && e.DevelopmentTypeBId == developmentTypeBId);

        public bool DevelopmentTypeCExisted(string name, int developmentTypeBId, int idToExcept) => Context.DevelopmentTypeCs
            .Any(e => e.Name == name && e.DevelopmentTypeCId != idToExcept && e.DevelopmentTypeBId == developmentTypeBId);
    }
}