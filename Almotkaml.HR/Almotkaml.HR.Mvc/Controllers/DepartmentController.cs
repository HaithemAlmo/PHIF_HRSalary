using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class DepartmentController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.Department.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DepartmentModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Department.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(DepartmentModel model, FormCollection form)
        {
            var editDepartmentId = IntValue(form["editDepartmentId"]);
            var deleteDepartmentId = IntValue(form["deleteDepartmentId"]);

            // Select
            if (editDepartmentId > 0)
                return Select(model, editDepartmentId);

            // Delete
            if (deleteDepartmentId > 0)
                return Delete(model, deleteDepartmentId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.DepartmentId == 0)
            {
                if (!HumanResource.Department.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.DepartmentId > 0)
            {
                if (!HumanResource.Department.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(DepartmentModel model, int editDepartmentId)
        {
            ModelState.Clear();
            model.DepartmentId = editDepartmentId;

            if (!HumanResource.Department.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(DepartmentModel model, int deleteDepartmentId)
        {
            ModelState.Clear();
            model.DepartmentId = deleteDepartmentId;

            if (!HumanResource.Department.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(DepartmentModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DepartmentModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.DepartmentGrid = loadedModel.DepartmentGrid;
            model.CenterList = loadedModel.CenterList;
        }
    }
}

