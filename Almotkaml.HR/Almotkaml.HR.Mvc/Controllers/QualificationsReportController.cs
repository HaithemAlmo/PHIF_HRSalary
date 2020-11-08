using Almotkaml.HR.Models;
using Almotkaml.HR.Reports;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class QualificationsReportController : BaseController
    {
        // GET: SettlementAbsenceReport
        public ActionResult Index()
        {
            var model = HumanResource.Qualification.Prepare();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(QualificationModel model, FormCollection form, string savedModel)
        {
            LoadModel(model, savedModel);

            HumanResource.Qualification.RefreshReport(model);

            if (!Request.IsAjaxRequest())
                return Report(model, savedModel);
            //return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(QualificationModel model, FormCollection form)
        {
            //LoadModel(model, savedModel);
            if (form["search"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }


            HumanResource.Qualification.Report(model);

            return PartialView("_Form", model);
        }

        private void LoadModel(QualificationModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<QualificationModel>(savedModel);

            if (loadedModel == null)
                return;

            model.QualificationGrid = loadedModel.QualificationGrid;
        }

        public ActionResult Report(QualificationModel model, string savedModel)
        {
            LoadModel(model, savedModel);
            //var format = string.Format("yyyy-MM-dd", dateFrom);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "QualificationsReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            HumanResource.Qualification.Report(model);

            var datasources = new HashSet<QualificationsReport>();

            foreach (var row in model.QualificationGrid)
            {
                datasources.Add(new QualificationsReport()
                {
                    EmployeeName= row.EmployeeName,
                    Qualification =row.QualificationTypeName,
                    Specialty= row.SpecialtyName,
                    SubSpecialty = row.SubSpecialtyName,
                    ExactSpecialty= row.ExactSpecialtyName,
                    AquiredSpecialty=row.AquiredSpecialty,
                });
            }

            //DateTime dateFrom = Convert.ToDateTime(model.DateFrom);
            //DateTime dateTo = Convert.ToDateTime(model.DateTo);
            ReportDataSource rdc = new ReportDataSource("QualificationsReport", datasources);
            //ReportParameterCollection reportParameters = new ReportParameterCollection
            //{
            //    //new ReportParameter("ReportParameter1", "كشف الغياب" ),
                //new ReportParameter("ReportParameter2",
                //    "من التاريخ : " + dateFrom.ToString("dd-MM-yyyy") + " حتى التاريخ : " +
                //    dateTo.ToString("dd-MM-yyyy")),
            //};

            //lr.SetParameters(reportParameters);
            lr.DataSources.Add(rdc);
            string mimeType;
            string encoding;
            string filenameextention;
            string deviceinfo =
                "<DeviceInfo>" +
                "<OutPutFormat>" + "PDF" + "</OutPutFormat>" +
                "</DeviceInfo>";
            Warning[] warnings;
            string[] stream;
            var renderedBytes = lr.Render(
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