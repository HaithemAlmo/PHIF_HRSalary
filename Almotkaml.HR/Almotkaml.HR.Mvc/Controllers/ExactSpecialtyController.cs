using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class ExactSpecialtyController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.ExactSpecialty.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ExactSpecialtyModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.ExactSpecialty.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(ExactSpecialtyModel model, FormCollection form)
        {
            var editExactSpecialtyId = IntValue(form["editExactSpecialtyId"]);
            var deleteExactSpecialtyId = IntValue(form["deleteExactSpecialtyId"]);

            // Select
            if (editExactSpecialtyId > 0)
                return Select(model, editExactSpecialtyId);

            // Delete
            if (deleteExactSpecialtyId > 0)
                return Delete(model, deleteExactSpecialtyId);

            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.ExactSpecialtyId == 0)
            {
                if (!HumanResource.ExactSpecialty.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.ExactSpecialtyId > 0)
            {
                if (!HumanResource.ExactSpecialty.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(ExactSpecialtyModel model, int editExactSpecialtyId)
        {
            ModelState.Clear();
            model.ExactSpecialtyId = editExactSpecialtyId;

            if (!HumanResource.ExactSpecialty.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(ExactSpecialtyModel model, int deleteExactSpecialtyId)
        {
            ModelState.Clear();
            model.ExactSpecialtyId = deleteExactSpecialtyId;

            if (!HumanResource.ExactSpecialty.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(ExactSpecialtyModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<ExactSpecialtyModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.ExactSpecialtyGrid = loadedModel.ExactSpecialtyGrid;
            model.SpecialtyList = loadedModel.SpecialtyList;
            model.SubSpecialtyList = loadedModel.SubSpecialtyList;
        }
    }
}

