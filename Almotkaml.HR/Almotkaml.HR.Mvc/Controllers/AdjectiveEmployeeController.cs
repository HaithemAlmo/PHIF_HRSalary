using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class AdjectiveEmployeeController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.AdjectiveEmployee.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AdjectiveEmployeeModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.AdjectiveEmployee.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(AdjectiveEmployeeModel model, FormCollection form)
        {
            var editAdjectiveEmployeeId = IntValue(form["editAdjectiveEmployeeId"]);
            var deleteAdjectiveEmployeeId = IntValue(form["deleteAdjectiveEmployeeId"]);

            // Select
            if (editAdjectiveEmployeeId > 0)
                return Select(model, editAdjectiveEmployeeId);

            // Delete
            if (deleteAdjectiveEmployeeId > 0)
                return Delete(model, deleteAdjectiveEmployeeId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.AdjectiveEmployeeId == 0)
            {
                if (!HumanResource.AdjectiveEmployee.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.AdjectiveEmployeeId > 0)
            {
                if (!HumanResource.AdjectiveEmployee.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(AdjectiveEmployeeModel model, int editAdjectiveEmployeeId)
        {
            ModelState.Clear();
            model.AdjectiveEmployeeId = editAdjectiveEmployeeId;

            if (!HumanResource.AdjectiveEmployee.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(AdjectiveEmployeeModel model, int deleteAdjectiveEmployeeId)
        {
            ModelState.Clear();
            model.AdjectiveEmployeeId = deleteAdjectiveEmployeeId;

            if (!HumanResource.AdjectiveEmployee.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(AdjectiveEmployeeModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<AdjectiveEmployeeModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.AdjectiveEmployeeGrid = loadedModel.AdjectiveEmployeeGrid;
            model.AdjectiveEmployeeTypeList = loadedModel.AdjectiveEmployeeTypeList;
        }
    }
}