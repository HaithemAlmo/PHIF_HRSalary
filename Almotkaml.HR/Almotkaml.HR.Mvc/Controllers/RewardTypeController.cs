using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class RewardTypeController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.RewardType.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RewardTypeModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.RewardType.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(RewardTypeModel model, FormCollection form)
        {
            var editRewardTypeId = IntValue(form["editRewardTypeId"]);
            var deleteRewardTypeId = IntValue(form["deleteRewardTypeId"]);

            // Select
            if (editRewardTypeId > 0)
                return Select(model, editRewardTypeId);

            // Delete
            if (deleteRewardTypeId > 0)
                return Delete(model, deleteRewardTypeId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.RewardTypeId == 0)
            {
                if (!HumanResource.RewardType.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.RewardTypeId > 0)
            {
                if (!HumanResource.RewardType.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(RewardTypeModel model, int editRewardTypeId)
        {
            ModelState.Clear();
            model.RewardTypeId = editRewardTypeId;

            if (!HumanResource.RewardType.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(RewardTypeModel model, int deleteRewardTypeId)
        {
            ModelState.Clear();
            model.RewardTypeId = deleteRewardTypeId;

            if (!HumanResource.RewardType.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(RewardTypeModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<RewardTypeModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.RewardTypeGrid = loadedModel.RewardTypeGrid;
        }
    }
}