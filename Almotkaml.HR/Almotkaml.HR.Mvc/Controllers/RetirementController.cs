using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class RetirementController : BaseController
    {
        // GET: Retirement
        public ActionResult Index()
        {
            var model = HumanResource.Retirement.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }
    }
}