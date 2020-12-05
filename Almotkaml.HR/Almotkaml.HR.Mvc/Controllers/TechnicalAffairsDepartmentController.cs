using Almotkaml.HR.Models;
using System;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class TechnicalAffairsDepartmentnController : BaseController
    {
        public ActionResult Index()
        {

            // var model = new TechnicalAffairsDepartmentModel ();
            var model = HumanResource.TechnicalAffairsDepartmentn.Prepare();
            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TechnicalAffairsDepartmentModel model, FormCollection form)
        {
            if (model.MonthWork  != 0 && model.YearWork !=0)
            {
               // model.DateFrom2 = DateTime.Parse(model.DateFrom);

                //model.Days2 = model.DateTo2.Day;
                //model.Days = model.Days - 1;
                HumanResource.Vacation.Refresh2(model);
            }
            else { model.MonthWork = 0;model.YearWork = DateTime.Now.Year ; }

            //var note = model.v;
            LoadModel(model, form["savedModel"]);

            //HumanResource.Vacation.Refresh(model);
            //model.MonthWork = ;
            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(TechnicalAffairsDepartmentModel model, FormCollection form)
        {
            var editTechnicalAffairsDepartmentId = IntValue(form["editTechnicalAffairsDepartmentd"]);
            var deleteTechnicalAffairsDepartmentId = IntValue(form["deleteTechnicalAffairsDepartmentId"]);

            // Select
            if (editTechnicalAffairsDepartmentId > 0)
                return Select(model, editTechnicalAffairsDepartmentId);

            // Delete
            if (deleteTechnicalAffairsDepartmentId > 0)
                return Delete(model, deleteTechnicalAffairsDepartmentId);

            // Insert
            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.TechnicalAffairsDepartmentId == 0)
            {
                //model.Note =model.NoteTest;
                //if (!HumanResource.Vacation.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.TechnicalAffairsDepartmentId > 0)
            {
                //if (!HumanResource.Vacation.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(TechnicalAffairsDepartmentModel model, int editTechnicalAffairsDepartmentId)
        {
            ModelState.Clear();
            model.TechnicalAffairsDepartmentId = editTechnicalAffairsDepartmentId;

            //if (!HumanResource.Vacation.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private PartialViewResult Delete(TechnicalAffairsDepartmentModel model, int deleteTechnicalAffairsDepartmentId)
        {
            ModelState.Clear();
            model.TechnicalAffairsDepartmentId = deleteTechnicalAffairsDepartmentId;

            //if (!HumanResource.Vacation.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(TechnicalAffairsDepartmentModel model, string savedModel)
        {
            //var note = model.Note;
            var loadedModel = LoadSavedModel<TechnicalAffairsDepartmentModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            //model.VacationGrid = loadedModel.VacationGrid;
            //model.EmployeeGrid = loadedModel.EmployeeGrid;
            //model.VacationTypeList = loadedModel.VacationTypeList;
            ////model.CountKidsList = loadedModel.CountKidsList;
            //model.Note = note;
        }
    }
}