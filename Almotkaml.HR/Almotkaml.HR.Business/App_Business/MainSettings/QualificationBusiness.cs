using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Domain.QualificationFactory;
using Almotkaml.HR.Models;
using Almotkaml.HR.Repository;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class QualificationBusiness : Business, IQualificationBusiness
    {
        public QualificationBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Qualification && permission;



        public QualificationModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Evaluation_Create))
                return Null<QualificationModel>(RequestState.NoPermission);

            return new QualificationModel()
            {
                CanCreate = ApplicationUser.Permissions.Evaluation_Create,
                CanEdit = ApplicationUser.Permissions.Evaluation_Edit,
                CanDelete = ApplicationUser.Permissions.Evaluation_Delete,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                QualificationGrid = UnitOfWork.Qualifications.GetQualificationByEmployeeId(0).ToGrid(),
                SpecialtyList = UnitOfWork.Specialties.GetAll().ToList(),
                QualificationTypeList = UnitOfWork.QualificationTypes.GetAll().ToList()
            };
        }

        public void Refresh(QualificationModel model)
        {
            model.QualificationGrid = UnitOfWork.Qualifications.GetQualificationByEmployeeId(model.EmployeeId).ToGrid();

            model.SubSpecialtyList = model.SpecialtyId > 0
                ? UnitOfWork.SubSpecialties.GetSubSpecialtyWithSpecialty(model.SpecialtyId).ToList()
                : new HashSet<SubSpecialtyListItem>();

            model.ExactSpecialtyList = model.SubSpecialtyId > 0
                ? UnitOfWork.ExactSpecialties.GetExactSpecialtyWithSubSpecialty(model.SubSpecialtyId.Value).ToList()
                : new HashSet<ExactSpecialtyListItem>();

            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            if (employee == null)
                return;
            model.EmployeeName = employee.GetFullName();
        }
        public void RefreshReport(QualificationModel model)
        {

            model.SpecialtyList = UnitOfWork.Specialties.GetAll().ToList();
            model.QualificationTypeList = UnitOfWork.QualificationTypes.GetAll().ToList();

            model.SubSpecialtyList = model.SpecialtyId > 0
                ? UnitOfWork.SubSpecialties.GetSubSpecialtyWithSpecialty(model.SpecialtyId).ToList()
                : new HashSet<SubSpecialtyListItem>();

            model.ExactSpecialtyList = model.SubSpecialtyId > 0
                ? UnitOfWork.ExactSpecialties.GetExactSpecialtyWithSubSpecialty(model.SubSpecialtyId.Value).ToList()
                : new HashSet<ExactSpecialtyListItem>();
        }
        public bool Select(QualificationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Evaluation_Edit))
                return Fail(RequestState.NoPermission);

            if (model.QualificationId <= 0)
                return Fail(RequestState.BadRequest);

            var qualification = UnitOfWork.Qualifications.Find(model.QualificationId);

            if (qualification == null)
                return Fail(RequestState.NotFound);

            var specialtyId = qualification.SpecialtyId ?? qualification.ExactSpecialty?.SubSpecialty?.SpecialtyId ?? qualification.SubSpecialty?.SpecialtyId ?? 0;
            var subSpecialtyId = qualification.SubSpecialtyId ?? qualification.ExactSpecialty?.SubSpecialty?.SubSpecialtyId ?? 0;

            model.QualificationId = qualification.QualificationId;
            model.Date = qualification.Date.FormatToString();
            model.GraduationCountry = qualification.GraduationCountry;
            model.EmployeeId = qualification.EmployeeId;
            model.NameDonorFoundation = qualification.NameDonorFoundation;
            model.QualificationTypeId = qualification.QualificationTypeId;
            model.AquiredSpecialty = qualification.AquiredSpecialty;
            model.Grade = qualification.Grade;
            model.DonorFoundationType = qualification.DonorFoundationType;
            model.SpecialtyList = UnitOfWork.Specialties.GetAll().ToList();
            model.SpecialtyId = specialtyId;

            model.SubSpecialtyList = UnitOfWork.SubSpecialties.GetSubSpecialtyWithSpecialty(specialtyId).ToList();
            model.SubSpecialtyId = subSpecialtyId;

            model.ExactSpecialtyList = UnitOfWork.ExactSpecialties.GetExactSpecialtyWithSubSpecialty(subSpecialtyId).ToList();
            model.ExactSpecialtyId = qualification.ExactSpecialtyId ?? 0;
            return true;

        }

        public bool Create(QualificationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Qualification_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var specialityHolder = Qualification.New()
                .WithEmployeeId(model.EmployeeId)
                .WithQualificationTypeId(model.QualificationTypeId)
                .WithDate(model.Date.ToDateTime())
                .WithGraduationCountry(model.GraduationCountry)
                .WithNameDonorFoundation(model.NameDonorFoundation);

            IAquiredSpecialtyHolder builder;

            switch (model.GetRequestedType())
            {
                case SpecialityType.Speciality:
                    builder = specialityHolder.WithSpecialtyId(model.SpecialtyId);
                    break;
                case SpecialityType.SubSpeciality:
                    builder = specialityHolder.WithSubSpecialtyId(model.SubSpecialtyId);
                    break;
                case SpecialityType.ExactSpeciality:
                    builder = specialityHolder.WithExactSpecialtyId(model.ExactSpecialtyId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            var qualification = builder.WithAquiredSpecialty(model.AquiredSpecialty)
                .WithDonorFoundationType(model.DonorFoundationType)
                .WithGrade(model.Grade)
                .Biuld();

            UnitOfWork.Qualifications.Add(qualification);

            UnitOfWork.Complete(n => n.Qualification_Create);
            Clear(model);

            return SuccessCreate();
        }

        public bool Edit(QualificationModel model)
        {
            if (model.QualificationId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Qualification_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var qualification = UnitOfWork.Qualifications.Find(model.QualificationId);

            if (qualification == null)
                return Fail(RequestState.NotFound);

            int? specialityId;
            var specialityType = model.GetRequestedType();

            switch (specialityType)
            {
                case SpecialityType.Speciality:
                    specialityId = model.SpecialtyId;
                    break;
                case SpecialityType.SubSpeciality:
                    specialityId = model.SubSpecialtyId;
                    break;
                case SpecialityType.ExactSpeciality:
                    specialityId = model.ExactSpecialtyId;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            qualification.Modify()
               .Employee(model.EmployeeId)
               .QualificationType(model.QualificationTypeId)
               .Date(model.Date.ToDateTime())
               .GraduationCountry(model.GraduationCountry)
               .NameDonorFoundation(model.NameDonorFoundation)
               .Specialty(specialityType, specialityId)
               .AquiredSpecialty(model.AquiredSpecialty)
               .DonorFoundationType(model.DonorFoundationType)
               .Grade(model.Grade)
               .Confirm();

            UnitOfWork.Complete(n => n.Qualification_Edit);

            Clear(model);
            return SuccessEdit();
        }

        public bool Delete(QualificationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Qualification_Delete))
                return Fail(RequestState.NoPermission);

            if (model.QualificationId <= 0)
                return Fail(RequestState.BadRequest);

            var qualification = UnitOfWork.Qualifications.Find(model.QualificationId);

            if (qualification == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Qualifications.Remove(qualification);

            if (!UnitOfWork.TryComplete(n => n.Qualification_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }



        private void Clear(QualificationModel model)
        {
            model.QualificationId = 0;
            model.Date = "";
            model.QualificationTypeId = 0;
            model.GraduationCountry = "";
            model.NameDonorFoundation = "";
            model.AquiredSpecialty = "";
            model.ExactSpecialtyId = 0;
            model.SubSpecialtyId = 0;
            model.SpecialtyId = 0;
        }

        public void Report(QualificationModel model)
        {
            var qualificationReportDto = new QualificationReportDto()
            {
                AquiredSpecialty = model.AquiredSpecialty,
                ExactSpecialtyId = model.ExactSpecialtyId ?? 0,
                QualificationTypeId = model.QualificationTypeId,
                SpecialtyId = model.SpecialtyId,
                SubSpecialtyId = model.SubSpecialtyId ?? 0,
            };

            model.QualificationGrid = UnitOfWork.Qualifications.GetQualificationReport(qualificationReportDto).ToGrid();
            //  model.QualificationGrid = qualificationGrid;
            //if (model.QualificationTypeId > 0)

            return;
        }

    }
}