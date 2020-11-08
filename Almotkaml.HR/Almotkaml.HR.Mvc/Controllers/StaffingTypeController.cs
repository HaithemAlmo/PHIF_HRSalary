using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class StaffingTypeController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.StaffingType.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(StaffingTypeModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.StaffingType.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(StaffingTypeModel model, FormCollection form)
        {
            var editStaffingTypeId = IntValue(form["editStaffingTypeId"]);
            var deleteStaffingTypeId = IntValue(form["deleteStaffingTypeId"]);

            // Select
            if (editStaffingTypeId > 0)
                return Select(model, editStaffingTypeId);

            // Delete
            if (deleteStaffingTypeId > 0)
                return Delete(model, deleteStaffingTypeId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.StaffingTypeId == 0)
            {
                if (!HumanResource.StaffingType.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.StaffingTypeId > 0)
            {
                if (!HumanResource.StaffingType.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(StaffingTypeModel model, int editStaffingTypeId)
        {
            ModelState.Clear();
            model.StaffingTypeId = editStaffingTypeId;

            if (!HumanResource.StaffingType.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(StaffingTypeModel model, int deleteStaffingTypeId)
        {
            ModelState.Clear();
            model.StaffingTypeId = deleteStaffingTypeId;

            if (!HumanResource.StaffingType.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(StaffingTypeModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<StaffingTypeModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.StaffingTypeGrid = loadedModel.StaffingTypeGrid;
        }
    }
}