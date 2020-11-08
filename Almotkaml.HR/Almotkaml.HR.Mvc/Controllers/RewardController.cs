using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class RewardController : BaseController
    {
        // GET: Reward
        public ActionResult Index()
        {
            var model = HumanResource.Reward.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RewardModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Reward.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(RewardModel model, FormCollection form)
        {
            var editRewardId = IntValue(form["editRewardId"]);
            var deleteRewardId = IntValue(form["deleteRewardId"]);

            // Select
            if (editRewardId > 0)
                return Select(model, editRewardId);

            // Delete
            if (deleteRewardId > 0)
                return Delete(model, deleteRewardId);

            // Insert
            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.RewardId == 0)
            {
                if (!HumanResource.Reward.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.RewardId > 0)
            {
                if (!HumanResource.Reward.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(RewardModel model, int editRewardId)
        {
            ModelState.Clear();
            model.RewardId = editRewardId;

            if (!HumanResource.Reward.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(RewardModel model, int deleteRewardId)
        {
            ModelState.Clear();
            model.RewardId = deleteRewardId;

            if (!HumanResource.Reward.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(RewardModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<RewardModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.RewardGrid = loadedModel.RewardGrid;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
            model.RewardTypeList = loadedModel.RewardTypeList;
        }
    }
}