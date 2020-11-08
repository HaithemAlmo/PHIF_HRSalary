using Almotkaml.Repository;

namespace Almotkaml.HR.Repository
{
    public interface IUnitOfWork : IDefaultUnitOfWork<Notify>
    {
        IActivityRepository Activities { get; }

        IUserRepository Users { get; }
        IUserGroupRepository UserGroups { get; }
        IAdjectiveEmployeeRepository AdjectiveEmployees { get; }
        IAdjectiveEmployeeTypeRepository AdjectiveEmployeeTypes { get; }
        IBranchRepository Branches { get; }
        ICurrentSituationRepository CurrentSituations { get; }
        IDepartmentRepository Departments { get; }
        IDivisionRepository Divisions { get; }
        IEmployeeRepository Employees { get; }
        IEmploymentTypeRepository EmploymentTypes { get; }
        IJobRepository Jobs { get; }
        IJobInfoRepository JobInfos { get; }
        IMilitaryDataRepository MilitaryDatas { get; }
        INationalityRepository Nationalities { get; }
        IPlaceRepository Places { get; }
        IQualificationRepository Qualifications { get; }
        IQualificationTypeRepository QualificationTypes { get; }
        IRewardRepository Rewards { get; }
        IRewardTypeRepository RewardTypes { get; }
        ISanctionRepository Sanctions { get; }
        ISanctionTypeRepository SanctionTypes { get; }
        ISpecialtyRepository Specialties { get; }
        IStaffingRepository Staffings { get; }
        IStaffingTypeRepository StaffingTypes { get; }
        IStaffingClassificationRepository StaffingClassification { get; }
        ISubSpecialtyRepository SubSpecialties { get; }
        IUnitRepository Units { get; }
        IVacationRepository Vacations { get; }
        IVacationTypeRepository VacationTypes { get; }
        ITimeSheetRepository TimeSheets { get; }
        ITrainingCourseRepository TrainingCourses { get; }

        IEvaluationRepository Evaluations { get; }

        IExtraWorkRepository ExtraWorks { get; }

        ISelfCoursesRepository SelfCourses { get; }
        IEndServicesRepository EndServices { get; }

        ISituationResolveJobRepository SituationResolveJobs { get; }
        IBankRepository Banks { get; }
        IBankBranchRepository BankBranches { get; }
        ICountryRepository Countries { get; }
        ICityRepository Cities { get; }
        IAbsenceRepository Absences { get; }
        ITransferRepository Transfers { get; }
        ICorporationRepository Corporations { get; }
        IDelegationRepository Delegations { get; }
        IPremiumRepository Premiums { get; }
        ISalaryRepository Salaries { get; }
        iHistorySubsended HistorySubsended { get; }

        ISettingRepository Settings { get; }
        IAdvancePaymentRepository AdvancePayments { get; }
        IExactSpecialtyRepository ExactSpecialties { get; }
        ICenterRepository Centers { get; }
        IHolidayRepository Holidays { get; }
        ICompanyInfoRepository CompanyInfo { get; }
        //IDevelopmentTypeERepository DevelopmentTypeEs { get; }
        IDevelopmentTypeDRepository DevelopmentTypeDs { get; }
        IDevelopmentTypeCRepository DevelopmentTypeCs { get; }
        IDevelopmentTypeBRepository DevelopmentTypeBs { get; }
        IDevelopmentTypeARepository DevelopmentTypeAs { get; }
        IDevelopmentStateRepository DevelopmentStates { get; }
        ITrainingRepository Trainings { get; }
        IRequestedQualificationRepository RequestedQualifications { get; }
        IDocumentTypeRepository DocumentTypes { get; }
        IDocumentRepository Documents { get; }
        IDocumentImageRepository DocumentImages { get; }
        ISalaryUnitRepository SalaryUnits { get; }
        IClassificationOnSearchingRepository ClassificationOnSearchings { get; }
        IClassificationOnWorkRepository ClassificationOnWorks { get; }
        ICoachRepository Coaches { get; }
        ICourseRepository Courses { get; }
    }
}
