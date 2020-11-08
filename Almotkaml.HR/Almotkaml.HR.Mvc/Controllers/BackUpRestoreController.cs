using System;
using System.Configuration;
using System.IO;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class BackUpRestoreController : BaseController
    {
        // GET: BackUpRestore
        public string Index()
        {
            var backUpFolder = ConfigurationManager.AppSettings["BackUpFolder"];
            Directory.CreateDirectory(backUpFolder);

            var path = backUpFolder + "B" + DateTime.Now.ToString("yyMMddHHmmss") + ".bak";

            return HumanResource.BackUpRestore.BackUp(path) ? path : "Failed";
        }
    }
}