using System;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class JobInfoRepository : Repository<JobInfo>, IJobInfoRepository
    {
        private HrDbContext Context { get; }

        internal JobInfoRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public JobInfo JobInfoByEmployeeId(int employeeId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<JobInfo> JobInfoByAll()
        {
            return Context.JobInfos
                .Include(s => s.Employee);


        }
    }
}