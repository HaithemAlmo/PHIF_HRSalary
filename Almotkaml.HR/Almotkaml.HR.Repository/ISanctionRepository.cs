using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface ISanctionRepository : IRepository<Sanction>
    {
        IEnumerable<Sanction> GetSanctionByEmployeeId(int employeeid);
    }
}