using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class MainController : BaseController
    {
        int Ischeck;
        public ActionResult IndexIscheck(int? id)
        {
            Ischeck = id??0;
            return Index();
        }
        // GET: Main
        public ActionResult Index()
        {
           
            var model = HumanResource.Account.Prepare();
            model.CheckUserPerm = Ischeck;
            if (model == null)
                return HumanResourceState();

            return View(model);
        }

    }
}