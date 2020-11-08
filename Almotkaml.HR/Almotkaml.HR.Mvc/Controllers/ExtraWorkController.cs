using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class ExtraworkController : BaseController
    {
        //GET: ExtraWork
        public ActionResult Index()
        {
            var model = HumanResource.ExtraWork.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ExtraWorkModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.ExtraWork.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(ExtraWorkModel model, FormCollection form)
        {
            var editExtraWorkId = IntValue(form["editExtraWorkId"]);
            var deleteExtraWorkId = IntValue(form["deleteExtraWorkId"]);

            // Select
            if (editExtraWorkId > 0)
                return Select(model, editExtraWorkId);

            // Delete
            if (deleteExtraWorkId > 0)
                return Delete(model, deleteExtraWorkId);

            // Insert
            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.ExtraWorkId == 0)
            {
                if (!HumanResource.ExtraWork.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.ExtraWorkId > 0)
            {
                if (!HumanResource.ExtraWork.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(ExtraWorkModel model, int editExtraWorkId)
        {
            ModelState.Clear();
            model.ExtraWorkId = editExtraWorkId;

            if (!HumanResource.ExtraWork.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(ExtraWorkModel model, int deleteExtraWorkId)
        {
            ModelState.Clear();
            model.ExtraWorkId = deleteExtraWorkId;

            if (!HumanResource.ExtraWork.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(ExtraWorkModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<ExtraWorkModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.ExtraWorkGridRows = loadedModel.ExtraWorkGridRows;
            model.EmployeeGrid = loadedModel.EmployeeGrid;

        }
    }
}