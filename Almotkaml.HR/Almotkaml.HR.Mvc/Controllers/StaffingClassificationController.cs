using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class StaffingClassificationController : BaseController
    {
        // GET: StaffingClassification
        public ActionResult Index()
        {

            var model = HumanResource.StaffingClassification.Prepare();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(StaffingClassificationModel model,FormCollection form)
        {

            LoadModel(model, form["savedModel"]);

            HumanResource.StaffingClassification.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(StaffingClassificationModel model, FormCollection form)
        {
            var editStaffingClassificationId = IntValue(form["editStaffingClassificationId"]);
            var deleteStaffingClassificationId = IntValue(form["deleteStaffingClassificationId"]);

            // Select
            if (editStaffingClassificationId > 0)
                return Select(model, editStaffingClassificationId);

            // Delete
            if (deleteStaffingClassificationId > 0)
                return Delete(model, deleteStaffingClassificationId);

            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.StaffingClassificationId == 0)
            {
                if (!HumanResource.StaffingClassification.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.StaffingClassificationId > 0)
            {
                if (!HumanResource.StaffingClassification.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }

        private PartialViewResult Select(StaffingClassificationModel model, int staffingClassificationId)
        {
            ModelState.Clear();
            model.StaffingClassificationId = staffingClassificationId;

            if (!HumanResource.StaffingClassification.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private PartialViewResult Delete(StaffingClassificationModel model, int staffingClassificationId)
        {
            ModelState.Clear();
            model.StaffingClassificationId = staffingClassificationId;

            if (!HumanResource.StaffingClassification.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }
        private void LoadModel(StaffingClassificationModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<StaffingClassificationModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.StaffingClassificationGrid = loadedModel.StaffingClassificationGrid;
        }

    }
}