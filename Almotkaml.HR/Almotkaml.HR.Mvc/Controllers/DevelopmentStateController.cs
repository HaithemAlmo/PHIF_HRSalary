using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class DevelopmentStateController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.DevelopmentState.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DevelopmentStateModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.DevelopmentState.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(DevelopmentStateModel model, FormCollection form)
        {
            var editDevelopmentStateId = IntValue(form["editDevelopmentStateId"]);
            var deleteDevelopmentStateId = IntValue(form["deleteDevelopmentStateId"]);

            // Select
            if (editDevelopmentStateId > 0)
                return Select(model, editDevelopmentStateId);

            // Delete
            if (deleteDevelopmentStateId > 0)
                return Delete(model, deleteDevelopmentStateId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.DevelopmentStateId == 0)
            {
                if (!HumanResource.DevelopmentState.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.DevelopmentStateId > 0)
            {
                if (!HumanResource.DevelopmentState.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(DevelopmentStateModel model, int editDevelopmentStateId)
        {
            ModelState.Clear();
            model.DevelopmentStateId = editDevelopmentStateId;

            if (!HumanResource.DevelopmentState.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(DevelopmentStateModel model, int deleteDevelopmentStateId)
        {
            ModelState.Clear();
            model.DevelopmentStateId = deleteDevelopmentStateId;

            if (!HumanResource.DevelopmentState.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(DevelopmentStateModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DevelopmentStateModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.Grid = loadedModel.Grid;
        }
    }
}