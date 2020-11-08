using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class HolidayController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.Holiday.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HolidayModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Holiday.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(HolidayModel model, FormCollection form)
        {
            var editHolidayId = IntValue(form["editHolidayId"]);
            var deleteHolidayId = IntValue(form["deleteHolidayId"]);

            // Select
            if (editHolidayId > 0)
                return Select(model, editHolidayId);

            // Delete
            if (deleteHolidayId > 0)
                return Delete(model, deleteHolidayId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.HolidayId == 0)
            {
                if (!HumanResource.Holiday.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.HolidayId > 0)
            {
                if (!HumanResource.Holiday.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(HolidayModel model, int editHolidayId)
        {
            ModelState.Clear();
            model.HolidayId = editHolidayId;

            if (!HumanResource.Holiday.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(HolidayModel model, int deleteHolidayId)
        {
            ModelState.Clear();
            model.HolidayId = deleteHolidayId;

            if (!HumanResource.Holiday.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(HolidayModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<HolidayModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.HolidayGrid = loadedModel.HolidayGrid;
        }
    }
}