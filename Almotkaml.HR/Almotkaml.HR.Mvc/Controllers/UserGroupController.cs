using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class UserGroupController : BaseController
    {
        // GET: UserGroup
        public ActionResult Index()
        {
            var model = HumanResource.UserGroup.Index();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // GET: UserGroup/Create
        public ActionResult Create()
        {
            var model = HumanResource.UserGroup.Prepare();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // POST: UserGroup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserGroupFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            HumanResource.UserGroup.Refresh(model);

            if (save == null)
                return View(model);

            if (!ModelState.IsValid)
                return View(model);

            if (!HumanResource.UserGroup.Create(model))
                return HumanResourceState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        // GET: UserGroup/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HumanResource.UserGroup.Find(id);

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: UserGroup/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserGroupFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            HumanResource.UserGroup.Refresh(model);

            if (save == null)
                return View(model);

            if (!ModelState.IsValid)
                return View(model);

            if (!HumanResource.UserGroup.Edit(id, model))
                return HumanResourceState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }


        // GET: UserGroup/Delete/5
        public ActionResult Delete(int id)
        {
            var model = HumanResource.UserGroup.Find(id);

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // POST: UserGroup/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool? post)
        {
            ModelState.Clear();
            var model = HumanResource.UserGroup.Find(id);
            if (!HumanResource.UserGroup.Delete(id, model))
                return HumanResourceState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        private void LoadModel(UserGroupFormModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<UserGroupFormModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
        }
    }
}
