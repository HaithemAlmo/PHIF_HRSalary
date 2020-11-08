using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index(int? userGroupId)
        {
            var model = userGroupId != null
                ? HumanResource.User.Index(userGroupId.Value)
                : HumanResource.User.Index();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            var model = HumanResource.User.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxCreate(model, save);
        }

        public PartialViewResult AjaxCreate(UserCreateModel model, string save)
        {
            HumanResource.User.Refresh(model);

            if (save == null)
                return PartialView("_FormCreate", model);

            if (!ModelState.IsValid)
                return PartialView("_FormCreate", model);

            if (!HumanResource.User.Create(model))
                return AjaxHumanResourceState("_FormCreate", model);

            CallRedirect();

            return PartialView("_FormCreate", model);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HumanResource.User.Find(id);

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserEditModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save);
        }

        private PartialViewResult AjaxEdit(int id, UserEditModel model, string save)
        {
            HumanResource.User.Refresh(model);

            if (save == null)
                return PartialView("_FormEdit", model);

            if (!ModelState.IsValid)
                return PartialView("_FormEdit", model);

            if (!HumanResource.User.Edit(id, model))
                return AjaxHumanResourceState("_FormEdit", model);

            CallRedirect();

            return PartialView("_FormEdit", model);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var model = HumanResource.User.Find(id);

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool? post)
        {
            ModelState.Clear();
            var model = HumanResource.User.Find(id);
            if (!HumanResource.User.Delete(id, model))
                return HumanResourceState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        private void LoadModel(UserCreateModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<UserEditModel>(savedModel);
            if (loadedModel == null)
                return;

            model.UserGroupList = loadedModel.UserGroupList;
        }
        private void LoadModel(UserEditModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<UserEditModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
            model.UserGroupList = loadedModel.UserGroupList;
        }
    }
}
