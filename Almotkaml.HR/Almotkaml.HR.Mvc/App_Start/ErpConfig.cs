using Almotkaml.Erp;
using System.Configuration;

namespace Almotkaml.HR.Mvc
{
    public class ErpConfig
    {
        public AppConfig LoadConfig()
        {
            var config = new AppConfig()
            {
                ConnectionString = ConfigurationManager.AppSettings["AccountingConnectionString"],
                IsDemo = true,
                RepositoryType = ErpRepository.GetType(ConfigurationManager.AppSettings["AccountingUnitOfWorkType"])
            };

            return config;
        }
    }
}