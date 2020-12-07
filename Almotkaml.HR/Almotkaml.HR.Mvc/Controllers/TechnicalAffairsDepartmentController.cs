using Almotkaml.HR.Models;
using System;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class TechnicalAffairsDepartmentController : BaseController
    {

        // GET: CostCenter
        public ActionResult Index()
        {
            var model = HumanResource.TechnicalAffairsDepartment.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }


        public void Refresh(TechnicalAffairsDepartmentModel model)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TechnicalAffairsDepartmentModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.TechnicalAffairsDepartment.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(TechnicalAffairsDepartmentModel model, FormCollection form)
        {
            var editTechnicalAffairsDepartmentId = IntValue(form["editTechnicalAffairsDepartmentd"]);
            var deleteTechnicalAffairsDepartmentId = IntValue(form["deleteTechnicalAffairsDepartmentId"]);

            // Select
            if (editTechnicalAffairsDepartmentId > 0)
                return Select(model, editTechnicalAffairsDepartmentId);

            // Delete
            //if (deleteTechnicalAffairsDepartmentId > 0)
            //    return Delete(model, deleteTechnicalAffairsDepartmentId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.TechnicalAffairsDepartmentId == 0)
            {
                if (!HumanResource.TechnicalAffairsDepartment .Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.TechnicalAffairsDepartmentId > 0)
            {
                if (!HumanResource.TechnicalAffairsDepartment.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }


        private PartialViewResult Select(TechnicalAffairsDepartmentModel model, int editTechnicalAffairsDepartmentId)
        {
            ModelState.Clear();
            model.TechnicalAffairsDepartmentId = editTechnicalAffairsDepartmentId;

            if (!HumanResource.TechnicalAffairsDepartment.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(TechnicalAffairsDepartmentModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<TechnicalAffairsDepartmentModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.EntrantsAndReviewersGrid = loadedModel.EntrantsAndReviewersGrid;
        }

   
    }
}