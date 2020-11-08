using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class QualificationTypeController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.QualificationType.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(QualificationTypeModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.QualificationType.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(QualificationTypeModel model, FormCollection form)
        {
            var editQualificationTypeId = IntValue(form["editQualificationTypeId"]);
            var deleteQualificationTypeId = IntValue(form["deleteQualificationTypeId"]);

            // Select
            if (editQualificationTypeId > 0)
                return Select(model, editQualificationTypeId);

            // Delete
            if (deleteQualificationTypeId > 0)
                return Delete(model, deleteQualificationTypeId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.QualificationTypeId == 0)
            {
                if (!HumanResource.QualificationType.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.QualificationTypeId > 0)
            {
                if (!HumanResource.QualificationType.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(QualificationTypeModel model, int editQualificationTypeId)
        {
            ModelState.Clear();
            model.QualificationTypeId = editQualificationTypeId;

            if (!HumanResource.QualificationType.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(QualificationTypeModel model, int deleteQualificationTypeId)
        {
            ModelState.Clear();
            model.QualificationTypeId = deleteQualificationTypeId;

            if (!HumanResource.QualificationType.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(QualificationTypeModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<QualificationTypeModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.QualificationTypeGrid = loadedModel.QualificationTypeGrid;
        }
    }
}