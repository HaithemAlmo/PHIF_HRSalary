using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SanctionTypeController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.SanctionType.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SanctionTypeModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.SanctionType.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(SanctionTypeModel model, FormCollection form)
        {
            var editSanctionTypeId = IntValue(form["editSanctionTypeId"]);
            var deleteSanctionTypeId = IntValue(form["deleteSanctionTypeId"]);

            // Select
            if (editSanctionTypeId > 0)
                return Select(model, editSanctionTypeId);

            // Delete
            if (deleteSanctionTypeId > 0)
                return Delete(model, deleteSanctionTypeId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.SanctionTypeId == 0)
            {
                if (!HumanResource.SanctionType.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.SanctionTypeId > 0)
            {
                if (!HumanResource.SanctionType.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(SanctionTypeModel model, int editSanctionTypeId)
        {
            ModelState.Clear();
            model.SanctionTypeId = editSanctionTypeId;

            if (!HumanResource.SanctionType.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(SanctionTypeModel model, int deleteSanctionTypeId)
        {
            ModelState.Clear();
            model.SanctionTypeId = deleteSanctionTypeId;

            if (!HumanResource.SanctionType.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(SanctionTypeModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SanctionTypeModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.SanctionTypeGrid = loadedModel.SanctionTypeGrid;
        }
    }
}