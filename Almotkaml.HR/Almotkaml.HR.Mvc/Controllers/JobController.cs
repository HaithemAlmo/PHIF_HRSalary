using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class JobController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.Job.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(JobModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Job.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(JobModel model, FormCollection form)
        {
            var editJobId = IntValue(form["editJobId"]);
            var deleteJobId = IntValue(form["deleteJobId"]);

            // Select
            if (editJobId > 0)
                return Select(model, editJobId);

            // Delete
            if (deleteJobId > 0)
                return Delete(model, deleteJobId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.JobId == 0)
            {
                if (!HumanResource.Job.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.JobId > 0)
            {
                if (!HumanResource.Job.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(JobModel model, int editJobId)
        {
            ModelState.Clear();
            model.JobId = editJobId;

            if (!HumanResource.Job.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(JobModel model, int deleteJobId)
        {
            ModelState.Clear();
            model.JobId = deleteJobId;

            if (!HumanResource.Job.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(JobModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<JobModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.JobGrid = loadedModel.JobGrid;
        }
    }
}

