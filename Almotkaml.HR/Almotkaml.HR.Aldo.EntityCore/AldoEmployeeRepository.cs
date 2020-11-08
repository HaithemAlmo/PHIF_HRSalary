using Almotkaml.HR.EntityCore;
using Almotkaml.HR.EntityCore.Repositories;
using System.Linq;

namespace Almotkaml.HR.Aldo.EntityCore
{
    public class AldoEmployeeRepository : EmployeeRepository//, IAldoEmpoyeeRepository
    {
        private HrDbContext Context { get; }

        public AldoEmployeeRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public override int GetJobNumber()
        {
            var number = 1001;

            var max = Context.JobInfos.Max(e => e.JobNumber) + 1;

            return max < number ? number : max;
        }
    }
}