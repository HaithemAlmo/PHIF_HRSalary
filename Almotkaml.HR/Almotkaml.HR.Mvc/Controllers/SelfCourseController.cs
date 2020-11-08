using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SelfCourseController : BaseController
    {
        // GET: SelfCourses
        public ActionResult Index()
        {
            var model = HumanResource.SelfCourses.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SelfCoursesModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.SelfCourses.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(SelfCoursesModel model, FormCollection form)
        {
            var editSelfCoursesId = IntValue(form["editSelfCoursesId"]);
            var deleteSelfCourseId = IntValue(form["deleteSelfCourseId"]);

            // Select
            if (editSelfCoursesId > 0)
                return Select(model, editSelfCoursesId);

            // Delete
            if (deleteSelfCourseId > 0)
                return Delete(model, deleteSelfCourseId);

            // Insert
            if (form["save"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.SelfCourseId == 0)
            {
                if (!HumanResource.SelfCourses.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.SelfCourseId > 0)
            {
                if (!HumanResource.SelfCourses.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(SelfCoursesModel model, int editSelfCoursesId)
        {
            ModelState.Clear();
            model.SelfCourseId = editSelfCoursesId;

            if (!HumanResource.SelfCourses.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(SelfCoursesModel model, int deleteSelfCoursesId)
        {
            ModelState.Clear();
            model.SelfCourseId = deleteSelfCoursesId;

            if (!HumanResource.SelfCourses.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(SelfCoursesModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SelfCoursesModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.SelfCoursesGrid = loadedModel.SelfCoursesGrid;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
            model.SpecialtyListItems = loadedModel.SpecialtyListItems;
            model.SubSpecialtyListItems = loadedModel.SubSpecialtyListItems;
        }
    }
}