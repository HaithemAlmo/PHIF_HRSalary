using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SalaryUnitController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.SalaryUnit.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SalaryUnitModel model, string savedModel, string save, FormCollection form)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, save);
        }

        private PartialViewResult AjaxIndex(SalaryUnitModel model, string save)
        {
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (save == null)
            {
                HumanResource.SalaryUnit.Refresh(model);
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!HumanResource.SalaryUnit.Save(model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(SalaryUnitModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SalaryUnitModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanSave = loadedModel.CanSave;
        }
    }
}