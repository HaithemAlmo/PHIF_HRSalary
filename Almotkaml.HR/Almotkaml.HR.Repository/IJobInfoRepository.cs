using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IJobInfoRepository : IRepository<JobInfo>
    {
        IEnumerable<JobInfo> JobInfoByAll();

        JobInfo JobInfoByEmployeeId(int employeeId);
    }
}