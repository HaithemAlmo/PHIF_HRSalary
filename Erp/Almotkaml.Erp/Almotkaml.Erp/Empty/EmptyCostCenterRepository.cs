using System.Collections.Generic;
using Almotkaml.Erp.Accounting.Domain;
using Almotkaml.Erp.Accounting.Repository;

namespace Almotkaml.Erp.Empty
{
    public class EmptyCostCenterRepository : ICostCenterRepository
    {
        public IEnumerable<ICostCenter> GetAll() => new HashSet<ICostCenter>();
    }
}