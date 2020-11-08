using Almotkaml;
using Almotkaml.HR.Models;
using Almotkaml.HR.Reports;
using Almotkaml.Resources;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class EmployeeReportController : BaseController
    {


        public ActionResult Index()
        {
            var model = HumanResource.EmployeeReport.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }
       
        public ActionResult EmployeeReport(EmployeeReportModel model, FormCollection  collection )
        {
            int totalSelected = 0;
            foreach (string key in collection.AllKeys)
            {
                int subTotalSelected = collection.GetValues(key).Where(x => x.Contains("true")).Count();
                totalSelected += subTotalSelected;

            }
            //if (totalSelected <7  )
            //{
            //    HumanResource.EmployeeReport.CheckCkeckBox(model);
            //    return View(model);
            //}
            //if (totalSelected > 9)
            //{
            //    HumanResource.EmployeeReport.CheckCkeckBox2(model);
            //    return View(model);
            //}
            //else
            //{

            return Report(model, totalSelected);
            //}
        }


        public ActionResult MowsalatReport(EmployeeReportModel model)
        {
            return Report1(model);
        }

        public ActionResult Report(EmployeeReportModel model,int numberSelect)
        {

            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "EmployeeReport.rdlc");



            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;

            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
           
            if (!HumanResource.EmployeeReport.Search(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<EmployeeReport>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new EmployeeReport()
                {
                 
                   BirthPlaseCheck = model.PlaceCheck,//false
                    EvaluationCheck=model.EvaluationCheck,
                    EvaluationDateCheck=model.EvaloitionDateCheck,
                    DonorFoundationCheck=model.DonorFoundationCheck,
                  EvaloitionDateCheck2=model.EvaloitionDateCheck2,
                  EvaloitionDateCheck3=model.EvaloitionDateCheck3,
                    EvaluationDate = row.EvaluationDate,
                    EvaluationDate2=row.EvaluationDate2,
                    EvaluationDate3=row.EvaluationDate3,
                    FatherNameCheck = model.FatherNameCheck,
                  
                    LastNameCheck = model.LastNameCheck,
                    GrenFtherCheck = model.GrenFtherCheck,
                    NameMotherCheck = model.NameMotherCheck,
                    NatinalityCheck = model.NatinalityCheck,
                    NationalityNumberCheck = model.NationalityNumberCheck,
                    JobNumberCheck = model.JobNumberCheck,
                    PalceBirthCheck = model.PalceBirthCheck,//false
                    UnitCheck = model.UnitCheck,
                    MangementCheck = model.MangementCheck,
                    PhoneCheck = model.PhoneCheck,
                    NotesCheck = model.NotesCheck,
                    NotesClosestCheck = model.NotesClosestCheck,
                    FatherEnglishCheck = model.FatherEnglishCheck,
                    DegreeCheck = model.DegreeCheck,
                    ContracetDateCheck = model.ContracetDateFromCheck,
                    ContracetDatetoCheck = model.ContracetDatetoCheck,
                    ForgenCheck = model.ForgenCheck,
                    BalanceOfleaveCheck = model.BalanceOfleaveCheck,
                    CurrentSituationCheck = model.CurrentSituationCheck,
                    CenterCheck = model.CenterCheck,
                    FirstEnglishCheck = model.FirstEnglishCheck,
                    FirstNameCheck = model.FirstNameCheck,
                    AddressCheck = model.AddressCheck,
                    DegreeNowCheck = model.DegreeNowCheck,
                    FormBirthCheck = model.FormBirthCheck,
                   
                    GenderCheck = model.GenderCheck,
                    AdressCheck = model.AddressCheck,
                    GreanFatherEnglishCheck = model.GreanFatherEnglishCheck,
                    AutomatedFigureCheck = model.AutomatedFigureCheck,
                    IdentityDateCheck = model.IdentityDateCheck,
                    IdentiyCardNumberCheck = model.IdentiyCardNumberCheck,
                    SalaryClassificationCheck = model.SalaryClassificationCheck,
                    IednttySourcePlaceCheck = model.IednttySourcePlaceCheck,
                    IssuancOftheapointmentCheck = model.IssuancOftheapointmentCheck,
                    bloodTypeCheck = model.bloodTypeCheck,
                    JobTitleCheck = model.JobTitleCheck,
                    LastEnglishCheck = model.LastEnglishCheck,
                    RelativeRelationCheck = model.RelativeRelationCheck,
                    MunicipalBranchCheck = model.MunicipalBranchCheck,
                    WorkPlaceCheck = model.WorkPlaceCheck,
                    NumberOfAppointmentDecisionCheck = model.NumberOfAppointmentDecisionCheck,
                    ReligionCheck = model.ReligionCheck,
                    PassportCheck = model.PassportCheck,
                    EmailCheck = model.EmailCheck,
                    PassportDateCheck = model.PassportDateCheck,
                    TypeOfClassificationByOwnersCheck = model.TypeOfClassificationByOwnersCheck,
                    PassportSourcePlaceCheck = model.PassportSourcePlaceCheck,
                    BoohFamilyNumberPaperCheck = model.BoohFamilyNumberPaperCheck,
                    TypeOfEmployerCheck = model.TypeOfEmployerCheck,
                    BookFamilyDateCheck = model.BookFamilyDateCheck,
                    TheClosestAccessPointCheck = model.TheClosestAccessPointCheck,
                    BookFamilyNumberCheck = model.BookFamilyNumberCheck,
                    PhoneNumberClosestCheck = model.PhoneNumberClosestCheck,
                    BouncDateFromCheck = model.BouncDateFromCheck,
                    TheClosestRelativesCheck = model.TheClosestRelativesCheck,
                    BookFamilySourcePlaceCheck = model.BookFamilySourcePlaceCheck,
                    BouncDateToCheck = model.BouncDateToCheck,
                    
                    SocialStatusCheck = model.SocialStatusCheck,
                    EmployerCheck = model.EmployerCheck,
                    EnrollmentNumberCheck = model.EnrollmentNumberCheck,
                    ToBirthCheck = model.ToBirthCheck,
                    TypeJobCheck = model.TypeJobCheck,
                    BouncMtriDateToCheck = model.BouncMtriDateToCheck,
                    BouncCheck = model.BouncCheck,
                    BouncMtriDatefromCheck = model.BouncMtriDatefromCheck,
                    BranchCheck = model.BranchCheck,
                    StreetCheck = model.StreetCheck,
                    ChildrenCheck = model.ChildrenCheck,
                    CivilRegistryCheck = model.CivilRegistryCheck,
                    ClassificationBasedOnlaborlawCheck = model.ClassificationBasedOnlaborlawCheck,
                    ClassificationBasedOnThelistOfresearchersCheck = model.ClassificationBasedOnThelistOfresearchersCheck,
                    DivisionCheck = model.DivisionCheck,
                    ClassificationByOwnersCheck = model.ClassificationByOwnersCheck,
                    DateOfAppointmentDecisionCheck = model.DateOfAppointmentDecisionCheck,
                    DirectlydateFromCheck = model.DirectlydateFromCheck,
                    DirectlyDatetoCheck = model.DirectlyDatetoCheck,
                    //
                    NumberOfAppointmentDecision = row.NumberOfAppointmentDecision,
                    WorkPlase = row.ContactInfoWorkAddress,
                    BirthPlase = row.BirthPlace,
                    FullName = row.FullName,
                    Specialty = row.Specialty,
                    Qualification = row.Qualification,
                    DateQualification = row.DateQualification,
                    DonorFoundation = row.DonorFoundation,
                    NameMother = row.MotherName,
                    Natinality = row.NationalityName,
                    NationalityNumber = row.NationalNumber,
                    JobNumber = row.JobNumber,
                    PalceBirth = row.BirthPlace,
                    Unit = row.UnitName,
                    Mangement = row.DepartmentName,
                    Phone = row.Phone,
                    Notes = row.Notes,
                    NotesClosest = row.ContactInfoNote,
                    FatherEnglish = row.EnglishFatherName,
                    Degree = row.Degree,
                    NationaltyMother = row.NationaltyMother,
                    DegreeNote = row.DegreeNote,
                    Forgen = row.LibyanOrForeigner == LibyanOrForeigner.Libyan ? "ليبي":"اجنبي",
                    BalanceOfleave = row.VacationBalance,
                    CurrentSituation = row.CurrentSituationName,
                    Center = row.CenterName,
                    FirstEnglish = row.EnglishFirstName,
                  
                    //  FirstName = row.g,
                    Address = row.Address,
                    DegreeNow = row.DegreeNow,
                    DateDegreeNow = row.DateDegreeNow,
                    // FormBirth = row.bir,
                    Gender = row.Gender == Gender.Female ? "انثى" : "ذكر",
                    Adress = row.Address,
                    GreanFatherEnglish = row.EnglishGrandfatherName,
                    AutomatedFigure = row.PassportAutoNumber,
                    IdentityDate = row.IdentificationCardIssueDate,
                    IdentiyCardNumber = row.IdentificationCardNumber,
                    //SalaryClassification = row.JobType,
                    IednttySourcePlace = row.IdentificationCardIssuePlace,
                    //   IssuancOftheapointment = row.PassportIssueDate,
                   
                    JobTitle = row.JobType == JobType.Contract ? " عقد" : row.JobType == JobType.Designation ? "مصنف"
                    : "غير محدد",
                    // LastEnglish = row.en,
                    RelativeRelation = row.ContactInfoRelativeRelation,
                    //  MunicipalBranch = row.MunicipalBranch,
                    WorkPlace = row.ContactInfoWorkAddress,
                    //  NumberOfAppointmentDecision = row.em,
                    Religion = row.Religion,
                    BirthDate = row.BirthDate,
                    Passport = row.PassportNumber,
                    Email = row.Email,
                    PassportDate = row.PassportIssueDate,
                    TypeOfClassificationByOwners = row.AdjectiveEmployeeTypeName,
                    PassportSourcePlace = row.PassportIssuePlace,
                    BoohFamilyNumberPaper = row.BookletFamilyNumber,
                    //  TypeOfEmployer = row.JobType,
                    BookFamilyDate = row.BookletIssueDate,
                    bloodType = row.BloodType.ToString() == "0" ?"": 
                    row.BloodType.ToString() == "1" ? "O+" :
                    row.BloodType.ToString() == "2" ? "AB+" :
                    row.BloodType.ToString() == "3" ? "A+" :
                    row.BloodType.ToString() == "4" ? "B+" :
                    row.BloodType.ToString() == "5" ? "O-" :
                    row.BloodType.ToString() == "6" ? "AB-" :
                    row.BloodType.ToString() == "7" ? "A-" :
                    row.BloodType.ToString() == "8" ? "B-" :"",

                    TheClosestAccessPoint = row.ContactInfoNearPoint,
                    BookFamilyNumber = row.BookletNumber,
                    PhoneNumberClosest = row.ContactInfoPhone,
                    BookFamilySourceNumber = row.BookFamilySourceNumber,
                    BouncDateFrom = row.DateBouns,
                    TheClosestRelatives = row.ContactInfoNearKindr,
                    BookFamilySourcePlace = row.BookletIssuePlace,
                    Evaluation = row.Evaluation == Grade.Acceptable ? "مقبول" :
                    row.Evaluation == Grade.Excellent ? "ممتاز" :
                    row.Evaluation == Grade.Good ? "جيد" :
                    row.Evaluation == Grade.VeryGood ? "جيد جدا" :
                    row.Evaluation == Grade.VeryWeak ? "ضعيف جدا" :
                    row.Evaluation == Grade.Weak ? "ضعيف" : "",

                    Evaluation2 = row.Evaluation2 == Grade.Acceptable ? "مقبول" :
                    row.Evaluation2 == Grade.Excellent ? "ممتاز" :
                    row.Evaluation2 == Grade.Good ? "جيد" :
                    row.Evaluation2 == Grade.VeryGood ? "جيد جدا" :
                    row.Evaluation2 == Grade.VeryWeak ? "ضعيف جدا" :
                    row.Evaluation2 == Grade.Weak ? "ضعيف" : "",



                    Evaluation3 = row.Evaluation3 == Grade.Acceptable ? "مقبول" :
                    row.Evaluation3 == Grade.Excellent ? "ممتاز" :
                    row.Evaluation3 == Grade.Good ? "جيد" :
                    row.Evaluation3 == Grade.VeryGood ? "جيد جدا" :
                    row.Evaluation3 == Grade.VeryWeak ? "ضعيف جدا" :
                    row.Evaluation3 == Grade.Weak ? "ضعيف" : "",


                    // BouncDateTo = row.boun,
                    SocialStatus = row.SocialStatus == SocialStatus.Divorcee ? "مطلق" :
                   row.SocialStatus == SocialStatus.DivorceeAndNurture ? "مطلق ويعول" :
                   row.SocialStatus == SocialStatus.Marrid ? "متزوج" :
                   row.SocialStatus == SocialStatus.MarridAndNurture ? "متزوج ويعول" :
                   row.SocialStatus == SocialStatus.Single ? "اعزب" :
                   row.SocialStatus == SocialStatus.Widower ? "ارملة" :
                   row.SocialStatus == SocialStatus.WidowerAndNurture ? "ارملة وتعول" : "غير محدد",
                    //  Employer = row.Employer,
                    EnrollmentNumber = row.BookletRegistrationNumber,

                    degreeMtriDate = row.DateMeritDegreeNow,
                    //ToBirth = row.ToBirth,
                    //   TypeJob = row.TypeJob,
                 SalaryClassification=row.JobName,
                    BouncMtriDateTo = row.DateMeritBouns,
                    Bounc = row.Bouns,
                 //   BouncMtriDatefrom = row.BouncMtriDatefrom,
                    Branch = row.BranchName,
                    Street = row.PlaceName,
                    Children = row.choldrenCount,
                    CivilRegistry = row.BookletCivilRegistry,
                    ClassificationBasedOnlaborlaw = row.ClassificationOnWorkName,
                    ClassificationBasedOnThelistOfresearchers = row.ClassificationOnSearchingName,
                    Division = row.DivisionName,
                    ClassificationByOwners = row.AdjectiveEmployeeName,
                    
                    //DateOfAppointmentDecision = row.da,
                    DirectlydateFrom = row.DirectlyDate,
                    //DirectlyDateto = row.DirectlyDateto,
                    SecurityCardNumber=row.SecurityNumber,
                    
                    DateOfAppointmentDecision=row.DateOfAppointmentDecision,


                });
            }
            var reportViewer = new ReportViewer();
            
          
         
            reportViewer.LocalReport.DataSources.Clear();
            var LongName = HumanResource.StartUp.CompanyInfo.LongName;// اسم الشركة
            var Department = HumanResource.StartUp.CompanyInfo.Department;// القسم
            ReportDataSource rdc = new ReportDataSource("EmployeeRepo", datasources);

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportViewer.LocalReport.DataSources.Add(rdc);
            reportParameters.Add(new ReportParameter("Title", "التقرير الحر"));
            var i = 12;
            var selectedCheck = i - numberSelect;
            reportParameters.Add(new ReportParameter("Department", Department));//القسم
            reportParameters.Add(new ReportParameter("CompanyName", LongName));// اسم الشركة
            reportParameters.Add(new ReportParameter("FullNameSize", selectedCheck + "in"));
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
        public ActionResult ReportGender(EmployeeReportModel model)
        {

            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "ReportAge.rdlc");

            model.GenderCheck = true;

            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;

            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.EmployeeReport.Search(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<EmployeeReport>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new EmployeeReport()
                {
                    JobNumber = row.JobNumber,
                    FullName = row.FullName,
                    Email = row.Email,
                    Division = row.DivisionName,
                    Unit = row.UnitName

                });
            }
            var reportViewer = new ReportViewer();



            reportViewer.LocalReport.DataSources.Clear();

            ReportDataSource rdc = new ReportDataSource("EmployeeRepo1", datasources);


            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportViewer.LocalReport.DataSources.Add(rdc);
            reportParameters.Add(new ReportParameter("Title", model.NameReport));
            //  reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
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


        /// // // /

        public ActionResult Report1(EmployeeReportModel model)
        {

            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "ReportMowsalatRepo.rdlc");



            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;

            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.EmployeeReport.Search(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<ReportMowsalat>();

            foreach (var row in model.Grid)
            {
                
                datasources.Add(new ReportMowsalat()
                {
                  EmployingDate=row?.DateOfAppointmentDecision.ToString(),
                    //   Id=model?.EvaluationDate.Value??0,
                    ////   EmployingDate=row.de
                    Id = model?.EvaluationDate ?? 0,

                    EvaluationDate2 = model?.EvaluationDate2 ?? 0,
                    
                    EvaluationDate3 = model?.EvaluationDate3??0,

                    FullName = row?.FullName,
NextLevelJob=row?.JobName,
NextDegre=row?.Degree??0,
NextDegreDate=row?.DateMeritDegreeNow,
BounceDate=row?.DateMeritBouns,
DegreDate=row?.DateDegreeNow,
CurrentDegre=row?.DegreeNow??0,
Specefication=row?.Specialty,
Qalifcation=row?.Qualification,
EpmployingState=row?.JobType == JobType.Contract ? "عقد " : row.JobType == JobType.Designation ? " مصنف" : "غير محدد",

                    AssessmentOfAnnualEfficiencyReports = row.Evaluation == Grade.Acceptable ? "مقبول" :
                    row.Evaluation == Grade.Excellent ? "ممتاز" :
                    row.Evaluation == Grade.Good ? "جيد" :
                    row.Evaluation == Grade.VeryGood ? "جيد جدا" :
                    row.Evaluation == Grade.VeryWeak ? "ضعيف جدا" :
                    row.Evaluation == Grade.Weak ? "ضعيف" : "غير محدد",

                    Evaluation2 = row.Evaluation2 == Grade.Acceptable ? "مقبول" :
                    row.Evaluation2 == Grade.Excellent ? "ممتاز" :
                    row.Evaluation2 == Grade.Good ? "جيد" :
                    row.Evaluation2 == Grade.VeryGood ? "جيد جدا" :
                    row.Evaluation2 == Grade.VeryWeak ? "ضعيف جدا" :
                    row.Evaluation2 == Grade.Weak ? "ضعيف" : "",



                    Evaluation3 = row.Evaluation3 == Grade.Acceptable ? "مقبول" :
                    row.Evaluation3 == Grade.Excellent ? "ممتاز" :
                    row.Evaluation3 == Grade.Good ? "جيد" :
                    row.Evaluation3 == Grade.VeryGood ? "جيد جدا" :
                    row.Evaluation3 == Grade.VeryWeak ? "ضعيف جدا" :
                    row.Evaluation3 == Grade.Weak ? "ضعيف" : "",


                    Ratio1=row.EvaluationRatio,
                    Ratio2=row.EvaluationRatio2,
                    Ratio3=row.EvaluationRatio3,
               


                  
                    CurrentJob = row?.JobName,
Notes=row?.Notes,



                });
            }
            var reportViewer = new ReportViewer();



            reportViewer.LocalReport.DataSources.Clear();

            ReportDataSource rdc = new ReportDataSource("EmployeeRepo1", datasources);

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportViewer.LocalReport.DataSources.Add(rdc);
            // reportParameters.Add(new ReportParameter("Title", "بطاقة المرتب"));
            //  reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
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



        // تقرير القوة العمومية 16_11_2019
        public ActionResult ManPowerReport(EmployeeReportModel model)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "ManPowerReport.rdlc");



            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;

            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.EmployeeReport.ManPowerReport(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<ManPowerReport>();

            foreach (var row in model.ManPowerReportGrid)
            {
                datasources.Add(new ManPowerReport()
                {
                    AdjectiveEmployeeType = row.AdjectiveEmployeeType,
                    PhDCount = row.PhDCount,
                    MasterCount = row.MasterCount,
                    DiplomaCount = row.DiplomaCount,
                    EngCount = row.EngCount,
                    AssistantCount = row.AssistantCount,
                    CraftsmanCount = row.CraftsmanCount,
                    OperationalCount = row.OperationalCount,
                    AdministrativeCount = row.AdministrativeCount,
                    WriterAdmCount = row.WriterAdmCount,
                    FinancialCount = row.FinancialCount,
                    BookkeeperCount = row.BookkeeperCount,
                    JuristCount = row.JuristCount,
                    AlternateCount = row.AlternateCount,
                    AssistantlitCountCount = row.AssistantlitCountCount,
                    CMilitaryACount = row.CMilitaryACount,
                    CStandardACount = row.CStandardACount,
                    DailyTimeCount = row.DailyTimeCount,
                    literalityEngCount = row.literalityEngCount,
                    OccSafEngCount = row.OccSafEngCount,
                    OfficerCount = row.OfficerCount,
                    OperationallitCount = row.OperationallitCount,
                    ServicesCount = row.ServicesCount,
                    SoldiersCount = row.SoldiersCount,
                    TechnicalSafEngCount = row.TechnicalSafEngCount,
                    WarrantOfficerCount = row.WarrantOfficerCount,

                });
            }
            var reportViewer = new ReportViewer();



            reportViewer.LocalReport.DataSources.Clear();
            //var LongName = HumanResource.StartUp.CompanyInfo.LongName;// اسم الشركة
            //var Department = HumanResource.StartUp.CompanyInfo.Department;// القسم
            ReportDataSource rdc = new ReportDataSource("ManPowerDataset", datasources);
            reportViewer.LocalReport.DataSources.Add(rdc);

            //ReportParameterCollection reportParameters = new ReportParameterCollection();
            //reportParameters.Add(new ReportParameter("Title", ""));
            //reportParameters.Add(new ReportParameter("Department", Department));//القسم
            //reportParameters.Add(new ReportParameter("CompanyName", LongName));// اسم الشركة

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




        /// //////
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(EmployeeReportModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HumanResource.EmployeeReport.Refresh(model);

            if (!Request.IsAjaxRequest())

                switch (form["reportType"])
                {
                    case "EmployeeReport":
                        return EmployeeReport(model,form);
                    case "ReportAge":
                        return ReportGender(model);
                    case "ReportMowsalatRepo":
                        return MowsalatReport(model);
                    case "ManPowerReport":
                        return ManPowerReport(model);
                }
            if (form["ReportAge"] != null)
            {
                HumanResource.EmployeeReport.SearchReports(model);

                // FingerResurs.FingerModel.FingerConnect(model);

            }
            if (form["ReportGender"] != null)
            {
                return ReportGender(model);

                // FingerResurs.FingerModel.FingerConnect(model);

            }
            if (form["ReportQualfaction"] != null)
            {
                HumanResource.EmployeeReport.SearchReports(model);

                // FingerResurs.FingerModel.FingerConnect(model);

            }
            if (form["ReportTypeQualfiction"] != null)
            {
                HumanResource.EmployeeReport.SearchReports(model);

                // FingerResurs.FingerModel.FingerConnect(model);

            }
            if (form["ReportDep"] != null)
            {
                HumanResource.EmployeeReport.SearchReports(model);

                // FingerResurs.FingerModel.FingerConnect(model);

            }
            if (form["ReportCar"] != null)
            {
                HumanResource.EmployeeReport.SearchReports(model);

                // FingerResurs.FingerModel.FingerConnect(model);

            }
            if (form["ReportCity"] != null)
            {
                HumanResource.EmployeeReport.SearchReports(model);

                // FingerResurs.FingerModel.FingerConnect(model);

            }
            if (form["ReportEndEmp"] != null)
            {
                HumanResource.EmployeeReport.SearchReports(model);

                // FingerResurs.FingerModel.FingerConnect(model);

            }
            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(EmployeeReportModel model, FormCollection form)
        {
            if (form["search"] == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            // Search
            if (!HumanResource.EmployeeReport.Search(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(EmployeeReportModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<EmployeeReportModel>(savedModel);

            if (loadedModel == null)
                return;

            model.Grid = loadedModel.Grid;
            model.DepartmentList = loadedModel.DepartmentList;
            model.CenterList = loadedModel.CenterList;
            model.ClassificationOnWorkList = loadedModel.ClassificationOnWorkList;
            model.AdjectiveEmployeeList = loadedModel.AdjectiveEmployeeList;
            model.AdjectiveEmployeeTypeList = loadedModel.AdjectiveEmployeeTypeList;
            model.BranchList = loadedModel.BranchList;
            model.ClassificationOnSearchingList = loadedModel.ClassificationOnSearchingList;
            model.CurrentSituationList = loadedModel.CurrentSituationList;
            model.DivisionList = loadedModel.DivisionList;
            model.JobList = loadedModel.JobList;
            model.NationalityList = loadedModel.NationalityList;
            model.PlaceList = loadedModel.PlaceList;
            model.StaffingList = loadedModel.StaffingList;
            model.StaffingTypeList = loadedModel.StaffingTypeList;
            model.UnitList = loadedModel.UnitList;
        }
    }
}

