using System.Collections.Generic;
using Almotkaml.HR.Domain;
using Almotkaml.Repository;

namespace Almotkaml.HR.Repository
{
    public interface ITransferRepository : IRepository<Transfer>
    {
        IEnumerable<Transfer> GetTransferByEmployeeId(int employeeid);
    }
}