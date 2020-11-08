using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class BankController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.Bank.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BankModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Bank.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(BankModel model, FormCollection form)
        {
            var editBankId = IntValue(form["editBankId"]);
            var deleteBankId = IntValue(form["deleteBankId"]);

            // Select
            if (editBankId > 0)
                return Select(model, editBankId);

            // Delete
            if (deleteBankId > 0)
                return Delete(model, deleteBankId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.BankId == 0)
            {
                if (!HumanResource.Bank.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.BankId > 0)
            {
                if (!HumanResource.Bank.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(BankModel model, int editBankId)
        {
            ModelState.Clear();
            model.BankId = editBankId;

            if (!HumanResource.Bank.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(BankModel model, int deleteBankId)
        {
            ModelState.Clear();
            model.BankId = deleteBankId;

            if (!HumanResource.Bank.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(BankModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<BankModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.BankGrid = loadedModel.BankGrid;
        }
    }
}