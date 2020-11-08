using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class StaffingController : BaseController
    {
        // GET: Staffing
        public ActionResult Index()
        {
            var model = HumanResource.Staffing.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(StaffingModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Staffing.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(StaffingModel model, FormCollection form)
        {
            var editStaffingId = IntValue(form["editStaffingId"]);
            var deleteStaffingId = IntValue(form["deleteStaffingId"]);

            // Select
            if (editStaffingId > 0)
                return Select(model, editStaffingId);

            // Delete
            if (deleteStaffingId > 0)
                return Delete(model, deleteStaffingId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.StaffingId == 0)
            {
                if (!HumanResource.Staffing.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.StaffingId > 0)
            {
                if (!HumanResource.Staffing.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(StaffingModel model, int editStaffingId)
        {
            ModelState.Clear();
            model.StaffingId = editStaffingId;

            if (!HumanResource.Staffing.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(StaffingModel model, int deleteStaffingId)
        {
            ModelState.Clear();
            model.StaffingId = deleteStaffingId;

            if (!HumanResource.Staffing.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(StaffingModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<StaffingModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.StaffingGrid = loadedModel.StaffingGrid;
            model.StaffingTypeList = loadedModel.StaffingTypeList;
        }
    }
}