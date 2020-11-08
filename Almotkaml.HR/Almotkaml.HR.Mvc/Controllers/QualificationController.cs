using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class QualificationController : BaseController
    {
        // GET: Qualification
        public ActionResult Index()
        {
            var model = HumanResource.Qualification.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(QualificationModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Qualification.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(QualificationModel model, FormCollection form)
        {
            var editQualificationId = IntValue(form["editQualificationId"]);
            var deleteQualificationId = IntValue(form["deleteQualificationId"]);

            // Select
            if (editQualificationId > 0)
                return Select(model, editQualificationId);

            // Delete
            if (deleteQualificationId > 0)
                return Delete(model, deleteQualificationId);

            // Insert
            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.QualificationId == 0)
            {
                if (!HumanResource.Qualification.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.QualificationId > 0)
            {
                if (!HumanResource.Qualification.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(QualificationModel model, int editQualificationId)
        {
            ModelState.Clear();
            model.QualificationId = editQualificationId;

            if (!HumanResource.Qualification.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(QualificationModel model, int deleteQualificationId)
        {
            ModelState.Clear();
            model.QualificationId = deleteQualificationId;

            if (!HumanResource.Qualification.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(QualificationModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<QualificationModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.QualificationGrid = loadedModel.QualificationGrid;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
            model.SpecialtyList = loadedModel.SpecialtyList;
            model.SubSpecialtyList = loadedModel.SubSpecialtyList;
            model.QualificationTypeList = loadedModel.QualificationTypeList;
        }
    }
}
