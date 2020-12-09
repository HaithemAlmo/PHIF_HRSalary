using Almotkaml.HR.Models;
using Almotkaml.HR.Reports;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class editController : BaseController
    {

        // GET: CostCenter
        public ActionResult Index()
        {
            var model = HumanResource.TechnicalAffairsDepartment.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }
        public void Refresh(TechnicalAffairsDepartmentModel model)
        {

         //   var employee = UnitOfWork.te.GetEntrantsAndReviewersByEmployeeId(model.EntrantsAndReviewersId);

            //if (employee == null)
            //    return;

            //model.EmployeeName = employee.EmployeeName;
            //model.EntrantsAndReviewersType = employee.EntrantsAndReviewersType;
         //   model.TechnicalAffairsDepartmentGrid = UnitOfWork.TechnicalAffairsDepartments.GetTechnicalAffairsDepartmentByEmployeeId(model.EntrantsAndReviewersId).ToGrid();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TechnicalAffairsDepartmentModel model, string search, string savedModel,FormCollection form)
        {
            LoadModel(model, savedModel);
            var searchid = IntValue(form["editEntrantsAndReviewersId"]);
            var print = (form["print"]);
            if (print == "print")
              //  if (!Request.IsAjaxRequest())
                return Report(model, savedModel, searchid);
            
            //return AjaxNotWorking();
            return AjaxIndex(model, searchid);
        }
        //public ActionResult Ajaxedit(TechnicalAffairsDepartmentModel model, string search)
        //{
        //    //    LoadModel(model, form["savedModel"]);

        //    //    HumanResource.TechnicalAffairsDepartment.Refresh(model);

        //    //    if (!Request.IsAjaxRequest())
        //    //        return AjaxNotWorking();

        //    //    return AjaxIndex(model, form);

        //    return View("edit", model);
        //}
        private PartialViewResult AjaxIndex(TechnicalAffairsDepartmentModel model, int searchid)
        {
            //if (searchid == 0)
            //{
            //    ModelState.Clear();
            //    return PartialView("_Form", model);
            //}
            // LoadModel(model, savedModel);
            HumanResource.TechnicalAffairsDepartment.Refresh0(model);

           

            //var print = (form["print"]);
            //if (print == "print")
            //{
            //   // return Report(model, savedModel);
            //    //    //var aa = model.EntrantsAndReviewersType;
            //    //    //if(model.EntrantsAndReviewersType != null) {
            //    //    //    HumanResource.TechnicalAffairsDepartment.Select(model);
            //    //    //}
            //    //    if(model.YearWork == 0 || model.MonthWork ==0)
            //    //        return PartialView("_Form", model);

            //    //    HumanResource.TechnicalAffairsDepartment.Select0(model);
            //    //    if(model !=null)
            //    //        return PartialView("_Form", model);
            //}

            if (searchid > 0)
            {
                if (HumanResource.TechnicalAffairsDepartment.SelectEntries(model, searchid))
                    return PartialView("_Form", model);
            }
            return PartialView("_Form", model);
        }

        public ActionResult Report(TechnicalAffairsDepartmentModel model, string savedModel,int searchid)
        {
            LoadModel(model, savedModel);
       //    var format = string.Format("yyyy-MM-dd", DateTime.Now);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "TechnicalAffairsDepartmentReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
          }

            if (!HumanResource.TechnicalAffairsDepartmentnReportBusiness.View(model,searchid))
                return HumanResourceState(model);

            var datasources = new HashSet<TechnicalAffairsDepartmentReport>();

            foreach (var row in model.TechnicalAffairsDepartmentGrid)
            {
                datasources.Add(new TechnicalAffairsDepartmentReport()
                {
                    EmployeeName = row.EmployeeName,
                    EmployeeType =
                                    row.EntrantsAndReviewersType == EntrantsAndReviewersType.Entrant ? "مدخل" :
                                    row.EntrantsAndReviewersType == EntrantsAndReviewersType.Reviewer ? "مراجع" :" " ,
                    MonthYearWork = row.YearWork + "/"+row.MonthWork,
                    DataEntryCount = row.DataEntry,
                    //FirstReviewCount =row.FirstReviewCount,
                    //AccommodationReviewCount=row.AccommodationReviewCount,
                    //ClincReviewCount=row.ClincReviewCount,
                    //TotalBalnace=row.TotalBalnace,
                });
            }

            DateTime date = Convert.ToDateTime(model.EmployeeName);
        //    DateTime name = Convert.ToInt64(model.DataEntry);
            ReportDataSource rdc = new ReportDataSource("TechnicalAffairsDataset", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection

            {
            //   new ReportParameter("name", "تقرير انهاء الخدمة"),
               new ReportParameter("date", DateTime.Now.ToString("dd-MM-yyyy")),
            //   // new ReportParameter("Date1", "كشف " + model.GetCauseOfEndService()),
            //    new ReportParameter("Date2", dateTo.ToString("dd-MM-yyyy")),
            //    new ReportParameter("CompanyName", LongName),
            //    new ReportParameter("Divetion", Department),
            };

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

        private PartialViewResult Select(TechnicalAffairsDepartmentModel model, int editTechnicalAffairsDepartmentId)
        {
            ModelState.Clear();
        model.TechnicalAffairsDepartmentId = editTechnicalAffairsDepartmentId;
             model.EntrantsAndReviewersId= editTechnicalAffairsDepartmentId;
            if (HumanResource.TechnicalAffairsDepartment.Select(model))
                HumanResource.TechnicalAffairsDepartment.Edit(model);
               // return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Create(TechnicalAffairsDepartmentModel model, int createTechnicalAffairsDepartmentId)
        {
            ModelState.Clear();
         //  model.TechnicalAffairsDepartmentId = editTechnicalAffairsDepartmentId;
            model.EntrantsAndReviewersId = model.TechnicalAffairsDepartmentId;
            if (!HumanResource.TechnicalAffairsDepartment.Create(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(TechnicalAffairsDepartmentModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<TechnicalAffairsDepartmentModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.EntrantsAndReviewersGrid = loadedModel.EntrantsAndReviewersGrid;
        }

   
    }
}