using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class SituationResolveJobRepository : Repository<SituationResolveJob>, ISituationResolveJobRepository
    {
        private HrDbContext Context { get; }

        internal SituationResolveJobRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<SituationResolveJob> GetSituationResolveJobByEmployeeId(int employeeId)
        {
            return Context.SituationResolveJobs
                .Include(e => e.Employee)
                .ThenInclude(j => j.JobInfo)
                .ThenInclude(j=>j.Job)
                .Where(s => s.EmployeeId == employeeId);
        }

        public bool IsLastRecode(int employeeId, int situationResolveJobId)
        {
            var max = Context.SituationResolveJobs
                .Where(s => s.EmployeeId == employeeId)
                .Max(s => s.SituationResolveJobId);

            return situationResolveJobId == max;
        }


    }
}