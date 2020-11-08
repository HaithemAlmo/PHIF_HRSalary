using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class AdjectiveEmployeeTypeController : BaseController
    {
        // GET: AdjectiveEmployeeType
        public ActionResult Index()
        {
            var model = HumanResource.AdjectiveEmployeeType.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AdjectiveEmployeeTypeModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.AdjectiveEmployeeType.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(AdjectiveEmployeeTypeModel model, FormCollection form)
        {
            var editAdjectiveEmployeeTypeId = IntValue(form["editAdjectiveEmployeeTypeId"]);
            var deleteAdjectiveEmployeeTypeId = IntValue(form["deleteAdjectiveEmployeeTypeId"]);

            // Select
            if (editAdjectiveEmployeeTypeId > 0)
                return Select(model, editAdjectiveEmployeeTypeId);

            // Delete
            if (deleteAdjectiveEmployeeTypeId > 0)
                return Delete(model, deleteAdjectiveEmployeeTypeId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.AdjectiveEmployeeTypeId == 0)
            {
                if (!HumanResource.AdjectiveEmployeeType.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.AdjectiveEmployeeTypeId > 0)
            {
                if (!HumanResource.AdjectiveEmployeeType.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(AdjectiveEmployeeTypeModel model, int editAdjectiveEmployeeTypeId)
        {
            ModelState.Clear();
            model.AdjectiveEmployeeTypeId = editAdjectiveEmployeeTypeId;

            if (!HumanResource.AdjectiveEmployeeType.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(AdjectiveEmployeeTypeModel model, int deleteAdjectiveEmployeeTypeId)
        {
            ModelState.Clear();
            model.AdjectiveEmployeeTypeId = deleteAdjectiveEmployeeTypeId;

            if (!HumanResource.AdjectiveEmployeeType.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(AdjectiveEmployeeTypeModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<AdjectiveEmployeeTypeModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.AdjectiveEmployeeTypeGrid = loadedModel.AdjectiveEmployeeTypeGrid;
        }
    }
}