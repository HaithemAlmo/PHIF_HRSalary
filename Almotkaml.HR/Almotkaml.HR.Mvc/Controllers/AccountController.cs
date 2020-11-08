using Almotkaml.HR.Models;
using Almotkaml.HR.Mvc.Library;
using System;
using System.Linq;
using System.Web.Mvc;

using System.Collections.Generic;
namespace Almotkaml.HR.Mvc.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        // GET: Account
        public RedirectToRouteResult Index()
        {
            
            return RedirectToAction(nameof(HomeController.Index), ControllerName(nameof(HomeController)));
        }

        public ActionResult Login()
        {
            if (Authentication.IsLoggedIn)
                return RedirectToAction(nameof(Index));

            var model = HumanResource.Account.Prepare();

            SaveModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string savedModel)
        {

            LoadModel(model, savedModel);

            if (Authentication.IsLoggedIn)
                return RedirectToAction(nameof(Index));

            if (!ModelState.IsValid)
                return View(model);

            if (!HumanResource.Account.Login(model))
                return View(model);

            SessionManager.Set(model);
       
            //var insert = HumanResource.AlldateAbsenseBusiness.Create(DefultDay);
            return RedirectToAction(nameof(HomeController.Index), ControllerName(nameof(HomeController)));
        }

        public RedirectToRouteResult Logout()
        {
            Session.Clear();

            return RedirectToAction(nameof(System.Web.UI.WebControls.Login));
        }


        public ActionResult UserProfile()
        {
            var model = HumanResource.Account.Profile();

            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserProfile(ProfileModel model)
        {
            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxProfile(model);
        }

        private PartialViewResult AjaxProfile(ProfileModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Account.Update(model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(LoginModel model, string serializedModel)
        {
            var loadedModel = LoadSavedModel<LoginModel>(serializedModel);

            if (loadedModel == null)
                return;

            model.YearsList = loadedModel.YearsList;
        }
    }
}