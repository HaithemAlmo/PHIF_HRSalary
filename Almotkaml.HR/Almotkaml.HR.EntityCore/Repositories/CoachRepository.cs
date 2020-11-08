using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class CoachRepository : Repository<Coach>, ICoachRepository
    {
        private HrDbContext Context { get; }

        internal CoachRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public override Coach Find(object id) => Context.Coaches
            .Include(c => c.Employee)
            .FirstOrDefault(c => c.CoachId == (int)id);

        public override IEnumerable<Coach> GetAll() => Context.Coaches
            .Include(c => c.Employee);
    }
}