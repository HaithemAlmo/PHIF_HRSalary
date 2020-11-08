using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class DocumentTypeController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.DocumentType.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DocumentTypeModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.DocumentType.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(DocumentTypeModel model, FormCollection form)
        {
            var editDocumentTypeId = IntValue(form["editDocumentTypeId"]);
            var deleteDocumentTypeId = IntValue(form["deleteDocumentTypeId"]);

            // Select
            if (editDocumentTypeId > 0)
                return Select(model, editDocumentTypeId);

            // Delete
            if (deleteDocumentTypeId > 0)
                return Delete(model, deleteDocumentTypeId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.DocumentTypeId == 0)
            {
                if (!HumanResource.DocumentType.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.DocumentTypeId > 0)
            {
                if (!HumanResource.DocumentType.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(DocumentTypeModel model, int editDocumentTypeId)
        {
            ModelState.Clear();
            model.DocumentTypeId = editDocumentTypeId;

            if (!HumanResource.DocumentType.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(DocumentTypeModel model, int deleteDocumentTypeId)
        {
            ModelState.Clear();
            model.DocumentTypeId = deleteDocumentTypeId;

            if (!HumanResource.DocumentType.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(DocumentTypeModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DocumentTypeModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.DocumentTypeGrid = loadedModel.DocumentTypeGrid;
        }
    }
}

