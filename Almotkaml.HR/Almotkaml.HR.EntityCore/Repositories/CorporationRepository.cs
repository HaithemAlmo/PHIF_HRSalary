using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class CorporationRepository : Repository<Corporation>, ICorporationRepository
    {

        private HrDbContext Context { get; }
        internal CorporationRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public override Corporation Find(object id)
        {
            return Context.Corporations
                .Include(t => t.City)
                .ThenInclude(c => c.Country)
                .FirstOrDefault(t => t.CorporationId == (int)id);
        }

        public override IEnumerable<Corporation> GetAll()
        {
            return Context.Corporations
                .Include(t => t.City)
                .ThenInclude(c => c.Country);
        }
    }
}