using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class PremiumController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.Premium.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PremiumModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Premium.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(PremiumModel model, FormCollection form)
        {
            var editPremiumId = IntValue(form["editPremiumId"]);
            var deletePremiumId = IntValue(form["deletePremiumId"]);

            // Select
            if (editPremiumId > 0)
                return Select(model, editPremiumId);

            // Delete
            if (deletePremiumId > 0)
                return Delete(model, deletePremiumId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.PremiumId == 0)
            {
                if (!HumanResource.Premium.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.PremiumId > 0)
            {
                if (!HumanResource.Premium.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(PremiumModel model, int editPremiumId)
        {
            ModelState.Clear();
            model.PremiumId = editPremiumId;

            if (!HumanResource.Premium.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(PremiumModel model, int deletePremiumId)
        {
            ModelState.Clear();
            model.PremiumId = deletePremiumId;

            if (!HumanResource.Premium.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(PremiumModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<PremiumModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.PremiumGrid = loadedModel.PremiumGrid;
        }
    }
}