using Almotkaml.HR.Aldo.Models;
using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Aldo.Mvc.Controllers
{
    public class EmployeeController : HR.Mvc.Controllers.EmployeeController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJob(int id, AldoJobInfoModel model, string save, string savedModel)
        {
            return base.EditJob(id, model, save, savedModel);
        }


        [HttpPost, ActionName("OldEditJob")]
        [ValidateAntiForgeryToken]
        public override ActionResult EditJob(int id, JobInfoModel model, string save, string savedModel)
        {
            return base.EditJob(id, model, save, savedModel);
        }
    }
}