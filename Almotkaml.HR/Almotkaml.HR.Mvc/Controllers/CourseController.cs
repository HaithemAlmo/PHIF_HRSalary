using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class CourseController : BaseController
    {
        // GET: Course
        public ActionResult Index()
        {
            var model = HumanResource.Course.Index();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            var model = HumanResource.Course.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxCreate(model, save);
        }

        public PartialViewResult AjaxCreate(CourseFormModel model, string save)
        {
            HumanResource.Course.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Course.Create(model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HumanResource.Course.Find(id);

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourseFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save);
        }

        private PartialViewResult AjaxEdit(int id, CourseFormModel model, string save)
        {
            HumanResource.Course.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Course.Edit(id, model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            var model = HumanResource.Course.Find(id);

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // POST: Course/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool? post)
        {
            ModelState.Clear();
            var model = HumanResource.Course.Find(id);
            if (!HumanResource.Course.Delete(id, model))
                return HumanResourceState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        private void LoadModel(CourseFormModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<CourseFormModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
            model.CountryList = loadedModel.CountryList;
        }

    }
}