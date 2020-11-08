using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class AdvancePaymentRepository : Repository<AdvancePayment>, IAdvancePaymentRepository
    {
        private HrDbContext Context { get; }

        internal AdvancePaymentRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }
        public override IEnumerable<AdvancePayment> GetAll()
        {
            return Context.AdvancePayments
                  .Include(p => p.Employee)
                  .ThenInclude(s => s.SalaryInfo)
                  .Include(s => s.Premium);
        }
        public IEnumerable<AdvancePayment> GetAdvancePaymentByEmployeeId(int employeeId)
        {
            return Context.AdvancePayments
                .Include(p => p.Employee)
                .ThenInclude(s=>s.SalaryInfo)
                .Include(s=>s.Premium)

                .Where(a => a.EmployeeId == employeeId);
        }
    }
}