using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class DevelopmentTypeBController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.DevelopmentTypeB.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DevelopmentTypeBModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.DevelopmentTypeB.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(DevelopmentTypeBModel model, FormCollection form)
        {
            var editDevelopmentTypeBId = IntValue(form["editDevelopmentTypeBId"]);
            var deleteDevelopmentTypeBId = IntValue(form["deleteDevelopmentTypeBId"]);

            // Select
            if (editDevelopmentTypeBId > 0)
                return Select(model, editDevelopmentTypeBId);

            // Delete
            if (deleteDevelopmentTypeBId > 0)
                return Delete(model, deleteDevelopmentTypeBId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.DevelopmentTypeBId == 0)
            {
                if (!HumanResource.DevelopmentTypeB.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.DevelopmentTypeBId > 0)
            {
                if (!HumanResource.DevelopmentTypeB.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(DevelopmentTypeBModel model, int editDevelopmentTypeBId)
        {
            ModelState.Clear();
            model.DevelopmentTypeBId = editDevelopmentTypeBId;

            if (!HumanResource.DevelopmentTypeB.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(DevelopmentTypeBModel model, int deleteDevelopmentTypeBId)
        {
            ModelState.Clear();
            model.DevelopmentTypeBId = deleteDevelopmentTypeBId;

            if (!HumanResource.DevelopmentTypeB.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(DevelopmentTypeBModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DevelopmentTypeBModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.Grid = loadedModel.Grid;
            model.DevelopmentTypeAList = loadedModel.DevelopmentTypeAList;
        }
    }
}

