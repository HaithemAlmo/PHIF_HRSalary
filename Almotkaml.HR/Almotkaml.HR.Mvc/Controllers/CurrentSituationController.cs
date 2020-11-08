using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class CurrentSituationController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.CurrentSituation.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CurrentSituationModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.CurrentSituation.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(CurrentSituationModel model, FormCollection form)
        {
            var editCurrentSituationId = IntValue(form["editCurrentSituationId"]);
            var deleteCurrentSituationId = IntValue(form["deleteCurrentSituationId"]);

            // Select
            if (editCurrentSituationId > 0)
                return Select(model, editCurrentSituationId);

            // Delete
            if (deleteCurrentSituationId > 0)
                return Delete(model, deleteCurrentSituationId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.CurrentSituationId == 0)
            {
                if (!HumanResource.CurrentSituation.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.CurrentSituationId > 0)
            {
                if (!HumanResource.CurrentSituation.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(CurrentSituationModel model, int editCurrentSituationId)
        {
            ModelState.Clear();
            model.CurrentSituationId = editCurrentSituationId;

            if (!HumanResource.CurrentSituation.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(CurrentSituationModel model, int deleteCurrentSituationId)
        {
            ModelState.Clear();
            model.CurrentSituationId = deleteCurrentSituationId;

            if (!HumanResource.CurrentSituation.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(CurrentSituationModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<CurrentSituationModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.CurrentSituationGrid = loadedModel.CurrentSituationGrid;
        }
    }
}