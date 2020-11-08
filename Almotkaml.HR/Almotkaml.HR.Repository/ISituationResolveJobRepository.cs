using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface ISituationResolveJobRepository : IRepository<SituationResolveJob>
    {
        IEnumerable<SituationResolveJob> GetSituationResolveJobByEmployeeId(int employeeId);
        bool IsLastRecode(int employeeId, int situationResolveJobId);
    }
}
