using Almotkaml.HR.Models;
using Almotkaml.HR.Reports;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SocialSecurityFundReportController : BaseController
    {
        // GET: SocialSecurityFund
        public ActionResult Index()
        {
            var model = HumanResource.SocialSecurityFundReport.Prepare();
            if (model == null)
                return HumanResourceState();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SocialSecurityFundReportModel model, string search, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return Report(model);

            return AjaxIndex(model, search);
        }
        private PartialViewResult AjaxIndex(SocialSecurityFundReportModel model, string search)
        {
            if (search == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.SocialSecurityFundReport.View(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(SocialSecurityFundReportModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SocialSecurityFundReportModel>(savedModel);

            if (loadedModel == null)
                return;

            model.Grid = loadedModel.Grid;
        }

        public ActionResult Report(SocialSecurityFundReportModel model)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SocialSecurityFund.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.SocialSecurityFundReport.View(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SocialSecurityFundReport>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new SocialSecurityFundReport()
                {
                    JobNumber = row.JobNumber,
                    Name = row.Name,
                    TotalSalary = row.TotalSalary,
                    CompanyShare = row.CompanyShare,
                    EmployeeShare = row.EmployeeShare,
                    GuaranteeType = row.GuaranteeType
                    //Date = //////
                });
            }

            ReportDataSource rdc = new ReportDataSource("SocialSecurityFund", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("ReportParameter1", "كشف الضمان الاجتماعي"));
            lr.SetParameters(reportParameters);
            lr.DataSources.Add(rdc);
            string mimeType;
            string encoding;
            string filenameextention;
            string deviceinfo =
                "<DeviceInfo>" +
                "<OutPutFormat>" + "PDF" + "</OutPutFormat>" +
                "<PageWidth>11.69in</PageWidth>" +
                "<PageHeight>8.27in</PageHeight>" +

                "</DeviceInfo>";
            Warning[] warnings;
            string[] stream;
            byte[] renderedBytes;
            renderedBytes = lr.Render(
                "PDF",
                deviceinfo,
                out mimeType,
                out encoding,
                out filenameextention,
                out stream,
                out warnings);

            return File(renderedBytes, mimeType);
        }
    }
}