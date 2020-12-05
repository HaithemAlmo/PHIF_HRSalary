using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using Almotkaml.HR.Repository;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class TechnicalAffairsDepartmentnBusiness : Business, ITechnicalAffairsDepartmentnBusiness
    {
        public TechnicalAffairsDepartmentnBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.TechnicalAffairsDepartmentnBusiness && permission;



        public TechnicalAffairsDepartmentModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Evaluation_Create))
                return Null<TechnicalAffairsDepartmentModel>(RequestState.NoPermission);

            return new TechnicalAffairsDepartmentModel()
            {
                CanCreate = ApplicationUser.Permissions.Evaluation_Create,
                CanEdit = ApplicationUser.Permissions.Evaluation_Edit,
                CanDelete = ApplicationUser.Permissions.Evaluation_Delete,
                EmployeeGrid = UnitOfWork.EntrantsAndReviewerss.GetAll().ToGrid(),
                //TechnicalAffairsDepartmentnGrid = UnitOfWork.TechnicalAffairsDepartmentns.GetTechnicalAffairsDepartmentnByEmployeeId(0).ToGrid(),
                //SpecialtyList = UnitOfWork.Specialties.GetAll().ToList(),
                //TechnicalAffairsDepartmentnTypeList = UnitOfWork.TechnicalAffairsDepartmentnTypes.GetAll().ToList()
            };
        }
        public void Refresh(TechnicalAffairsDepartmentModel model)
        {
            //model.TechnicalAffairsDepartmentnGrid = UnitOfWork.TechnicalAffairsDepartmentns.GetTechnicalAffairsDepartmentnByEmployeeId(model.EmployeeId).ToGrid();

            //model.SubSpecialtyList = model.SpecialtyId > 0
            //    ? UnitOfWork.SubSpecialties.GetSubSpecialtyWithSpecialty(model.SpecialtyId).ToList()
            //    : new HashSet<SubSpecialtyListItem>();

            //model.ExactSpecialtyList = model.SubSpecialtyId > 0
            //    ? UnitOfWork.ExactSpecialties.GetExactSpecialtyWithSubSpecialty(model.SubSpecialtyId.Value).ToList()
            //    : new HashSet<ExactSpecialtyListItem>();

            //var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            //if (employee == null)
            //    return;
            //model.EmployeeName = employee.GetFullName();
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
        public bool Select(TechnicalAffairsDepartmentModel model)
        {
            //if (!HavePermission(ApplicationUser.Permissions.Evaluation_Edit))
            //    return Fail(RequestState.NoPermission);

            //if (model.TechnicalAffairsDepartmentnId <= 0)
            //    return Fail(RequestState.BadRequest);

            //var TechnicalAffairsDepartmentn = UnitOfWork.TechnicalAffairsDepartmentns.Find(model.TechnicalAffairsDepartmentnId);

            //if (TechnicalAffairsDepartmentn == null)
            //    return Fail(RequestState.NotFound);

            //var specialtyId = TechnicalAffairsDepartmentn.SpecialtyId ?? TechnicalAffairsDepartmentn.ExactSpecialty?.SubSpecialty?.SpecialtyId ?? TechnicalAffairsDepartmentn.SubSpecialty?.SpecialtyId ?? 0;
            //var subSpecialtyId = TechnicalAffairsDepartmentn.SubSpecialtyId ?? TechnicalAffairsDepartmentn.ExactSpecialty?.SubSpecialty?.SubSpecialtyId ?? 0;

            //model.TechnicalAffairsDepartmentnId = TechnicalAffairsDepartmentn.TechnicalAffairsDepartmentnId;
            //model.Date = TechnicalAffairsDepartmentn.Date.FormatToString();
            //model.GraduationCountry = TechnicalAffairsDepartmentn.GraduationCountry;
            //model.EmployeeId = TechnicalAffairsDepartmentn.EmployeeId;
            //model.NameDonorFoundation = TechnicalAffairsDepartmentn.NameDonorFoundation;
            //model.TechnicalAffairsDepartmentnTypeId = TechnicalAffairsDepartmentn.TechnicalAffairsDepartmentnTypeId;
            //model.AquiredSpecialty = TechnicalAffairsDepartmentn.AquiredSpecialty;
            //model.Grade = TechnicalAffairsDepartmentn.Grade;
            //model.DonorFoundationType = TechnicalAffairsDepartmentn.DonorFoundationType;
            //model.SpecialtyList = UnitOfWork.Specialties.GetAll().ToList();
            //model.SpecialtyId = specialtyId;

            //model.SubSpecialtyList = UnitOfWork.SubSpecialties.GetSubSpecialtyWithSpecialty(specialtyId).ToList();
            //model.SubSpecialtyId = subSpecialtyId;

            //model.ExactSpecialtyList = UnitOfWork.ExactSpecialties.GetExactSpecialtyWithSubSpecialty(subSpecialtyId).ToList();
            //model.ExactSpecialtyId = TechnicalAffairsDepartmentn.ExactSpecialtyId ?? 0;
            return true;

        }
        public bool Create(TechnicalAffairsDepartmentModel model)
        {
            //    if (!HavePermission(ApplicationUser.Permissions.TechnicalAffairsDepartmentn_Create))
            //        return Fail(RequestState.NoPermission);

            //    if (!ModelState.IsValid(model))
            //        return false;

            //    var specialityHolder = TechnicalAffairsDepartmentn.New()
            //        .WithEmployeeId(model.EmployeeId)
            //        .WithTechnicalAffairsDepartmentnTypeId(model.TechnicalAffairsDepartmentnTypeId)
            //        .WithDate(model.Date.ToDateTime())
            //        .WithGraduationCountry(model.GraduationCountry)
            //        .WithNameDonorFoundation(model.NameDonorFoundation);

            //    IAquiredSpecialtyHolder builder;

            //    switch (model.GetRequestedType())
            //    {
            //        case SpecialityType.Speciality:
            //            builder = specialityHolder.WithSpecialtyId(model.SpecialtyId);
            //            break;
            //        case SpecialityType.SubSpeciality:
            //            builder = specialityHolder.WithSubSpecialtyId(model.SubSpecialtyId);
            //            break;
            //        case SpecialityType.ExactSpeciality:
            //            builder = specialityHolder.WithExactSpecialtyId(model.ExactSpecialtyId);
            //            break;
            //        default:
            //            throw new ArgumentOutOfRangeException();
            //    }


            //    var TechnicalAffairsDepartmentn = builder.WithAquiredSpecialty(model.AquiredSpecialty)
            //        .WithDonorFoundationType(model.DonorFoundationType)
            //        .WithGrade(model.Grade)
            //        .Biuld();

            //    UnitOfWork.TechnicalAffairsDepartmentns.Add(TechnicalAffairsDepartmentn);

            //    UnitOfWork.Complete(n => n.TechnicalAffairsDepartmentn_Create);
            //    Clear(model);

            return SuccessCreate();
        }
        public bool Edit(TechnicalAffairsDepartmentModel model)
    {
            //    if (model.TechnicalAffairsDepartmentnId <= 0)
            //        return Fail(RequestState.BadRequest);

            //    if (!HavePermission(ApplicationUser.Permissions.TechnicalAffairsDepartmentn_Edit))
            //        return Fail(RequestState.NoPermission);

            //    if (!ModelState.IsValid(model))
            //        return false;

            //    var TechnicalAffairsDepartmentn = UnitOfWork.TechnicalAffairsDepartmentns.Find(model.TechnicalAffairsDepartmentnId);

            //    if (TechnicalAffairsDepartmentn == null)
            //        return Fail(RequestState.NotFound);

            //    int? specialityId;
            //    var specialityType = model.GetRequestedType();

            //    switch (specialityType)
            //    {
            //        case SpecialityType.Speciality:
            //            specialityId = model.SpecialtyId;
            //            break;
            //        case SpecialityType.SubSpeciality:
            //            specialityId = model.SubSpecialtyId;
            //            break;
            //        case SpecialityType.ExactSpeciality:
            //            specialityId = model.ExactSpecialtyId;
            //            break;
            //        default:
            //            throw new ArgumentOutOfRangeException();
            //    }

            //    TechnicalAffairsDepartmentn.Modify()
            //       .Employee(model.EmployeeId)
            //       .TechnicalAffairsDepartmentnType(model.TechnicalAffairsDepartmentnTypeId)
            //       .Date(model.Date.ToDateTime())
            //       .GraduationCountry(model.GraduationCountry)
            //       .NameDonorFoundation(model.NameDonorFoundation)
            //       .Specialty(specialityType, specialityId)
            //       .AquiredSpecialty(model.AquiredSpecialty)
            //       .DonorFoundationType(model.DonorFoundationType)
            //       .Grade(model.Grade)
            //       .Confirm();

            //    UnitOfWork.Complete(n => n.TechnicalAffairsDepartmentn_Edit);

            //    Clear(model);
            return SuccessEdit();
        }
        public bool Delete(TechnicalAffairsDepartmentModel model)
        {
            //    if (!HavePermission(ApplicationUser.Permissions.TechnicalAffairsDepartmentn_Delete))
            //        return Fail(RequestState.NoPermission);

            //    if (model.TechnicalAffairsDepartmentnId <= 0)
            //        return Fail(RequestState.BadRequest);

            //    var TechnicalAffairsDepartmentn = UnitOfWork.TechnicalAffairsDepartmentns.Find(model.TechnicalAffairsDepartmentnId);

            //    if (TechnicalAffairsDepartmentn == null)
            //        return Fail(RequestState.NotFound);

            //    UnitOfWork.TechnicalAffairsDepartmentns.Remove(TechnicalAffairsDepartmentn);

            //    if (!UnitOfWork.TryComplete(n => n.TechnicalAffairsDepartmentn_Delete))
            //        return Fail(UnitOfWork.Message);

            return SuccessDelete();
            }
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