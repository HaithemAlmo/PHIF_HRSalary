using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IExtraWorkRepository : IRepository<Extrawork>
    {
        IEnumerable<Extrawork> GetEmployeeWithExtraWork();

        IEnumerable<Extrawork> GetExtraWorkByEmployeeId(int employeeid);
        int HaveExtraWorkCount(DateTime date);

    }
}
