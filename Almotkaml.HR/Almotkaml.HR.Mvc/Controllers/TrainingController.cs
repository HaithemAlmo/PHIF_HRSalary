using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class TrainingController : BaseController
    {
        // GET: Training
        public ActionResult Index()
        {
            var model = HumanResource.Training.Index();

            return model == null ? HumanResourceState() : View(model);
        }

        // GET: Training/Create
        public ActionResult Create()
        {
            var model = HumanResource.Training.Prepare();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // POST: Training/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrainingFormModel model, FormCollection form, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return ManageRequest(model, form);
        }

        private PartialViewResult ManageRequest(TrainingFormModel model, FormCollection form)
        {
            HumanResource.Training.Refresh(model);

            int? editDetailId = IntValue(form["editDetailId"]);
            int? deleteDetailId = IntValue(form["deleteDetailId"]);

            if (editDetailId > 0)
                return EditDetail(model, editDetailId.Value);

            if (deleteDetailId > 0)
                return DeleteDetail(model, deleteDetailId.Value);

            if (form["save"] != null)
                return Save(model);

            ModelState.Clear();
            return PartialView("_Form", model);
        }

        private PartialViewResult EditDetail(TrainingFormModel model, int value)
        {
            model.TrainingDetailForm.TrainingDetailId = value;
            ModelState.Clear();

            return !HumanResource.Training.SelectDetail(model)
                ? AjaxHumanResourceState("_Form", model)
                : PartialView("_Form", model);
        }
        private PartialViewResult DeleteDetail(TrainingFormModel model, int value)
        {
            model.TrainingDetailForm.TrainingDetailId = value;
            ModelState.Clear();

            return !HumanResource.Training.DeleteDetail(model)
                ? AjaxHumanResourceState("_Form", model)
                : PartialView("_Form", model);
        }

        private PartialViewResult Save(TrainingFormModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Training.Save(model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect(model.TrainingId);
            ModelState.Clear();
            return PartialView("_Form", model);
        }

        // GET: Training/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HumanResource.Training.Find(id);

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // POST: Training/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TrainingFormModel model, FormCollection form, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return ManageRequest(model, form);
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

            if (!HumanResource.Training.Delete(model))
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
            model.CountryList = loadedModel.CountryList;
            model.DevelopmentStateList = loadedModel.DevelopmentStateList;
            model.DevelopmentTypeAList = loadedModel.DevelopmentTypeAList;
            model.TrainingDetailForm.TrainingDetailGrid = loadedModel.TrainingDetailForm.TrainingDetailGrid;
            model.TrainingDetailForm.EmployeeGrid = loadedModel.TrainingDetailForm.EmployeeGrid;
            model.RequestedQualificationList = loadedModel.RequestedQualificationList;
            model.CorporationGrid = loadedModel.CorporationGrid;
            model.TrainingId = loadedModel.TrainingId;
        }
    }
}