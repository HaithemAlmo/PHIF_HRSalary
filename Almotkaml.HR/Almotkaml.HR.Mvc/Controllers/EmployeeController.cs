using Almotkaml.Extensions;
using Almotkaml.HR.Models;
using Almotkaml.HR.Mvc.ViewModels;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee
        public virtual ActionResult Index()
        {
            var model = HumanResource.Employee.Index();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(EmployeeIndexModel model, string import, HttpPostedFileBase file, string savedModel, FormCollection form, int? id)
        {
            if (!string.IsNullOrWhiteSpace(import))
                return Import(file);
            switch (form["reportType"])
            {
                case "Show":
                    return Edit(id ?? 0);
            }

            LoadModel(model, savedModel);
            HumanResource.Employee.Refresh(model);

            if (model == null)
                return HumanResourceState();

            return View(model);
        }


        // GET: Employee/Create
        public virtual ActionResult Create()
        {
            var model = HumanResource.Employee.Prepare();

            if (model == null)
                return HumanResourceState();

            //SaveModel(model);

            return View(model);
        }
        public virtual ActionResult CreateQualificationModel()
        {
            var model = HumanResource.Employee.Prepare1();

            if (model == null)
                return HumanResourceState();

            //SaveModel(model);

            return View(model);
        }
        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(PersonalModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxCreate(model, save);
        }
        public virtual ActionResult CreateQualificationModel(QualificationModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxCreateQualification(model, save);
        }

        public PartialViewResult AjaxCreate(PersonalModel model, string save)
        {
            HumanResource.Employee.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_PersonalForm", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_PersonalForm", model);

            if (!HumanResource.Employee.Create(model))
                return AjaxHumanResourceState("_PersonalForm", model);

            CallRedirect(model.EmployeeId);

            return PartialView("_PersonalForm", model);
        }
        public PartialViewResult AjaxCreateQualification(QualificationModel model, string save)
        {
            HumanResource.Employee.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_QualificationModelForm", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_QualificationModelForm", model);

            if (!HumanResource.Qualification.Create(model))
                return AjaxHumanResourceState("_QualificationModelForm", model);

            CallRedirect(model.EmployeeId);

            return PartialView("_QualificationModelForm", model);
        }
        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HumanResource.Employee.Find(id);

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: Employee/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, EmployeeFormModel model, string save, string savedModel)
        //{
        //    var requestedModel = LoadModel(model, savedModel);

        //    if (!Request.IsAjaxRequest())
        //        return AjaxNotWorking();

        //    switch (requestedModel)
        //    {
        //        case RequestedModel.PersonalModel:
        //            return AjaxEdit(id, model.PersonalModel, save);

        //        case RequestedModel.JobInfoModel:
        //            return AjaxEdit(id, model.JobInfoModel, save);

        //        case RequestedModel.MilitaryDataModel:
        //            return AjaxEdit(id, model.MilitaryDataModel, save);


        //        default:
        //            return AjaxHumanResourceState("_Form", model);
        //    }
        //}


        //public ActionResult EditPersonal(int id) => RedirectToAction("Edit", new { id });
        //public ActionResult EditQualification(int id) => RedirectToAction("Edit", new { id });
        //public ActionResult EditJob(int id) => RedirectToAction("Edit", new { id });
        //public ActionResult EditJobDegree(int id) => RedirectToAction("Edit", new { id });
        //public ActionResult EditMilitary(int id) => RedirectToAction("Edit", new { id });
        //public ActionResult DeleteMilitary(int id) => RedirectToAction("Edit", new { id });
        //public ActionResult EditDocument(int id) => RedirectToAction("Edit", new { id });
        //public ActionResult CreateQualificationModel(int id) => RedirectToAction("Edit", new { id });
        public ActionResult EditSalaryInfo(int id) => RedirectToAction("Edit", new { id });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult EditPersonal(int id, PersonalModel model, string save, string savedModel, bool? uploadAvatar, HttpPostedFileBase uploadedfile)
        {
            LoadModel(model, savedModel);

            if (uploadAvatar ?? false)
                return Upload(model, uploadedfile);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult EditJob(int id, JobInfoModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save);
        }
        //public virtual ActionResult EditJobDegree(int id, JobInfoDegreeModel model, string save, string savedModel, int? edit, int? Promotion, int? Settlement)
        [HttpPost]
        [ValidateAntiForgeryToken]

        public virtual ActionResult EditJobDegree(int id, JobInfoDegreeModel model, string save, string savedModel, FormCollection form)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save, form);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMilitary(int id, MilitaryDataModel model, string save, string delete, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save, delete);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult EditQualification(int id, QualificationModel model, bool? save, string savedModel, int? editQualificationId, int? deleteQualificationId)
        {
            LoadModel(model, savedModel);



            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(model, save ?? false, editQualificationId, deleteQualificationId);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDocument(int id, DocumentModel model, bool? save, string savedModel, int? editDocumentId, int? deleteDocumentId, int? deleteDocumentImageId, int? deleteImageIndex, bool? upload, IEnumerable<HttpPostedFileBase> uploadedImages)
        {
            LoadModel(model, savedModel);

            if (upload ?? false)
                return Upload(model, uploadedImages);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(model, save ?? false, editDocumentId, deleteDocumentId, deleteDocumentImageId, deleteImageIndex);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMilitary(int id, MilitaryDataModel model, string save, string delete, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save, delete);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditSalaryInfo(int id, SalaryInfoModel model, string save, string savedModel)
        //{
        //    LoadModel(model, savedModel);

        //    if (!Request.IsAjaxRequest())
        //        return AjaxNotWorking();

        //    return AjaxEdit(id, model, save);
        //}


        private PartialViewResult AjaxEdit(int id, PersonalModel model, string save)
        {
            //var personal = model.PersonalModel;

            HumanResource.Employee.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_PersonalForm", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_PersonalForm", model);

            if (!HumanResource.Employee.Edit(id, model))
                return AjaxHumanResourceState("_PersonalForm", model);



            return PartialView("_PersonalForm", model);
        }


        private PartialViewResult AjaxEdit(QualificationModel model, bool save, int? editQualificationId, int? deleteQualificationId)

        {

            HumanResource.Employee.Refresh(model);

            if (editQualificationId != null)
            {
                model.QualificationId = editQualificationId.Value;
                if (!HumanResource.Employee.SelectQualification(model))
                    return AjaxHumanResourceState("_QualificationModelForm", model);
            }

            if (deleteQualificationId != null)
            {
                model.QualificationId = deleteQualificationId.Value;
                if (!HumanResource.Employee.DeleteQualification(model))
                    return AjaxHumanResourceState("_QualificationModelForm", model);
            }

            if (!save)
            {
                ModelState.Clear();
                return PartialView("_QualificationModelForm", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_QualificationModelForm", model);

            if (!HumanResource.Employee.SaveQualification(model))
                return AjaxHumanResourceState("_QualificationModelForm", model);


            ModelState.Clear();

            return PartialView("_QualificationModelForm", model);
        }

        private PartialViewResult AjaxEdit(int id, JobInfoModel model, string save)
        {
            HumanResource.Employee.Refresh(id, model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_JobInfoModelForm", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_JobInfoModelForm", model);

            if (!HumanResource.Employee.Edit(id, model))
                return AjaxHumanResourceState("_JobInfoModelForm", model);



            return PartialView("_JobInfoModelForm", model);
        }


        private PartialViewResult AjaxEdit(int id, JobInfoDegreeModel model, string save, FormCollection form)
        {
            //HumanResource.Employee.Refresh(id, model);

            if (form["editJobInfoId"] != null)
            {
                //ModelState.Clear();
                model.EmployeeId = id;


                if (!HumanResource.Employee.Edit(id, model))
                    return AjaxHumanResourceState("_JobInfoDegreeModelForm", model);

            }
            if (form["SettlementJobInfoId"] != null)
            {

                model.SituationResolveJob = new SituationResolveJobModel();
                model.SituationResolveJob.SituationResolveJobId = HumanResource.Employee.Find(id).SituationResolveJobModel.SituationResolveJobId;
                if (model.SituationResolveJob.SituationResolveJobId == 0)
                {
                    //(model.DegreeNow, model.BounNow, model.DecisionNumber, model.DecisionDate.ToDateTime(), model.JobNowId,model.Note )
                    model.SituationResolveJob.EmployeeId = id;
                    model.SituationResolveJob.DegreeNow = model.DegreeNow ?? 0;
                    model.SituationResolveJob.BounNow = model.Bouns ?? 0;
                    model.SituationResolveJob.DecisionDate = model.DateDegreeNow;
                    model.SituationResolveJob.DecisionNumber = model.DegreeLastResolutionNumber.ToString();
                    model.SituationResolveJob.JobNowId = model.JobId ?? 0;
                    if (!HumanResource.SituationResolveJob.Create(model.SituationResolveJob, 1))
                        return AjaxHumanResourceState("_JobInfoDegreeModelForm", model);
                }

                if (model.SituationResolveJob.SituationResolveJobId > 0)
                {
                    if (!HumanResource.SituationResolveJob.Edit(model.SituationResolveJob))
                        return AjaxHumanResourceState("_JobInfoDegreeModelForm", model);
                }
            }
            if (form["PromotionJobInfoId"] != null)
            {
                //ModelState.Clear();
                model.EmployeeId = id;


                if (!HumanResource.Degree.Submit(model, 2))
                    return AjaxHumanResourceState("_JobInfoDegreeModelForm", model);

            }

            return PartialView("_JobInfoDegreeModelForm", model);
            //ModelState.Clear();
            //if (save == null)
            //{
            //    ModelState.Clear();
            //    return PartialView("_JobInfoDegreeModelForm", model);
            //}

            //if (!ModelState.IsValid)
            //    return PartialView("_JobInfoDegreeModelForm", model);

            //if (!HumanResource.Employee.Edit(id, model))
            //    return AjaxHumanResourceState("_JobInfoDegreeModelForm", model);
            //if (!HumanResource.Employee.PromotionJobInfo(id, model))
            //    return AjaxHumanResourceState("_JobInfoDegreeModelForm", model);
            //if (!HumanResource.Employee.SettlementJobInfo(id, model))
            //    return AjaxHumanResourceState("_JobInfoDegreeModelForm", model);



        }
        //++////////////////////////////////////


        private PartialViewResult AjaxEdit(int id, MilitaryDataModel model, string save, string delete)
        {
            HumanResource.Employee.Refresh(model);

            if (save == null && delete == null)
            {
                ModelState.Clear();
                return PartialView("_MilitaryDataModelForm", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_MilitaryDataModelForm", model);
            if (save != null)
            {
                if (!HumanResource.Employee.Edit(id, model))
                    return AjaxHumanResourceState("_MilitaryDataModelForm", model);
            }

            if (delete != null)
            {
                if (!HumanResource.Employee.DeleteMilitaryData(id, model))
                    return AjaxHumanResourceState("_MilitaryDataModelForm", model);
                ModelState.Clear();
            }



            return PartialView("_MilitaryDataModelForm", model);
        }

        private PartialViewResult AjaxEdit(DocumentModel model, bool save, int? editDocumentId, int? deleteDocumentId, int? deleteDocumentImageId, int? deleteImageIndex)
        {
            HumanResource.Employee.Refresh(model);

            if (editDocumentId != null)
            {
                model.DocumentId = editDocumentId.Value;
                if (!HumanResource.Employee.SelectDocument(model))
                    return AjaxHumanResourceState("_DocumentModelForm", model);
            }
            if (deleteDocumentId != null)
            {
                model.DocumentId = deleteDocumentId.Value;
                if (!HumanResource.Employee.DeleteDocument(model))
                    return AjaxHumanResourceState("_DocumentModelForm", model);
            }
            if (deleteDocumentImageId != null)
            {
                if (!HumanResource.Employee.DeleteImage(deleteDocumentImageId.Value))
                    return AjaxHumanResourceState("_DocumentModelForm", model);

                var imageId = model.LoadedImages.FirstOrDefault(i => i == deleteDocumentImageId.Value);
                model.LoadedImages.Remove(imageId);
            }

            if (deleteImageIndex != null)
            {
                if (model.SavedImages.Count > deleteImageIndex.Value)
                {
                    var image = model.SavedImages[deleteImageIndex.Value];
                    model.SavedImages.Remove(image);
                }
            }

            if (!save)
            {
                ModelState.Clear();
                return PartialView("_DocumentModelForm", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_DocumentModelForm", model);

            if (!HumanResource.Employee.SaveDocument(model))
                return AjaxHumanResourceState("_DocumentModelForm", model);


            ModelState.Clear();

            return PartialView("_DocumentModelForm", model);
        }

        private PartialViewResult Upload(DocumentModel model, IEnumerable<HttpPostedFileBase> uploadedImages)
        {
            HumanResource.Employee.Refresh(model);

            if (uploadedImages != null)
            {
                var images = uploadedImages as IList<HttpPostedFileBase> ?? uploadedImages.ToList();
                if (images.Any())
                {
                    ModelState.Clear();
                    foreach (var image in images)
                    {
                        var stream = new MemoryStream();
                        image.InputStream.CopyTo(stream);
                        model.SavedImages.Add(stream.ToArray());
                    }
                }
            }
            ModelState.Clear();
            return PartialView("_DocumentModelForm", model);
        }
        private PartialViewResult Upload(PersonalModel model, HttpPostedFileBase uploadedAvatar)
        {
            HumanResource.Employee.Refresh(model);

            if (uploadedAvatar == null)
                return PartialView("_PersonalForm", model);

            var stream = new MemoryStream();
            uploadedAvatar.InputStream.CopyTo(stream);
            model.Image = stream.ToArray();

            ModelState.Clear();
            ViewBag.KeepPanelOpen = true;
            return PartialView("_PersonalForm", model);
        }

        public ActionResult GetImage(int id)
        {
            var imageData = HumanResource.Employee.LoadImage(id);

            if (imageData == null || imageData.Length == 0)
                return new EmptyResult();

            return File(imageData, "image/jpg");
        }

        public ActionResult GetAvatar(int id)
        {
            var imageData = HumanResource.Employee.LoadAvatar(id);

            if (imageData == null || imageData.Length == 0)
                return new EmptyResult();

            return File(imageData, "image/jpg");
        }


        //private PartialViewResult AjaxEdit(int id, SalaryInfoModel model, string save)
        //{
        //    HumanResource.Employee.Refresh(model);

        //    if (save == null)
        //    {
        //        ModelState.Clear();
        //        return PartialView("_SalaryInfoModelForm", model);
        //    }

        //    if (!ModelState.IsValid)
        //        return PartialView("_SalaryInfoModelForm", model);

        //    if (!HumanResource.Employee.Edit(id, model))
        //        return AjaxHumanResourceState("_SalaryInfoModelForm", model);

        //    

        //    return PartialView("_SalaryInfoModelForm", model);
        //}


        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var model = HumanResource.Employee.Find(id);

            if (model == null)
                return HumanResourceState();

            return View(model.PersonalModel);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool? post)
        {
            ModelState.Clear();
            var model = HumanResource.Employee.Find(id);
            if (!HumanResource.Employee.Delete(id, model.PersonalModel))
                return HumanResourceState(model.PersonalModel);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        private RequestedModel LoadModel(EmployeeFormModel model, string savedModel)
        {
            var request = RequestedModel.Unknown;

            var loadedModel = LoadSavedModel<EmployeeFormModel>(savedModel);
            if (loadedModel == null)
                return request;

            if (model.PersonalModel == null)
                model.PersonalModel = loadedModel.PersonalModel;
            else
            {
                model.PersonalModel.CanSubmit = loadedModel.PersonalModel.CanSubmit;
                request = RequestedModel.PersonalModel;
            }
            if (model.QualificationModel == null)
                model.QualificationModel = loadedModel.QualificationModel;
            else
            {
                model.QualificationModel.CanSubmit = loadedModel.QualificationModel.CanSubmit;
                request = RequestedModel.Qualification;
            }

            if (model.JobInfoModel == null)
                model.JobInfoModel = loadedModel.JobInfoModel;
            else
            {
                model.JobInfoModel.CanSubmit = loadedModel.JobInfoModel.CanSubmit;
                request = RequestedModel.JobInfoModel;
            }

            if (model.MilitaryDataModel == null)
                model.MilitaryDataModel = loadedModel.MilitaryDataModel;
            else
            {
                model.MilitaryDataModel.CanSubmit = loadedModel.MilitaryDataModel.CanSubmit;
                request = RequestedModel.MilitaryDataModel;
            }
            //if (model.SalaryInfoModel == null)
            //    model.SalaryInfoModel = loadedModel.SalaryInfoModel;
            //else
            //{
            //    model.SalaryInfoModel.CanSubmit = loadedModel.SalaryInfoModel.CanSubmit;
            //    request = RequestedModel.SalaryInfoModel;
            //}

            return request;
        }
        private void LoadModel(EmployeeIndexModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<EmployeeIndexModel>(savedModel);

            if (loadedModel == null)
                return;
            model.DepartmentList = loadedModel.DepartmentList;
            model.DivisionList = loadedModel.DivisionList;
            model.CenterList = loadedModel.CenterList;
        }
        private void LoadModel(PersonalModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<PersonalModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
            model.BranchList = loadedModel.BranchList;
            model.NationalityList = loadedModel.NationalityList;
            model.HaveImage = loadedModel.HaveImage;
            model.Image = loadedModel.Image;
        }
        private void LoadModel(JobInfoModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<JobInfoModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
            model.CenterList = loadedModel.CenterList;
            model.AdjectiveEmployeeTypeList = loadedModel.AdjectiveEmployeeTypeList;
            model.StaffingTypeList = loadedModel.StaffingTypeList;
            model.CurrentSituationList = loadedModel.CurrentSituationList;
            model.JobList = loadedModel.JobList;
            model.ClassificationOnSearchingList = loadedModel.ClassificationOnSearchingList;
            model.ClassificationOnWorkList = loadedModel.ClassificationOnWorkList;
        }
        private void LoadModel(JobInfoDegreeModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<JobInfoDegreeModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
            model.CanPromotion = loadedModel.CanPromotion;
            model.CanSettlement = loadedModel.CanSettlement;
            model.CanEdit = loadedModel.CanEdit;
            model.CenterList = loadedModel.CenterList;
            model.AdjectiveEmployeeTypeList = loadedModel.AdjectiveEmployeeTypeList;
            model.JobList = loadedModel.JobList;
            //model.JobId = loadedModel.JobId;
            //model.DegreeLastResolutionNumber = loadedModel.DegreeLastResolutionNumber;
            model.DegreeNow = loadedModel.DegreeNow;
            model.Bouns = loadedModel.Bouns;
            model.DateDegreeNow = loadedModel.DateDegreeNow;

            //model.StaffingTypeList = loadedModel.StaffingTypeList;
            //model.CurrentSituationList = loadedModel.CurrentSituationList;
            // model.JobList = loadedModel.JobList;
            model.ClassificationOnSearchingList = loadedModel.ClassificationOnSearchingList;
            model.ClassificationOnWorkList = loadedModel.ClassificationOnWorkList;
        }
        private void LoadModel(MilitaryDataModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<MilitaryDataModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
        }
        private void LoadModel(DocumentModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DocumentModel>(savedModel);
            if (loadedModel == null)
                return;

            model.DocumentGrid = loadedModel.DocumentGrid;
            model.DocumentId = loadedModel.DocumentId;
            model.EmployeeId = loadedModel.EmployeeId;
            model.DocumentTypeList = loadedModel.DocumentTypeList;
            model.Number = loadedModel.Number;
            model.LoadedImages = loadedModel.LoadedImages;
            model.SavedImages = loadedModel.SavedImages;
            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
        }

        private void LoadModel(QualificationModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<QualificationModel>(savedModel);

            if (loadedModel == null)
                return;
            model.CanSubmit = loadedModel.CanSubmit;
            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.QualificationGrid = loadedModel.QualificationGrid;
            model.EmployeeGrid = loadedModel.EmployeeGrid;
            model.SpecialtyList = loadedModel.SpecialtyList;
            model.SubSpecialtyList = loadedModel.SubSpecialtyList;
            model.QualificationTypeList = loadedModel.QualificationTypeList;
        }

        //private void LoadModel(QualificationModel model, string savedModel)
        //{
        //    var loadedModel = LoadSavedModel<QualificationModel>(savedModel);
        //    if (loadedModel == null)
        //        return;


        //    model.CanSubmit = loadedModel.CanSubmit;
        //    model.SubSpecialtyList = loadedModel.SubSpecialtyList;
        //    model.SpecialtyList = loadedModel.SpecialtyList;
        //    model.QualificationTypeList = loadedModel.QualificationTypeList;
        //    model.ExactSpecialtyList = loadedModel.ExactSpecialtyList;


        //}


        //private void LoadModel(SalaryInfoModel model, string savedModel)
        //{
        //    var loadedModel = LoadSavedModel<SalaryInfoModel>(savedModel);
        //    if (loadedModel == null)
        //        return;

        //    model.PremiumList = loadedModel.PremiumList;
        //    model.EmployeePremiumList = loadedModel.EmployeePremiumList;
        //    model.BankList = loadedModel.BankList;
        //    model.CanSubmit = loadedModel.CanSubmit;
        //}
        private ActionResult Import(HttpPostedFileBase file)
        {
            var fileName = "";
            var path = "";

            if (file != null && file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);

                if (fileName == null)
                {
                    HumanResource.Message = "FileNotFound";
                    return View("Index");
                }

                path = Path.Combine(Server.MapPath("~/Tempfiles/"), fileName);
                file.SaveAs(path);
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                HumanResource.Message = "file not uploaded";
                return View("Index");
            }
            var succeed = false;
            var dicDegree = new Dictionary<string, int>
            {
                {"لايوجد",0},
                {"و - الاولى",1},
                {"و - الثانية",2},
                {"و - الثالثة",3},
                {"و - الرابعة",4},
                {"و - الخامسة",5},
                {"و - السادسة",6},
                {"و - السابعة",7},
                {"و - الثامنة",8},
                {"و - التاسعة",9},
                {"و - العاشرة",10},
                {"و - الحادية عشر",11},
                {"و - الثانية عشر",12},
                {"و - الثالثة عشر",13},
                {"و - الرابعة عشر",14},
                {"هـ قضائية - السابعة",7},
                {"هـ قضائية - التاسعة",9},
                {"هـ قضائية - العاشرة أ",101},
                {"هـ قضائية - العاشرة ب",102},
                {"هـ قضائية - الحادية عشر",11},
                {"هـ قضائية - الثانية عشر",12},
                {"هـ قضائية - الثالثة عشر أ",131},
                {"هـ قضائية - الثالثة عشر ب",132},
                {"هـ قضائية - الرابعة عشر أ",141},
                {"هـ قضائية - الرابعة عشر ب",142},
            };

            using (var xlPackage = new ExcelPackage(new FileInfo(path)))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                var totalRows = 3180;// myWorksheet.Dimension.End.Row;
                //var totalColumns = myWorksheet.Dimension.End.Column;
                var beginRow = 3174;
                var employeeId = 0;
                var employeeName = "";
                var bankBranchId = 0;
                var salayClassification = SalayClassification.Default;

                for (var rowNum = beginRow; rowNum < totalRows; rowNum++) //selet starting row here
                {
                    var nationalNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.A]?.Value?.ToString();
                    var fileNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.C]?.Value?.ToString();
                    var degree = myWorksheet.Cells[rowNum, (int)ExcelColumnType.E]?.Value?.ToString();
                    int boun;
                    int.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.F]?.Value?.ToString(), out boun);
                    var bank = myWorksheet.Cells[rowNum, (int)ExcelColumnType.G]?.Value?.ToString();
                    var bondNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.H]?.Value?.ToString();
                    decimal basicSalary;
                    decimal.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.J]?.Value?.ToString(), out basicSalary);
                    //=================
                    var oldJobNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AG]?.Value?.ToString();
                    var fullName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AI]?.Value?.ToString();
                    //====date start
                    //double birthDateNumber;
                    //double.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.AJ]?.Value?.ToString(), out birthDateNumber);
                    //if (birthDateNumber > 59) birthDateNumber -= 1; //Excel/Lotus 2/29/1900    
                    //var birthDate = new DateTime(1899, 12, 31).AddDays(birthDateNumber);
                    DateTime birthDateNumber;
                    DateTime.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.AJ]?.Value?.ToString(), out birthDateNumber);
                    //var birthDate = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AJ]?.Value?.ToString();
                    //====date end
                    var birthPlace = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AK]?.Value?.ToString();
                    var motherName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AL]?.Value?.ToString();
                    var gender = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AM]?.Value?.ToString();
                    var socialStatus = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AN]?.Value?.ToString();
                    int childCount;
                    int.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.F]?.Value?.ToString(), out childCount);
                    var nationalty = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AP]?.Value?.ToString();
                    var nationaltyPartner = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AQ]?.Value?.ToString();
                    var yaol = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AR]?.Value?.ToString();
                    var blodType = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AS]?.Value?.ToString();
                    //==================
                    var qualificationTypeName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AW]?.Value?.ToString();
                    var nameDonorFoundation = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AX]?.Value?.ToString();
                    //====date start
                    DateTime graduationDateNumber;
                    DateTime.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.AY]?.Value?.ToString(), out graduationDateNumber);
                    // if (graduationDateNumber > 59) graduationDateNumber -= 1; //Excel/Lotus 2/29/1900    
                    var graduationDate = graduationDateNumber;// new DateTime(1899, 12, 31).AddDays(graduationDateNumber);
                    //====date end
                    var grade = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AZ]?.Value?.ToString();
                    var graduationCountry = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BA]?.Value?.ToString();
                    var specialtyName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BB]?.Value?.ToString();
                    var subSpecialtyName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BC]?.Value?.ToString();
                    var exactSpecialtyName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BD]?.Value?.ToString();
                    var aquiredSpecialtyName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BE]?.Value?.ToString();
                    //=====================
                    var adjective = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BI]?.Value?.ToString();
                    var currentSituationName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BJ]?.Value?.ToString();
                    var jobType = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BK]?.Value?.ToString();
                    var decisionNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BL]?.Value?.ToString();
                    //====date start
                    DateTime decisionDateNumber;
                    DateTime.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.BM]?.Value?.ToString(), out decisionDateNumber);
                    //if (decisionDateNumber > 59) decisionDateNumber -= 1; //Excel/Lotus 2/29/1900    
                    var decisionDate = decisionDateNumber;// new DateTime(1899, 12, 31).AddDays(decisionDateNumber);
                    //====date end
                    int degreeInQarar;
                    int.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.BN]?.Value?.ToString(), out degreeInQarar);
                    //====date start
                    DateTime directionDateNumber;
                    DateTime.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.BO]?.Value?.ToString(), out directionDateNumber);
                    //if (directionDateNumber > 59) directionDateNumber -= 1; //Excel/Lotus 2/29/1900    
                    var directionDate = directionDateNumber;// new DateTime(1899, 12, 31).AddDays(directionDateNumber);
                    //====date end
                    var orqazinationQrarr = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BP]?.Value?.ToString();
                    DateTime contractEndDateValue;
                    DateTime.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.BR]?.Value?.ToString(), out contractEndDateValue);
                    var contractEndDate = contractEndDateValue;
                    var healthStatus = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BS]?.Value?.ToString();
                    int lastDegree;
                    int.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.BT]?.Value?.ToString(), out lastDegree);
                    int degreesNow;
                    int.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.BU]?.Value?.ToString(), out degreesNow);
                    //====date start
                    DateTime dgreeNowDateNumber;
                    DateTime.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.BO]?.Value?.ToString(), out dgreeNowDateNumber);
                    // if (dgreeNowDateNumber > 59) dgreeNowDateNumber -= 1; //Excel/Lotus 2/29/1900    
                    var dgreeNowDate = dgreeNowDateNumber;// new DateTime(1899, 12, 31).AddDays(dgreeNowDateNumber);
                    //====date end
                    var lastDegreeQararNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BW]?.Value?.ToString();
                    //====date start
                    DateTime dateMeritBounNowNumber;
                    DateTime.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.BX]?.Value?.ToString(), out dateMeritBounNowNumber);
                    //if (dateMeritBounNowNumber > 59) dateMeritBounNowNumber -= 1; //Excel/Lotus 2/29/1900    
                    var dateMeritBounNow = dateMeritBounNowNumber;// new DateTime(1899, 12, 31).AddDays(dateMeritBounNowNumber);
                    //====date end
                    var classificationOnSearchingName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BY]?.Value?.ToString();
                    var classificationOnWorkName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.BZ]?.Value?.ToString();
                    int vacationBalanc;
                    int.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.CA]?.Value?.ToString(), out vacationBalanc);
                    //====date start
                    DateTime vacationLastDateNumber;
                    DateTime.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.CB]?.Value?.ToString(), out vacationLastDateNumber);
                    //if (vacationLastDateNumber > 59) vacationLastDateNumber -= 1; //Excel/Lotus 2/29/1900    
                    var vacationLastDate = vacationLastDateNumber;// new DateTime(1899, 12, 31).AddDays(vacationLastDateNumber);
                    //====date end
                    var currentClassification = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CC]?.Value?.ToString();
                    var inNadb = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CD]?.Value?.ToString();
                    var inDerasa = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CE]?.Value?.ToString();
                    //================
                    var centerName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CH]?.Value?.ToString();
                    var departmentName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CI]?.Value?.ToString();
                    var divisionName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CJ]?.Value?.ToString();
                    var unitName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CK]?.Value?.ToString();
                    //var stateEmployee = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CL]?.Value?.ToString();
                    //==================
                    //var branchOrPlace = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CP]?.Value?.ToString();
                    var address = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CP]?.Value?.ToString();
                    var contactInfoNearPoint = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CQ]?.Value?.ToString();
                    var phone = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CR]?.Value?.ToString();
                    var email = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CS]?.Value?.ToString();
                    //var address = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CS]?.Value?.ToString();
                    var contactInfoNearKindr = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CT]?.Value?.ToString();
                    var contactInfoRelativeRelation = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CU]?.Value?.ToString();
                    var contactInfoPhone = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CV]?.Value?.ToString();
                    var contactInfoAddress = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CW]?.Value?.ToString();
                    var contactInfoWorkAddress = myWorksheet.Cells[rowNum, (int)ExcelColumnType.CX]?.Value?.ToString();
                    //==================
                    var passportNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.DB]?.Value?.ToString();
                    var passportAutoNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.DC]?.Value?.ToString();
                    //====date start
                    DateTime passportIssueDateNumber;
                    DateTime.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.BX]?.Value?.ToString(), out passportIssueDateNumber);
                    //if (passportIssueDateNumber > 59) passportIssueDateNumber -= 1; //Excel/Lotus 2/29/1900    
                    var passportIssueDate = passportIssueDateNumber;// new DateTime(1899, 12, 31).AddDays(passportIssueDateNumber);
                    //====date end
                    var passportIssuePlace = myWorksheet.Cells[rowNum, (int)ExcelColumnType.DE]?.Value?.ToString();
                    //====date start
                    DateTime passportExpirationDateNumber;
                    DateTime.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.BX]?.Value?.ToString(), out passportExpirationDateNumber);
                    //if (passportExpirationDateNumber > 59) passportExpirationDateNumber -= 1; //Excel/Lotus 2/29/1900    
                    var passportExpirationDate = passportExpirationDateNumber;// new DateTime(1899, 12, 31).AddDays(passportExpirationDateNumber);
                    //====date end
                    //==================
                    var bookletNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.DJ]?.Value?.ToString();
                    var bookletRegistrationNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.DK]?.Value?.ToString();
                    var bookletFamilyNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.DL]?.Value?.ToString();
                    //====date start
                    DateTime bookletIssueDateNumber;
                    DateTime.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.BX]?.Value?.ToString(), out bookletIssueDateNumber);
                    //if (bookletIssueDateNumber > 59) bookletIssueDateNumber -= 1; //Excel/Lotus 2/29/1900    
                    var bookletIssueDate = bookletIssueDateNumber;// new DateTime(1899, 12, 31).AddDays(bookletIssueDateNumber);
                    //====date end
                    var bookletIssuePlace = myWorksheet.Cells[rowNum, (int)ExcelColumnType.DN]?.Value?.ToString();
                    var bookletCivilRegistry = myWorksheet.Cells[rowNum, (int)ExcelColumnType.DO]?.Value?.ToString();
                    ////================== start old
                    ////================== start old
                    //var financialNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.B]?.Value?.ToString();
                    //var fullName = myWorksheet.Cells[rowNum, (int)ExcelColumnType.C]?.Value?.ToString();
                    //var nationalNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.D]?.Value?.ToString();
                    //var degree = myWorksheet.Cells[rowNum, (int)ExcelColumnType.E]?.Value?.ToString();
                    //int boun;
                    //int.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.F]?.Value?.ToString(), out boun);
                    //var bank = myWorksheet.Cells[rowNum, (int)ExcelColumnType.G]?.Value?.ToString();
                    //var bondNumber = myWorksheet.Cells[rowNum, (int)ExcelColumnType.H]?.Value?.ToString();
                    //var monthDate = myWorksheet.Cells[rowNum, (int)ExcelColumnType.J]?.Value?.ToString();
                    //decimal basicSalary;
                    //decimal.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.K]?.Value?.ToString(), out basicSalary);
                    //decimal extraWork;
                    //decimal.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.L]?.Value?.ToString(), out extraWork);
                    //decimal ration;
                    //decimal.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.M]?.Value?.ToString(), out ration);
                    //decimal extraGeneralValue;
                    //decimal.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.N]?.Value?.ToString(), out extraGeneralValue);
                    //decimal delegation;
                    //decimal.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.O]?.Value?.ToString(), out delegation);
                    ////var extraWork = myWorksheet.Cells[rowNum, (int)ExcelColumnType.P]?.Value?.ToString();
                    ////var reward = myWorksheet.Cells[rowNum, (int)ExcelColumnType.Q]?.Value?.ToString();
                    //var totalSalary = myWorksheet.Cells[rowNum, (int)ExcelColumnType.R]?.Value?.ToString();
                    //var solidarityFund = myWorksheet.Cells[rowNum, (int)ExcelColumnType.S]?.Value?.ToString();
                    ////var extraWork = myWorksheet.Cells[rowNum, (int)ExcelColumnType.T]?.Value?.ToString();
                    ////var extraWork = myWorksheet.Cells[rowNum, (int)ExcelColumnType.U]?.Value?.ToString();
                    ////var extraWork = myWorksheet.Cells[rowNum, (int)ExcelColumnType.V]?.Value?.ToString();
                    //decimal absence;
                    //decimal.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.W]?.Value?.ToString(), out absence);
                    //decimal sanction;
                    //decimal.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.X]?.Value?.ToString(), out sanction);
                    ////var extraWork = myWorksheet.Cells[rowNum, (int)ExcelColumnType.Y]?.Value?.ToString();
                    ////var extraWork = myWorksheet.Cells[rowNum, (int)ExcelColumnType.Z]?.Value?.ToString();
                    //decimal mawada;
                    //decimal.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.AA]?.Value?.ToString(), out mawada);
                    ////var extraWork = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AB]?.Value?.ToString();
                    ////var extraWork = myWorksheet.Cells[rowNum, (int)ExcelColumnType.AC]?.Value?.ToString();
                    //decimal otherDiscount;
                    //decimal.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.AD]?.Value?.ToString(), out otherDiscount);
                    //double directionDateNumber;
                    //double.TryParse(myWorksheet.Cells[rowNum, (int)ExcelColumnType.AG]?.Value?.ToString(), out directionDateNumber);
                    ////================================== get monthDate
                    //if (directionDateNumber > 59) directionDateNumber -= 1; //Excel/Lotus 2/29/1900    
                    //var directionDate = new DateTime(1899, 12, 31).AddDays(directionDateNumber);
                    ////========================= end Old
                    ////========================= end Old
                    //var month = monthDate.Substring(4, 2);
                    //var year = monthDate.Substring(0, 4);
                    //var day = 1;
                    //var dateSalary = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), day);
                    var bloodType = new BloodType();
                    switch (blodType)
                    {
                        case "A-":
                            bloodType = BloodType.AMinus;
                            break;
                        case "A+":
                            bloodType = BloodType.APlus;
                            break;
                        case "AB-":
                            bloodType = BloodType.AbMinus;
                            break;
                        case "AB+":
                            bloodType = BloodType.AbPlus;
                            break;
                        case "B-":
                            bloodType = BloodType.BMinus;
                            break;
                        case "B+":
                            bloodType = BloodType.BPlus;
                            break;
                        case "O-":
                            bloodType = BloodType.OMinus;
                            break;
                        case "O+":
                            bloodType = BloodType.OPlus;
                            break;
                        default:
                            bloodType = BloodType.Unknown;
                            break;
                    }
                    var socialStatusEnter = new SocialStatus();
                    switch (socialStatus)
                    {
                        case "متزوج":
                        case "متزوجة":
                            if (yaol == "تعول" || yaol == "يعول")
                                socialStatusEnter = SocialStatus.MarridAndNurture;
                            else
                                socialStatusEnter = SocialStatus.Marrid;
                            break;
                        case "أعزب":
                        case "عزباء":
                            socialStatusEnter = SocialStatus.Single;
                            break;
                        case "أرملة":
                        case "أرمل":
                            if (yaol == "تعول" || yaol == "يعول")
                                socialStatusEnter = SocialStatus.WidowerAndNurture;
                            else
                                socialStatusEnter = SocialStatus.Widower;
                            break;
                        case "مطلقة":
                        case "مطلق":
                            if (yaol == "تعول" || yaol == "يعول")
                                socialStatusEnter = SocialStatus.DivorceeAndNurture;
                            else
                                socialStatusEnter = SocialStatus.Divorcee;
                            break;

                        default:
                            socialStatusEnter = SocialStatus.Unknown;
                            break;
                    }
                    if (employeeName != fullName)
                    {
                        //================================== 
                        //================================== get degree
                        var degreeNow = 0;
                        var clampDegreeNow = 0;
                        if (degree != null)
                        {
                            var degrees = degree.Split('-');
                            var degreeType = "";
                            for (var i = 0; i < degrees.Count(); i++)
                            {
                                if (i == 0)
                                {
                                    degreeType = degrees[0];
                                }
                            }
                            salayClassification = degreeType == "هـ قضائية "
                                ? SalayClassification.Clamp
                                : SalayClassification.Default;

                            if (salayClassification == SalayClassification.Clamp)
                                clampDegreeNow = dicDegree[degree];
                            else
                                degreeNow = dicDegree[degree];
                        }
                        //==================================
                        //================================== get bank
                        var bankId = 0;
                        var bankName = "";
                        var bankBranchName = "";
                        if (bank != null)
                        {
                            var banks = bank.Split('/');
                            for (var i = 0; i < banks.Count(); i++)
                            {
                                if (i == 0)
                                {
                                    bankName = banks[0];
                                }

                                if (i == 1)
                                {
                                    bankBranchName = banks[1];
                                }
                            }
                            if (bankName == "الجمهوريه")
                                bankName = "الجمهورية";
                            if (bankName == "التجارى")
                                bankName = "التجاري";
                            if (bankName == "الوحده")
                                bankName = "الوحدة";
                            if (bankName == "الصحارى")
                                bankName = "الصحاري";
                        }
                        var bankModel = new BankModel()
                        {
                            Name = bankName
                        };
                        if (HumanResource.Bank.Prepare().BankGrid.Any(e => e.Name.Contains(bankName)))
                        {
                            bankId = HumanResource.Bank.Prepare()
                                .BankGrid.FirstOrDefault(e => e.Name.Contains(bankName)).BankId;
                        }
                        else if (HumanResource.Bank.Create(bankModel))
                        {
                            bankId = HumanResource.Bank.Prepare()
                                .BankGrid.FirstOrDefault(e => e.Name.Contains(bankName)).BankId;
                        }
                        else
                        {
                            var message = HumanResource.Message;
                            throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        }
                        var bankBranchModel = new BankBranchModel()
                        {
                            Name = bankBranchName,
                            BankId = bankId
                        };
                        var modelBankBranch = HumanResource.BankBranch.Prepare();
                        if (modelBankBranch.BankBranchGrid.Any(e => e.Name.Contains(bankBranchName) && e.BankId == bankId))
                        {
                            bankBranchId = modelBankBranch
                                .BankBranchGrid.FirstOrDefault(e => e.Name.Contains(bankBranchName)
                                && e.BankId == bankId).BankBranchId;
                        }
                        else if (HumanResource.BankBranch.Create(bankBranchModel))
                        {
                            bankBranchId = modelBankBranch
                                .BankBranchGrid.FirstOrDefault(e => e.Name.Contains(bankBranchName)
                                && e.BankId == bankId).BankBranchId;
                        }
                        else
                        {
                            var message = HumanResource.Message;
                            throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        }
                        //==================================
                        //==================================
                        var centerId = 0;
                        var departmentId = 0;
                        var divisionId = 0;
                        var unitId = 0;
                        //var centerName = "";
                        //var departmentName = "";
                        //var divisionName = "";
                        //var unitName = "";
                        if (centerName == null)
                        {
                            centerName = "0";
                        }
                        var centerModel = new CenterModel()
                        {
                            Name = centerName
                        };
                        if (HumanResource.Center.Prepare().CenterGrid.Any(e => e.Name.Contains(centerName)))
                        {
                            centerId = HumanResource.Center.Prepare()
                                .CenterGrid.FirstOrDefault(e => e.Name.Contains(centerName)).CenterId;
                        }
                        else if (HumanResource.Center.Create(centerModel))
                        {
                            centerId = HumanResource.Center.Prepare()
                                .CenterGrid.FirstOrDefault(e => e.Name.Contains(centerName)).CenterId;
                        }
                        else
                        {
                            var message = HumanResource.Message;
                            throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        }
                        //===========================================
                        if (departmentName == null)
                        {
                            departmentName = centerName + "1";
                        }
                        var departmentModel = new DepartmentModel()
                        {
                            Name = departmentName,
                            CenterId = centerId
                        };
                        var modelDepartment = HumanResource.Department.Prepare();
                        if (modelDepartment.DepartmentGrid.Any(e => e.Name.Contains(departmentName) && e.CenterId == centerId))
                        {
                            departmentId = modelDepartment
                                .DepartmentGrid.FirstOrDefault(e => e.Name.Contains(departmentName)
                                && e.CenterId == centerId).DepartmentId;
                        }
                        else if (HumanResource.Department.Create(departmentModel))
                        {
                            departmentId = modelDepartment
                                .DepartmentGrid.FirstOrDefault(e => e.Name.Contains(departmentName)
                                && e.CenterId == centerId).DepartmentId;
                        }
                        else
                        {
                            var message = HumanResource.Message;
                            throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        }
                        //===========================================
                        if (divisionName == null || divisionName == " " || divisionName == "")
                        {
                            divisionName = departmentName + "2";
                        }

                        var divisionModel = new DivisionModel()
                        {
                            Name = divisionName,
                            DepartmentId = departmentId,
                            CenterId = centerId
                        };
                        var modelDivision = HumanResource.Division.Prepare();
                        if (modelDivision.DivisionGrid.Any(e => e.Name.Contains(divisionName) && e.DepartmentId == departmentId))
                        {
                            divisionId = modelDivision
                                .DivisionGrid.FirstOrDefault(e => e.Name.Contains(divisionName)
                                && e.DepartmentId == departmentId).DivisionId;
                        }
                        else if (HumanResource.Division.Create(divisionModel))
                        {
                            divisionId = modelDivision
                                .DivisionGrid.FirstOrDefault(e => e.Name.Contains(divisionName)
                                && e.DepartmentId == departmentId).DivisionId;
                        }
                        else
                        {
                            var message = HumanResource.Message;
                            throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        }
                        //===========================================
                        if (unitName == null)
                        {
                            unitName = divisionName + "3";
                        }
                        var unitModel = new UnitModel()
                        {
                            Name = unitName,
                            DivisionId = divisionId,
                            DepartmentId = departmentId,
                            CenterId = centerId
                        };
                        var modelUnit = HumanResource.Unit.Prepare();
                        if (modelUnit.UnitGrid.Any(e => e.Name.Contains(unitName) && e.DivisionId == divisionId))
                        {
                            unitId = modelUnit
                                .UnitGrid.FirstOrDefault(e => e.Name.Contains(unitName)
                                && e.DivisionId == divisionId).UnitId;
                        }
                        else if (HumanResource.Unit.Create(unitModel))
                        {
                            unitId = modelUnit
                                .UnitGrid.FirstOrDefault(e => e.Name.Contains(unitName)
                                && e.DivisionId == divisionId).UnitId;
                        }
                        else
                        {
                            var message = HumanResource.Message;
                            throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        }
                        //==================================
                        //==================================
                        var SpecialtyId = 0;
                        var SubSpecialtyId = 0;
                        var ExactSpecialtyId = 0;
                        if (specialtyName != null)
                        {
                            var SpecialtyModel = new SpecialtyModel()
                            {
                                Name = specialtyName
                            };
                            if (HumanResource.Specialty.Prepare().SpecialtyGrid.Any(e => e.Name.Contains(specialtyName)))
                            {
                                SpecialtyId = HumanResource.Specialty.Prepare()
                                    .SpecialtyGrid.FirstOrDefault(e => e.Name.Contains(specialtyName)).SpecialtyId;
                            }
                            else if (HumanResource.Specialty.Create(SpecialtyModel))
                            {
                                SpecialtyId = HumanResource.Specialty.Prepare()
                                    .SpecialtyGrid.FirstOrDefault(e => e.Name.Contains(specialtyName)).SpecialtyId;
                            }
                            else
                            {
                                var message = HumanResource.Message;
                                throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                            }
                            //===========================================
                            if (subSpecialtyName == null)
                            {
                                subSpecialtyName = "غير معروف";
                            }
                            var SubSpecialtyModel = new SubSpecialtyModel()
                            {
                                Name = subSpecialtyName,
                                SpecialtyId = SpecialtyId
                            };
                            var modelSubSpecialty = HumanResource.SubSpecialty.Prepare();
                            if (modelSubSpecialty.SubSpecialtyGrid.Any(e => e.Name.Contains(subSpecialtyName) && e.SpecialtyId == SpecialtyId))
                            {
                                SubSpecialtyId = modelSubSpecialty
                                    .SubSpecialtyGrid.FirstOrDefault(e => e.Name.Contains(subSpecialtyName)
                                                                          && e.SpecialtyId == SpecialtyId).SubSpecialtyId;
                            }
                            else if (HumanResource.SubSpecialty.Create(SubSpecialtyModel))
                            {
                                SubSpecialtyId = modelSubSpecialty
                                    .SubSpecialtyGrid.FirstOrDefault(e => e.Name.Contains(subSpecialtyName)
                                                                          && e.SpecialtyId == SpecialtyId).SubSpecialtyId;
                            }
                            else
                            {
                                var message = HumanResource.Message;
                                throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                            }
                            //===========================================
                            if (exactSpecialtyName == null)
                            {
                                exactSpecialtyName = "غير معروف";
                            }

                            var ExactSpecialtyModel = new ExactSpecialtyModel()
                            {
                                Name = exactSpecialtyName,
                                SubSpecialtyId = SubSpecialtyId,
                                SpecialtyId = SpecialtyId
                            };
                            var modelExactSpecialty = HumanResource.ExactSpecialty.Prepare();
                            if (modelExactSpecialty.ExactSpecialtyGrid.Any(e => e.Name.Contains(exactSpecialtyName) && e.SubSpecialtyId == SubSpecialtyId))
                            {
                                ExactSpecialtyId = modelExactSpecialty
                                    .ExactSpecialtyGrid.FirstOrDefault(e => e.Name.Contains(exactSpecialtyName)
                                                                            && e.SubSpecialtyId == SubSpecialtyId).ExactSpecialtyId;
                            }
                            else if (HumanResource.ExactSpecialty.Create(ExactSpecialtyModel))
                            {
                                ExactSpecialtyId = modelExactSpecialty
                                    .ExactSpecialtyGrid.FirstOrDefault(e => e.Name.Contains(exactSpecialtyName)
                                                                            && e.SubSpecialtyId == SubSpecialtyId).ExactSpecialtyId;
                            }
                            else
                            {
                                var message = HumanResource.Message;
                                throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                            }

                        }
                        //===========================================
                        //================================== get names
                        var names = fullName.Split(' ');
                        var remaining = fullName.Split(' ').ToList();
                        var firstName = "";
                        var fatherName = "";
                        var grandfatherName = "";
                        var lastName = "";
                        for (var i = 0; i < names.Count(); i++)
                        {
                            if (i == 0)
                            {
                                firstName = names[0];
                                remaining.RemoveAt(0);
                            }

                            if (i == 1)
                            {
                                fatherName = names[1];
                                remaining.RemoveAt(0);
                            }

                            if (i == 2)
                            {
                                grandfatherName = names[2];
                                remaining.RemoveAt(0);
                            }

                            if (i == 3)
                            {
                                lastName = string.Join(" ", remaining);
                            }
                            if (string.IsNullOrWhiteSpace(grandfatherName))
                                grandfatherName = "غير موجود";
                            if (string.IsNullOrWhiteSpace(lastName))
                                lastName = "غير موجود";
                        }
                        //==================================
                        int? currentSituationId = 0;
                        if (currentSituationName != null)
                        {
                            var CurrentSituationModel = new CurrentSituationModel()
                            {
                                Name = currentSituationName
                            };
                            if (HumanResource.CurrentSituation.Prepare().CurrentSituationGrid.Any(e => e.Name.Contains(currentSituationName)))
                            {
                                currentSituationId = HumanResource.CurrentSituation.Prepare()
                                    .CurrentSituationGrid.FirstOrDefault(e => e.Name.Contains(currentSituationName)).CurrentSituationId;
                            }
                            else if (HumanResource.CurrentSituation.Create(CurrentSituationModel))
                            {
                                currentSituationId = HumanResource.CurrentSituation.Prepare()
                                    .CurrentSituationGrid.FirstOrDefault(e => e.Name.Contains(currentSituationName)).CurrentSituationId;
                            }
                            else
                            {
                                var message = HumanResource.Message;
                                throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                            }
                        }
                        //==================================
                        //var JobId = 0;
                        //var JobModel = new JobModel()
                        //{
                        //    Name = JobName
                        //};
                        //if (HumanResource.Job.Prepare().JobGrid.Any(e => e.Name.Contains(JobName)))
                        //{
                        //    JobId = HumanResource.Job.Prepare()
                        //        .JobGrid.FirstOrDefault(e => e.Name.Contains(JobName)).JobId;
                        //}
                        //else if (HumanResource.Job.Create(JobModel))
                        //{
                        //    JobId = HumanResource.Job.Prepare()
                        //        .JobGrid.FirstOrDefault(e => e.Name.Contains(JobName)).JobId;
                        //}
                        //else
                        //{
                        //    var message = HumanResource.Message;
                        //    throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        //}

                        //==================================
                        //==================================
                        int? ClassificationOnSearchingId = 0;
                        if (classificationOnSearchingName != null)
                        {
                            var ClassificationOnSearchingModel = new ClassificationOnSearchingModel()
                            {
                                Name = classificationOnSearchingName
                            };
                            if (HumanResource.ClassificationOnSearching.Prepare().Grid.Any(e => e.Name.Contains(classificationOnSearchingName)))
                            {
                                ClassificationOnSearchingId = HumanResource.ClassificationOnSearching.Prepare()
                                    .Grid.FirstOrDefault(e => e.Name.Contains(classificationOnSearchingName)).ClassificationOnSearchingId;
                            }
                            else if (HumanResource.ClassificationOnSearching.Create(ClassificationOnSearchingModel))
                            {
                                ClassificationOnSearchingId = HumanResource.ClassificationOnSearching.Prepare()
                                    .Grid.FirstOrDefault(e => e.Name.Contains(classificationOnSearchingName)).ClassificationOnSearchingId;
                            }
                            else
                            {
                                var message = HumanResource.Message;
                                throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                            }
                        }
                        //==================================
                        //==================================
                        int? ClassificationOnWorkId = 0;
                        if (classificationOnWorkName != null)
                        {
                            var ClassificationOnWorkModel = new ClassificationOnWorkModel()
                            {
                                Name = classificationOnWorkName
                            };
                            if (HumanResource.ClassificationOnWork.Prepare().Grid.Any(e => e.Name.Contains(classificationOnWorkName)))
                            {
                                ClassificationOnWorkId = HumanResource.ClassificationOnWork.Prepare()
                                    .Grid.FirstOrDefault(e => e.Name.Contains(classificationOnWorkName)).ClassificationOnWorkId;
                            }
                            else if (HumanResource.ClassificationOnWork.Create(ClassificationOnWorkModel))
                            {
                                ClassificationOnWorkId = HumanResource.ClassificationOnWork.Prepare()
                                    .Grid.FirstOrDefault(e => e.Name.Contains(classificationOnWorkName)).ClassificationOnWorkId;
                            }
                            else
                            {
                                var message = HumanResource.Message;
                                throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                            }
                        }
                        //==================================
                        //==================================
                        //var AdjectiveEmployeeTypeId = 0;
                        //var AdjectiveEmployeeId = 0;

                        //var AdjectiveEmployeeTypeModel = new AdjectiveEmployeeTypeModel()
                        //{
                        //    Name = AdjectiveEmployeeTypeName
                        //};
                        //if (HumanResource.AdjectiveEmployeeType.Prepare().AdjectiveEmployeeTypeGrid.Any(e => e.Name.Contains(AdjectiveEmployeeTypeName)))
                        //{
                        //    AdjectiveEmployeeTypeId = HumanResource.AdjectiveEmployeeType.Prepare()
                        //        .AdjectiveEmployeeTypeGrid.FirstOrDefault(e => e.Name.Contains(AdjectiveEmployeeTypeName)).AdjectiveEmployeeTypeId;
                        //}
                        //else if (HumanResource.AdjectiveEmployeeType.Create(AdjectiveEmployeeTypeModel))
                        //{
                        //    AdjectiveEmployeeTypeId = HumanResource.AdjectiveEmployeeType.Prepare()
                        //        .AdjectiveEmployeeTypeGrid.FirstOrDefault(e => e.Name.Contains(AdjectiveEmployeeTypeName)).AdjectiveEmployeeTypeId;
                        //}
                        //else
                        //{
                        //    var message = HumanResource.Message;
                        //    throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        //}
                        ////===========================================
                        //if (AdjectiveEmployeeName == "")
                        //{
                        //    AdjectiveEmployeeName = AdjectiveEmployeeTypeName + "1";
                        //}
                        //var AdjectiveEmployeeModel = new AdjectiveEmployeeModel()
                        //{
                        //    Name = AdjectiveEmployeeName,
                        //    AdjectiveEmployeeTypeId = AdjectiveEmployeeTypeId
                        //};
                        //var modelAdjectiveEmployee = HumanResource.AdjectiveEmployee.Prepare();
                        //if (modelAdjectiveEmployee.AdjectiveEmployeeGrid.Any(e => e.Name.Contains(AdjectiveEmployeeName) && e.AdjectiveEmployeeTypeId == AdjectiveEmployeeTypeId))
                        //{
                        //    AdjectiveEmployeeId = modelAdjectiveEmployee
                        //        .AdjectiveEmployeeGrid.FirstOrDefault(e => e.Name.Contains(AdjectiveEmployeeName)
                        //                                            && e.AdjectiveEmployeeTypeId == AdjectiveEmployeeTypeId).AdjectiveEmployeeId;
                        //}
                        //else if (HumanResource.AdjectiveEmployee.Create(AdjectiveEmployeeModel))
                        //{
                        //    AdjectiveEmployeeId = modelAdjectiveEmployee
                        //        .AdjectiveEmployeeGrid.FirstOrDefault(e => e.Name.Contains(AdjectiveEmployeeName)
                        //                                            && e.AdjectiveEmployeeTypeId == AdjectiveEmployeeTypeId).AdjectiveEmployeeId;
                        //}
                        //else
                        //{
                        //    var message = HumanResource.Message;
                        //    throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        //}
                        ////===========================================
                        ////==================================
                        //var StaffingTypeId = 0;
                        //var StaffingId = 0;

                        //var StaffingTypeModel = new StaffingTypeModel()
                        //{
                        //    Name = StaffingTypeName
                        //};
                        //if (HumanResource.StaffingType.Prepare().StaffingTypeGrid.Any(e => e.Name.Contains(StaffingTypeName)))
                        //{
                        //    StaffingTypeId = HumanResource.StaffingType.Prepare()
                        //        .StaffingTypeGrid.FirstOrDefault(e => e.Name.Contains(StaffingTypeName)).StaffingTypeId;
                        //}
                        //else if (HumanResource.StaffingType.Create(StaffingTypeModel))
                        //{
                        //    StaffingTypeId = HumanResource.StaffingType.Prepare()
                        //        .StaffingTypeGrid.FirstOrDefault(e => e.Name.Contains(StaffingTypeName)).StaffingTypeId;
                        //}
                        //else
                        //{
                        //    var message = HumanResource.Message;
                        //    throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        //}
                        ////===========================================
                        //if (StaffingName == "")
                        //{
                        //    StaffingName = StaffingTypeName + "1";
                        //}
                        //var StaffingModel = new StaffingModel()
                        //{
                        //    Name = StaffingName,
                        //    StaffingTypeId = StaffingTypeId
                        //};
                        //var modelStaffing = HumanResource.Staffing.Prepare();
                        //if (modelStaffing.StaffingGrid.Any(e => e.Name.Contains(StaffingName) && e.StaffingTypeId == StaffingTypeId))
                        //{
                        //    StaffingId = modelStaffing
                        //        .StaffingGrid.FirstOrDefault(e => e.Name.Contains(StaffingName)
                        //                                            && e.StaffingTypeId == StaffingTypeId).StaffingId;
                        //}
                        //else if (HumanResource.Staffing.Create(StaffingModel))
                        //{
                        //    StaffingId = modelStaffing
                        //        .StaffingGrid.FirstOrDefault(e => e.Name.Contains(StaffingName)
                        //                                            && e.StaffingTypeId == StaffingTypeId).StaffingId;
                        //}
                        //else
                        //{
                        //    var message = HumanResource.Message;
                        //    throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        //}
                        //===========================================
                        //==================================
                        //var BranchId = 0;
                        //var PlaceId = 0;

                        //var BranchModel = new BranchModel()
                        //{
                        //    Name = BranchName
                        //};
                        //if (HumanResource.Branch.Prepare().BranchGrid.Any(e => e.Name.Contains(BranchName)))
                        //{
                        //    BranchId = HumanResource.Branch.Prepare()
                        //        .BranchGrid.FirstOrDefault(e => e.Name.Contains(BranchName)).BranchId;
                        //}
                        //else if (HumanResource.Branch.Create(BranchModel))
                        //{
                        //    BranchId = HumanResource.Branch.Prepare()
                        //        .BranchGrid.FirstOrDefault(e => e.Name.Contains(BranchName)).BranchId;
                        //}
                        //else
                        //{
                        //    var message = HumanResource.Message;
                        //    throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        //}
                        //===========================================
                        //if (PlaceName == "")
                        //{
                        //    PlaceName = BranchName;
                        //}
                        //var PlaceModel = new PlaceModel()
                        //{
                        //    Name = PlaceName,
                        //    BranchId = BranchId
                        //};
                        //var modelPlace = HumanResource.Place.Prepare();
                        //if (modelPlace.PlaceGrid.Any(e => e.Name.Contains(PlaceName) && e.BranchId == BranchId))
                        //{
                        //    PlaceId = modelPlace
                        //        .PlaceGrid.FirstOrDefault(e => e.Name.Contains(PlaceName)
                        //                                            && e.BranchId == BranchId).PlaceId;
                        //}
                        //else if (HumanResource.Place.Create(PlaceModel))
                        //{
                        //    PlaceId = modelPlace
                        //        .PlaceGrid.FirstOrDefault(e => e.Name.Contains(PlaceName)
                        //                                            && e.BranchId == BranchId).PlaceId;
                        //}
                        //else
                        //{
                        //    var message = HumanResource.Message;
                        //    throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        //}
                        //===========================================
                        //===========================================
                        var bookletModel = new BookletModel()
                        {
                            Number = bookletNumber,
                            CivilRegistry = bookletCivilRegistry,
                            FamilyNumber = bookletFamilyNumber,
                            IssueDate = bookletIssueDate == new DateTime(0001, 01, 01)
                            ? new DateTime(1900, 01, 01).FormatToString() : bookletIssueDate.FormatToString(),
                            IssuePlace = bookletIssuePlace,
                            RegistrationNumber = bookletRegistrationNumber
                        };
                        //==================================
                        var passportModel = new PassportModel()
                        {
                            Number = passportNumber,
                            IssuePlace = passportIssuePlace,
                            IssueDate = passportIssueDate == new DateTime(0001, 01, 01)
                            ? new DateTime(1900, 01, 01).FormatToString() : passportIssueDate.FormatToString(),
                            AutoNumber = passportAutoNumber,
                            ExpirationDate = passportExpirationDate == new DateTime(0001, 01, 01)
                            ? new DateTime(1900, 01, 01).FormatToString() : passportExpirationDate.FormatToString(),
                        };
                        //==================================
                        var contactInfoModel = new ContactInfoModel()
                        {
                            Address = contactInfoAddress,
                            NearKindr = contactInfoNearKindr,
                            NearPoint = contactInfoNearPoint,
                            Phone = contactInfoPhone,
                            RelativeRelation = contactInfoRelativeRelation,
                            WorkAddress = contactInfoWorkAddress,
                        };
                        //==================================
                        var identificationCardModel = new IdentificationCardModel()
                        {
                            //Number = ,
                            //IssuePlace = ,
                            //IssueDate = 
                        };
                        //==================================
                        var personalModel = new PersonalModel()
                        {
                            FirstName = firstName,
                            FatherName = fatherName,
                            GrandfatherName = grandfatherName,
                            LastName = lastName,
                            NationalNumber = nationalNumber,
                            //BranchId = 1,
                            //PlaceId = 1,
                            BirthDate = birthDateNumber == new DateTime(0001, 01, 01)
                            ? new DateTime(1900, 01, 01).FormatToString() : birthDateNumber.FormatToString(),
                            BirthPlace = birthPlace,
                            Booklet = bookletModel,
                            Passport = passportModel,
                            ContactInfo = contactInfoModel,
                            IdentificationCard = identificationCardModel,
                            LibyanOrForeigner = LibyanOrForeigner.Libyan,
                            Address = address,
                            Phone = phone,
                            BloodType = bloodType,
                            ChildernCount = childCount,
                            Email = email,
                            Gender = gender == "ذكر" ? Gender.Male : Gender.Female,
                            MotherName = motherName,
                            Religion = Religion.Muslim,
                            SocialStatus = socialStatusEnter,
                        };
                        var modelEmployee = HumanResource.Employee.Index();
                        if (modelEmployee.EmployeeGrid.Any(e => e.ArabicFullName.Contains(fullName)))
                        {
                            employeeId = modelEmployee
                                .EmployeeGrid.FirstOrDefault(e => e.ArabicFullName.Contains(fullName)).EmployeeId;
                        }
                        else if (HumanResource.Employee.Create(personalModel))
                        {
                            employeeId = modelEmployee
                                .EmployeeGrid.FirstOrDefault(e => e.ArabicFullName.Contains(fullName)).EmployeeId;
                        }
                        else
                        {
                            var message = HumanResource.Message;
                            throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        }

                        //===================================
                        var employmentValuesModel = new EmploymentValuesModel()
                        {
                            //BenefitFromServicesDate = ,
                            //BenefitFromServicesSide = ,
                            //CollaboratorDate = ,
                            //CollaboratorSide = ,
                            ContractDateFrom = jobType == "عقد" ? null : directionDate == new DateTime(0001, 01, 01)
                            ? new DateTime(1970, 01, 01).FormatToString() : directionDate.FormatToString(),

                            ContractDateTo = jobType == "عقد" ? null : contractEndDate == new DateTime(0001, 01, 01)
                            ? new DateTime(1970, 01, 01).FormatToString() : contractEndDate.FormatToString(),

                            DesignationIssue = orqazinationQrarr,

                            DesignationResolutionDate = decisionDate == new DateTime(0001, 01, 01)
                            ? new DateTime(1970, 01, 01).FormatToString() : decisionDate.FormatToString(),
                            DesignationResolutionNumber = decisionNumber,
                            //EmptiedDate = ,
                            //EmptiedSide = ,
                            //LoaningDate = ,
                            //LoaningSide = ,
                            //TransferDate = ,
                            //TransferSide =
                        };
                        //===================================
                        var jobInfoModel = new JobInfoModel()
                        {
                            SalayClassification = salayClassification,
                            DegreeNow = degreeNow,
                            ClampDegreeNow = (ClampDegree?)clampDegreeNow,
                            Bouns = boun,
                            EmployeeId = employeeId,
                            //AdjectiveEmployeeId = 1,
                            //AdjectiveEmployeeTypeId = 1,
                            CenterId = centerId,
                            CurrentSituationId = currentSituationId == 0 ? null : currentSituationId,
                            DepartmentId = departmentId,
                            DivisionId = divisionId,
                            //JobId = 1,
                            //StaffingId = 1,
                            UnitId = unitId,
                            JobType = jobType == "عقد" ? JobType.Contract : jobType == "" ? 0 : JobType.Designation,
                            //StaffingTypeId = 1,
                            EmploymentValues = employmentValuesModel,
                            DirectlyDate = directionDate == new DateTime(0001, 01, 01)
                            ? new DateTime(1980, 01, 01).FormatToString() : directionDate.FormatToString(),
                            Adjective = adjective == "عسكري" ? Adjective.Soldier : Adjective.Civilian,
                            CurrentClassification = currentClassification,
                            HealthStatus = healthStatus,
                            OldJobNumber = oldJobNumber,
                            //CenterNumber = ,
                            JobNumber = 0,
                            Degree = lastDegree,
                            //ClampDegree = ,
                            ClassificationOnSearchingId = ClassificationOnSearchingId == 0 ? null : ClassificationOnSearchingId,
                            ClassificationOnWorkId = ClassificationOnWorkId == 0 ? null : ClassificationOnWorkId,
                            DateBouns = dateMeritBounNow == new DateTime(0001, 01, 01)
                            ? new DateTime(1980, 01, 01).FormatToString() : dateMeritBounNow.AddYears(-1).FormatToString(),
                            DateDegreeNow = dgreeNowDate == new DateTime(0001, 01, 01)
                            ? new DateTime(1980, 01, 01).FormatToString() : dgreeNowDate.FormatToString(),
                            DateMeritBouns = dateMeritBounNow == new DateTime(0001, 01, 01)
                            ? new DateTime(1980, 01, 01).FormatToString() : dateMeritBounNow.FormatToString(),
                            //DateMeritDegreeNow = ,
                            DegreeLastResolutionNumber = degreeInQarar,
                            //JobNumberApproved = ,
                            //Notes = ,
                            Redirection = Redirection.No,
                            RedirectionNote = "",
                            //SerialNumber = ,
                            VacationBalance = vacationBalanc
                        };
                        if (HumanResource.Employee.Find(employeeId).JobInfoModel != null)
                        {
                            if (!HumanResource.Employee.Edit(employeeId, jobInfoModel))
                            {
                                var message = HumanResource.Message;
                                throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                            }
                        }

                        //==================================
                        //var delegationPremiumId = HumanResource.Premium.Prepare().PremiumGrid
                        //    .FirstOrDefault(e => e.Name.Contains("علاوة ندب"))
                        //    .PremiumId;
                        var mawadaPremiumId = HumanResource.Premium.Prepare().PremiumGrid
                            .FirstOrDefault(e => e.Name.Contains("خصم المودة"))
                            .PremiumId;
                        //var otherDiscountPremiumId = HumanResource.Premium.Prepare().PremiumGrid
                        //    .FirstOrDefault(e => e.Name.Contains("خصميات اخرى"))
                        //    .PremiumId;
                        var employeePremiumList = new List<TemEmployeePremiumListItemEE>
                        {
                            //new EmployeePremiumListItem()
                            //{
                            //    PremiumId = delegationPremiumId,
                            //    Value = delegation
                            //},
                            new TemEmployeePremiumListItemEE()
                            {
                                PremiumId = mawadaPremiumId,
                                Value = -2
                            },
                            //new EmployeePremiumListItem()
                            //{
                            //    PremiumId = otherDiscountPremiumId,
                            //    Value = -otherDiscount
                            //}
                        };
                        var salaryInfoFormModel = new SalaryInfoFormModel()
                        {
                            BasicSalary = basicSalary,
                            BankBranchId = bankBranchId,
                            BankId = bankId,
                            BondNumber = bondNumber,
                            FileNumber = fileNumber,
                            EmployeeId = employeeId,
                            IsDesignation = true,
                            //FinancialNumber = financialNumber,
                            GuaranteeType = GuaranteeType.All,
                            TemEmployeePremiumListItem = employeePremiumList,
                            EmployeeName = fullName,
                            //ExtraGeneralValue = ,
                            //ExtraValue = ,
                            //SalayClassification = salayClassification,
                            //SecurityNumber = 
                        };
                        if (HumanResource.SalaryInfo.Index().SalaryInfoGrid.All(e => e.EmployeeId != employeeId))
                            continue;
                        if (!HumanResource.SalaryInfo.Save(employeeId, salaryInfoFormModel))
                        {
                            var message = HumanResource.Message;
                            throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                        }
                    }
                    //==================================
                    //var salaryFormModel = new SalaryFormModel()
                    //{
                    //    EmployeeId = employeeId,
                    //    AbsenceDays = (int)(absence * 30 / basicSalary),
                    //    MonthDate = dateSalary.FormatToString(),
                    //    BoundNumber = bondNumber,
                    //    FileNumber = fileNumber,
                    //    BasicSalary = basicSalary,
                    //    //AdvancePremiumInside = ,
                    //    //AdvancePremiumOutside = ,
                    //    Sanction = sanction,
                    //    BankBranchId = bankBranchId,
                    //    ExtraGeneralValue = salayClassification == SalayClassification.Default ?
                    //                extraGeneralValue : 0,
                    //    ExtraValue = salayClassification == SalayClassification.Clamp ?
                    //                extraGeneralValue : 0,
                    //};
                    ////if (HumanResource.OldSalary.Index().SalaryGrid.Any(e => e.EmployeeName.Contains(fullName)
                    ////        && e.MonthDate == dateSalary.FormatToString()))
                    ////    continue;
                    //if (!HumanResource.Salary.Create(salaryFormModel))
                    //{
                    //    var message = HumanResource.Message;
                    //    throw new Exception(message + " " + HumanResource.ModelState.ValidationMessages);
                    //}
                    //==================================
                    employeeName = fullName;
                    succeed = true;
                }
            }

            if (!succeed)
            {
                HumanResource.Message = "error";
                return View("Index");
            }

            return RedirectToAction("Index");
        }
    }
    /// <summary>









    /// </summary>






    internal enum RequestedModel
    {
        Unknown = 0,
        PersonalModel = 1,
        JobInfoModel = 2,
        MilitaryDataModel = 3,
        DocumentModel = 4,
        Qualification = 5,
        JobInfoDegreeModel = 6,

        //SalaryInfoModel = 4
    }
}