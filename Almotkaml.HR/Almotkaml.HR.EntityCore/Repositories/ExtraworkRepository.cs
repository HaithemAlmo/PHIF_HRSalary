using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class ExtraworkRepository : Repository<Extrawork>, IExtraWorkRepository
    {
        private HrDbContext Context { get; }
        internal ExtraworkRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<Extrawork> GetEmployeeWithExtraWork() => Context.Extraworks
            .Include(e => e.Employee);

        public IEnumerable<Extrawork> GetExtraWorkByEmployeeId(int employeeid) => Context.Extraworks
            .Include(e => e.Employee)
            .Where(e => e.EmployeeId == employeeid);

        public int HaveExtraWorkCount(DateTime date)
            => Context.Extraworks.Count(e => e.DateFrom.Date >= date.Date && e.DateTo.Date <= date.Date);

        public override Extrawork Find(object id) => Context.Extraworks
            .Include(e => e.Employee)
            .FirstOrDefault(p => p.ExtraworkId == (int)id);
    }
}
