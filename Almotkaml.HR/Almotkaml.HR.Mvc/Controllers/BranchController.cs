using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class BranchController : BaseController
    {
        // GET: CostCenter
        public ActionResult Index()
        {
            var model = HumanResource.Branch.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BranchModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Branch.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(BranchModel model, FormCollection form)
        {
            var editBranchId = IntValue(form["editBranchId"]);
            var deleteBranchId = IntValue(form["deleteBranchId"]);

            // Select
            if (editBranchId > 0)
                return Select(model, editBranchId);

            // Delete
            if (deleteBranchId > 0)
                return Delete(model, deleteBranchId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.BranchId == 0)
            {
                if (!HumanResource.Branch.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.BranchId > 0)
            {
                if (!HumanResource.Branch.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(BranchModel model, int editBranchId)
        {
            ModelState.Clear();
            model.BranchId = editBranchId;

            if (!HumanResource.Branch.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(BranchModel model, int deleteBranchId)
        {
            ModelState.Clear();
            model.BranchId = deleteBranchId;

            if (!HumanResource.Branch.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(BranchModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<BranchModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.BranchGrid = loadedModel.BranchGrid;
        }
    }
}