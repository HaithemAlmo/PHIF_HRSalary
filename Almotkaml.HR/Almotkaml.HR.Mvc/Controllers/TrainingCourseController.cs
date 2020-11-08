using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class TrainingCourseController : BaseController
    {
        // GET:TrainingCourse
        public ActionResult Index()
        {
            var model = HumanResource.TrainingCourse.Index();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // GET:TrainingCourse/Create
        public ActionResult Create()
        {
            var model = HumanResource.TrainingCourse.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST:TrainingCourse/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrainingCourseFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxCreate(model, save);
        }

        public PartialViewResult AjaxCreate(TrainingCourseFormModel model, string save)
        {
            HumanResource.TrainingCourse.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.TrainingCourse.Create(model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET:TrainingCourse/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HumanResource.TrainingCourse.Find(id);

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST:TrainingCourse/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrainingCourseFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save);
        }

        private PartialViewResult AjaxEdit(int id, TrainingCourseFormModel model, string save)
        {
            HumanResource.TrainingCourse.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.TrainingCourse.Edit(id, model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET:TrainingCourse/Delete/5
        public ActionResult Delete(int id)
        {
            var model = HumanResource.TrainingCourse.Find(id);

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // POST:TrainingCourse/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool? post)
        {
            ModelState.Clear();
            var model = HumanResource.TrainingCourse.Find(id);
            if (!HumanResource.TrainingCourse.Delete(id, model))
                return HumanResourceState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        private void LoadModel(TrainingCourseFormModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<TrainingCourseFormModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
        }
    }
}