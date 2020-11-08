using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class DevelopmentTypeAController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.DevelopmentTypeA.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DevelopmentTypeAModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.DevelopmentTypeA.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(DevelopmentTypeAModel model, FormCollection form)
        {
            var editDevelopmentTypeAId = IntValue(form["editDevelopmentTypeAId"]);
            var deleteDevelopmentTypeAId = IntValue(form["deleteDevelopmentTypeAId"]);

            // Select
            if (editDevelopmentTypeAId > 0)
                return Select(model, editDevelopmentTypeAId);

            // Delete
            if (deleteDevelopmentTypeAId > 0)
                return Delete(model, deleteDevelopmentTypeAId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.DevelopmentTypeAId == 0)
            {
                if (!HumanResource.DevelopmentTypeA.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.DevelopmentTypeAId > 0)
            {
                if (!HumanResource.DevelopmentTypeA.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(DevelopmentTypeAModel model, int editDevelopmentTypeAId)
        {
            ModelState.Clear();
            model.DevelopmentTypeAId = editDevelopmentTypeAId;

            if (!HumanResource.DevelopmentTypeA.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(DevelopmentTypeAModel model, int deleteDevelopmentTypeAId)
        {
            ModelState.Clear();
            model.DevelopmentTypeAId = deleteDevelopmentTypeAId;

            if (!HumanResource.DevelopmentTypeA.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(DevelopmentTypeAModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DevelopmentTypeAModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.Grid = loadedModel.Grid;
        }
    }
}