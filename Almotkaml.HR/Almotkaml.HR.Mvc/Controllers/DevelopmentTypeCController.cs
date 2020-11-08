using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class DevelopmentTypeCController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.DevelopmentTypeC.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DevelopmentTypeCModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.DevelopmentTypeC.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(DevelopmentTypeCModel model, FormCollection form)
        {
            var editDevelopmentTypeCId = IntValue(form["editDevelopmentTypeCId"]);
            var deleteDevelopmentTypeCId = IntValue(form["deleteDevelopmentTypeCId"]);

            // Select
            if (editDevelopmentTypeCId > 0)
                return Select(model, editDevelopmentTypeCId);

            // Delete
            if (deleteDevelopmentTypeCId > 0)
                return Delete(model, deleteDevelopmentTypeCId);

            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            // Insert
            if (model.DevelopmentTypeCId == 0)
            {
                if (!HumanResource.DevelopmentTypeC.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.DevelopmentTypeCId > 0)
            {
                if (!HumanResource.DevelopmentTypeC.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(DevelopmentTypeCModel model, int editDevelopmentTypeCId)
        {
            ModelState.Clear();
            model.DevelopmentTypeCId = editDevelopmentTypeCId;

            if (!HumanResource.DevelopmentTypeC.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(DevelopmentTypeCModel model, int deleteDevelopmentTypeCId)
        {
            ModelState.Clear();
            model.DevelopmentTypeCId = deleteDevelopmentTypeCId;

            if (!HumanResource.DevelopmentTypeC.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(DevelopmentTypeCModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DevelopmentTypeCModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.Grid = loadedModel.Grid;
            model.DevelopmentTypeBList = loadedModel.DevelopmentTypeBList;
            model.DevelopmentTypeAList = loadedModel.DevelopmentTypeAList;
        }
    }
}

