using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class RequestedQualificationController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.RequestedQualification.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RequestedQualificationModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.RequestedQualification.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(RequestedQualificationModel model, FormCollection form)
        {
            var editRequestedQualificationId = IntValue(form["editRequestedQualificationId"]);
            var deleteRequestedQualificationId = IntValue(form["deleteRequestedQualificationId"]);

            // Select
            if (editRequestedQualificationId > 0)
                return Select(model, editRequestedQualificationId);

            // Delete
            if (deleteRequestedQualificationId > 0)
                return Delete(model, deleteRequestedQualificationId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.RequestedQualificationId == 0)
            {
                if (!HumanResource.RequestedQualification.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.RequestedQualificationId > 0)
            {
                if (!HumanResource.RequestedQualification.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(RequestedQualificationModel model, int editRequestedQualificationId)
        {
            ModelState.Clear();
            model.RequestedQualificationId = editRequestedQualificationId;

            if (!HumanResource.RequestedQualification.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(RequestedQualificationModel model, int deleteRequestedQualificationId)
        {
            ModelState.Clear();
            model.RequestedQualificationId = deleteRequestedQualificationId;

            if (!HumanResource.RequestedQualification.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(RequestedQualificationModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<RequestedQualificationModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.Grid = loadedModel.Grid;
        }
    }
}