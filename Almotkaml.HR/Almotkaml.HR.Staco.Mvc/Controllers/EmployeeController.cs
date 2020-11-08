using Almotkaml.HR.Models;
using Almotkaml.HR.Staco.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace Almotkaml.HR.Staco.Mvc.Controllers
{
    public class EmployeeController : HR.Mvc.Controllers.EmployeeController
    {
        [HttpPost, ActionName("OldCreate")]
        [ValidateAntiForgeryToken]
        public override ActionResult Create(PersonalModel model, string save, string savedModel)
        {
            throw new InvalidOperationException();
        }

        [HttpPost, ActionName("OldEdit")]
        [ValidateAntiForgeryToken]
        public override ActionResult EditPersonal(int id, PersonalModel model, string save, string savedModel, bool? uploadAvatar, HttpPostedFileBase uploadedfile)
        {
            throw new InvalidOperationException();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StacoPersonalModel model, string save, string savedModel)
        {
            return base.Create(model, save, savedModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPersonal(int id, StacoPersonalModel model, string save, string savedModel, bool? uploadAvatar, HttpPostedFileBase uploadedfile)
        {
            return base.EditPersonal(id, model, save, savedModel, uploadAvatar, uploadedfile);
        }
    }
}