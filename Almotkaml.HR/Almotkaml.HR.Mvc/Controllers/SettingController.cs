using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SettingController : BaseController
    {
        // GET: Settings
        public ActionResult Index()
        {
            var model = HumanResource.Setting.Get();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SettingsModel model, string save, string savedModel)
        {
            if (model.TextboxFrom != "" && model.TextboxFrom != null && model.NumberCheck != "" && model.NumberCheck != null)
            {
                ModelState.Clear();
                if (ModelState.IsValid)
                {
                    if (model.Number == 0)
                    {
                        model.Number = 1;
                    }
                    var sum = int.Parse(model.TextboxFrom) + (int.Parse(model.NumberCheck) * model.Number);
                    model.TextboxTo = sum.ToString();
                }
            }
                LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, save);
        }

        private PartialViewResult AjaxIndex(SettingsModel model, string save)
        {
            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Setting.Save(model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(SettingsModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SettingsModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
        }
    }
}