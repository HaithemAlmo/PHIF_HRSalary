using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class VacationTypeController : BaseController
    {
        // GET: VacationType
        public ActionResult Index()
        {
            var model = HumanResource.VacationType.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VacationTypeModel model, string savedModel, FormCollection form)
        {
            LoadModel(model, savedModel);

            HumanResource.VacationType.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(VacationTypeModel model, FormCollection form)
        {
            var editVacationTypeId = IntValue(form["editVacationTypeId"]);
            var deleteVacationTypeId = IntValue(form["deleteVacationTypeId"]);
            // Select
            if (editVacationTypeId > 0)
                return Select(model, editVacationTypeId);

            // Delete
            if (deleteVacationTypeId > 0)
                return Delete(model, deleteVacationTypeId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.VacationTypeId == 0)
            {
                if (!HumanResource.VacationType.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.VacationTypeId > 0)
            {
                if (!HumanResource.VacationType.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(VacationTypeModel model, int editVacationTypeId)
        {
            ModelState.Clear();
            model.VacationTypeId = editVacationTypeId;

            if (!HumanResource.VacationType.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(VacationTypeModel model, int deleteVacationTypeId)
        {
            ModelState.Clear();
            model.VacationTypeId = deleteVacationTypeId;

            if (!HumanResource.VacationType.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(VacationTypeModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<VacationTypeModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.Grid = loadedModel.Grid;
        }
    }
}