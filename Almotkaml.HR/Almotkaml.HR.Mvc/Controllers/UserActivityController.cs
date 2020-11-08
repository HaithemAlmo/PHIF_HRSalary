using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class UserActivityController : BaseController
    {
        // GET: UserActivity
        public ActionResult Index()
        {
            var model = HumanResource.UserActivity.Index();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserActivityModel model, string search, string savedModel)
        {
            LoadModel(model, savedModel);

            HumanResource.UserActivity.Refresh(model);


            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, search);
        }

        private PartialViewResult AjaxIndex(UserActivityModel model, string search)
        {
            if (search == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!HumanResource.UserActivity.Search(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(UserActivityModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<UserActivityModel>(savedModel);

            if (loadedModel == null)
                return;

            model.GridRows = loadedModel.GridRows;
            model.UserListItems = loadedModel.UserListItems;
        }
    }
}