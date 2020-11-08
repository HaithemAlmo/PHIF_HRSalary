using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IEndServicesRepository : IRepository<EndServices>
    {
        IEnumerable<EndServices> GetEndServicesesWithEmployee();
        IEnumerable<EndServices> GetEndServicesesWithEmployeeBy(DateTime dateFrom, DateTime dateTo
            , CauseOfEndService causeOfEndService);
    }
}
