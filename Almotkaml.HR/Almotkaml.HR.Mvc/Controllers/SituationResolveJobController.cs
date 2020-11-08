using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SituationResolveJobController : BaseController
    {
        // GET: SituationResolveJob
        public ActionResult Index()
        {
            var model = HumanResource.SituationResolveJob.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SituationResolveJobModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.SituationResolveJob.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(SituationResolveJobModel model, FormCollection form)
        {
            var editSituationResolveJobId = IntValue(form["editSituationResolveJobId"]);
            var deleteSituationResolveJobId = IntValue(form["deleteSituationResolveJobId"]);

            // Select
            if (editSituationResolveJobId > 0)
                return Select(model, editSituationResolveJobId);

            // Delete
            if (deleteSituationResolveJobId > 0)
                return Delete(model, deleteSituationResolveJobId);

            // Insert
            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.SituationResolveJobId == 0)
            {
                if (!HumanResource.SituationResolveJob.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.SituationResolveJobId > 0)
            {
                if (!HumanResource.SituationResolveJob.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(SituationResolveJobModel model, int editSituationResolveJobId)
        {
            ModelState.Clear();
            model.SituationResolveJobId = editSituationResolveJobId;

            if (!HumanResource.SituationResolveJob.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(SituationResolveJobModel model, int deleteSituationResolveJobId)
        {
            ModelState.Clear();
            model.SituationResolveJobId = deleteSituationResolveJobId;

            if (!HumanResource.SituationResolveJob.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(SituationResolveJobModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SituationResolveJobModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.SituationResolveJobGrid = loadedModel.SituationResolveJobGrid;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
            model.JobNowList = loadedModel.JobNowList;

        }
    }
}