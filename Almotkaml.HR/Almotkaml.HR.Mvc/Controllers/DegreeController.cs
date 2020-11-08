using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class DegreeController : BaseController
    {
        // GET: Degree
        public ActionResult Index()
        {
            var model = HumanResource.Degree.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DegreeModel model, string savedModel, int? editEmployeeId, int? cancelEmployeeId)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, editEmployeeId, cancelEmployeeId);
        }

        private PartialViewResult AjaxIndex(DegreeModel model, int? editEmployeeId, int? cancelEmployeeId)
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
        private PartialViewResult Submit(DegreeModel model, int? editEmployeeId)
        {
            ModelState.Clear();
            model.EmployeeId = editEmployeeId ?? 0;

            if (!HumanResource.Degree.Submit(model))
                return AjaxHumanResourceState("_Form", model);

            model = HumanResource.Degree.Prepare();

            return PartialView("_Form", model);
        }

        private PartialViewResult Cancel(DegreeModel model, int? cancelEmployeeId)
        {
            ModelState.Clear();
            model.EmployeeId = cancelEmployeeId ?? 0;

            if (!HumanResource.Degree.Cancel(model))
                return AjaxHumanResourceState("_Form", model);

            model = HumanResource.Degree.Prepare();

            return PartialView("_Form", model);
        }

        private void LoadModel(DegreeModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DegreeModel>(savedModel);

            if (loadedModel == null)
                return;

            model.DegreeGrid = loadedModel.DegreeGrid;
            //model.DegreeGrid = loadedModel.DegreeGrid.Select(d => new DegreeGridRow()
            //{
            //    EmployeeId = d.EmployeeId,
            //    Degree = d.Degree,
            //    JobNumber = d.JobNumber,
            //    JobId = model.DegreeGrid.FirstOrDefault(a => a.EmployeeId == d.EmployeeId)?.JobId ?? 0,
            //    ArabicFullName = d.ArabicFullName,
            //    Boun = d.Boun,
            //    DateDegreeNow = d.DateDegreeNow,
            //    DateMeritDegreeNow = d.DateMeritDegreeNow,
            //    DegreeNow = d.DegreeNow,
            //    DepartmentName = d.DepartmentName,
            //    DivisionName = d.DivisionName,
            //    MeritBoun = d.MeritBoun,
            //    MeritDegreeNow = d.MeritDegreeNow,
            //    NationalNumber = d.NationalNumber
            //}).ToList();
            //model.CanSubmit = loadedModel.CanSubmit;
        }
    }
}