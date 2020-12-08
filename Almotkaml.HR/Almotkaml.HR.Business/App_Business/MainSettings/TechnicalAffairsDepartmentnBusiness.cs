using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using Almotkaml.HR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
//using static Almotkaml.HR.Models.TechnicalAffairsDepartmentModel;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class TechnicalAffairsDepartmentnBusiness : Business, ITechnicalAffairsDepartmentnBusiness
    {
        public TechnicalAffairsDepartmentnBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.TechnicalAffairsDepartment && permission;


        public TechnicalAffairsDepartmentModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.TechnicalAffairsDepartment_Create))
                return Null<TechnicalAffairsDepartmentModel>(RequestState.NoPermission);

            return new TechnicalAffairsDepartmentModel()
            {
                CanCreate = ApplicationUser.Permissions.TechnicalAffairsDepartment_Create,
                CanEdit = ApplicationUser.Permissions.TechnicalAffairsDepartment_Edit,
                EntrantsAndReviewersGrid  = UnitOfWork.EntrantsAndReviewerss .GetAll().ToGrid(),
                TechnicalAffairsDepartmentGrid = UnitOfWork.TechnicalAffairsDepartments .GetTechnicalAffairsDepartmentByEmployeeId(0).ToGrid(),
                ////    CanDelete = ApplicationUser.Permissions.TechnicalAffairsDepartment_Delete,
                //TechnicalAffairsDepartmentGrid = UnitOfWork.TechnicalAffairsDepartments.GetTechnicalAffairsDepartmentByEmployeeId(0).ToGrid(),
                ////TechnicalAffairsDepartmentGrid = UnitOfWork.TechnicalAffairsDepartments 
                ////    .GetAll()
                ////    .Select(a => new TechnicalAffairsDepartmentGridRow()
                ////    {
                ////      TechnicalAffairsDepartmentId = a.TechnicalAffairsDepartmentId,
                ////       // EntrantsAndReviewersId = a.EntrantsAndReviewersId,
                ////       EmployeeName = a .EntrantsAndReviewers.EmployeeName,

                ////        //MonthWork = a.MonthWork,
                //        //YearWork = a.YearWork,
                //  TotalBalance = a.TotalBalance,

                //    }),
            };
        }

        public bool Select(TechnicalAffairsDepartmentModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.TechnicalAffairsDepartment_Edit))
                return Fail(RequestState.NoPermission);
            if (model.EntrantsAndReviewersId <= 0)
                return Fail(RequestState.BadRequest);

            var technicalAffairsDepartment = UnitOfWork.TechnicalAffairsDepartments .Find((long)model.TechnicalAffairsDepartmentId);

            if (technicalAffairsDepartment == null)
                return Fail(RequestState.NotFound);

            model.EntrantsAndReviewersId = technicalAffairsDepartment.EntrantsAndReviewersId;
            model.EmployeeName = technicalAffairsDepartment.EntrantsAndReviewers?.EmployeeName ;
            model.MonthWork  = technicalAffairsDepartment.MonthWork;
            model.YearWork  = technicalAffairsDepartment.YearWork;
            model.DataEntry  = technicalAffairsDepartment.DataEntryCount;
            model.FirstReview = technicalAffairsDepartment.FirstReviewCount;
            model.AccommodationReview = technicalAffairsDepartment.AccommodationReviewCount;
            model.ClincReview = technicalAffairsDepartment.ClincReviewCount;
         
            return true;

        }


        public  void Select0(TechnicalAffairsDepartmentModel model)
        {
           // if (!HavePermission(ApplicationUser.Permissions.TechnicalAffairsDepartment_Edit))
               // return Fail(RequestState.NoPermission);
            //if (model.EntrantsAndReviewersId <= 0)
            //    return Fail(RequestState.BadRequest);
            //if (model.EntrantsAndReviewersType != null)
            //{
            //    if (model.EntrantsAndReviewersType = 0)
                //    var technicalAffairsDepartment1 = UnitOfWork.TechnicalAffairsDepartments.Findispaid(model.YearWork,model.MonthWork);
                //if (technicalAffairsDepartment1 == null)
                //    return Fail(RequestState.NotFound);



            var grid = UnitOfWork.TechnicalAffairsDepartments.Findispaid(model.YearWork, model.MonthWork).ToList();

            model.TechnicalAffairsDepartmentGrid = grid.ToGrid();
            //return new TechnicalAffairsDepartmentModel()
            //{
            //    TechnicalAffairsDepartmentGrid = UnitOfWork.TechnicalAffairsDepartments.GetAll().ToGrid(),
            //  //  model.EntrantsAndReviewersId = grid.ge
            //};
            //model.EntrantsAndReviewersId = grid.;
            //model.EmployeeName = grid.EntrantsAndReviewers?.EmplsoyeeName;
            //model.MonthWork = grid.MonthWork;
            //model.YearWork = grid.YearWork;
            //model.DataEntry = grid.DataEntryCount;
            //model.FirstReview = grid.FirstReviewCount;
            //model.AccommodationReview = grid.AccommodationReviewCount;
            //model.ClincReview = grid.ClincReviewCount;
            // return true
            //return new TechnicalAffairsDepartmentModel()
            //{
            //    TechnicalAffairsDepartmentGrid = UnitOfWork.TechnicalAffairsDepartments.GetAll().ToGrid(),
            //    TechnicalAffairsDepartmentGrid = grid.ToGrid(),
            //    CanCreate = ApplicationUser.Permissions.Employee_Create,
            //    CanEdit = ApplicationUser.Permissions.Employee_Edit,
            //    CanDelete = ApplicationUser.Permissions.Employee_Delete,
            //};





            //model.EntrantsAndReviewersId = technicalAffairsDepartment1.EntrantsAndReviewersId;
            //model.EmployeeName = technicalAffairsDepartment1.EntrantsAndReviewers?.EmployeeName;
            //model.EntrantsAndReviewersType = technicalAffairsDepartment1.EntrantsAndReviewers.EntrantsAndReviewersType;

            //model.MonthWork = technicalAffairsDepartment.MonthWork;
            //model.YearWork = technicalAffairsDepartment.YearWork;
            //model.DataEntry = technicalAffairsDepartment.DataEntryCount;
            //model.FirstReview = technicalAffairsDepartment.FirstReviewCount;
            //model.AccommodationReview = technicalAffairsDepartment.AccommodationReviewCount;
            //model.ClincReview = technicalAffairsDepartment.ClincReviewCount;

            //  return true;

        }
            //var technicalAffairsDepartment = UnitOfWork.TechnicalAffairsDepartments.Find((long)model.EntrantsAndReviewersId);

            //if (technicalAffairsDepartment == null)
            //    return Fail(RequestState.NotFound);

            //model.EntrantsAndReviewersId = technicalAffairsDepartment.EntrantsAndReviewersId;
            //model.EmployeeName = technicalAffairsDepartment.EntrantsAndReviewers?.EmployeeName;
            //model.MonthWork = technicalAffairsDepartment.MonthWork;
            //model.YearWork = technicalAffairsDepartment.YearWork;
            //model.DataEntry = technicalAffairsDepartment.DataEntryCount;
            //model.FirstReview = technicalAffairsDepartment.FirstReviewCount;
            //model.AccommodationReview = technicalAffairsDepartment.AccommodationReviewCount;
            //model.ClincReview = technicalAffairsDepartment.ClincReviewCount;

        //    return true;

        //}



        public bool SelectEntries(TechnicalAffairsDepartmentModel model ,int id) 
        { 
            if (!HavePermission(ApplicationUser.Permissions.EntrantsAndReviewers_Edit))
                return Fail(RequestState.NoPermission);
            //if (_editTechnicalAffairsDepartmentId <= 0)
            //    return Fail(RequestState.BadRequest);

            var technicalAffairsDepartment = UnitOfWork.TechnicalAffairsDepartments.Find1(id, model.MonthWork ,model.YearWork);

            if (technicalAffairsDepartment == null)
                return Fail(RequestState.NotFound);

            //technicalAffairsDepartment.Modify()
            //   .EntrantsAndReviewersId(model.EntrantsAndReviewersId)
            //   .MonthWork(model.MonthWork)
            //   .YearWork(model.YearWork)
            //   .DataEntryCount(model.DataEntryCount)
            //   .DataEntryBalance(model.DataEntryBalance)
            //   .FirstReviewCount(model.FirstReview)
            //   .FirstReviewBalance(model.FirstReviewBalance)
            //   .AccommodationReviewCount(model.AccommodationReview)
            //   .AccommodationReviewBalance(model.AccommodationReviewBalance)
            //   .ClincReviewCount(model.ClincReview)
            //   .ClincReviewBalance(model.ClincReviewBalance)
            //   .TotalBalance(model.TotalBalance)
            //   .Note(model.Note)
            //.IsPaid(true)
            //.Confirm();


               //_editTechnicalAffairsDepartmentId = entrantsAndReviewer;
               //model.EmployeeName = entrantsAndReviewer.EmployeeName;
               //model.EntrantsAndReviewersId = entrantsAndReviewer.EntrantsAndReviewersId;
               //model.EntrantsAndReviewersType = entrantsAndReviewer.EntrantsAndReviewersType;
            UnitOfWork.Complete(n => n.TechnicalAffairsDepartment_Edit);

            return SuccessEdit();

           

        }
        //استجلاب سعر الورقة لادخال البيانات
        public decimal DataEntryCollect(ISettings settings)
        {
            decimal dataEntryCollect = 0;
            dataEntryCollect = settings.DataEntryPrice;
            var value2 = string.Format("{0:0.000}", /*Math.Truncate(*/dataEntryCollect * 1000/*)*/ / 1000);

            return decimal.Parse(value2);
        }
        //استجلاب سعر الملف للمراجعة الاولية 
        public decimal firstReviewCollect(ISettings settings)
        {
            decimal FirstReview = 0;
            FirstReview = settings.FirstReviewPrice ;
            var value2 = string.Format("{0:0.000}", /*Math.Truncate(*/FirstReview * 1000/*)*/ / 1000);

            return decimal.Parse(value2);
        }

        //استجلاب سعر الملف للمراجعةالايواء 
        public decimal AccommodationReviewCollect(ISettings settings)
        {
            decimal AccommodationReview = 0;
            AccommodationReview = settings.AccommodationReviewPrice ;
            var value2 = string.Format("{0:0.000}", /*Math.Truncate(*/AccommodationReview * 1000/*)*/ / 1000);

            return decimal.Parse(value2);
        }
        //استجلاب سعر الملف للعيادات  
        public decimal ClincReviewCollect(ISettings settings)
        {
            decimal ClincReview = 0;
            ClincReview = settings.ClincReviewPrice ;
            var value2 = string.Format("{0:0.000}", /*Math.Truncate(*/ClincReview * 1000/*)*/ / 1000);

            return decimal.Parse(value2);
        }


        public bool Create(TechnicalAffairsDepartmentModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.TechnicalAffairsDepartment_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.TechnicalAffairsDepartments .NameIsExisted(model.TechnicalAffairsDepartmentId ))
                return NameExisted();
            
            var technicalAffairsDepartment = TechnicalAffairsDepartment.New()
                .WithEntrantsAndReviewersId(model.EntrantsAndReviewersId)
                .WithMonthWork(model.MonthWork)
                .WithYearWork(model.YearWork)
                .WithDataEntryCount(model.DataEntry)
                .WithDataEntryBalance(model.DataEntry * DataEntryCollect(Settings))
                .WithFirstReviewCount(model.FirstReview)
                .WithFirstReviewBalance(model.FirstReview * firstReviewCollect(Settings))
                .WithAccommodationReviewCount(model.AccommodationReview)
                .WithAccommodationReviewBalance(model.AccommodationReview * AccommodationReviewCollect(Settings))
                .WithClincReviewCount(model.ClincReview)
                .WithClincReviewBalance(model.ClincReview * ClincReviewCollect(Settings))
                .WithTotalBalance((model.DataEntry * DataEntryCollect(Settings))+(model.FirstReview * firstReviewCollect(Settings)) +(model.AccommodationReview * AccommodationReviewCollect(Settings)) +(model.ClincReview * ClincReviewCollect(Settings)))
                .WithNote(model.Note)
                .WithIsPaid(false )
                .Biuld();
                
            UnitOfWork.TechnicalAffairsDepartments .Add(technicalAffairsDepartment);

            UnitOfWork.Complete(n => n.TechnicalAffairsDepartment_Create);
            model.TechnicalAffairsDepartmentGrid = UnitOfWork.TechnicalAffairsDepartments.GetTechnicalAffairsDepartmentByEmployeeId(model.TechnicalAffairsDepartmentId).ToGrid();
      
            return SuccessCreate();


        }


        public bool Edit(TechnicalAffairsDepartmentModel model)

        {
            if (model.TechnicalAffairsDepartmentId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.TechnicalAffairsDepartment_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var technicalAffairsDepartment = UnitOfWork.TechnicalAffairsDepartments.Find(model.TechnicalAffairsDepartmentId);

            if (technicalAffairsDepartment == null)
                return Fail(RequestState.NotFound);

            if ( UnitOfWork.TechnicalAffairsDepartments.NameIsExisted(model.TechnicalAffairsDepartmentId))
                return NameExisted();
            technicalAffairsDepartment.Modify()
                .EntrantsAndReviewersId(model.EntrantsAndReviewersId)
                .MonthWork(model.MonthWork)
                .YearWork(model.YearWork)
                .DataEntryCount(model.DataEntry)
                .DataEntryBalance(model.DataEntryBalance)
                .FirstReviewCount(model.FirstReview)
                .FirstReviewBalance(model.FirstReviewBalance)
                .AccommodationReviewCount(model.AccommodationReview)
                .AccommodationReviewBalance(model.AccommodationReviewBalance)
                .ClincReviewCount(model.ClincReview)
                .ClincReviewBalance(model.ClincReviewBalance)
                .TotalBalance(model.TotalBalance)
                .Note(model.Note)
                .IsPaid(model.IsPaid)
                .Confirm()
                
                
                ;

            UnitOfWork.Complete(n => n.TechnicalAffairsDepartment_Edit);
            model.TechnicalAffairsDepartmentGrid = UnitOfWork.TechnicalAffairsDepartments.GetTechnicalAffairsDepartmentByEmployeeId(model.TechnicalAffairsDepartmentId).ToGrid();

            return SuccessEdit();
       
        }


        ////public bool Delete(EntrantsAndReviewersModel model)
        ////{
        ////    if (!HavePermission(ApplicationUser.Permissions.EntrantsAndReviewers_Delete))
        ////        return Fail(RequestState.NoPermission);

        ////    if (model.EntrantsAndReviewersId <= 0)
        ////        return Fail(RequestState.BadRequest);

        ////    var entrantsAndReviewers = UnitOfWork.EntrantsAndReviewerss.Find(model.EntrantsAndReviewersId);

        ////    if (entrantsAndReviewers == null)
        ////        return Fail(RequestState.NotFound);

        ////    UnitOfWork.EntrantsAndReviewerss.Remove(entrantsAndReviewers);

        ////    if (!UnitOfWork.TryComplete(n => n.EntrantsAndReviewers_Delete))
        ////        return Fail(UnitOfWork.Message);

        ////    return SuccessDelete();
        ////}
        
                public void Refresh0(TechnicalAffairsDepartmentModel model)
        {

            var employee = UnitOfWork.TechnicalAffairsDepartments.GetAll().Where(e => e.YearWork == model.YearWork && e.MonthWork == model.MonthWork);

            if (employee == null)
                return;


            //return new TechnicalAffairsDepartmentModel()
            //    {
            //       TechnicalAffairsDepartmentGrid = employee.,
            //    };

            //model.EmployeeName = employee.EmployeeName;
            //model.EntrantsAndReviewersType = employee.EntrantsAndReviewersType;
            model.TechnicalAffairsDepartmentGrid = UnitOfWork.TechnicalAffairsDepartments.GetEntrantsAndReviewersBy(model.YearWork,model.MonthWork).ToGrid();
        }
        public void Refresh(TechnicalAffairsDepartmentModel model)
        {

            var employee = UnitOfWork.EntrantsAndReviewerss.GetEntrantsAndReviewersByEmployeeId(model.EntrantsAndReviewersId);

            if (employee == null)
                return;

            model.EmployeeName = employee.EmployeeName;
            model.EntrantsAndReviewersType = employee.EntrantsAndReviewersType;
            model.TechnicalAffairsDepartmentGrid = UnitOfWork.TechnicalAffairsDepartments.GetTechnicalAffairsDepartmentByEmployeeId(model.EntrantsAndReviewersId).ToGrid();
        }

        public bool Delete(TechnicalAffairsDepartmentModel model)
        {
            throw new NotImplementedException();
        }
        //public void RefreshReport(TechnicalAffairsDepartmentnModel model)
        //{

        //    model.SpecialtyList = UnitOfWork.Specialties.GetAll().ToList();
        //    model.TechnicalAffairsDepartmentnTypeList = UnitOfWork.TechnicalAffairsDepartmentnTypes.GetAll().ToList();

        //    model.SubSpecialtyList = model.SpecialtyId > 0
        //        ? UnitOfWork.SubSpecialties.GetSubSpecialtyWithSpecialty(model.SpecialtyId).ToList()
        //        : new HashSet<SubSpecialtyListItem>();

        //    model.ExactSpecialtyList = model.SubSpecialtyId > 0
        //        ? UnitOfWork.ExactSpecialties.GetExactSpecialtyWithSubSpecialty(model.SubSpecialtyId.Value).ToList()
        //        : new HashSet<ExactSpecialtyListItem>();
        //}




        //private void Clear(TechnicalAffairsDepartmentnModel model)
        //{
        //    model.TechnicalAffairsDepartmentnId = 0;
        //    model.Date = "";
        //    model.TechnicalAffairsDepartmentnTypeId = 0;
        //    model.GraduationCountry = "";
        //    model.NameDonorFoundation = "";
        //    model.AquiredSpecialty = "";
        //    model.ExactSpecialtyId = 0;
        //    model.SubSpecialtyId = 0;
        //    model.SpecialtyId = 0;
        //}
        //public void Report(TechnicalAffairsDepartmentnModel model)
        //{
        //    var TechnicalAffairsDepartmentnReportDto = new TechnicalAffairsDepartmentnReportDto()
        //    {
        //        AquiredSpecialty = model.AquiredSpecialty,
        //        ExactSpecialtyId = model.ExactSpecialtyId ?? 0,
        //        TechnicalAffairsDepartmentnTypeId = model.TechnicalAffairsDepartmentnTypeId,
        //        SpecialtyId = model.SpecialtyId,
        //        SubSpecialtyId = model.SubSpecialtyId ?? 0,
        //    };

        //    model.TechnicalAffairsDepartmentnGrid = UnitOfWork.TechnicalAffairsDepartmentns.GetTechnicalAffairsDepartmentnReport(TechnicalAffairsDepartmentnReportDto).ToGrid();
        //    //  model.TechnicalAffairsDepartmentnGrid = TechnicalAffairsDepartmentnGrid;
        //    //if (model.TechnicalAffairsDepartmentnTypeId > 0)

        //return;
        //   }
    }
}