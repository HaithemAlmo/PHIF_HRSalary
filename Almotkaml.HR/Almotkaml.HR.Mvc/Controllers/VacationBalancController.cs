using System.Web.Mvc;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class VacationBalancController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.Vacation.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VacationModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(VacationModel model, FormCollection form)
        {
            // Add Vacation Balanc
            if (form["add"] != null)
            {
                if (!HumanResource.Vacation.VacationBalancYear(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(VacationModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<VacationModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanVacationBalance = loadedModel.CanVacationBalance;
        }
    }
}