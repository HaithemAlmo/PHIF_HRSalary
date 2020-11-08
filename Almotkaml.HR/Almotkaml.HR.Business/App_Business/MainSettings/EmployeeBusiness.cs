using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using Almotkaml.HR.Repository;
using Almotkaml.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class EmployeeBusiness : Business, IEmployeeBusiness
    {
        public EmployeeBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        protected bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Employee && permission;
        private bool HaveDocumentPermission(bool permission = true)
            => ApplicationUser.Permissions.Employee && ApplicationUser.Permissions.Document && permission;

        public EmployeeIndexModel Index()
        {
            if (!HavePermission())
                return Null<EmployeeIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.Employees.GetGride().ToList();


            return new EmployeeIndexModel()
            {
                CenterList = UnitOfWork.Centers.GetAll().ToList(),

                EmployeeGrid = grid.ToGrid(),
                CanCreate = ApplicationUser.Permissions.Employee_Create,
                CanEdit = ApplicationUser.Permissions.Employee_Edit,
                CanDelete = ApplicationUser.Permissions.Employee_Delete,
            };
        }
        public virtual void Refresh(EmployeeIndexModel model)
        {
            var employeeReportDto = new EmployeeReportDto()
            {
                CenterId = model.CenterId ?? 0,
                DivisionId = model.DivisionId ?? 0,
                UnitId = model.UnitId ?? 0,
                DepartmentId = model.DepartmentId ?? 0

            };
            var List = UnitOfWork.Employees.GetEmployeeReport(employeeReportDto).ToList();
            model.EmployeeGrid = List.ToGrid();
            model.CenterList = UnitOfWork.Centers.GetAll().ToList();


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


        public void Refresh(PersonalModel model)
        {
            if (model == null)
                return;

            model.PlaceList = model.BranchId > 0
                ? UnitOfWork.Places.GetPlaceWithBranch(model.BranchId ?? 0).ToList()
                : new HashSet<PlaceListItem>();
        }

        public virtual void Refresh(int id, JobInfoModel model)
        {
            if (model == null)
                return;

            model.AdjectiveEmployeeList = model.AdjectiveEmployeeTypeId > 0
                ? UnitOfWork.AdjectiveEmployees.GetAdjectiveEmployeeWithType(model.AdjectiveEmployeeTypeId.Value).ToList()
                : new HashSet<AdjectiveEmployeeListItem>();

            model.DepartmentList = model.CenterId > 0
                ? UnitOfWork.Departments.GetDepartmentWithCenter(model.CenterId).ToList()
                : new HashSet<DepartmentListItem>();

            model.DivisionList = model.DepartmentId > 0
                ? UnitOfWork.Divisions.GetDivisionWithDepartment(model.DepartmentId).ToList()
                : new HashSet<DivisionListItem>();

            if (model.DivisionId > 0)
                model.UnitList = UnitOfWork.Units.GetUnitWithDivision(model.DivisionId).ToList();
            else
                model.UnitList = new HashSet<UnitListItem>();


            model.StaffingTypeList = UnitOfWork.StaffingTypes.GetAll().ToList();

            model.StaffingList = model.StaffingTypeId > 0
                ? UnitOfWork.Staffings.GetStaffingWithStaffingType(model.StaffingTypeId ?? 0).ToList()
                : new HashSet<StaffingListItem>();

            model.StaffingClassificationList = model.StaffingId > 0
                ? UnitOfWork.Staffings.GetStaffingType(model.StaffingId ?? 0).ToList().Select(d => new StaffingClassificationListItem
                {
                    Name = d.Name,
                    StaffingClassificationId = d.StaffingClassificationId,
                })
                : new HashSet<StaffingClassificationListItem>();

            var employee = UnitOfWork.Employees.Find(id);

            if (employee == null)
                return;

            model.CenterNumber = UnitOfWork.Centers.GetCenterNumberBy(model.CenterId);

            model.JobNumber = employee.JobInfo == null || employee.JobInfo.JobNumber == 0
               ? UnitOfWork.Employees.GetJobNumber()
               : (int)employee.JobInfo?.JobNumber;
            //HALEEM                    
            int num = (int)model.JobClass;
            var jobnumclass = num.ToString() + model.JobNumber.ToString();
            model.JobNumber = int.Parse(jobnumclass);
            model.Bouns = employee.JobInfo?.Bouns;
        }

        public void Refresh(MilitaryDataModel model)
        {
        }

        public void Refresh(DocumentModel model)
        {
            if (model.DocumentTypeId > 0)
            {
                var documentType = UnitOfWork.DocumentTypes.Find(model.DocumentTypeId);

                if (documentType == null)
                {
                    Fail(SharedMessages.NotExisted);
                    return;
                }

                model.HaveDecisionNumber = documentType.HaveDecisionNumber;
                model.HaveDecisionYear = documentType.HaveDecisionYear;
                model.HaveExpireDate = documentType.HaveExpireDate;
            }
            else
            {
                model.HaveDecisionNumber = false;
                model.HaveDecisionYear = false;
                model.HaveExpireDate = false;
            }
        }

        //public void Refresh(SalaryInfoModel model)
        //{
        //    if (model == null)
        //        return;

        //    model.BankBranchList = model.BankId > 0
        //        ? UnitOfWork.BankBranches.GetBankBranchWithBank(model.BankId).ToList()
        //        : new HashSet<BankBranchListItem>();
        //}

        public PersonalModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Employee_Create))
                return Null<PersonalModel>(RequestState.NoPermission);

            return new PersonalModel()
            {
                NationalityList = UnitOfWork.Nationalities.GetAll().ToList(),
                BranchList = UnitOfWork.Branches.GetAll().ToList(),
                CanSubmit = ApplicationUser.Permissions.Employee_Create
            };
        }

        public JobInfoDegreeModel PrepareJobInfoDegree()
        {


            return new JobInfoDegreeModel()
            {

                DegreeGrid = UnitOfWork.Employees.GetEmployeeDegree().ToDegreeGrid(),
                //JobList = UnitOfWork.Jobs.GetAll().ToList(),
                CanEdit = ApplicationUser.Permissions.Employee_Edit,
                CanSubmit = ApplicationUser.Permissions.Employee_Create,
                CanPromotion = ApplicationUser.Permissions.Employee_Promotion,
                CanSettlement = ApplicationUser.Permissions.Employee_Settlement

            };
        }

        public void Refresh(JobInfoDegreeModel model)
        {



            if (!HavePermission(ApplicationUser.Permissions.Employee_Promotion))
                return;


            //var grid = UnitOfWork.Employees.GetGride().ToList();

            model.DegreeGrid = UnitOfWork.Employees.GetEmployeeDegree().ToDegreeGrid();

            if (model.PromotionType > 0 && model.PromotionType == PromotionType.PromotionEnt)
                model.DegreeGrid = model.DegreeGrid.Where
                    (d => d.DateDegreeNow.ToDateTime().AddYears(10) >= DateTime.Now).ToList();

            else
                model.DegreeGrid = model.DegreeGrid.Where
            (d => d.DateDegreeNow.ToDateTime().AddYears(3) < DateTime.Now).ToList();


            if (model.PromotionSeason > 0 && model.PromotionSeason == PromotionSeason.FirstOfYear)
                model.DegreeGrid = model.DegreeGrid.Where
                    (d => d.DateDegreeNow.ToDateTime().Month <= 6 && 
                    d.DateDegreeNow.ToDateTime().Day <= 31).ToList();
           else model.DegreeGrid = model.DegreeGrid.Where
                   (d => d.DateDegreeNow.ToDateTime().Month > 6 && d.DateDegreeNow.ToDateTime().Month <=12 &&
                    d.DateDegreeNow.ToDateTime().Day <= 31).ToList();


            model.CanSubmit = ApplicationUser.Permissions.Employee_Edit;
            model.CanEdit = ApplicationUser.Permissions.Employee_Edit;
            model.CanPromotion = ApplicationUser.Permissions.Employee_Promotion;
            model.CanSettlement = ApplicationUser.Permissions.Employee_Settlement;
            model.PromotionType = model.PromotionType;
            model.PromotionSeason = model.PromotionSeason;

        }


        public QualificationModel Prepare1()
        {
            if (!HavePermission(ApplicationUser.Permissions.Qualification))
                return Null<QualificationModel>(RequestState.NoPermission);

            return new QualificationModel()
            {
                CanCreate = ApplicationUser.Permissions.Evaluation_Create,
                CanEdit = ApplicationUser.Permissions.Evaluation_Edit,
                CanDelete = ApplicationUser.Permissions.Evaluation_Delete,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                QualificationGrid = UnitOfWork.Qualifications.GetQualificationByEmployeeId(0).ToGrid(),
                SpecialtyList = UnitOfWork.Specialties.GetAll().ToList(),
                QualificationTypeList = UnitOfWork.QualificationTypes.GetAll().ToList(),
            };
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
               .AquiredSpecialty(model.AquiredSpecialty)
               .Confirm();

            UnitOfWork.Complete(n => n.Qualification_Edit);

            //
            return SuccessEdit();
        }
        //public bool Edit(int id, QualificationModel model)
        //{
        //    if (id <= 0)
        //        return Fail(RequestState.BadRequest);

        //    if (!HavePermission(ApplicationUser.Permissions.Qualification_Edit))
        //        return Fail(RequestState.NoPermission);

        //    if (!ModelState.IsValid(model))
        //        return false;

        //    var Qualification = UnitOfWork.Qualifications.Find(id);

        //    //if (Qualification.q == null)
        //    //    return false;
        //    var modifier = Qualification.Modify()
        //        .QualificationType(model.QualificationTypeId)
        //       // .Specialty(model..SpecialtyId)
        //        .AquiredSpecialty(model.AquiredSpecialty)

        //                    .Date((DateTime.Parse(model.Date)))
        //        .DonorFoundationType(model.DonorFoundationType)
        //        .Grade(model.Grade)
        //        .GraduationCountry(model.GraduationCountry)
        //        .NameDonorFoundation(model.NameDonorFoundation)


        //        .Confirm();

        //    UnitOfWork.Complete(n => n.Qualification_Edit);

        //    return SuccessEdit();
        //}

        public bool Create(PersonalModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Employee_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;
            var employeeAll = UnitOfWork.Employees.GetAll();


            var employee = Employee.New()
               .WithFirstName(model.FirstName, model.EnglishFirstName)
               .WithFatherName(model.FatherName, model.EnglishFatherName)
               .WithGrandfatherName(model.GrandfatherName, model.EnglishGrandfatherName)
               .WithLastName(model.LastName, model.EnglishLastName)
               .WithMotherName(model.MotherName)
               .WithGender(model.Gender)
               .WithBirthDate(model.BirthDate.ToDateTime())
               .WithBirthPlace(model.BirthPlace)
               .WithNationalNumber(model.NationalNumber)
               .WithReligion(model.Religion)
               .WithNationalityId(model.NationalityId)
               .WithWifeNationalityId(model.NationalityId)/////////
               .WithPlaceId(model.PlaceId)
               .WithAddress(model.Address)
               .WithPhone(model.Phone)
               .WithEmail(model.Email)
               .WithSocialStatus(model.SocialStatus)
               .WithChildernCount(model.ChildernCount)
               .WithBloodType(model.BloodType)
               .WithIsActive(model.IsActive)
               .WithBooklet(model.Booklet?.ToDomain())
               .WithPassport(model.Passport?.ToDomain())
               .WithIdentificationCard(model.IdentificationCard?.ToDomain())
               .WithImage(model.Image)
               .WithContactInfo(model.ContactInfo?.ToDomain())
               .Biuld();

            UnitOfWork.Employees.Add(employee);

            UnitOfWork.Complete(n => n.Employee_Create);
            model.EmployeeId = employee.EmployeeId;
            return SuccessCreate();
        }
        //public bool Create(Qualification model)
        //{
        //    if (!HavePermission(ApplicationUser.Permissions.Qualification_Create))
        //        return Fail(RequestState.NoPermission);

        //    if (!ModelState.IsValid(model))
        //        return false;
        //    var employeeAll = UnitOfWork.Qualifications.GetAll();


        //    var qualification = Qualification.New()


        //        .WithEmployeeId()




        //       .Biuld();

        //    UnitOfWork.Qualifications.Add(qualification);

        //    UnitOfWork.Complete(n => n.Qualification_Create);
        //    model.EmployeeId = employee.EmployeeId;
        //    return SuccessCreate();
        //}
        public virtual EmployeeFormModel Find(int id)
        {
            if (!HavePermission(ApplicationUser.Permissions.Employee_Edit))
                return Null<EmployeeFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<EmployeeFormModel>(RequestState.BadRequest);

            var employee = UnitOfWork.Employees.Find(id);

            if (employee == null)
                return Null<EmployeeFormModel>(RequestState.NotFound);

            var branchId = employee.Place?.Branch?.BranchId ?? 0;
            var adjectiveEmployeeTypeId = employee.JobInfo?.AdjectiveEmployee?.AdjectiveEmployeeTypeId ?? 0;
            var staffingTypeId = employee.JobInfo?.Staffing?.StaffingTypeId ?? 0;
            var staffingId = employee.JobInfo?.StaffingId ?? 0;
            var departmentId = employee.JobInfo?.Unit?.Division?.DepartmentId ?? 0;
            var divisionId = employee.JobInfo?.Unit?.DivisionId ?? 0;
            var centerId = employee.JobInfo?.Unit?.Division?.Department?.CenterId ?? 0;

            var classificationOnSearchingId = employee.JobInfo?.ClassificationOnSearchingId ?? 0;
            var classificationOnWorkId = employee.JobInfo?.ClassificationOnWorkId ?? 0;
            var jobNumber = employee.JobInfo != null && employee.JobInfo.JobNumber > 0
                ? employee.JobInfo.JobNumber
                : UnitOfWork.Employees.GetJobNumber();
            //HALEEM     
            var jobcalssnum = employee.JobInfo?.JobClassValu ?? 0;
            JobClass num = (JobClass)jobcalssnum;
            var jobnmber = jobcalssnum.ToString() + jobNumber.ToString();
            //end
            var documents = UnitOfWork.Documents.GetByEmployee(employee);
            var Qualification = UnitOfWork.Qualifications.GetQualificationByEmployee(employee);

            var Transfer = UnitOfWork.Transfers.GetTransferByEmployeeId(id).ToGrid()
                           .Where(t => t.DateFrom.ToDateTime() <= DateTime.Now && t.DateTo.ToDateTime() >= DateTime.Now).FirstOrDefault();
            //if (Transfer != null)
            //    var currentsituation = Transfer.JobTypeTransfer;
            return new EmployeeFormModel()
            {
                JobInfoModel =
                {
                     JobNumber = int.Parse(jobnmber),
                    AdjectiveEmployeeId = employee.JobInfo?.AdjectiveEmployeeId ?? 0,
                    AdjectiveEmployeeTypeId = employee.JobInfo?.AdjectiveEmployee?.AdjectiveEmployeeTypeId ?? 0,
                    EmploymentValues = employee.JobInfo?.EmploymentValues?.ToModel(),
                    EmployeeId = employee.EmployeeId,
                    Bouns = employee.JobInfo?.Bouns ?? 0,
                    DateMeritBouns = employee.JobInfo?.DateMeritBouns.FormatToString() ?? "",
                    StaffingId = employee.JobInfo?.StaffingId ?? 0,
                    StaffingClassificationId= employee.JobInfo?.StaffingClassificationId ?? 0,
                    JobNumberApproved = employee.JobInfo?.JobNumberApproved ?? 0,
                    UnitId = employee.JobInfo?.UnitId ?? 0,
                    DateMeritDegreeNow = employee.JobInfo?.DateMeritDegreeNow.FormatToString() ?? "",
                    DegreeNow = employee.JobInfo?.DegreeNow ?? 0,
                    DateDegreeNow = employee.JobInfo?.DateDegreeNow.FormatToString() ?? "",
                    CurrentSituationId = employee.JobInfo?.CurrentSituationId ?? 0,
                    DateBouns = employee.JobInfo?.DateBouns.FormatToString() ?? "",
                    StaffingTypeId = employee.JobInfo?.Staffing?.StaffingTypeId ?? 0,
                    JobId = employee.JobInfo?.JobId ?? 0,
                    DirectlyDate = employee.JobInfo?.DirectlyDate.FormatToString() ?? "",
                    Degree = employee.JobInfo?.Degree ?? 0,
                    DepartmentId = employee.JobInfo?.Unit?.Division?.DepartmentId ?? 0,
                    DivisionId = employee.JobInfo?.Unit?.DivisionId ?? 0,
                    CenterId = centerId,
                    JobClass=num,
                    AdjectiveEmployeeList = UnitOfWork.AdjectiveEmployees.GetAdjectiveEmployeeWithType(adjectiveEmployeeTypeId).ToList(),
                    AdjectiveEmployeeTypeList = UnitOfWork.AdjectiveEmployeeTypes.GetAll().ToList(),
                    CurrentSituationList = UnitOfWork.CurrentSituations.GetAll().ToList(),
                    JobList = UnitOfWork.Jobs.GetAll().ToList(),
                    //NoteList = UnitOfWork..GetPlaceWithBranch(branchId).ToList(),//////
                    StaffingList = UnitOfWork.Staffings.GetStaffingWithStaffingType(staffingTypeId).ToList(),
                    StaffingClassificationList= UnitOfWork.StaffingClassification.GetWithStaffings(staffingId).ToList(),
                    StaffingTypeList = UnitOfWork.StaffingTypes.GetAll().ToList(),
                    CenterList = UnitOfWork.Centers.GetAll().ToList(),
                    DepartmentList = UnitOfWork.Departments.GetDepartmentWithCenter(centerId).ToList(),
                    DivisionList = UnitOfWork.Divisions.GetDivisionWithDepartment(departmentId).ToList(),
                    UnitList = UnitOfWork.Units.GetUnitWithDivision(divisionId).ToList(),
                    JobType = employee.JobInfo?.JobType ?? 0,
                    //FinancialData = employee.JobInfo?.FinancialData?.ToModel(),
                    //BankBranchList = UnitOfWork.BankBranches.GetBankBranchWithBank(bankId).ToList(),
                    //BankList = UnitOfWork.Banks.GetAll().ToList(),
                    //BankId = bankId,
                    //NoteList = ,
                    LeaderType=employee.JobInfo?.leaderType ??0,
                    VacationBalance = employee.JobInfo?.VacationBalance ?? 0,
                    Notes = employee.JobInfo?.Notes,
                    ClampDegree =  (ClampDegree?) employee.JobInfo?.Degree,
                    ClampDegreeNow =(ClampDegree?) employee.JobInfo?.DegreeNow,
                    SalayClassification = employee.JobInfo?.SalayClassification??0,
                    ClassificationOnSearchingId = classificationOnSearchingId,
                    ClassificationOnWorkId = classificationOnWorkId,
                    //JobClass = employee.JobInfo?.JobClass??0,
                    CenterNumber = employee.JobInfo?.Unit?.Division?.Department?.Center?.CenterNumber??0,
                    ClassificationOnSearchingList = UnitOfWork.ClassificationOnSearchings.GetAll().ToList(),
                    ClassificationOnWorkList = UnitOfWork.ClassificationOnWorks.GetAll().ToList(),
                    Redirection = employee.JobInfo?.Redirection??0,
                    RedirectionNote = employee.JobInfo?.RedirectionNote,
                    OldJobNumber = employee.JobInfo?.OldJobNumber,
                    CanSubmit = ApplicationUser.Permissions.Employee_Edit,
                       Situons=employee.JobInfo?.Situons??0,
                    SituionsNumber=employee.JobInfo?.SituionsNumber??0,
                   JobNumberLIC=employee.JobInfo?.JobNumberLIC ?? 0
                },
                //JobInfoDegreeModel =
                //{
                //    // JobNumber = int.Parse(jobnmber),
                //    AdjectiveEmployeeId = employee.JobInfo?.AdjectiveEmployeeId ?? 0,
                //    AdjectiveEmployeeTypeId = employee.JobInfo?.AdjectiveEmployee?.AdjectiveEmployeeTypeId ?? 0,
                //    EmploymentValues = employee.JobInfo?.EmploymentValues?.ToModel(),
                //    //SituationResolveJob =employee.JobInfo?.SituationResolveJob?.ToModel(),
                //    EmployeeId = employee.EmployeeId,
                //    Bouns = employee.JobInfo?.Bouns ?? 0,
                //    DateMeritBouns = employee.JobInfo?.DateMeritBouns.FormatToString() ?? "",
                //    //StaffingId = employee.JobInfo?.StaffingId ?? 0,
                //   // StaffingClassificationId= employee.JobInfo?.StaffingClassificationId ?? 0,
                //    //JobNumberApproved = employee.JobInfo?.JobNumberApproved ?? 0,
                //   // UnitId = employee.JobInfo?.UnitId ?? 0,
                //    DateMeritDegreeNow = employee.JobInfo?.DateMeritDegreeNow.FormatToString() ?? "",
                //    DegreeNow = employee.JobInfo?.DegreeNow ?? 0,
                //    DateDegreeNow = employee.JobInfo?.DateDegreeNow.FormatToString() ?? "",
                //   // CurrentSituationId = employee.JobInfo?.CurrentSituationId ?? 0,
                //    DateBouns = employee.JobInfo?.DateBouns.FormatToString() ?? "",
                //    //StaffingTypeId = employee.JobInfo?.Staffing?.StaffingTypeId ?? 0,
                //    JobId = employee.JobInfo?.JobId ?? 0,
                //    DirectlyDate = employee.JobInfo?.DirectlyDate.FormatToString() ?? "",
                //    Degree = employee.JobInfo?.Degree ?? 0,
                //    //DepartmentId = employee.JobInfo?.Unit?.Division?.DepartmentId ?? 0,
                //    //DivisionId = employee.JobInfo?.Unit?.DivisionId ?? 0,
                //    //CenterId = centerId,
                //    //JobClass=num,
                //    //AdjectiveEmployeeList = UnitOfWork.AdjectiveEmployees.GetAdjectiveEmployeeWithType(adjectiveEmployeeTypeId).ToList(),
                //    //AdjectiveEmployeeTypeList = UnitOfWork.AdjectiveEmployeeTypes.GetAll().ToList(),
                //    //CurrentSituationList = UnitOfWork.CurrentSituations.GetAll().ToList(),
                //    JobList = UnitOfWork.Jobs.GetAll().ToList(),
                //    //NoteList = UnitOfWork..GetPlaceWithBranch(branchId).ToList(),//////
                //    //StaffingList = UnitOfWork.Staffings.GetStaffingWithStaffingType(staffingTypeId).ToList(),
                //    //StaffingClassificationList= UnitOfWork.StaffingClassification.GetWithStaffings(staffingId).ToList(),
                //    //StaffingTypeList = UnitOfWork.StaffingTypes.GetAll().ToList(),
                //    //CenterList = UnitOfWork.Centers.GetAll().ToList(),
                //    //DepartmentList = UnitOfWork.Departments.GetDepartmentWithCenter(centerId).ToList(),
                //    //DivisionList = UnitOfWork.Divisions.GetDivisionWithDepartment(departmentId).ToList(),
                //    //UnitList = UnitOfWork.Units.GetUnitWithDivision(divisionId).ToList(),
                //    JobType = employee.JobInfo?.JobType ?? 0,
                //    //FinancialData = employee.JobInfo?.FinancialData?.ToModel(),
                //    //BankBranchList = UnitOfWork.BankBranches.GetBankBranchWithBank(bankId).ToList(),
                //    //BankList = UnitOfWork.Banks.GetAll().ToList(),
                //    //BankId = bankId,
                //    //NoteList = ,
                //    //VacationBalance = employee.JobInfo?.VacationBalance ?? 0,
                //    //Notes = employee.JobInfo?.Notes,
                //    ClampDegree =  (ClampDegree?) employee.JobInfo?.Degree,
                //    ClampDegreeNow =(ClampDegree?) employee.JobInfo?.DegreeNow,
                //    SalayClassification = employee.JobInfo?.SalayClassification??0,
                //    ClassificationOnSearchingId = classificationOnSearchingId,
                //    ClassificationOnWorkId = classificationOnWorkId,
                //    //JobClass = employee.JobInfo?.JobClass??0,
                //    //CenterNumber = employee.JobInfo?.Unit?.Division?.Department?.Center?.CenterNumber??0,
                //    //ClassificationOnSearchingList = UnitOfWork.ClassificationOnSearchings.GetAll().ToList(),
                //    //ClassificationOnWorkList = UnitOfWork.ClassificationOnWorks.GetAll().ToList(),
                //    //Redirection = employee.JobInfo?.Redirection??0,
                //    //RedirectionNote = employee.JobInfo?.RedirectionNote,
                //    //OldJobNumber = employee.JobInfo?.OldJobNumber,
                //    CanSubmit = ApplicationUser.Permissions.Employee_Edit,
                //    CanEdit=ApplicationUser.Permissions.Employee_Edit,
                //    CanPromotion= ApplicationUser.Permissions.Employee_Promotion,
                //    CanSettlement= ApplicationUser.Permissions.Employee_Settlement,

                //       Situons=employee.JobInfo?.Situons??0,
                //    //SituionsNumber=employee.JobInfo?.SituionsNumber??0,
                //},
                MilitaryDataModel =
                {
                    EmployeeId = employee.EmployeeId,
                    AdjectiveMilitary = employee.MilitaryData?.AdjectiveMilitary ?? 0,
                    College = employee.MilitaryData?.College,
                    GranduationDate = employee.MilitaryData?.GranduationDate.FormatToString() ?? "",
                    MilitaryNumber = employee.MilitaryData?.MilitaryNumber,
                    MotherUnit = employee.MilitaryData?.MotherUnit,
                    Rank = employee.MilitaryData?.Rank,
                    Subunit = employee.MilitaryData?.Subunit,
                    CanSubmit = ApplicationUser.Permissions.Employee_Edit
                },
                PersonalModel =
                {
                // add by ali alherbade 19-08-2019
                    IsActive = employee.IsActive,
                //
                    BranchList = UnitOfWork.Branches.GetAll().ToList(),
                    PlaceList = UnitOfWork.Places.GetPlaceWithBranch(branchId).ToList(),
                    NationalityList = UnitOfWork.Nationalities.GetAll().ToList(),
                    Address = employee.Address,
                    BirthDate = employee.BirthDate.FormatToString(),
                    BirthPlace = employee.BirthPlace,
                    BloodType = employee.BloodType,
                    Booklet = employee.Booklet?.ToModel(),
                    BranchId = branchId,
                    ChildernCount = employee.ChildernCount.GetValueOrDefault(),
                    Email = employee.Email,
                    EmployeeId = id,
                    EnglishFatherName = employee.EnglishFatherName,
                    EnglishFirstName = employee.EnglishFirstName,
                    EnglishGrandfatherName = employee.EnglishGrandfatherName,
                    EnglishLastName = employee.EnglishLastName,
                    FatherName = employee.FatherName,
                    FirstName = employee.FirstName,
                    Gender = employee.Gender,
                    GrandfatherName = employee.GrandfatherName,
                    IdentificationCard = employee.IdentificationCard?.ToModel(),
                    LastName = employee.LastName,
                    MotherName = employee.MotherName,
                    NationalNumber = employee.NationalNumber,
                    NationalityId = employee.NationalityId.GetValueOrDefault(),
                    Passport = employee.Passport?.ToModel(),
                    Phone = employee.Phone,
                    PlaceId = employee.PlaceId.GetValueOrDefault(),
                    Religion = employee.Religion,
                    SocialStatus = employee.SocialStatus,
                    ContactInfo = employee.ContactInfo?.ToModel(),
                    CanSubmit = ApplicationUser.Permissions.Employee_Edit,
                    LibyanOrForeigner = employee.LibyanOrForeigner,
                    Image = employee.Image,
                    HaveImage = employee.Image != null && employee.Image.Length > 0
                },
                DocumentModel =
                {
                    DocumentGrid = documents.ToGrid(),
                    DocumentTypeList = UnitOfWork.DocumentTypes.GetAll().ToList(),
                    EmployeeId = id,
                    CanCreate = ApplicationUser.Permissions.Document_Create,
                    CanEdit = ApplicationUser.Permissions.Document_Edit,
                    CanDelete = ApplicationUser.Permissions.Document_Delete,
                    Number = UnitOfWork.Documents.GetMaxNumber(id)
                }
                ,
                QualificationModel =
                {
                    // EmployeeId = id,
                    EmployeeId = employee.EmployeeId,
                    SpecialtyList= UnitOfWork.Specialties.GetAll().ToList(),
                    SubSpecialtyList=UnitOfWork.SubSpecialties.GetAll().ToList(),
                    QualificationTypeList=UnitOfWork.QualificationTypes.GetAll().ToList(),
                    ExactSpecialtyList =UnitOfWork.ExactSpecialties.GetAll().ToList(),
                    QualificationGrid= Qualification.ToGrid(),
                     CanCreate = ApplicationUser.Permissions.Qualification_Create,
                    CanEdit = ApplicationUser.Permissions.Qualification_Edit,
                    CanDelete = ApplicationUser.Permissions.Qualification_Delete,
                    EmployeeName= UnitOfWork.Employees.GetEmployeeNameById(employee.EmployeeId).GetFullName(),
                }
                //SalaryInfoModel = new SalaryInfoModel()
                //{
                //    BankBranchId = employee.SalaryInfo?.BankBranchId??0,
                //    BankId = bankId,
                //    BankBranchList = UnitOfWork.BankBranches.GetBankBranchWithBank(bankId).ToList(),
                //    BankList = UnitOfWork.Banks.GetAll().ToList(),
                //    BasicSalary = employee.SalaryInfo?.BasicSalary??0,
                //    BondNumber = employee.SalaryInfo?.BondNumber,
                //    FinancialNumber = employee.SalaryInfo?.FinancialNumber,
                //    GuaranteeType = employee.SalaryInfo?.GuaranteeType ?? 0,
                //    SecurityNumber = employee.SalaryInfo?.SecurityNumber,
                //    EmployeePremiumList = UnitOfWork.Employees.GetEmployeePremiumBy(employee.EmployeeId).ToList(),
                //    PremiumList = UnitOfWork.Premiums.GetAll().ToList()
                //}
            };

        }

        public bool Delete(int id, PersonalModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Employee_Delete))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            var employee = UnitOfWork.Employees.Find(id);

            if (employee == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Employees.Remove(employee);

            if (!UnitOfWork.TryComplete(n => n.Employee_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        public bool Edit(int id, PersonalModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Employee_Edit))
                return Fail(RequestState.NoPermission);
            if (!ModelState.IsValid(model))
                return false;

            var employee = UnitOfWork.Employees.Find(id);
            var employeeAll = UnitOfWork.Employees.GetAll().Where(s => s.EmployeeId != id);

            if (model.NationalNumber.ToString().Length != 12)
                return ErrorNationaltyNumber();
            bool Exisite = employeeAll.Any(s => s.NationalNumber == model.NationalNumber);
            if (Exisite == true)
                return Duplicate();
            if (employee == null)
                return Fail(RequestState.NotFound);

            var modifier = employee.Modify()
                .FirstName(model.FirstName, model.EnglishFirstName)
                .FatherName(model.FatherName, model.EnglishFatherName)
                .GrandfatherName(model.GrandfatherName, model.EnglishGrandfatherName)
                .LastName(model.LastName, model.EnglishLastName)
                .MotherName(model.MotherName)
                .Gender(model.Gender)
                .BirthDate(DateTime.Parse(model.BirthDate))
                .BirthPlace(model.BirthPlace)
                .NationalNumber(model.NationalNumber)
                .Religion(model.Religion)
                .Nationality(model.NationalityId)
                .Place(model.PlaceId)
                .Address(model.Address)
                .Phone(model.Phone)
                .Email(model.Email)
                .SocialStatus(model.SocialStatus)
                .ChildernCount(model.ChildernCount)
                .BloodType(model.BloodType)
                .IsActive(model.IsActive)
                .Booklet(model.Booklet.ToDomain())
                .Passport(model.Passport.ToDomain())
                .IdentificationCard(model.IdentificationCard.ToDomain())
                .ContactInfo(model.ContactInfo?.ToDomain());

            if (model.ImageIsSet)
                modifier.WithImage(model.Image);

            modifier.Confirm();

            UnitOfWork.Complete(n => n.Employee_Edit);

            return SuccessEdit();
        }
        
        public virtual bool Edit(int id, JobInfoModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Employee_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;
            int num = (int)model.JobClass;

            var employee = UnitOfWork.Employees.Find(id);

            if (employee.JobInfo == null)
                return false;

            if (employee.JobInfo.JobNumberLIC == 0)
            {
                if (UnitOfWork.Employees.NumIsExisted(model.JobNumberLIC ?? 0))
                    return ModelState.AddError(m => model.JobNumberLIC, SharedMessages.NumIsExisted);

            }
            else if (employee.JobInfo.JobNumberLIC > 0)
            {
                if (employee.JobInfo.JobNumberLIC != model.JobNumberLIC)
                {
                    if (UnitOfWork.Employees.NumIsExisted(model.JobNumber, model.JobNumberLIC ?? 0))
                        return ModelState.AddError(m => model.JobNumberLIC, SharedMessages.NumIsExisted);
                }
            }
            //if (UnitOfWork.Employees.NumIsExisted(model.JobNumberLIC ?? 0))
            //    return ModelState.AddError(m => model.JobNumberLIC, SharedMessages.NumIsExisted);

            var modifier = employee.JobInfo.Modify()
                .EmploymentValues(model.EmploymentValues.ToDomain())
                .DirectlyDate(model.DirectlyDate.ToDateTime())
                .Degree(model.Degree, model.ClampDegree, model.SalayClassification)
                .Job(model.JobId)
                .JobNumberApproved(model.JobNumberApproved)
                .CurrentSituation(model.CurrentSituationId)
                .Unit(model.UnitId)
                //.DegreeNow(model.DegreeNow, model.ClampDegreeNow, model.SalayClassification)
                .DegreeNow(model.DegreeNow)
                .DateDegreeNow(model.DateDegreeNow.ToDateTime())
                .DateMeritDegreeNow(model.DateMeritDegreeNow.ToDateTime())
                .Bouns(model.Bouns)
                .Bounshr(model.Bouns)
                .DateBounshr(model.DateBouns.ToDateTime())
                .DateBouns(model.DateBouns.ToDateTime())
                .DateMeritBouns(model.DateMeritBouns.ToDateTime())
                .AdjectiveEmployee(model.AdjectiveEmployeeId)
                .Staffing(model.StaffingId)
                .StaffingClassification(model.StaffingClassificationId)
                .JobType(model.JobType)
                .VacationBalance(model.VacationBalance)
                .Notes(model.Notes)
                .ClassificationOnSearching(model.ClassificationOnSearchingId)
                .ClassificationOnWork(model.ClassificationOnWorkId)
                .SalayClassification(model.SalayClassification)
                 .WithJobClass(num)
                .Redirection(model.Redirection, model.RedirectionNote)
                .OldJobNumber(model.OldJobNumber)
                .HealthStatus(model.HealthStatus)
                 .WithSituons(model.Situons)
                .WithSituionsNumber(model.SituionsNumber)
                .Adjective(model.Adjective)
                .JobNumberLIC(model.JobNumberLIC)
            .LeaderType(model.LeaderType);


            if (employee.JobInfo.JobNumber == 0)
                modifier.JobNumber(UnitOfWork.Employees.GetJobNumber());

            //if (employee.JobInfo.JobNumberLIC == 0)
            //    modifier.JobNumberLIC(UnitOfWork.Employees.GetJobNumberLIC());

            modifier.Confirm();

            UnitOfWork.Complete(n => n.Employee_Edit);

            return SuccessEdit();
        }

        public bool Edit(int id, MilitaryDataModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Employee_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var empolyee = UnitOfWork.Employees.Find(id);

            if (empolyee.MilitaryData == null)
                return false;

            empolyee.MilitaryData.Modify()
                .AdjectiveMilitary(model.AdjectiveMilitary)
                .College(model.College)
                .GranduationDate(model.GranduationDate.ToDateTime())
                .MilitaryNumber(model.MilitaryNumber)
                .MotherUnit(model.MotherUnit)
                .Rank(model.Rank)
                .Subunit(model.Subunit)
                .Confirm();

            UnitOfWork.Complete(n => n.Employee_Edit);

            return SuccessEdit();
        }
        public bool SaveQualification(QualificationModel model) => model.QualificationId > 0
       ? Edit(model)
       : Create(model);

        public bool SaveDocument(DocumentModel model) => model.DocumentId > 0
            ? Edit(model)
            : Create(model);

        private bool Create(DocumentModel model)
        {
            if (!HaveDocumentPermission(ApplicationUser.Permissions.Document_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var documentType = UnitOfWork.DocumentTypes.Find(model.DocumentTypeId);

            if (documentType == null)
                return Fail(RequestState.NotFound);

            var expireDate = documentType.HaveExpireDate
                ? model.ExpireDate.ToDateTime()
                : (DateTime?)null;

            var decisionNumber = documentType.HaveDecisionNumber
                ? model.DecisionNumber
                : null;

            var decisionYear = documentType.HaveDecisionYear
                ? model.DecisionYear
                : null;

            var document = Document.New()
                .ForEmployeeId(model.EmployeeId)
                .WithType(documentType)
                .WithNumber(UnitOfWork.Documents.GetMaxNumber(model.EmployeeId))
                .IssuedInDate(model.IssueDate.ToDateTime())
                .IssuedInPlace(model.IssuePlace)
                .ExpireIn(expireDate)
                .WithDecisionNumber(decisionNumber)
                .DecisionInYear(decisionYear)
                .WithNote(model.Note)
                .Build();

            foreach (var image in model.SavedImages)
                document.DocumentImages.Add(DocumentImage.New(document, image));

            UnitOfWork.Documents.Add(document);

            UnitOfWork.Complete(n => n.Document_Create);

            var documents = UnitOfWork.Documents.GetByEmployee(model.EmployeeId);

            Reload(model, documents);

            return SuccessCreate();
        }

        private bool Edit(DocumentModel model)
        {
            if (!HaveDocumentPermission(ApplicationUser.Permissions.Document_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var document = UnitOfWork.Documents.Find(model.DocumentId);

            if (document == null)
                return Fail(RequestState.NotFound);

            var documentType = UnitOfWork.DocumentTypes.Find(model.DocumentTypeId);

            if (documentType == null)
                return Fail(RequestState.NotFound);

            var expireDate = documentType.HaveExpireDate
                ? model.ExpireDate.ToDateTime()
                : (DateTime?)null;

            var decisionNumber = documentType.HaveDecisionNumber
                ? model.DecisionNumber
                : null;

            var decisionYear = documentType.HaveDecisionYear
                ? model.DecisionYear
                : null;

            document.Modify()
                .Type(documentType)
                .IssueDate(model.IssueDate.ToDateTime())
                .IssuePlace(model.IssuePlace)
                .DecisionNumber(decisionNumber)
                .DecisionInYear(decisionYear)
                .ExpireDate(expireDate)
                .WithNote(model.Note)
                .Confirm();

            foreach (var image in model.SavedImages)
                document.DocumentImages.Add(DocumentImage.New(document, image));

            UnitOfWork.Complete(n => n.Document_Edit);

            var documents = UnitOfWork.Documents.GetByEmployee(model.EmployeeId);

            Reload(model, documents);

            return SuccessCreate();
        }

        private static void Reload(DocumentModel model, IEnumerable<Document> documents)
        {
            model.DocumentTypeId = 0;
            model.DecisionNumber = null;
            model.DecisionYear = null;
            model.ExpireDate = null;
            model.IssueDate = null;
            model.IssuePlace = null;
            model.Note = null;
            model.DocumentId = 0;
            model.HaveDecisionNumber = false;
            model.HaveExpireDate = false;
            model.HaveDecisionYear = false;
            model.Number = 0;
            model.LoadedImages = new HashSet<int>();
            model.SavedImages.Clear();
            model.DocumentGrid = documents.ToGrid();
        }

        private static void Reload(QualificationModel model, IEnumerable<Qualification> Qualification)
        {
            model.QualificationTypeId = 0;
            model.Date = null;
            model.ExactSpecialtyId = 0;
            model.SubSpecialtyId = 0;
            model.NameDonorFoundation = null;
            model.Grade = 0;
            model.NameDonorFoundation = null;
            model.SpecialtyId = 0;
            model.GraduationCountry = null;

        }

        public bool SelectDocument(DocumentModel model)
        {
            if (!HaveDocumentPermission())
                return Fail(RequestState.NoPermission);

            if (model.DocumentId <= 0)
                return Fail(RequestState.BadRequest);

            var document = UnitOfWork.Documents.GetDocumentWithImages(model.DocumentId);

            if (document == null)
                return Fail(RequestState.NotFound);

            model.DocumentTypeId = document.DocumentTypeId;
            model.HaveDecisionNumber = document.DocumentType.HaveDecisionNumber;
            model.HaveDecisionYear = document.DocumentType.HaveDecisionYear;
            model.HaveExpireDate = document.DocumentType.HaveExpireDate;
            model.LoadedImages = document.DocumentImages.Select(d => d.DocumentImageId).ToList();
            model.Number = document.Number;
            model.DecisionNumber = document.DecisionNumber;
            model.DecisionYear = document.DecisionYear;
            model.ExpireDate = document.ExpireDate?.FormatToString();
            model.IssueDate = document.IssueDate.FormatToString();
            model.Note = document.Note;

            return true;
        }

        public bool SelectQualification(QualificationModel model)
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

            Domain.QualificationFactory.IAquiredSpecialtyHolder builder;

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

        public bool DeleteImage(int documentImageId)
        {
            if (!HaveDocumentPermission(ApplicationUser.Permissions.Document_Edit))
                return Fail(RequestState.NoPermission);

            if (documentImageId <= 0)
                return Fail(RequestState.BadRequest);

            var documentImage = UnitOfWork.DocumentImages.Find(documentImageId);

            if (documentImage == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.DocumentImages.Remove(documentImage);

            UnitOfWork.Complete(n => n.Document_Edit);

            return true;
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
        public byte[] LoadAvatar(int employeeId) => UnitOfWork.Employees.GetImageById(employeeId);

        public byte[] LoadImage(int documentImageId)
        {
            if (!HaveDocumentPermission())
                return Null<byte[]>(RequestState.NoPermission);

            if (documentImageId <= 0)
                return Null<byte[]>(RequestState.BadRequest);

            var documentImage = UnitOfWork.DocumentImages.Find(documentImageId);

            return documentImage == null ? Null<byte[]>(RequestState.NotFound) : documentImage.Image;
        }

        public bool DeleteDocument(DocumentModel model)
        {
            if (!HaveDocumentPermission(ApplicationUser.Permissions.Document_Delete))
                return Fail(RequestState.NoPermission);

            if (model.DocumentId <= 0)
                return Fail(RequestState.BadRequest);

            var document = UnitOfWork.Documents.Find(model.DocumentId);

            if (document == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Documents.Remove(document);

            if (!UnitOfWork.TryComplete(n => n.Document_Delete))
                return Fail(UnitOfWork.Message);

            Reload(model, UnitOfWork.Documents.GetByEmployee(model.EmployeeId));

            return SuccessDelete();
        }
        public bool DeleteQualification(QualificationModel model)
        {
            if (!HaveDocumentPermission(ApplicationUser.Permissions.Qualification_Delete))
                return Fail(RequestState.NoPermission);

            if (model.QualificationId <= 0)
                return Fail(RequestState.BadRequest);

            var q = UnitOfWork.Qualifications.Find(model.QualificationId);

            if (q == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Qualifications.Remove(q);

            if (!UnitOfWork.TryComplete(n => n.Qualification_Delete))
                return Fail(UnitOfWork.Message);

            Reload(model, UnitOfWork.Qualifications.GetQualificationByEmployeeId(model.EmployeeId));

            return SuccessDelete();
        }
        public bool DeleteMilitaryData(int id, MilitaryDataModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Employee_Edit))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            var militaryData = UnitOfWork.Employees.FindMilitaryData(id);

            if (militaryData == null)
                return Fail(RequestState.NotFound);


            UnitOfWork.Employees.RemoveMilitaryData(militaryData);

            if (!UnitOfWork.TryComplete(d => d.Employee_Edit))
                return Fail(UnitOfWork.Message);

            ClearMilitaryData(model);
            return SuccessDelete();
        }
        private void ClearMilitaryData(MilitaryDataModel model)
        {
            model.AdjectiveMilitary = 0;
            model.College = "";
            model.GranduationDate = "";
            model.MilitaryNumber = "";
            model.MotherUnit = "";
            model.Rank = "";
            model.Subunit = "";
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

  
        public virtual void Refresh(int id, JobInfoDegreeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Employee_Edit))
                return;

            if (id <= 0)
                return;

            var employee = UnitOfWork.Employees.Find(id);

            if (employee == null)
                return;


            var classificationOnSearchingId = employee.JobInfo?.ClassificationOnSearchingId ?? 0;
            var classificationOnWorkId = employee.JobInfo?.ClassificationOnWorkId ?? 0;

            model.EmployeeName = employee.GetFullName();
            model.AdjectiveEmployeeId = employee.JobInfo?.AdjectiveEmployeeId ?? 0;
            model.AdjectiveEmployeeTypeId = employee.JobInfo?.AdjectiveEmployee?.AdjectiveEmployeeTypeId ?? 0;
            model.EmploymentValues = employee.JobInfo?.EmploymentValues?.ToModel();

            model.EmployeeId = employee.EmployeeId;
            model.Bouns = employee.JobInfo?.Bouns ?? 0;
            model.DateMeritBouns = employee.JobInfo?.DateMeritBouns.FormatToString() ?? "";

            model.DateMeritDegreeNow = employee.JobInfo?.DateMeritDegreeNow.FormatToString() ?? "";
            model.DegreeNow = employee.JobInfo?.DegreeNow ?? 0;
            model.DateDegreeNow = employee.JobInfo?.DateDegreeNow.FormatToString() ?? "";

            model.DateBouns = employee.JobInfo?.DateBouns.FormatToString() ?? "";

            model.JobId = employee.JobInfo?.JobId ?? 0;
            model.DirectlyDate = employee.JobInfo?.DirectlyDate.FormatToString() ?? "";
            model.Degree = employee.JobInfo?.Degree ?? 0;
            model.JobList = UnitOfWork.Jobs.GetAll().ToList();
            model.JobType = employee.JobInfo?.JobType ?? 0;
            model.ClampDegree = (ClampDegree?)employee.JobInfo?.Degree;
            model.ClampDegreeNow = (ClampDegree?)employee.JobInfo?.DegreeNow;
            model.SalayClassification = employee.JobInfo?.SalayClassification ?? 0;
            model.ClassificationOnSearchingId = classificationOnSearchingId;
            model.ClassificationOnWorkId = classificationOnWorkId;
            model.CanSubmit = ApplicationUser.Permissions.Employee_Edit;
            model.CanEdit = ApplicationUser.Permissions.Employee_Edit;
            model.CanPromotion = ApplicationUser.Permissions.Employee_Promotion;
            model.CanSettlement = ApplicationUser.Permissions.Employee_Settlement;
            model.Situons = employee.JobInfo?.Situons ?? 0;
            model.DecisionDate = model.DecisionDate;

        }

        public virtual bool Edit(int id, JobInfoDegreeModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Employee_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;
            //int num = (int)model.JobClass;

            var employee = UnitOfWork.Employees.Find(id);

            if (employee.JobInfo == null)
                return false;

            var modifier = employee.JobInfo.Modify()
                .EmploymentValues(model.EmploymentValues.ToDomain())
                .DirectlyDate(model.DirectlyDate.ToDateTime())
                .Degree(model.Degree, model.ClampDegree, model.SalayClassification)
                .DegreeNow(model.DegreeNow, model.ClampDegreeNow, model.SalayClassification)
                .DateDegreeNow(model.DateDegreeNow.ToDateTime())
                .DateMeritDegreeNow(model.DateMeritDegreeNow.ToDateTime())
                .Bouns(model.Bouns)
                .Bounshr(model.Bounshr)
                .DateBounshr(model.DateBouns.ToDateTime())
                .DateBouns(model.DateBouns.ToDateTime())
                .DateMeritBouns(model.DateMeritBouns.ToDateTime())

                .ClassificationOnSearching(model.ClassificationOnSearchingId)
                .ClassificationOnWork(model.ClassificationOnWorkId)
                .SalayClassification(model.SalayClassification);


            modifier.Confirm();

            UnitOfWork.Complete(n => n.Degree_Edit);

            return SuccessEdit();
        }

        public bool PromotionJobInfo(int id, JobInfoDegreeModel model)
        {
            throw new NotImplementedException();
        }

        public bool SettlementJobInfo(int id, JobInfoDegreeModel model)
        {
            throw new NotImplementedException();
        }


        //void IEmployeeBusiness1.Refresh(PersonalModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //void IEmployeeBusiness1.Refresh(EmployeeIndexModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //void IEmployeeBusiness1.Refresh(int id, JobInfoModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //void IEmployeeBusiness1.Refresh(MilitaryDataModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //void IEmployeeBusiness1.Refresh(DocumentModel model)
        //{
        //    throw new NotImplementedException();
        //}



        //PersonalModel IEmployeeBusiness1.Prepare()
        //{
        //    throw new NotImplementedException();
        //}

        //bool IEmployeeBusiness1.Create(PersonalModel model)
        //{
        //    throw new NotImplementedException();
        //}



        //bool IEmployeeBusiness1.Delete(int id, PersonalModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //bool IEmployeeBusiness1.Edit(int id, PersonalModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //bool IEmployeeBusiness1.Edit(int id, JobInfoModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //bool IEmployeeBusiness1.Edit(int id, MilitaryDataModel model)
        //{
        //    throw new NotImplementedException();
        //}

        ////bool IEmployeeBusiness1.Edit(QualificationModel model)
        ////{
        ////    throw new NotImplementedException();
        ////}

        //bool IEmployeeBusiness1.SaveDocument(DocumentModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //bool IEmployeeBusiness1.SelectDocument(DocumentModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //bool IEmployeeBusiness1.DeleteImage(int documentImageId)
        //{
        //    throw new NotImplementedException();
        //}

        //byte[] IEmployeeBusiness1.LoadAvatar(int employeeId)
        //{
        //    throw new NotImplementedException();
        //}

        //byte[] IEmployeeBusiness1.LoadImage(int documentImageId)
        //{
        //    throw new NotImplementedException();
        //}

        //bool IEmployeeBusiness1.DeleteDocument(DocumentModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //bool IEmployeeBusiness1.DeleteMilitaryData(int id, MilitaryDataModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //void IEmployeeBusiness1.Refresh()
        //{
        //    throw new NotImplementedException();
        //}
        //public bool Edit(int id, SalaryInfoModel model)
        //{
        //    if (id <= 0)
        //        return Fail(RequestState.BadRequest);

        //    if (!HavePermission(ApplicationUser.Permissions.Employee_Edit))
        //        return Fail(RequestState.NoPermission);

        //    if (!ModelState.IsValid(model))
        //        return false;

        //    var empolyee = UnitOfWork.Employees.Find(id);

        //    if (empolyee.SalaryInfo == null)
        //        return false;

        //    empolyee.SalaryInfo.Modify(model.BankBranchId, model.GuaranteeType, model.BondNumber, model.BasicSalary,
        //                    model.SecurityNumber, model.FinancialNumber);

        //    UnitOfWork.Complete();

        //    return SuccessEdit();
        //}
    }
}