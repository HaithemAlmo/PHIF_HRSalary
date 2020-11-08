using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business;
using Almotkaml.HR.Models;
using Almotkaml.HR.Mvc.Library;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    [Authorized]
    public abstract class BaseController : Controller
    {
        protected IHumanResource HumanResource { get; }
        protected BaseController()
        {



            if (Controller == "Main" && Action == "Index")
            {
                Authentication.ToLogin = true;

            }
            if (Controller == "Account" && Action == "Login")
            {
                Authentication.ToLogin = true;
            }


            LoginModel loginModel = null;

            try
            {
                SessionManager.Load();
                loginModel = new LoginModel()
                {
                    UserName = SessionManager.UserName,
                    Password = SessionManager.Password,
                };
            }
            catch
            {
                RedirectToLogin();
            }
            if(loginModel.UserName == null)
                RedirectToLogin();

            HumanResource = GetHumanResource(loginModel);
            ViewBag.SettingsModel = HumanResource.StartUp.Settings;
            ViewBag.CompanyInfoModel = HumanResource.StartUp.CompanyInfo;
            ViewBag.ProfileModel = HumanResource.StartUp.ApplicationUser;
            ViewBag.ApplicationModel = HumanResource;
            ViewBag.IsDemo = HumanResource.StartUp.AppConfig.IsDemo;

            if (Controller == "Main" && Action == "Index")
            {
                IsSigned();

            }
            if (HumanResource.IsLogged && Controller != "Main" && Action != "Index")
                IsSigned();

            else if( Controller != "Main" && Action != "Index")
                RedirectToLogin();

            ShowCategory();
        }

        protected override void Dispose(bool disposing)
        {
            HumanResource.Dispose();
            base.Dispose(disposing);
        }

        private static IHumanResource GetHumanResource(LoginModel loginModel)
        {
            //var typeName = ConfigurationManager.AppSettings["HumanResourceType"];
            //var type = Type.GetType(typeName, true);
            //if (type == null) return null;

            //return ObjectCreator.Create<IHumanResource>(type, new StartUp<LoginModel>()
            //{
            //    LoginModel = loginModel,
            //    AppConfig = HumanResourceConfig.LoadConfig()
            //}, new ErpConfig().LoadConfig());

            return new HumanResource(new StartUp<LoginModel>()
            {
                LoginModel = loginModel,
                AppConfig = HumanResourceConfig.LoadConfig()
            }, new ErpConfig().LoadConfig());
        }
        private void ShowCategory()
        {

            ViewData["CategoryMode"] = System.Web.HttpContext.Current?.Request.QueryString["c"];

            ViewData["ActiveController"] = Controller;
            ViewData[Controller] = "active";
        }

        protected ActionResult AjaxNotWorking() => new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        #region helpers

        protected string Controller { get; } = HtmlRequestHelper.Controller(null);
        protected string Action { get; } = HtmlRequestHelper.Action(null);
        protected string Id { get; } = HtmlRequestHelper.Id(null);

        private ActionResult RedirectToLogin()
        {
            Authentication.IsLoggedIn = false;
            return RedirectToAction("Login", "Account");
        }

        private ContentResult NoPermission()
        {
            Authentication.Allowed = false;
            return Content("ليست لديك الصلاحية لدخول هذه الصفحة");
        }

        private void IsSigned()
        {
            Authentication.IsLoggedIn = true;
            Authentication.Allowed = true;
        }

        protected ActionResult HumanResourceState(object model = null)
        {
            ModelStateReCheck();

            switch (HumanResource.RequestState)
            {
                case RequestState.BadRequest:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                case RequestState.NoPermission:
                    return NoPermission();

                case RequestState.NotFound:
                    return HttpNotFound();

                case RequestState.NotLogged:
                    return RedirectToLogin();

                case RequestState.Valid:
                    return View(model);
                default:
                    return View(model);
            }
        }
        protected PartialViewResult AjaxHumanResourceState(string partialViewName, object model)
        {
            ModelStateReCheck();

            switch (HumanResource.RequestState)
            {
                case RequestState.BadRequest:
                    HumanResource.Message = "Bad Request";
                    break;

                case RequestState.NoPermission:
                    HumanResource.Message = "No Permission";
                    break;

                case RequestState.NotFound:
                    HumanResource.Message = "Not Found";
                    break;
                case RequestState.Valid:
                case RequestState.Invalid:
                    break;
                case RequestState.NotLogged:
                    HumanResource.Message = "Not Logged In";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return PartialView(partialViewName, model);
        }

        protected void CallRedirect(long modelId = 0)
        {
            ViewData["Done"] = "Done";
            ViewData["ModelId"] = modelId;
            TempData["Note"] = HumanResource.Message;
        }

        protected void CallRedirect(bool forceRedirect)
        {
            ViewData["Done"] = forceRedirect ? "fDone" : "Done";
            TempData["Note"] = HumanResource.Message;
        }

        protected void SuccessNote()
        {
            TempData["Note"] = HumanResource.Message;
        }

        protected void SaveModel(object model)
        {
            ViewData["SerializedModel"] = JsonConvert.SerializeObject(model);
        }

        protected TModel LoadSavedModel<TModel>(string savedModel)
        {
            return JsonConvert.DeserializeObject<TModel>(savedModel);
        }

        protected string ControllerName(string controller)
        {
            return controller.Replace("Controller", "");
        }

        protected void ClearModelState(Type properType, string propertyName, bool closePanel = false)
        {
            foreach (var property in properType.GetProperties())
            {
                if (ModelState.Keys.Contains(propertyName + "." + property.Name))
                    ModelState[propertyName + "." + property.Name].Errors.Clear();
            }

            if (closePanel)
                ClosePanel();
        }

        protected long LongValue(string value)
        {
            long number;
            return long.TryParse(value, out number) ? number : 0;
        }
        protected int IntValue(string value)
        {
            int number;
            return int.TryParse(value, out number) ? number : 0;
        }

        protected void ClosePanel()
        {
            ViewData["PanelStateOpened"] = "none";
            ViewData["PanelStateClosed"] = "";
        }

        protected void OpenPanel()
        {
            ViewData["PanelStateOpened"] = "";
            ViewData["PanelStateClosed"] = "none";
        }

        private void ModelStateReCheck()
        {
            foreach (var propertyState in HumanResource.ModelState.Properties.Where(p => !p.IsValid))
                ModelState.AddModelError(propertyState.Name, propertyState.ErrorMessage);
        }

        #endregion
    }
}