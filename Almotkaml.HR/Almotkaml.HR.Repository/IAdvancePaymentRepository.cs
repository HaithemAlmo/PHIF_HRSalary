using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IAdvancePaymentRepository : IRepository<AdvancePayment>
    {
        IEnumerable<AdvancePayment> GetAdvancePaymentByEmployeeId(int employeeId);

    }
}