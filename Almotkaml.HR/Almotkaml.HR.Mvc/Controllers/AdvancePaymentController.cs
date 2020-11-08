using Almotkaml.HR.Models;
using Almotkaml.HR.Reports;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class AdvancePaymentController : BaseController
    {
        public ActionResult Index()
        {
            var model = HumanResource.AdvancePayment.Prepare();
           
            if (model == null)
                return HumanResourceState();
     
            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AdvancePaymentModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);
            var id = model.EmployeeId;
            HumanResource.AdvancePayment.Refresh(model);
            //model.Jobnumber = model.AdvancePaymentGrid?.FirstOrDefault().jobnumber;
            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(AdvancePaymentModel model, FormCollection form)
        {
            var editAdvancePaymentId = IntValue(form["editAdvancePaymentId"]);
            var deleteAdvancePaymentId = IntValue(form["deleteAdvancePaymentId"]);

            // Select
            if (editAdvancePaymentId > 0)
                return Select(model, editAdvancePaymentId);

            // Delete
            if (deleteAdvancePaymentId > 0)
                return Delete(model, deleteAdvancePaymentId);

            // Insert
            if (form["save"] == null) return PartialView("_Form", model);

            if (!ModelState.IsValid)
                return PartialView("_Form", model);


            if (model.AdvancePaymentId == 0)
            {
                if (!HumanResource.AdvancePayment.Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.AdvancePaymentId > 0)
            {
                if (!HumanResource.AdvancePayment.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }
            ModelState.Clear();
            //CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(AdvancePaymentModel model, int editAdvancePaymentId)
        {
            ModelState.Clear();
            model.AdvancePaymentId = editAdvancePaymentId;

            if (!HumanResource.AdvancePayment.Select(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(AdvancePaymentModel model, int deleteAdvancePaymentId)
        {
            ModelState.Clear();
            model.AdvancePaymentId = deleteAdvancePaymentId;

            if (!HumanResource.AdvancePayment.Delete(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(AdvancePaymentModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<AdvancePaymentModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.AdvancePaymentGrid = loadedModel.AdvancePaymentGrid;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
        }
        public ActionResult EmployeeAdvanceDetectionInside(AdvancePaymentModel model2)
        {
            var model = HumanResource.AdvancePayment.Prepare();

            return ReportInside(model.EmployeeAdvanceDetectionReportModel);
        }
        public ActionResult AdvanceDetectionInside(AdvancePaymentModel model2)
        {
           
            var model = HumanResource.AdvancePayment.Prepare();

            return ReportInside(model.AdvanceDetectionReportModel);
        }
        public ActionResult EmployeeAdvanceDetectionOutside(AdvancePaymentModel model2)
        {
            var model = HumanResource.AdvancePayment.Prepare();

            return ReportOutside(model.EmployeeAdvanceDetectionReportModel);
        }
        public ActionResult AdvanceDetectionOutside()
        {
            var model = HumanResource.AdvancePayment.Prepare();

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

            if (!HumanResource.AdvancePayment.ViewInside(model))
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
            reportParameters.Add(new ReportParameter("EmployeeName", ""));
            reportParameters.Add(new ReportParameter("Value", ""));
            reportParameters.Add(new ReportParameter("JobNumber", ""));
            reportParameters.Add(new ReportParameter("Rest", ""));
            reportParameters.Add(new ReportParameter("Date", ""));
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

            if (!HumanResource.AdvancePayment.ViewInside(model))
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
            reportParameters.Add(new ReportParameter("DateFrom", ""));
            reportParameters.Add(new ReportParameter("DateTo", ""));
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

            if (!HumanResource.AdvancePayment.ViewOutside(model))
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
            reportParameters.Add(new ReportParameter("EmployeeName", ""));
            reportParameters.Add(new ReportParameter("Value", ""));
            reportParameters.Add(new ReportParameter("JobNumber", ""));
            reportParameters.Add(new ReportParameter("Rest", ""));
            reportParameters.Add(new ReportParameter("Date", ""));
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

            if (!HumanResource.AdvancePayment.ViewOutside(model))
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
            reportParameters.Add(new ReportParameter("DateFrom", ""));
            reportParameters.Add(new ReportParameter("DateTo", ""));
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