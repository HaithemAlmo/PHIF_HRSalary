using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SanctionController : BaseController
    {
        // GET: Sanction
        public ActionResult Index()
        {
            var model = HumanResource.Sanction.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SanctionModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Sanction.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(SanctionModel model, FormCollection form)
        {
            var editSanctionId = IntValue(form["editSanctionId"]);
            var deleteSanctionId = IntValue(form["deleteSanctionId"]);

            // Select
            if (editSanctionId > 0)
                return Select(model, editSanctionId);

            // Delete
            if (deleteSanctionId > 0)
                return Delete(model, deleteSanctionId);

            // Insert
            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.SanctionId == 0)
            {
                if (!HumanResource.Sanction.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.SanctionId > 0)
            {
                if (!HumanResource.Sanction.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(SanctionModel model, int editSanctionId)
        {
            ModelState.Clear();
            model.SanctionId = editSanctionId;

            if (!HumanResource.Sanction.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(SanctionModel model, int deleteSanctionId)
        {
            ModelState.Clear();
            model.SanctionId = deleteSanctionId;

            if (!HumanResource.Sanction.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(SanctionModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SanctionModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.SanctionGrid = loadedModel.SanctionGrid;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
            model.SanctionTypeList = loadedModel.SanctionTypeList;
            
        }
    }
}