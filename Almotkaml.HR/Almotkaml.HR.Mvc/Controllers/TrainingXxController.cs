using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class TrainingXxController : BaseController
    {
        // GET: Training
        public ActionResult Index()
        {
            var model = HumanResource.Training.Index();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // GET: Training/Create
        public ActionResult Create()
        {
            var model = HumanResource.Training.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: Training/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrainingFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxCreate(model, save);
        }

        public PartialViewResult AjaxCreate(TrainingFormModel model, string save)
        {
            HumanResource.Training.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Training.Create(model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET: Training/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HumanResource.Training.Find(id);

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: Training/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrainingFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save);
        }

        private PartialViewResult AjaxEdit(int id, TrainingFormModel model, string save)
        {
            HumanResource.Training.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Training.Edit(id, model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET: Training/Delete/5
        public ActionResult Delete(int id)
        {
            var model = HumanResource.Training.Find(id);

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // POST: Training/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool? post)
        {
            ModelState.Clear();
            var model = HumanResource.Training.Find(id);
            if (!HumanResource.Training.Delete(id, model))
                return HumanResourceState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        private void LoadModel(TrainingFormModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<TrainingFormModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
        }
    }
}