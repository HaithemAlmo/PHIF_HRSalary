using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class SanctionRepository : Repository<Sanction>, ISanctionRepository
    {
        private HrDbContext Context { get; }

        internal SanctionRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<Sanction> GetSanctionByEmployeeId(int employeeid)
        {
            return Context.Sanctions
                .Include(e => e.Employee)
                .Include(s => s.SanctionType)
                .Where(e => e.EmployeeId == employeeid);
        }
    }
}