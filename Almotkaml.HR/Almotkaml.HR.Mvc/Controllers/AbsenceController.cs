using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class AbsenceController : BaseController
    {
        // GET: Absence
        public ActionResult Index()
        {
            var model = HumanResource.Absence.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AbsenceModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);


            HumanResource.Absence.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(AbsenceModel model, FormCollection form)
        {
            var editAbsenceId = IntValue(form["editAbsenceId"]);
            var deleteAbsenceId = IntValue(form["deleteAbsenceId"]);

            // Select
            if (editAbsenceId > 0)
                return Select(model, editAbsenceId);

            // Delete
            if (deleteAbsenceId > 0)
                return Delete(model, deleteAbsenceId);

            // Insert
            if (form["save"] == null) return PartialView("_Form", model);

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.AbsenceId == 0)
            {
                if (!HumanResource.Absence.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.AbsenceId > 0)
            {
                if (!HumanResource.Absence.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(AbsenceModel model, int editAbsenceId)
        {
            ModelState.Clear();
            model.AbsenceId = editAbsenceId;

            if (!HumanResource.Absence.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(AbsenceModel model, int deleteAbsenceId)
        {
            ModelState.Clear();
            model.AbsenceId = deleteAbsenceId;

            if (!HumanResource.Absence.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(AbsenceModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<AbsenceModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.AbsenceGrid = loadedModel.AbsenceGrid;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
        }

    }
}