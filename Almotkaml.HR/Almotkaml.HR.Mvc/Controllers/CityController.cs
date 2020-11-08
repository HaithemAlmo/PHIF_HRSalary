using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class CityController : BaseController
    {
        // GET: City
        public ActionResult Index()
        {
            var model = HumanResource.City.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CityModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.City.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(CityModel model, FormCollection form)
        {
            var editCityId = IntValue(form["editCityId"]);
            var deleteCityId = IntValue(form["deleteCityId"]);

            // Select
            if (editCityId > 0)
                return Select(model, editCityId);

            // Delete
            if (deleteCityId > 0)
                return Delete(model, deleteCityId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.CityId == 0)
            {
                if (!HumanResource.City.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.CityId > 0)
            {
                if (!HumanResource.City.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(CityModel model, int editCityId)
        {
            ModelState.Clear();
            model.CityId = editCityId;

            if (!HumanResource.City.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(CityModel model, int deleteCityId)
        {
            ModelState.Clear();
            model.CityId = deleteCityId;

            if (!HumanResource.City.Delete(model))
                return AjaxHumanResourceState("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(CityModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<CityModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.CityGrid = loadedModel.CityGrid;
            model.CountryList = loadedModel.CountryList;
        }
    }
}

