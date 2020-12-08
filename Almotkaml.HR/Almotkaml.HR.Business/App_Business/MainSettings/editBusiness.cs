using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using Almotkaml.HR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using static Almotkaml.HR.Models.TechnicalAffairsDepartmentModel;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{ }
//    public class editBusiness : Business, ITechnicalAffairsDepartmentnBusiness
//    {
//        public editBusiness(HumanResource humanResource)
//            : base(humanResource)
//        {
//        }

//        private bool HavePermission(bool permission = true)
//            => ApplicationUser.Permissions.TechnicalAffairsDepartment && permission;


//        public TechnicalAffairsDepartmentModel Prepare()
//        {
//            if (!HavePermission(ApplicationUser.Permissions.TechnicalAffairsDepartment_Create))
//                return Null<TechnicalAffairsDepartmentModel>(RequestState.NoPermission);

//            return new TechnicalAffairsDepartmentModel()
//            {
//                CanCreate = ApplicationUser.Permissions.TechnicalAffairsDepartment_Create,
//                CanEdit = ApplicationUser.Permissions.TechnicalAffairsDepartment_Edit,
//                //    CanDelete = ApplicationUser.Permissions.TechnicalAffairsDepartment_Delete,
//                EntrantsAndReviewersGrid = UnitOfWork.EntrantsAndReviewerss 
//                    .GetAll()
//                    .Select(a => new EntrantsAndReviewersGridRow ()
//                    {
//                        //TechnicalAffairsDepartmentId = a.TechnicalAffairsDepartmentId,
//                        EntrantsAndReviewersId = a.EntrantsAndReviewersId,
//                       EmployeeName = a .EmployeeName,

//                        //MonthWork = a.MonthWork,
//                        //YearWork = a.YearWork,
//                        //TotalBalance = a.TotalBalance,

//                    }),
//            };
//        }

//        public bool Select(TechnicalAffairsDepartmentModel model)
//        {
//            if (!HavePermission(ApplicationUser.Permissions.TechnicalAffairsDepartment_Edit))
//                return Fail(RequestState.NoPermission);
//            if (model.EntrantsAndReviewersId <= 0)
//                return Fail(RequestState.BadRequest);

//            var technicalAffairsDepartment = UnitOfWork.TechnicalAffairsDepartments .Find((long)model.EntrantsAndReviewersId);

//            if (technicalAffairsDepartment == null)
//                return Fail(RequestState.NotFound);

//            model.EntrantsAndReviewersId = technicalAffairsDepartment.EntrantsAndReviewersId;
//            model.EmployeeName = technicalAffairsDepartment.EntrantsAndReviewers?.EmployeeName ;
//            model.MonthWork  = technicalAffairsDepartment.MonthWork;
//            model.YearWork  = technicalAffairsDepartment.YearWork;
//            model.DataEntry  = technicalAffairsDepartment.DataEntryCount;
//            model.FirstReview = technicalAffairsDepartment.FirstReviewCount;
//            model.AccommodationReview = technicalAffairsDepartment.AccommodationReviewCount;
//            model.ClincReview = technicalAffairsDepartment.ClincReviewCount;
         
//            return true;

//        }

//        public bool SelectEntries(TechnicalAffairsDepartmentModel model)
//        { 
//            if (!HavePermission(ApplicationUser.Permissions.EntrantsAndReviewers_Edit))
//                return Fail(RequestState.NoPermission);
//            //if (_editTechnicalAffairsDepartmentId <= 0)
//            //    return Fail(RequestState.BadRequest);

//            var entrantsAndReviewer = UnitOfWork.TechnicalAffairsDepartments .Find1(model.EntrantsAndReviewersId ,model.MonthWork ,model.YearWork);

//            if (entrantsAndReviewer == null)
//                return Fail(RequestState.NotFound);

//            //_editTechnicalAffairsDepartmentId = entrantsAndReviewer;
//            //model.EmployeeName = entrantsAndReviewer.EmployeeName;
//            //model.EntrantsAndReviewersId = entrantsAndReviewer.EntrantsAndReviewersId;
//            //model.EntrantsAndReviewersType = entrantsAndReviewer.EntrantsAndReviewersType;

//            return true;

//        }


//        public bool Create(TechnicalAffairsDepartmentModel model)
//        {
//            if (!HavePermission(ApplicationUser.Permissions.TechnicalAffairsDepartment_Create))
//                return Fail(RequestState.NoPermission);

//            if (!ModelState.IsValid(model))
//                return false;

//            if (UnitOfWork.TechnicalAffairsDepartments .NameIsExisted(model.TechnicalAffairsDepartmentId ))
//                return NameExisted();
//            var technicalAffairsDepartment = TechnicalAffairsDepartment.New(model.TechnicalAffairsDepartmentId, model.MonthWork , model.YearWork ,
//                model.DataEntry , model.DataEntryBalance , model.FirstReview ,model .FirstReviewBalance , model.AccommodationReview , model.AccommodationReviewBalance
//                , model.ClincReview , model.ClincReviewBalance , model.TotalBalance, model.Note, model.IsPaid 
//                );
//            UnitOfWork.TechnicalAffairsDepartments .Add(technicalAffairsDepartment);

//            UnitOfWork.Complete(n => n.TechnicalAffairsDepartment_Create);

//            return SuccessCreate();


//        }


//        public bool Edit(TechnicalAffairsDepartmentModel model)

//        {
//            if (model.TechnicalAffairsDepartmentId <= 0)
//                return Fail(RequestState.BadRequest);

//            if (!HavePermission(ApplicationUser.Permissions.TechnicalAffairsDepartment_Edit))
//                return Fail(RequestState.NoPermission);

