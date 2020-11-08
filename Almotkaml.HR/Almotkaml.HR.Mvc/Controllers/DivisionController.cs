using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class DivisionController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.Division.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DivisionModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Division.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(DivisionModel model, FormCollection form)
        {
            var editDivisionId = IntValue(form["editDivisionId"]);
            var deleteDivisionId = IntValue(form["deleteDivisionId"]);

            // Select
            if (editDivisionId > 0)
                return Select(model, editDivisionId);

            // Delete
            if (deleteDivisionId > 0)
                return Delete(model, deleteDivisionId);

            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            // Insert
            if (model.DivisionId == 0)
            {
                if (!HumanResource.Division.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.DivisionId > 0)
            {
                if (!HumanResource.Division.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(DivisionModel model, int editDivisionId)
        {
            ModelState.Clear();
            model.DivisionId = editDivisionId;

            if (!HumanResource.Division.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(DivisionModel model, int deleteDivisionId)
        {
            ModelState.Clear();
            model.DivisionId = deleteDivisionId;

            if (!HumanResource.Division.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(DivisionModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DivisionModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.DivisionGrid = loadedModel.DivisionGrid;
            model.DepartmentList = loadedModel.DepartmentList;
            model.CenterList = loadedModel.CenterList;
        }
    }
}

