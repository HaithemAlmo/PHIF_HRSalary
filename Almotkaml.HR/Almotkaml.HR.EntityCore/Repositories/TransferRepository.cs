using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class TransferRepository : Repository<Transfer>, ITransferRepository
    {
        private HrDbContext Context { get; }

        internal TransferRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<Transfer> GetTransferByEmployeeId(int employeeid)
        {
            return Context.Transfers
                .Include(e => e.Employee)
                .Where(e => e.EmployeeId == employeeid);
        }


    }
}