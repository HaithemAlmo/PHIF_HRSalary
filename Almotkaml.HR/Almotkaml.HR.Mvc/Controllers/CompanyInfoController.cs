using Almotkaml.HR.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class CompanyInfoController : BaseController
    {
        // GET:CompanyInfo
        public ActionResult Index()
        {
            var model = HumanResource.CompanyInfo.Get();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CompanyInfoModel model, HttpPostedFileBase file, string save, string savedModel)
        {
            LoadModel(model, savedModel);
            //var logoPath = Upload(file);

            if (save == null)
            {
                ModelState.Clear();
                return View(model);
            }

            if (!ModelState.IsValid)
                return View(model);

            //model.LogoPath = logoPath;

            if (!HumanResource.CompanyInfo.Save(model))
                return HumanResourceState(model);

            CallRedirect();

            return RedirectToAction("Index");
        }

        private void LoadModel(CompanyInfoModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<CompanyInfoModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
        }


        private string Upload(HttpPostedFileBase file)
        {
            const string defaultPath = "~/Images/Almotkaml.png";

            var temp = Path.Combine(Server.MapPath("~/Tempfiles/"));

            var virtualPath = HumanResourceConfig.ApplicationFolderVirtualPath + "Images/Logo.png";

            var target = HumanResourceConfig.ApplicationFolderFullPath + "Images\\Logo.png";
            Directory.CreateDirectory(temp);
            Directory.CreateDirectory(HumanResourceConfig.ApplicationFolderFullPath + "Images");

            if (file == null || file.ContentLength <= 0)
                return defaultPath;

            var fileName = Path.GetFileName(file.FileName);

            if (fileName == null)
                return defaultPath;

            var path = temp + fileName;

            try
            {
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }
            catch
            {
                HumanResource.Message = "Error delete old image !";
                return defaultPath;
            }

            file.SaveAs(path);

            try
            {
                if (System.IO.File.Exists(target))
                    System.IO.File.Delete(target);
            }
            catch
            {
                HumanResource.Message = "Error delete old image !";
                return defaultPath;
            }

            System.IO.File.Move(temp + fileName, target);

            return string.IsNullOrWhiteSpace(fileName) ? defaultPath : virtualPath;
        }
    }
}