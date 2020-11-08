using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class EvaluationController : BaseController
    {
        //GET: Evaluation
        public ActionResult Index()
        {
            var model = HumanResource.Evaluation.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(EvaluationModel model, FormCollection form)
        {
            var note = model.Note;
            LoadModel(model, form["savedModel"]);

            HumanResource.Evaluation.Refresh(model);
            model.Note = note;
            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(EvaluationModel model, FormCollection form)
        {
            var editEvaluationId = IntValue(form["editEvaluationId"]);
            var deleteEvaluationId = IntValue(form["deleteEvaluationId"]);

            // Select
            if (editEvaluationId > 0)
                return Select(model, editEvaluationId);

            // Delete
            if (deleteEvaluationId > 0)
                return Delete(model, deleteEvaluationId);

            // Insert
            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.EvaluationId == 0)
            {
                if (!HumanResource.Evaluation.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.EvaluationId > 0)
            {
                if (!HumanResource.Evaluation.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(EvaluationModel model, int editEvaluationId)
        {
            ModelState.Clear();
            model.EvaluationId = editEvaluationId;

            if (!HumanResource.Evaluation.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(EvaluationModel model, int deleteEvaluationId)
        {
            ModelState.Clear();
            model.EvaluationId = deleteEvaluationId;

            if (!HumanResource.Evaluation.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(EvaluationModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<EvaluationModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.EvaluationGrird = loadedModel.EvaluationGrird;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
        }
    }
}