using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class EvaluationRepository : Repository<Evaluation>, IEvaluationRepository
    {
        private HrDbContext Context { get; }
        internal EvaluationRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<Evaluation> GetEvaluationByEmployeeId(int employeeId)
        {
            return Context.Evaluations
                .Include(e => e.Employee)
                .Where(e => e.EmployeeId == employeeId);
        }
 
    }
}
