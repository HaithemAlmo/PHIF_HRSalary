using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class ClassificationOnWorkController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.ClassificationOnWork.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ClassificationOnWorkModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.ClassificationOnWork.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(ClassificationOnWorkModel model, FormCollection form)
        {
            var editClassificationOnWorkId = IntValue(form["editClassificationOnWorkId"]);
            var deleteClassificationOnWorkId = IntValue(form["deleteClassificationOnWorkId"]);

            // Select
            if (editClassificationOnWorkId > 0)
                return Select(model, editClassificationOnWorkId);

            // Delete
            if (deleteClassificationOnWorkId > 0)
                return Delete(model, deleteClassificationOnWorkId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.ClassificationOnWorkId == 0)
            {
                if (!HumanResource.ClassificationOnWork.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.ClassificationOnWorkId > 0)
            {
                if (!HumanResource.ClassificationOnWork.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(ClassificationOnWorkModel model, int editClassificationOnWorkId)
        {
            ModelState.Clear();
            model.ClassificationOnWorkId = editClassificationOnWorkId;

            if (!HumanResource.ClassificationOnWork.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(ClassificationOnWorkModel model, int deleteClassificationOnWorkId)
        {
            ModelState.Clear();
            model.ClassificationOnWorkId = deleteClassificationOnWorkId;

            if (!HumanResource.ClassificationOnWork.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(ClassificationOnWorkModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<ClassificationOnWorkModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.Grid = loadedModel.Grid;
        }
    }
}