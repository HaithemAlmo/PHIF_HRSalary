using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class ClassificationOnSearchingController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.ClassificationOnSearching.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ClassificationOnSearchingModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.ClassificationOnSearching.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(ClassificationOnSearchingModel model, FormCollection form)
        {
            var editClassificationOnSearchingId = IntValue(form["editClassificationOnSearchingId"]);
            var deleteClassificationOnSearchingId = IntValue(form["deleteClassificationOnSearchingId"]);

            // Select
            if (editClassificationOnSearchingId > 0)
                return Select(model, editClassificationOnSearchingId);

            // Delete
            if (deleteClassificationOnSearchingId > 0)
                return Delete(model, deleteClassificationOnSearchingId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.ClassificationOnSearchingId == 0)
            {
                if (!HumanResource.ClassificationOnSearching.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.ClassificationOnSearchingId > 0)
            {
                if (!HumanResource.ClassificationOnSearching.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(ClassificationOnSearchingModel model, int editClassificationOnSearchingId)
        {
            ModelState.Clear();
            model.ClassificationOnSearchingId = editClassificationOnSearchingId;

            if (!HumanResource.ClassificationOnSearching.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(ClassificationOnSearchingModel model, int deleteClassificationOnSearchingId)
        {
            ModelState.Clear();
            model.ClassificationOnSearchingId = deleteClassificationOnSearchingId;

            if (!HumanResource.ClassificationOnSearching.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(ClassificationOnSearchingModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<ClassificationOnSearchingModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.Grid = loadedModel.Grid;
        }
    }
}