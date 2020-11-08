using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.Home.View();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }
    }
}