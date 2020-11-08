using Almotkaml.HR.Models;
using Almotkaml.HR.Reports;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;


namespace Almotkaml.HR.Mvc.Controllers
{
    public class AdvancePaymentReportController : BaseController
    {
        // GET: AdvancePayment
        public ActionResult Index()
        {
            var model = HumanResource.AdvancePaymentReport.Prepare();
            if (model == null)
                return HumanResourceState();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AdvancePaymentReportModels indexModel, string savedModel, string AdvanceDetectionInside, string AdvanceDetectionOutside, string EmployeeAdvanceDetectionInside, string EmployeeAdvanceDetectionOutside,FormCollection form)
        {
          
            LoadModel(indexModel, savedModel);

            HumanResource.AdvancePaymentReport.Refresh(indexModel);

            if (AdvanceDetectionInside != null)
            {
                var model = HumanResource.AdvancePaymentReport.Index(indexModel);

                return ReportInside(model.AdvanceDetectionReportModel);


            }
            if (AdvanceDetectionOutside != null)
            {
                var model = HumanResource.AdvancePaymentReport.Index(indexModel);

                return ReportOutside(model.AdvanceDetectionReportModel);

            }

            if (EmployeeAdvanceDetectionInside != null)
            {
                var model = HumanResource.AdvancePaymentReport.Index(indexModel);

                return ReportInside(model.EmployeeAdvanceDetectionReportModel);

            }

            if (EmployeeAdvanceDetectionOutside != null)
            {
                var model = HumanResource.AdvancePaymentReport.Index(indexModel);

                return ReportOutside(model.EmployeeAdvanceDetectionReportModel);

            }


            return View(indexModel);
        }


        private void LoadModel(AdvancePaymentReportModels model, string savedModel)
        {
            var loadedModel = LoadSavedModel<AdvancePaymentReportModels>(savedModel);

            if (loadedModel == null)
                return;

            model.FullReportGrid = loadedModel.FullReportGrid;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
        }


        public ActionResult EmployeeAdvanceDetectionInside(AdvancePaymentReportModels indexModel)
        {
            var model = HumanResource.AdvancePaymentReport.Index(indexModel);

            return ReportInside(model.EmployeeAdvanceDetectionReportModel);
        }
        public ActionResult AdvanceDetectionInside(AdvancePaymentReportModels indexModel)
        {
            var model = HumanResource.AdvancePaymentReport.Index(indexModel);

            return ReportInside(model.AdvanceDetectionReportModel);
        }
        public ActionResult EmployeeAdvanceDetectionOutside(AdvancePaymentReportModels indexModel)
        {
            var model = HumanResource.AdvancePaymentReport.Index(indexModel);

            return ReportOutside(model.EmployeeAdvanceDetectionReportModel);
        }
        public ActionResult AdvanceDetectionOutside(AdvancePaymentReportModels indexModel)
        {
            var model = HumanResource.AdvancePaymentReport.Index(indexModel);

            return ReportOutside(model.AdvanceDetectionReportModel);
        }

        public ActionResult ReportInside(EmployeeAdvanceDetectionReportModel model)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "EmployeeAdvanceDetectionReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.AdvancePaymentReport.ViewInside(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<EmployeeAdvanceDetection>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new EmployeeAdvanceDetection()
                {
                    JobNumber = row.JobNumber,
                    EmployeeName = row.EmployeeName,
                    Value = row.Value,
                    Date = row.Date,
                    EmployeeId = row.EmployeeId,
                    DeductionDate = row.DeductionDate,
                    InstallmentValue = row.InstallmentValue,
                    Rest = row.Rest
                });
            }

            ReportDataSource rdc = new ReportDataSource("EmployeeAdvanceDetection", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف بالسلف الداخلية للموظف"));
            reportParameters.Add(new ReportParameter("EmployeeName", datasources.FirstOrDefault()?.EmployeeName));
            reportParameters.Add(new ReportParameter("Value", datasources.FirstOrDefault()?.Value.ToString()));
            reportParameters.Add(new ReportParameter("JobNumber", datasources.FirstOrDefault()?.JobNumber));
            reportParameters.Add(new ReportParameter("Rest", datasources.FirstOrDefault()?.Rest.ToString()));
            reportParameters.Add(new ReportParameter("Date", datasources.FirstOrDefault()?.Date));
            lr.SetParameters(reportParameters);
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
        public ActionResult ReportInside(AdvanceDetectionReportModel model)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "AdvanceDetectionReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.AdvancePaymentReport.ViewInside(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<AdvanceDetection>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new AdvanceDetection()
                {
                    JobNumber = row.JobNumber,
                    EmployeeName = row.EmployeeName,
                    Value = row.Value,
                    Date = row.Date,
                    Rest = row.Rest,
                    CostCenterName = row.CostCenterName,
                    //CostCenterId = row.CostCenterId,
                    //TafKeet =
                });
            }

            ReportDataSource rdc = new ReportDataSource("AdvanceDetection", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف بالسلف الداخلية "));
            reportParameters.Add(new ReportParameter("DateFrom", model.DateFrom));
            reportParameters.Add(new ReportParameter("DateTo", model.DateTo));
            lr.SetParameters(reportParameters);
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
        public ActionResult ReportOutside(EmployeeAdvanceDetectionReportModel model)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "EmployeeAdvanceDetectionReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.AdvancePaymentReport.ViewOutside(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<EmployeeAdvanceDetection>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new EmployeeAdvanceDetection()
                {
                    JobNumber = row.JobNumber,
                    EmployeeName = row.EmployeeName,
                    Value = row.Value,
                    Date = row.Date,
                    EmployeeId = row.EmployeeId,
                    DeductionDate = row.DeductionDate,
                    InstallmentValue = row.InstallmentValue,
                    Rest = row.Rest
                });
            }

            ReportDataSource rdc = new ReportDataSource("EmployeeAdvanceDetection", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف بالسلف الخارجية للموظف"));
            reportParameters.Add(new ReportParameter("EmployeeName", datasources.FirstOrDefault()?.EmployeeName));
            reportParameters.Add(new ReportParameter("Value", datasources.FirstOrDefault()?.Value.ToString()));
            reportParameters.Add(new ReportParameter("JobNumber", datasources.FirstOrDefault()?.JobNumber));
            reportParameters.Add(new ReportParameter("Rest", datasources.FirstOrDefault()?.Rest.ToString()));
            reportParameters.Add(new ReportParameter("Date", datasources.FirstOrDefault()?.Date));
            lr.SetParameters(reportParameters);
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
        public ActionResult ReportOutside(AdvanceDetectionReportModel model)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "AdvanceDetectionReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.AdvancePaymentReport.ViewOutside(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<AdvanceDetection>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new AdvanceDetection()
                {
                    JobNumber = row.JobNumber,
                    EmployeeName = row.EmployeeName,
                    Value = row.Value,
                    Date = row.Date,
                    Rest = row.Rest,
                    CostCenterName = row.CostCenterName,
                    //CostCenterId = row.CostCenterId,
                    //TafKeet =
                });
            }

            ReportDataSource rdc = new ReportDataSource("AdvanceDetection", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف بالسلف الخارجية "));
            reportParameters.Add(new ReportParameter("DateFrom", model.DateFrom));
            reportParameters.Add(new ReportParameter("DateTo", model.DateTo));
            lr.SetParameters(reportParameters);
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