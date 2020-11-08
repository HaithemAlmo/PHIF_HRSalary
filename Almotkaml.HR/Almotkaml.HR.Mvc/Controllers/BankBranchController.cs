using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class BankBranchController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.BankBranch.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BankBranchModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.BankBranch.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(BankBranchModel model, FormCollection form)
        {
            var editBankBranchId = IntValue(form["editBankBranchId"]);
            var deleteBankBranchId = IntValue(form["deleteBankBranchId"]);

            // Select
            if (editBankBranchId > 0)
                return Select(model, editBankBranchId);

            // Delete
            if (deleteBankBranchId > 0)
                return Delete(model, deleteBankBranchId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.BankBranchId == 0)
            {
                if (!HumanResource.BankBranch.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.BankBranchId > 0)
            {
                if (!HumanResource.BankBranch.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }
            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(BankBranchModel model, int editBankBranchId)
        {
            ModelState.Clear();
            model.BankBranchId = editBankBranchId;

            if (!HumanResource.BankBranch.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(BankBranchModel model, int deleteBankBranchId)
        {
            ModelState.Clear();
            model.BankBranchId = deleteBankBranchId;

            if (!HumanResource.BankBranch.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(BankBranchModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<BankBranchModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.BankBranchGrid = loadedModel.BankBranchGrid;
            model.BankList = loadedModel.BankList;
            model.AccountingManualList = loadedModel.AccountingManualList;
        }
    }
}