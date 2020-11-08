using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class BounshrController : BaseController
    {
        // GET: Bouns
        public ActionResult Index()
        {
            var model = HumanResource.Bouns.Preparehr();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BounsModel model, string savedModel, int? editEmployeeId, int? cancelEmployeeId)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, editEmployeeId, cancelEmployeeId);
        }

        private PartialViewResult AjaxIndex(BounsModel model, int? editEmployeeId, int? cancelEmployeeId)
        {
            // Submit
            if (editEmployeeId > 0)
                return Submit(model, editEmployeeId);

            if (cancelEmployeeId > 0)
                return Cancel(model, cancelEmployeeId);


            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Submit(BounsModel model, int? editEmployeeId)
        {
            ModelState.Clear();
            model.EmployeeId = editEmployeeId ?? 0;

            if (!HumanResource.Bouns.Submithr(model))
                return AjaxHumanResourceState("_Form", model);

            model = HumanResource.Bouns.Preparehr();

            return PartialView("_Form", model);
        }
        private PartialViewResult Cancel(BounsModel model, int? cancelEmployeeId)
        {
            ModelState.Clear();
            model.EmployeeId = cancelEmployeeId ?? 0;

            if (!HumanResource.Bouns.Cancel(model))
                return AjaxHumanResourceState("_Form", model);

            model = HumanResource.Bouns.Preparehr();

            return PartialView("_Form", model);
        }

        private void LoadModel(BounsModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<BounsModel>(savedModel);

            if (loadedModel == null)
                return;

            model.BounsGrid = loadedModel.BounsGrid;
            model.CanSubmit = loadedModel.CanSubmit;
        }
    }
}