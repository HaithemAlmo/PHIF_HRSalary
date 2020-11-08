using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class CoachController : BaseController
    {
        // GET: Coach
        public ActionResult Index()
        {
            var model = HumanResource.Coach.Index();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // GET: Coach/Create
        public ActionResult Create()
        {
            var model = HumanResource.Coach.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: Coach/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoachFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxCreate(model, save);
        }

        public PartialViewResult AjaxCreate(CoachFormModel model, string save)
        {
            HumanResource.Coach.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Coach.Create(model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET: Coach/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HumanResource.Coach.Find(id);

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: Coach/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CoachFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save);
        }

        private PartialViewResult AjaxEdit(int id, CoachFormModel model, string save)
        {
            HumanResource.Coach.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Coach.Edit(id, model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET: Coach/Delete/5
        public ActionResult Delete(int id)
        {
            var model = HumanResource.Coach.Find(id);

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // POST: Coach/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool? post)
        {
            ModelState.Clear();
            var model = HumanResource.Coach.Find(id);
            if (!HumanResource.Coach.Delete(id, model))
                return HumanResourceState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        private void LoadModel(CoachFormModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<CoachFormModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
        }

    }
}