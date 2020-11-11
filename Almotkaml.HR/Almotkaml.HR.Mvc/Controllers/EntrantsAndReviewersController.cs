using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    //public class EntrantsAndReviewersController : Controller
    //{
    //    // GET: EntrantsAndReviewers
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }
    //}

    public class EntrantsAndReviewersController : BaseController
    {
        // GET: CostCenter
        public ActionResult Index()
        {
            var model = HumanResource.EntrantsAndReviewers.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(EntrantsAndReviewersModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.EntrantsAndReviewers.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(EntrantsAndReviewersModel model, FormCollection form)
        {
            var editEntrantsAndReviewersId = IntValue(form["editEntrantsAndReviewersId"]);
            var deleteEntrantsAndReviewersId = IntValue(form["deleteEntrantsAndReviewersId"]);

            // Select
            if (editEntrantsAndReviewersId > 0)
                return Select(model, editEntrantsAndReviewersId);

            // Delete
            if (deleteEntrantsAndReviewersId > 0)
                return Delete(model, deleteEntrantsAndReviewersId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.EntrantsAndReviewersId == 0)
            {
                if (!HumanResource.EntrantsAndReviewers.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.EntrantsAndReviewersId > 0)
            {
                if (!HumanResource.EntrantsAndReviewers .Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(EntrantsAndReviewersModel model, int editEntrantsAndReviewersId)
        {
           ModelState.Clear();
            model.EntrantsAndReviewersId = editEntrantsAndReviewersId;

            if (!HumanResource.EntrantsAndReviewers.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(EntrantsAndReviewersModel model, int deleteEntrantsAndReviewersId)
        {
            ModelState.Clear();
            model.EntrantsAndReviewersId = deleteEntrantsAndReviewersId;

            if (!HumanResource.EntrantsAndReviewers.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(EntrantsAndReviewersModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<EntrantsAndReviewersModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.EntrantsAndReviewersGrid = loadedModel.EntrantsAndReviewersGrid;
        }
    }
}