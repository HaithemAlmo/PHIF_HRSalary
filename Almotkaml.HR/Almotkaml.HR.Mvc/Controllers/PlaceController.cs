using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class PlaceController : BaseController
    {
        // GET: Place
        public ActionResult Index()
        {
            var model = HumanResource.Place.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PlaceModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.Place.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(PlaceModel model, FormCollection form)
        {
            var editPlaceId = IntValue(form["editPlaceId"]);
            var deletePlaceId = IntValue(form["deletePlaceId"]);

            // Select
            if (editPlaceId > 0)
                return Select(model, editPlaceId);

            // Delete
            if (deletePlaceId > 0)
                return Delete(model, deletePlaceId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.PlaceId == 0)
            {
                if (!HumanResource.Place.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.PlaceId > 0)
            {
                if (!HumanResource.Place.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(PlaceModel model, int editPlaceId)
        {
            ModelState.Clear();
            model.PlaceId = editPlaceId;

            if (!HumanResource.Place.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(PlaceModel model, int deletePlaceId)
        {
            ModelState.Clear();
            model.PlaceId = deletePlaceId;

            if (!HumanResource.Place.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(PlaceModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<PlaceModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.PlaceGrid = loadedModel.PlaceGrid;
            model.BranchList = loadedModel.BranchList;
        }
    }
}

