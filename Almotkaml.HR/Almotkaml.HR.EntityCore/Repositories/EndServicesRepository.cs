using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class EndServicesRepository : Repository<EndServices>, IEndServicesRepository
    {

        private HrDbContext Context { get; }
        internal EndServicesRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public override EndServices Find(object id)
        {
            return Context.EndServiceses
                .Include(e => e.Employee)
                .FirstOrDefault(e => e.EndServicesId == (int)id);
        }

        public IEnumerable<EndServices> GetEndServicesesWithEmployee()
        {
            return Context.EndServiceses
                .Include(e => e.Employee);
        }

        public IEnumerable<EndServices> GetEndServicesesWithEmployeeBy(DateTime dateFrom
            , DateTime dateTo, CauseOfEndService causeOfEndService)
        {
        if(causeOfEndService == 0)
                return Context.EndServiceses
                    .Include(e => e.Employee)
                    .ThenInclude(e => e.Qualifications)
                    .ThenInclude(q => q.QualificationType)
                     .Include(e => e.Employee)
                    .ThenInclude(e => e.JobInfo)
                    .ThenInclude(j => j.Job)
                     .Include(e => e.Employee)
                    .ThenInclude(e => e.JobInfo)
                    .ThenInclude(j => j.Unit)
                    .ThenInclude(u => u.Division)
                    .ThenInclude(d => d.Department)
                    .ThenInclude(d => d.Center)
                    
                    .Where(e => e.DecisionDate >= dateFrom
                              && e.DecisionDate <= dateTo);
            return Context.EndServiceses
                .Include(e => e.Employee)
                .ThenInclude(e => e.Qualifications)
                .ThenInclude(q => q.QualificationType)
                 .Include(e => e.Employee)
                    .ThenInclude(e => e.JobInfo)
                    .ThenInclude(j => j.Job)
                .Include(e => e.Employee)
                .ThenInclude(e => e.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center)
               

                .Where(e => e.CauseOfEndService == causeOfEndService
                          && e.DecisionDate >= dateFrom
                          && e.DecisionDate <= dateTo);
        }
    }
}
