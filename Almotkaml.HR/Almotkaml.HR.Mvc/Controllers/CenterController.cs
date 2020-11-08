using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class CenterController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.Center.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CenterModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Center.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(CenterModel model, FormCollection form)
        {
            var editCenterId = IntValue(form["editCenterId"]);
            var deleteCenterId = IntValue(form["deleteCenterId"]);

            // Select
            if (editCenterId > 0)
                return Select(model, editCenterId);

            // Delete
            if (deleteCenterId > 0)
                return Delete(model, deleteCenterId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.CenterId == 0)
            {
                if (!HumanResource.Center.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.CenterId > 0)
            {
                if (!HumanResource.Center.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(CenterModel model, int editCenterId)
        {
            ModelState.Clear();
            model.CenterId = editCenterId;

            if (!HumanResource.Center.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(CenterModel model, int deleteCenterId)
        {
            ModelState.Clear();
            model.CenterId = deleteCenterId;

            if (!HumanResource.Center.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(CenterModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<CenterModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.CenterGrid = loadedModel.CenterGrid;
            model.CostCenterList = loadedModel.CostCenterList;
        }
    }
}