//            if (!ModelState.IsValid(model))
//                return false;

//            var technicalAffairsDepartment = UnitOfWork.TechnicalAffairsDepartments.Find(model.TechnicalAffairsDepartmentId);

//            if (technicalAffairsDepartment == null)
//                return Fail(RequestState.NotFound);

//            if ( UnitOfWork.TechnicalAffairsDepartments.NameIsExisted(model.TechnicalAffairsDepartmentId))
//                return NameExisted();
//            technicalAffairsDepartment.Modify(model.EntrantsAndReviewersId, model.MonthWork, model.YearWork,
//                model.DataEntry, model.DataEntryBalance, model.FirstReview, model.FirstReviewBalance, model.AccommodationReview, model.AccommodationReviewBalance
//                , model.ClincReview, model.ClincReviewBalance, model.TotalBalance, model.Note, true);

//            UnitOfWork.Complete(n => n.TechnicalAffairsDepartment_Edit);

//            return SuccessEdit();
       
//        }


//        ////public bool Delete(EntrantsAndReviewersModel model)
//        ////{
//        ////    if (!HavePermission(ApplicationUser.Permissions.EntrantsAndReviewers_Delete))
//        ////        return Fail(RequestState.NoPermission);

//        ////    if (model.EntrantsAndReviewersId <= 0)
//        ////        return Fail(RequestState.BadRequest);

//        ////    var entrantsAndReviewers = UnitOfWork.EntrantsAndReviewerss.Find(model.EntrantsAndReviewersId);

//        ////    if (entrantsAndReviewers == null)
//        ////        return Fail(RequestState.NotFound);

//        ////    UnitOfWork.EntrantsAndReviewerss.Remove(entrantsAndReviewers);

//        ////    if (!UnitOfWork.TryComplete(n => n.EntrantsAndReviewers_Delete))
//        ////        return Fail(UnitOfWork.Message);

//        ////    return SuccessDelete();
//        ////}
//        public void Refresh(TechnicalAffairsDepartmentModel model)
//        {
//            //model.TechnicalAffairsDepartmentnGrid = UnitOfWork.TechnicalAffairsDepartmentns.GetTechnicalAffairsDepartmentnByEmployeeId(model.EmployeeId).ToGrid();

//            //model.SubSpecialtyList = model.SpecialtyId > 0
//            //    ? UnitOfWork.SubSpecialties.GetSubSpecialtyWithSpecialty(model.SpecialtyId).ToList()
//            //    : new HashSet<SubSpecialtyListItem>();

//            //model.ExactSpecialtyList = model.SubSpecialtyId > 0
//            //    ? UnitOfWork.ExactSpecialties.GetExactSpecialtyWithSubSpecialty(model.SubSpecialtyId.Value).ToList()
//            //    : new HashSet<ExactSpecialtyListItem>();

//            //var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
//            //if (employee == null)
//            //    return;
//            //model.EmployeeName = employee.GetFullName();
//        }

//        public bool Delete(TechnicalAffairsDepartmentModel model)
//        {
//            throw new NotImplementedException();
//        }
//        //public void RefreshReport(TechnicalAffairsDepartmentnModel model)
//        //{

//        //    model.SpecialtyList = UnitOfWork.Specialties.GetAll().ToList();
//        //    model.TechnicalAffairsDepartmentnTypeList = UnitOfWork.TechnicalAffairsDepartmentnTypes.GetAll().ToList();

//        //    model.SubSpecialtyList = model.SpecialtyId > 0
//        //        ? UnitOfWork.SubSpecialties.GetSubSpecialtyWithSpecialty(model.SpecialtyId).ToList()
//        //        : new HashSet<SubSpecialtyListItem>();

//        //    model.ExactSpecialtyList = model.SubSpecialtyId > 0
//        //        ? UnitOfWork.ExactSpecialties.GetExactSpecialtyWithSubSpecialty(model.SubSpecialtyId.Value).ToList()
//        //        : new HashSet<ExactSpecialtyListItem>();
//        //}




//        //private void Clear(TechnicalAffairsDepartmentnModel model)
//        //{
//        //    model.TechnicalAffairsDepartmentnId = 0;
//        //    model.Date = "";
//        //    model.TechnicalAffairsDepartmentnTypeId = 0;
//        //    model.GraduationCountry = "";
//        //    model.NameDonorFoundation = "";
//        //    model.AquiredSpecialty = "";
//        //    model.ExactSpecialtyId = 0;
//        //    model.SubSpecialtyId = 0;
//        //    model.SpecialtyId = 0;
//        //}
//        //public void Report(TechnicalAffairsDepartmentnModel model)
//        //{
//        //    var TechnicalAffairsDepartmentnReportDto = new TechnicalAffairsDepartmentnReportDto()
//        //    {
//        //        AquiredSpecialty = model.AquiredSpecialty,
//        //        ExactSpecialtyId = model.ExactSpecialtyId ?? 0,
//        //        TechnicalAffairsDepartmentnTypeId = model.TechnicalAffairsDepartmentnTypeId,
//        //        SpecialtyId = model.SpecialtyId,
//        //        SubSpecialtyId = model.SubSpecialtyId ?? 0,
//        //    };

//        //    model.TechnicalAffairsDepartmentnGrid = UnitOfWork.TechnicalAffairsDepartmentns.GetTechnicalAffairsDepartmentnReport(TechnicalAffairsDepartmentnReportDto).ToGrid();
//        //    //  model.TechnicalAffairsDepartmentnGrid = TechnicalAffairsDepartmentnGrid;
//        //    //if (model.TechnicalAffairsDepartmentnTypeId > 0)

//        //return;
//        //   }
//    }
//}