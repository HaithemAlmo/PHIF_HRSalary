using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Almotkaml.HR.Aldo.Mvc
{
    public class MvcApplication : HR.Mvc.MvcApplication
    {
        protected override void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
