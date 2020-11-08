using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
namespace Almotkaml.HR.EntityCore.Repositories
{
 public    class HistorySubsendedRepository : Repository<HistorySubsended>, iHistorySubsended
    {
        private HrDbContext Context { get; }

        internal HistorySubsendedRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }
    }
}
