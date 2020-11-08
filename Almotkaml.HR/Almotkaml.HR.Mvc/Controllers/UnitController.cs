using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class UnitController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.Unit.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UnitModel model, string savedModel, FormCollection form)
        {
            LoadModel(model, savedModel);

            HumanResource.Unit.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(UnitModel model, FormCollection form)
        {
            var editUnitId = IntValue(form["editUnitId"]);
            var deleteUnitId = IntValue(form["deleteUnitId"]);

            // Select
            if (editUnitId > 0)
                return Select(model, editUnitId);

            // Delete
            if (deleteUnitId > 0)
                return Delete(model, deleteUnitId);

            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.UnitId == 0)
            {
                if (!HumanResource.Unit.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.UnitId > 0)
            {
                if (!HumanResource.Unit.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(UnitModel model, int editUnitId)
        {
            ModelState.Clear();
            model.UnitId = editUnitId;

            if (!HumanResource.Unit.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(UnitModel model, int deleteUnitId)
        {
            ModelState.Clear();
            model.UnitId = deleteUnitId;

            if (!HumanResource.Unit.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(UnitModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<UnitModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.UnitGrid = loadedModel.UnitGrid;
            model.DepartmentList = loadedModel.DepartmentList;
            model.DivisionList = loadedModel.DivisionList;
            model.CenterList = loadedModel.CenterList;
        }
    }
}


