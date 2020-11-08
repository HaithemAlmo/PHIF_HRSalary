using Almotkaml.HR.Models;
using System;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class VacationController : BaseController
    {
        public ActionResult Index()
        {

            var model = HumanResource.Vacation.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VacationModel model, FormCollection form)
        {
            if (model.Days != 0 && model.DateFrom!=null )
            {
                model.DateFrom2 = DateTime.Parse(model.DateFrom);

                //model.Days2 = model.DateTo2.Day;
                //model.Days = model.Days - 1;
                HumanResource.Vacation.Refresh2(model);
            }
            else { model.Days = 0;model.DateTo =DateTime.Now.Date ; }

            var note = model.Note;
            LoadModel(model, form["savedModel"]);

            HumanResource.Vacation.Refresh(model);
            model.NoteTest = note;
            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(VacationModel model, FormCollection form)
        {
            var editVacationId = IntValue(form["editVacationId"]);
            var deleteVacationId = IntValue(form["deleteVacationId"]);

            // Select
            if (editVacationId > 0)
                return Select(model, editVacationId);

            // Delete
            if (deleteVacationId > 0)
                return Delete(model, deleteVacationId);

            // Insert
            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.VacationId == 0)
            {
                model.Note =model.NoteTest;
                if (!HumanResource.Vacation.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.VacationId > 0)
            {
                if (!HumanResource.Vacation.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(VacationModel model, int editVacationId)
        {
            ModelState.Clear();
            model.VacationId = editVacationId;

            if (!HumanResource.Vacation.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private PartialViewResult Delete(VacationModel model, int deleteVacationId)
        {
            ModelState.Clear();
            model.VacationId = deleteVacationId;

            if (!HumanResource.Vacation.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(VacationModel model, string savedModel)
        {
            var note = model.Note;
            var loadedModel = LoadSavedModel<VacationModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.VacationGrid = loadedModel.VacationGrid;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
            model.VacationTypeList = loadedModel.VacationTypeList;
            //model.CountKidsList = loadedModel.CountKidsList;
            model.Note = note;
        }
    }
}