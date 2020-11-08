using System.Collections.Generic;
using Almotkaml.Erp.Accounting.Domain;

namespace Almotkaml.Erp.Accounting.Repository
{
    public interface ICostCenterRepository
    {
        IEnumerable<ICostCenter> GetAll();
    }
}