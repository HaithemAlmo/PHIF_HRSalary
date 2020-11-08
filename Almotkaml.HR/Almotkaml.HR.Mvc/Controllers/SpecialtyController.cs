using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SpecialtyController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.Specialty.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SpecialtyModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Specialty.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(SpecialtyModel model, FormCollection form)
        {
            var editSpecialtyId = IntValue(form["editSpecialtyId"]);
            var deleteSpecialtyId = IntValue(form["editSpecialtyId"]);

            // Select
            if (editSpecialtyId > 0)
                return Select(model, editSpecialtyId);

            // Delete
            if (deleteSpecialtyId > 0)
                return Delete(model, deleteSpecialtyId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.SpecialtyId == 0)
            {
                if (!HumanResource.Specialty.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.SpecialtyId > 0)
            {
                if (!HumanResource.Specialty.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(SpecialtyModel model, int editSpecialtyId)
        {
            ModelState.Clear();
            model.SpecialtyId = editSpecialtyId;

            if (!HumanResource.Specialty.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(SpecialtyModel model, int deleteSpecialtyId)
        {
            ModelState.Clear();
            model.SpecialtyId = deleteSpecialtyId;

            if (!HumanResource.Specialty.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(SpecialtyModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SpecialtyModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.SpecialtyGrid = loadedModel.SpecialtyGrid;
        }
    }
}