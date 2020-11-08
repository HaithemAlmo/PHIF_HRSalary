using Almotkaml.Erp.Empty;
using System;

namespace Almotkaml.Erp
{
    public static class ErpRepository
    {
        public static Type GetType(string erpRepositoryType)
            => Type.GetType(erpRepositoryType) ?? typeof(EmptyErpUnitOfWork);
    }
}