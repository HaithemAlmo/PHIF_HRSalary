using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class DevelopmentTypeDController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.DevelopmentTypeD.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DevelopmentTypeDModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.DevelopmentTypeD.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(DevelopmentTypeDModel model, FormCollection form)
        {
            var editDevelopmentTypeDId = IntValue(form["editDevelopmentTypeDId"]);
            var deleteDevelopmentTypeDId = IntValue(form["deleteDevelopmentTypeDId"]);

            // Select
            if (editDevelopmentTypeDId > 0)
                return Select(model, editDevelopmentTypeDId);

            // Delete
            if (deleteDevelopmentTypeDId > 0)
                return Delete(model, deleteDevelopmentTypeDId);

            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.DevelopmentTypeDId == 0)
            {
                if (!HumanResource.DevelopmentTypeD.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.DevelopmentTypeDId > 0)
            {
                if (!HumanResource.DevelopmentTypeD.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(DevelopmentTypeDModel model, int editDevelopmentTypeDId)
        {
            ModelState.Clear();
            model.DevelopmentTypeDId = editDevelopmentTypeDId;

            if (!HumanResource.DevelopmentTypeD.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(DevelopmentTypeDModel model, int deleteDevelopmentTypeDId)
        {
            ModelState.Clear();
            model.DevelopmentTypeDId = deleteDevelopmentTypeDId;

            if (!HumanResource.DevelopmentTypeD.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(DevelopmentTypeDModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DevelopmentTypeDModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.Grid = loadedModel.Grid;
            model.DevelopmentTypeAList = loadedModel.DevelopmentTypeAList;
            model.DevelopmentTypeBList = loadedModel.DevelopmentTypeBList;
            model.DevelopmentTypeCList = loadedModel.DevelopmentTypeCList;
        }
    }
}


