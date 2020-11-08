using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class TransferController : BaseController
    {
        // GET: Transfer
        public ActionResult Index()
        {
            var model = HumanResource.Transfer.Prepare();

            if (model == null)
                return HumanResourceState();
            foreach (var row in model.TransferGrid)
            {

                if (row.JobTypeTransfer == JobTypeTransfer.EmptiedPart)
                {
                    row.TransferName = "تفرغ كامل";
                }
                if (row.JobTypeTransfer == JobTypeTransfer.EmptiedPart)
                {
                    row.TransferName = "تفرغ جزئي";
                }
                if (row.JobTypeTransfer == JobTypeTransfer.Delegation)
                {
                    row.TransferName = "ندب";
                }
                if (row.JobTypeTransfer == JobTypeTransfer.Collaborator)
                {
                    row.TransferName = "متعاون";
                }
            }
            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TransferModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Transfer.Refresh(model);
        
            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(TransferModel model, FormCollection form)
        {
            var editTransferId = IntValue(form["editTransferId"]);
            var deleteTransferId = IntValue(form["deleteTransferId"]);

            // Select
            if (editTransferId > 0)
                return Select(model, editTransferId);

            // Delete
            if (deleteTransferId > 0)
                return Delete(model, deleteTransferId);

            // Insert
            if (form["save"] == null)
            {
           
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.TransferId == 0)
            {
                if (!HumanResource.Transfer.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.TransferId > 0)
            {
                if (!HumanResource.Transfer.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }
        
            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(TransferModel model, int editTransferId)
        {
            ModelState.Clear();
            model.TransferId = editTransferId;

            if (!HumanResource.Transfer.Select(model))
                return AjaxHumanResourceState("_Form", model);
            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(TransferModel model, int deleteTransferId)
        {
            ModelState.Clear();
            model.TransferId = deleteTransferId;

            if (!HumanResource.Transfer.Delete(model))
                return AjaxHumanResourceState("_Form", model);
           
            return PartialView("_Form", model);
        }

        private void LoadModel(TransferModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<TransferModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.TransferGrid = loadedModel.TransferGrid;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
        }
    }
}