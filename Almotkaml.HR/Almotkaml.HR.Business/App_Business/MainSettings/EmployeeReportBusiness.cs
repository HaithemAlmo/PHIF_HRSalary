using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;
using Almotkaml.HR.Repository;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class EmployeeReportBusiness : Business, IEmployeeReportBusiness
    {
        public EmployeeReportBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        public EmployeeReportModel Prepare()
        {
            return new EmployeeReportModel()
            {

                QualificationTypeList2 = UnitOfWork.QualificationTypes.GetAll().ToList(),
                ClassificationOnWorkList = UnitOfWork.ClassificationOnWorks.GetAll().ToList(),
                BranchList = UnitOfWork.Branches.GetAll().ToList(),
                CenterList = UnitOfWork.Centers.GetAll().ToList(),
                AdjectiveEmployeeTypeList = UnitOfWork.AdjectiveEmployeeTypes.GetAll().ToList(),
                CurrentSituationList2 = UnitOfWork.CurrentSituations.GetAll().ToList2(),
                JobList = UnitOfWork.Jobs.GetAll().ToList(),
                NationalityList = UnitOfWork.Nationalities.GetAll().ToList(),
                ClassificationOnSearchingList = UnitOfWork.ClassificationOnSearchings.GetAll().ToList(),
                StaffingTypeList = UnitOfWork.StaffingTypes.GetAll().ToList()
            };
        }

        public void Refresh(EmployeeReportModel model)
        {
            if (model == null)
                return;

            model.PlaceList = model.BranchId > 0
                ? UnitOfWork.Places.GetPlaceWithBranch(model.BranchId ?? 0).ToList()
                : new HashSet<PlaceListItem>();

            model.AdjectiveEmployeeList = model.AdjectiveEmployeeTypeId > 0
                    ? UnitOfWork.AdjectiveEmployees.GetAdjectiveEmployeeWithType(model.AdjectiveEmployeeTypeId ?? 0).ToList()
                    : new HashSet<AdjectiveEmployeeListItem>();

            model.DepartmentList = model.CenterId > 0
                ? UnitOfWork.Departments.GetDepartmentWithCenter(model.CenterId ?? 0).ToList()
                : new HashSet<DepartmentListItem>();

            model.DivisionList = model.DepartmentId > 0
                ? UnitOfWork.Divisions.GetDivisionWithDepartment(model.DepartmentId ?? 0).ToList()
                : new HashSet<DivisionListItem>();

            if (model.DivisionId > 0)
                model.UnitList = UnitOfWork.Units.GetUnitWithDivision(model.DivisionId ?? 0).ToList();
            else
                model.UnitList = new HashSet<UnitListItem>();

            model.StaffingList = model.StaffingTypeId > 0
                ? UnitOfWork.Staffings.GetStaffingWithStaffingType(model.StaffingTypeId ?? 0).ToList()
                : new HashSet<StaffingListItem>();

        }
        public void CheckCkeckBox ( EmployeeReportModel model)
        {
            CheckBoxNumber();
            
        }
        public bool SearchReports(EmployeeReportModel model)
        {
            var GetEmployess = UnitOfWork.Employees.GetAll().ToList();
            var grid = new List<EmployeeReportGridRow>();

            if (model.AgeFromTo==true)
            {
             //   var SerchAge= GetEmployess.Where(s=>s.BirthDate.Value.y)
            }
            if (model.GenderCheck==true)
            {
                foreach (var row in GetEmployess.Where(s => s.Gender == model.Gender).ToList())
                {
                    grid.Add(new EmployeeReportGridRow()
                    {
                        JobNumber = row.EmployeeId.ToString(),
                        FullName = row.GetFullName(),
                        Email = row.JobInfo.Unit.Division.Department.Name,
                        DivisionName = row.JobInfo.Unit.Division.Name,
                        UnitName = row.JobInfo.Unit.Name

                    });
                }
                    model.Grid = grid;
            }

            if (model.ToBirthCheck == true)
            {

            }
            if (model.CenterCheck == true)
            {

            }
            if (model.cityCheck == true)
            {

            }
            if (model.EndedEmpCheck == true)
            {

            }
            if (model.ToBirthCheck == true)
            {

            }
            return true;
        }
        public bool Search(EmployeeReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var employeeReportDto = new EmployeeReportDto()
            {


                CurrentSituationList = model.CurrentSituationList2,
                ChildrenCount = model.ChildernCount ?? 0,
                //DateOfAppointmentDecision=model.dateo
                EvaluationDate2 = model.EvaluationDate2 ?? 0,
                EvaluationDate3 = model.EvaluationDate3 ?? 0,
                EnglishName = model.EnglishFirstName,
                EvaluationDate = model.EvaluationDate ?? 0,
                JobType = model.JobType,
                Degree = model.Degree ?? 0,
                CenterId = model.CenterId ?? 0,
                ClassificationOnWorkId = model.ClassificationOnWorkId ?? 0,
                ClassificationOnSearchingId = model.ClassificationOnSearchingId ?? 0,
                JobNumber = model.JobNumber,
                Phone = model.Phone,
                NationalityId = model.NationalityId ?? 0,
                Address = model.Address,
                DegreeNow = model.DegreeNow ?? 0,
                VacationBalance = model.VacationBalance ?? 0,
                AdjectiveEmployeeId = model.AdjectiveEmployeeId ?? 0,
                AdjectiveEmployeeTypeId = model.AdjectiveEmployeeTypeId ?? 0,
                AdjectiveMilitary = model.AdjectiveMilitary,
                BirthDateFrom = model.BirthDateFrom.ToNullableDateTime(),
                BirthDateTo = model.BirthDateTo.ToNullableDateTime(),
                BirthPlace = model.BirthPlace,
                BloodType = model.BloodType,
                BookletCivilRegistry = model.Booklet.CivilRegistry,
                BookletFamilyNumber = model.Booklet.FamilyNumber,
                BookletIssueDate = model.Booklet.IssueDate.ToNullableDateTime(),
                BookletIssuePlace = model.Booklet.IssuePlace,
                BookletNumber = model.Booklet.Number,
                BookletRegistrationNumber = model.Booklet.RegistrationNumber,
                Bouns = model.Bouns ?? 0,
                BranchId = model.BranchId ?? 0,
                ChildernCount = model.ChildernCount ?? 0,
                College = model.College,
                ContactInfoAddress = model.ContactInfo.Address,
                ContactInfoNearKindr = model.ContactInfo.NearKindr,
                ContactInfoNearPoint = model.ContactInfo.NearPoint,
                ContactInfoNote = model.ContactInfo.Note,
                ContactInfoPhone = model.ContactInfo.Phone,
                ContactInfoRelativeRelation = model.ContactInfo.RelativeRelation,
                ContactInfoWorkAddress = model.ContactInfo.WorkAddress,
                CurrentSituationId = model.CurrentSituationId ?? 0,
                DateBounsFrom = model.DateBounsFrom.ToNullableDateTime(),
                DateBounsTo = model.DateBounsFrom.ToNullableDateTime(),
                DateDegreeNowFrom = model.DateDegreeNowFrom.ToNullableDateTime(),
                DateDegreeNowTo = model.DateDegreeNowTo.ToNullableDateTime(),
                DateMeritBouns = model.DateMeritBounsTo.ToNullableDateTime(),
                DateMeritDegreeNowFrom = model.DateMeritDegreeNowFrom.ToNullableDateTime(),
                DateMeritDegreeNowTo = model.DateMeritDegreeNowTo.ToNullableDateTime(),
                //DegreeLastResolutionNumber = model.DegreeLastResolutionNumber ?? 0,
                DepartmentId = model.DepartmentId ?? 0,
                DirectlyDateFrom = model.DirectlyDateFrom.ToNullableDateTime(),
                DirectlyDateTo = model.DirectlyDateTo.ToNullableDateTime(),
                DivisionId = model.DivisionId ?? 0,
                Email = model.Email,
                EnglishFatherName = model.EnglishFatherName,
                EnglishFirstName = model.EnglishFirstName,
                EnglishGrandfatherName = model.EnglishGrandfatherName,
                EnglishLastName = model.EnglishLastName,
                FatherName = model.FatherName,
                FirstName = model.FirstName,
                Gender = model.Gender,
                //QualificationTypeId = model.QualificationTypeId??0,
                GrandfatherName = model.GrandfatherName,
                GranduationDateFrom = model.GranduationDateFrom.ToNullableDateTime(),
                GranduationDateTo = model.GranduationDateTo.ToNullableDateTime(),
                IdentificationCardIssueDateFrom = model.IdentificationCardIssueDateFrom.ToNullableDateTime(),
                IdentificationCardIssueDateTo = model.IdentificationCardIssueDateTo.ToNullableDateTime(),
                IdentificationCardIssuePlace = model.IdentificationCard.IssuePlace,
                IdentificationCardNumber = model.IdentificationCard.Number,
                JobId = model.JobId ?? 0,
                JobInfoNotes = model.Notes,
                JobNumberApproved = model.JobNumberApproved ?? 0,
                LastName = model.LastName,
                LibyanOrForeigner = model.LibyanOrForeigner,
                MilitaryNumber = model.MilitaryNumber,
                MotherName = model.MotherName,
                MotherUnit = model.MotherUnit,
                NationalNumber = model.NationalNumber,
                PassportAutoNumber = model.Passport.AutoNumber,
                PassportIssueDateFrom = model.PassportIssueDateFrom.ToNullableDateTime(),
                PassportIssueDateTo = model.PassportIssueDateTo.ToNullableDateTime(),
                PassportIssuePlace = model.Passport.IssuePlace,
                PassportNumber = model.Passport.Number,
                PlaceId = model.PlaceId ?? 0,
                Rank = model.Rank,
                Religion = model.Religion,
                SocialStatus = model.SocialStatus,
                StaffingId = model.StaffingId ?? 0,
                StaffingTypeId = model.StaffingTypeId ?? 0,
                Subunit = model.Subunit,

                UnitId = model.UnitId ?? 0,

            };

            { }
            var employees = UnitOfWork.Employees.GetEmployeeReport(employeeReportDto).ToList();
            ManPowerReport(model);
            if (employees == null)
                return false;

            var grid = new List<EmployeeReportGridRow>();


            foreach (var employee in employees)
            {
                grid.Add(new EmployeeReportGridRow()
                {

                    choldrenCount = employee?.ChildernCount ?? 0,
                    DateOfAppointmentDecision = employee?.JobInfo?.EmploymentValues?.DesignationResolutionDate.Value.Year + "-" +
                                                employee?.JobInfo?.EmploymentValues?.DesignationResolutionDate.Value.Month + "-" +
                                                employee?.JobInfo?.EmploymentValues?.DesignationResolutionDate.Value.Day,
                    NumberOfAppointmentDecision = employee?.JobInfo?.EmploymentValues?.DesignationResolutionNumber,

                    EvaluationDate2 = employee?.Evaluations?.FirstOrDefault(e => e?.Year == model?.EvaluationDate3)?.Year ?? 0,
                    EvaluationDate3 = employee?.Evaluations?.FirstOrDefault(e => e?.Year == model?.EvaluationDate2)?.Year ?? 0,

                    EvaluationDate = employee?.Evaluations?.FirstOrDefault(e => e?.Year == model?.EvaluationDate)?.Year ?? 0,
                    BookFamilySourceNumber = employee?.BookFamilySourceNumber,
                    DegreeNote = employee?.JobInfo?.DegreeNote,
                    NationaltyMother = employee?.NationaltyMother,
                    EvaluationRatio = employee?.Evaluations?.FirstOrDefault(e => e?.Year == model?.EvaluationDate)?.Ratio ?? 0,
                    EvaluationRatio2 = employee?.Evaluations?.FirstOrDefault(e => e?.Year == model?.EvaluationDate2)?.Ratio ?? 0,
                    EvaluationRatio3 = employee?.Evaluations?.FirstOrDefault(e => e?.Year == model?.EvaluationDate3)?.Ratio ?? 0,

                    Evaluation2 = employee?.Evaluations?.FirstOrDefault(e => e?.Year == model?.EvaluationDate2)?.Grade ?? 0,
                    Evaluation3 = employee?.Evaluations?.FirstOrDefault(e => e?.Year == model?.EvaluationDate3)?.Grade ?? 0,
                    Evaluation = employee?.Evaluations?.FirstOrDefault(e => e?.Year == model?.EvaluationDate)?.Grade ?? 0,
                    FullName = employee?.GetFullName(),
                    DonorFoundation = employee?.Qualifications?.FirstOrDefault()?.NameDonorFoundation,
                    Qualification = employee?.Qualifications?.FirstOrDefault()?.QualificationType?.Name,
                    DateQualification = employee?.Qualifications?.FirstOrDefault()?.Date.Date,
                    Specialty = employee?.Qualifications?.FirstOrDefault()?.Specialty?.Name,
                    SecurityNumber = employee?.SalaryInfo?.SecurityNumber,
                    Notes = employee?.JobInfo?.Notes,
                    JobType = employee?.JobInfo?.JobType ?? 0,
                    Degree = employee?.JobInfo?.Degree ?? 0,
                    CenterName = employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,
                    ClassificationOnWorkName = employee?.JobInfo?.ClassificationOnSearching?.Name,
                    ClassificationOnSearchingName = employee?.JobInfo?.ClassificationOnSearching?.Name,
                    JobNumber = employee?.JobInfo?.JobClassValu + employee?.JobInfo?.GetJobNumber(),
                    Phone = employee?.Phone,
                    NationalityName = employee?.Nationality?.Name,
                    Address = employee?.Address,
                    DegreeNow = employee?.JobInfo?.DegreeNow ?? 0,
                    VacationBalance = employee?.JobInfo?.VacationBalance ?? 0,
                    AdjectiveEmployeeName = employee?.JobInfo?.AdjectiveEmployee?.Name,
                    AdjectiveEmployeeTypeName = employee?.JobInfo?.AdjectiveEmployee?.AdjectiveEmployeeType?.Name,
                    AdjectiveMilitary = employee?.MilitaryData?.AdjectiveMilitary ?? 0,
                    BirthDate = employee?.BirthDate?.FormatToString(),
                    BirthPlace = employee?.BirthPlace,
                    BloodType = employee?.BloodType ?? 0,

                    BookletCivilRegistry = employee?.Booklet?.CivilRegistry,
                    BookletFamilyNumber = employee?.Booklet?.FamilyNumber,
                    BookletIssueDate = employee?.Booklet?.IssueDate?.FormatToString(),
                    BookletIssuePlace = employee?.Booklet?.IssuePlace,
                    BookletNumber = employee?.Booklet?.Number,
                    BookletRegistrationNumber = employee?.Booklet?.RegistrationNumber,
                    Bouns = employee?.JobInfo?.Bounshr ?? 0,
                    BranchName = employee?.Place?.Branch?.Name,
                    ChildernCount = employee?.ChildernCount ?? 0,
                    College = employee?.MilitaryData?.College,
                    ContactInfoAddress = employee?.ContactInfo?.Address,
                    ContactInfoNearKindr = employee?.ContactInfo?.NearKindr,
                    ContactInfoNearPoint = employee?.ContactInfo?.NearPoint,
                    ContactInfoNote = employee?.ContactInfo?.Note,
                    ContactInfoPhone = employee?.ContactInfo?.Phone,
                    ContactInfoRelativeRelation = employee?.ContactInfo?.RelativeRelation,
                    ContactInfoWorkAddress = employee?.ContactInfo?.WorkAddress,
                    CurrentSituationName = employee?.JobInfo?.CurrentSituation?.Name,
                    DateBouns = employee?.JobInfo?.DateBouns?.FormatToString(),
                    DateDegreeNow = employee?.JobInfo?.DateDegreeNow?.FormatToString(),
                    DateMeritBouns = employee?.JobInfo?.DateMeritBouns?.FormatToString(),
                    DateMeritDegreeNow = employee?.JobInfo?.DateMeritDegreeNow?.FormatToString(),
                    //DegreeLastResolutionNumber = employee?.JobInfo??.DegreeLastResolutionNumber ?? 0,
                    DepartmentName = employee?.JobInfo?.Unit?.Division?.Department?.Name,
                    DirectlyDate = employee?.JobInfo?.DirectlyDate?.FormatToString(),
                    DivisionName = employee?.JobInfo?.Unit?.Division?.Name,
                    Email = employee?.Email,
                    EnglishFatherName = employee?.EnglishFatherName,
                    EnglishFirstName = employee?.EnglishFirstName,
                    EnglishGrandfatherName = employee?.EnglishGrandfatherName,
                    EnglishLastName = employee?.EnglishLastName,
                    FatherName = employee?.FatherName,
                    FirstName = employee?.FirstName,
                    Gender = employee?.Gender ?? 0,
                    //  QualificationTypeId=employee.Qualifications.Select(s=>s.QualificationType.Name).First(),
                    GrandfatherName = employee?.GrandfatherName,
                    GranduationDate = employee?.MilitaryData?.GranduationDate?.FormatToString(),
                    IdentificationCardIssueDate = employee?.IdentificationCard?.IssueDate?.FormatToString(),
                    IdentificationCardIssuePlace = employee?.IdentificationCard?.IssuePlace,
                    IdentificationCardNumber = employee?.IdentificationCard?.Number,
                    JobName = employee?.JobInfo?.Job?.Name,
                    JobInfoNotes = employee?.JobInfo?.Notes,
                    JobNumberApproved = employee?.JobInfo?.JobNumberApproved ?? 0,
                    LastName = employee?.LastName,
                    LibyanOrForeigner = employee?.LibyanOrForeigner ?? 0,
                    MilitaryNumber = employee?.MilitaryData?.MilitaryNumber,
                    MotherName = employee?.MotherName,
                    MotherUnit = employee?.MilitaryData?.MotherUnit,
                    NationalNumber = employee?.NationalNumber,
                    PassportAutoNumber = employee?.Passport?.AutoNumber,
                    PassportIssueDate = employee?.Passport?.IssueDate?.FormatToString(),
                    PassportIssuePlace = employee?.Passport?.IssuePlace,
                    PassportNumber = employee?.Passport?.Number,
                    PlaceName = employee?.Place?.Name,
                    Rank = employee?.MilitaryData?.Rank,
                    Religion = employee?.Religion ?? 0,
                    SocialStatus = employee?.SocialStatus ?? 0,
                    StaffingName = employee?.JobInfo?.Staffing?.Name,
                    StaffingTypeName = employee?.JobInfo?.Staffing?.StaffingType?.Name,
                    Subunit = employee?.MilitaryData?.Subunit,
                    UnitName = employee?.JobInfo?.Unit?.Name,
                });
            }
            CheckBoxNumber();
            model.Grid = grid;
            return true;
        }
        //  ﬁ—Ì— «·ﬁÊ… «·⁄„Ê„Ì… 16_11_2019
        public bool ManPowerReport(EmployeeReportModel model)
        {
            var report = UnitOfWork.Employees.GetEmployeeReport2().ToList();

            if (report == null)
                return false;

            var grid = new List<ManPowerReportGridRow>();
            // var grid2 = UnitOfWork.Absences.GetAll();


            foreach (var row in report)
            {

                grid.Add(new ManPowerReportGridRow()
                {
                    AdjectiveEmployeeType = row.AdjectiveEmployeeType,
                    PhDCount = row.PhDCount,
                    MasterCount = row.MasterCount,
                    DiplomaCount = row.DiplomaCount,
                    EngCount = row.EngCount,
                    AssistantCount = row.AssistantCount,
                    CraftsmanCount = row.CraftsmanCount,
                    OperationalCount = row.OperationalCount,
                });

                CheckBoxNumber();

            }
            //var g = grid.Distinct().ToList();
            model.ManPowerReportGrid = grid;
            return true;
        }

        public void CheckCkeckBox2(EmployeeReportModel model)
        {
            CheckBoxNumber2();
        }
    }
}