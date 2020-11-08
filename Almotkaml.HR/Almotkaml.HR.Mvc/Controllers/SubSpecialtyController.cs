using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SubSpecialtyController : BaseController
    {
        // GET: SubSpecialty
        public ActionResult Index()
        {
            var model = HumanResource.SubSpecialty.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SubSpecialtyModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.SubSpecialty.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(SubSpecialtyModel model, FormCollection form)
        {
            var editSubSpecialtyId = IntValue(form["editSubSpecialtyId"]);
            var deleteSubSpecialtyId = IntValue(form["deleteSubSpecialtyId"]);

            // Select
            if (editSubSpecialtyId > 0)
                return Select(model, editSubSpecialtyId);

            // Delete
            if (deleteSubSpecialtyId > 0)
                return Delete(model, deleteSubSpecialtyId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.SubSpecialtyId == 0)
            {
                if (!HumanResource.SubSpecialty.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.SubSpecialtyId > 0)
            {
                if (!HumanResource.SubSpecialty.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(SubSpecialtyModel model, int editSubSpecialtyId)
        {
            ModelState.Clear();
            model.SubSpecialtyId = editSubSpecialtyId;

            if (!HumanResource.SubSpecialty.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(SubSpecialtyModel model, int deleteSubSpecialtyId)
        {
            ModelState.Clear();
            model.SubSpecialtyId = deleteSubSpecialtyId;

            if (!HumanResource.SubSpecialty.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(SubSpecialtyModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SubSpecialtyModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.SubSpecialtyGrid = loadedModel.SubSpecialtyGrid;
            model.SpecialtyList = loadedModel.SpecialtyList;
        }
    }
}