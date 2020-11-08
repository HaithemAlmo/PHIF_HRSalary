using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.EntityCore.Repositories;
using Almotkaml.HR.EntityCore.Resource;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;

namespace Almotkaml.HR.EntityCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppConfig _appConfig;
        private IActivityRepository _activities;
        private IUserRepository _users;
        private IUserGroupRepository _userGroups;
        private IAdjectiveEmployeeRepository _adjectiveEmployees;
        private IAdjectiveEmployeeTypeRepository _adjectiveEmployeeTypes;
        private IBranchRepository _branches;
        private ICurrentSituationRepository _currentSituations;
        private IDepartmentRepository _departments;
        private IDivisionRepository _divisions;
        private IEmployeeRepository _employees;
        private IEmploymentTypeRepository _employmentTypes;
        private IJobRepository _jobs;
        private IClassificationOnWorkRepository _classificationOnWorks;
        private IClassificationOnSearchingRepository _classificationOnSearchings;
        private IJobInfoRepository _jobInfos;
        private iHistorySubsended _HistorySubsended;

        private IMilitaryDataRepository _militaryDatas;
        private INationalityRepository _nationalities;
        private IPlaceRepository _places;
        private IQualificationRepository _qualifications;
        private IQualificationTypeRepository _qualificationTypes;
        private IRewardRepository _rewards;
        private IRewardTypeRepository _rewardTypes;
        private ISanctionRepository _sanctions;
        private ISanctionTypeRepository _sanctionTypes;
        private ISpecialtyRepository _specialties;
        private IStaffingRepository _staffings;
        private IStaffingTypeRepository _staffingTypes;
        private IStaffingClassificationRepository _staffingClassification;
        private ISubSpecialtyRepository _subSpecialties;
        private IUnitRepository _units;
        private IVacationRepository _vacations;
        private IVacationTypeRepository _vacationTypes;
        private ITrainingCourseRepository _trainingCourses;
        private IEvaluationRepository _evaluations;
        private IExtraWorkRepository _extraWorks;
        private ISelfCoursesRepository _selfCourses;
        private IEndServicesRepository _endServices;
        private ISituationResolveJobRepository _situationResolveJobs;
        private IBankRepository _banks;
        private IBankBranchRepository _bankBranches;
        private ICountryRepository _countries;
        private ICityRepository _cities;
        private IAbsenceRepository _absences;
        private ITransferRepository _transfers;
        private ICorporationRepository _corporations;
        private IDelegationRepository _delegations;
        private IPremiumRepository _premiums;
        private ISalaryRepository _salaries;
        private ISettingRepository _settings;
        private IAdvancePaymentRepository _advancePayments;
        private IExactSpecialtyRepository _exactSpecialties;
        private ICenterRepository _centers;
        private IHolidayRepository _holidays;
        private ITrainingRepository _trainings;
        private IRequestedQualificationRepository _requestedQualifications;
        private IDocumentTypeRepository _documentTypes;
        private IDocumentRepository _documents;
        private IDocumentImageRepository _documentImages;
        private ICompanyInfoRepository _companyInfo;
        private IDevelopmentStateRepository _developmentStates;
        private IDevelopmentTypeARepository _developmentTypeAs;
        private IDevelopmentTypeBRepository _developmentTypeBs;
        private IDevelopmentTypeCRepository _developmentTypeCs;
        private IDevelopmentTypeDRepository _developmentTypeDs;
        private ISalaryUnitRepository _salaryUnits;
        private ICoachRepository _coaches;
        private ICourseRepository _courses;

        protected UnitOfWork(AppConfig appConfig, int loggedInUserId = 0)
        {
            _appConfig = appConfig;
            Check.NotNull(appConfig, nameof(appConfig));
            Context = new HrDbContext(appConfig.ConnectionString, loggedInUserId);

            if (!Context.Database.GetPendingMigrations().Any())
                return;

            Context.Database.Migrate();
            SeedData.Load(Context);
        }

        protected HrDbContext Context { get; }

        public void Dispose()
        {
            Context.Dispose();
        }

        public bool TryComplete()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Message = e.ToString();

                if (e.InnerException?.Message.Contains("table \"dbo.") ?? false)
                {
                    var tableName = e.InnerException.Message.Between("table \"dbo.", '"');
                    var name = new ResourceManager(typeof(Tables)).GetString(tableName);
                    Message = Messages.UnableToDelete + " "
                              + (string.IsNullOrWhiteSpace(name) ? tableName : name);
                }
                if (e.Message.Contains("' and '"))
                {
                    var tableName = e.Message.Between("' and '", '\'');
                    var name = new ResourceManager(typeof(Tables)).GetString(tableName);
                    Message = Messages.UnableToDelete + " "
                              + (string.IsNullOrWhiteSpace(name) ? tableName : name);
                }
                return false;
            }

            return true;
        }

        public void Complete(Expression<Func<Notify, bool>> expression)
        {
            if (expression != null)
                Context.Activities.Add(Activity.New(Context.LoggedInUserId, expression.ToExpressionTarget()));

            Complete();
        }

        public bool TryComplete(Expression<Func<Notify, bool>> expression)
        {
            if (expression != null)
                Context.Activities.Add(Activity.New(Context.LoggedInUserId, expression.ToExpressionTarget()));

            return TryComplete();
        }

        public void Complete()
        {
           
            try
            {
 Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public bool BackUp(string path)
        {
            var cn = new SqlConnection(_appConfig.ConnectionString);

            if (cn.State != ConnectionState.Open)
                cn.Open();

            if (string.IsNullOrWhiteSpace(path))
            {
                const string folder = @"D:\" + nameof(HR) + "BackUp";

                Directory.CreateDirectory(folder);

                path = folder + @"\A" + DateTime.Now.ToString("yyMMddHHmmss") + ".bak";
            }

            var cmd = new SqlCommand
            {
                CommandText = @"BACKUP DATABASE " + _appConfig.DbName
                              + @" TO DISK = '" + path + "'",
                CommandType = CommandType.Text,
                Connection = cn
            };

            cmd.ExecuteReader();
            cn.Close();
            return true;
        }

        public bool Restore(string location)
        {
            try
            {
                var con = new SqlConnection(_appConfig.ConnectionString);

                if (con.State != ConnectionState.Open)
                    con.Open();

                var sqlStmt2 = "ALTER DATABASE " + _appConfig.DbName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                var bu2 = new SqlCommand(sqlStmt2, con);
                bu2.ExecuteNonQuery();

                var sqlStmt3 = "USE MASTER RESTORE DATABASE  " + _appConfig.DbName + " FROM DISK= '" + location + "' WITH REPLACE;";
                var bu3 = new SqlCommand(sqlStmt3, con);
                bu3.ExecuteNonQuery();

                var sqlStmt4 = "ALTER DATABASE  " + _appConfig.DbName + " SET MULTI_USER";
                var bu4 = new SqlCommand(sqlStmt4, con);
                bu4.ExecuteNonQuery();

                con.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }


        /// <summary>
        ///  please initialize these properties like in Accounting ...
        /// </summary>
        public string Message { get; private set; }

        public IActivityRepository Activities
        {
            get
            {
                if (_activities != null)
                    return _activities;

                _activities = new ActivityRepository(Context);
                return _activities;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (_users != null)
                    return _users;

                _users = new UserRepository(Context);
                return _users;
            }
        }

        public IUserGroupRepository UserGroups
        {
            get
            {
                if (_userGroups != null)
                    return _userGroups;

                _userGroups = new UserGroupRepository(Context);
                return _userGroups;
            }
        }

        public IAdjectiveEmployeeRepository AdjectiveEmployees
        {
            get
            {
                if (_adjectiveEmployees != null)
                    return _adjectiveEmployees;

                _adjectiveEmployees = new AdjectiveEmployeeRepository(Context);
                return _adjectiveEmployees;
            }
        }

        public IAdjectiveEmployeeTypeRepository AdjectiveEmployeeTypes
        {
            get
            {
                if (_adjectiveEmployeeTypes != null)
                    return _adjectiveEmployeeTypes;

                _adjectiveEmployeeTypes = new AdjectiveEmployeeTypeRepository(Context);
                return _adjectiveEmployeeTypes;
            }
        }

        public IBranchRepository Branches
        {
            get
            {
                if (_branches != null)
                    return _branches;

                _branches = new BranchRepository(Context);
                return _branches;
            }
        }

        public ICurrentSituationRepository CurrentSituations
        {
            get
            {
                if (_currentSituations != null)
                    return _currentSituations;

                _currentSituations = new CurrentSituationRepository(Context);
                return _currentSituations;
            }
        }

        public IDepartmentRepository Departments
        {
            get
            {
                if (_departments != null)
                    return _departments;

                _departments = new DepartmentRepository(Context);
                return _departments;
            }
        }

        public IDivisionRepository Divisions
        {
            get
            {
                if (_divisions != null)
                    return _divisions;

                _divisions = new DivisionRepository(Context);
                return _divisions;
            }
        }

        public virtual IEmployeeRepository Employees
        {
            get
            {
                if (_employees != null)
                    return _employees;

                _employees = new EmployeeRepository(Context);
                return _employees;
            }
        }

        public IEmploymentTypeRepository EmploymentTypes
        {
            get
            {
                if (_employmentTypes != null)
                    return _employmentTypes;

                _employmentTypes = new EmploymentTypeRepository(Context);
                return _employmentTypes;
            }
        }

        public IJobRepository Jobs
        {
            get
            {
                if (_jobs != null)
                    return _jobs;

                _jobs = new JobRepository(Context);
                return _jobs;
            }
        }

        public IClassificationOnWorkRepository ClassificationOnWorks
        {
            get
            {
                if (_classificationOnWorks != null)
                    return _classificationOnWorks;

                _classificationOnWorks = new ClassificationOnWorkRepository(Context);
                return _classificationOnWorks;
            }
        }


        public IClassificationOnSearchingRepository ClassificationOnSearchings
        {
            get
            {
                if (_classificationOnSearchings != null)
                    return _classificationOnSearchings;

                _classificationOnSearchings = new ClassificationOnSearchingRepository(Context);
                return _classificationOnSearchings;
            }
        }

        public IJobInfoRepository JobInfos
        {
            get
            {
                if (_jobInfos != null)
                    return _jobInfos;

                _jobInfos = new JobInfoRepository(Context);
                return _jobInfos;
            }
        }

        public IMilitaryDataRepository MilitaryDatas
        {
            get
            {
                if (_militaryDatas != null)
                    return _militaryDatas;

                _militaryDatas = new MilitaryDataRepository(Context);
                return _militaryDatas;
            }
        }

        public INationalityRepository Nationalities
        {
            get
            {
                if (_nationalities != null)
                    return _nationalities;

                _nationalities = new NationalityRepository(Context);
                return _nationalities;
            }
        }

        public IPlaceRepository Places
        {
            get
            {
                if (_places != null)
                    return _places;

                _places = new PlaceRepository(Context);
                return _places;
            }
        }

        public IQualificationRepository Qualifications
        {
            get
            {
                if (_qualifications != null)
                    return _qualifications;

                _qualifications = new QualificationRepository(Context);
                return _qualifications;
            }
        }

        public IQualificationTypeRepository QualificationTypes
        {
            get
            {
                if (_qualificationTypes != null)
                    return _qualificationTypes;

                _qualificationTypes = new QualificationTypeRepository(Context);
                return _qualificationTypes;
            }
        }

        public IRewardRepository Rewards
        {
            get
            {
                if (_rewards != null)
                    return _rewards;

                _rewards = new RewardRepository(Context);
                return _rewards;
            }
        }

        public IRewardTypeRepository RewardTypes
        {
            get
            {
                if (_rewardTypes != null)
                    return _rewardTypes;

                _rewardTypes = new RewardTypeRepository(Context);
                return _rewardTypes;
            }
        }

        public ISanctionRepository Sanctions
        {
            get
            {
                if (_sanctions != null)
                    return _sanctions;

                _sanctions = new SanctionRepository(Context);
                return _sanctions;
            }
        }

        public ISanctionTypeRepository SanctionTypes
        {
            get
            {
                if (_sanctionTypes != null)
                    return _sanctionTypes;

                _sanctionTypes = new SanctionTypeRepository(Context);
                return _sanctionTypes;
            }
        }

        public ISpecialtyRepository Specialties
        {
            get
            {
                if (_specialties != null)
                    return _specialties;

                _specialties = new SpecialtyRepository(Context);
                return _specialties;
            }
        }

        public IStaffingRepository Staffings
        {
            get
            {
                if (_staffings != null)
                    return _staffings;

                _staffings = new StaffingRepository(Context);
                return _staffings;
            }
        }

        public IStaffingTypeRepository StaffingTypes
        {
            get
            {
                if (_staffingTypes != null)
                    return _staffingTypes;

                _staffingTypes = new StaffingTypeRepository(Context);
                return _staffingTypes;
            }
        }
        public IStaffingClassificationRepository StaffingClassification
        {
            get
            {
                if (_staffingClassification != null)
                    return _staffingClassification;

                _staffingClassification = new StaffingClassificationRepository(Context);
                return _staffingClassification;
            }
        }
        public ISubSpecialtyRepository SubSpecialties
        {
            get
            {
                if (_subSpecialties != null)
                    return _subSpecialties;

                _subSpecialties = new SubSpecialtyRepository(Context);
                return _subSpecialties;
            }
        }

        public IUnitRepository Units
        {
            get
            {
                if (_units != null)
                    return _units;

                _units = new UnitRepository(Context);
                return _units;
            }
        }

        public IVacationRepository Vacations
        {
            get
            {
                if (_vacations != null)
                    return _vacations;

                _vacations = new VacationRepository(Context);
                return _vacations;
            }
        }

        public IVacationTypeRepository VacationTypes
        {
            get
            {
                if (_vacationTypes != null)
                    return _vacationTypes;

                _vacationTypes = new VacationTypeRepository(Context);
                return _vacationTypes;
            }
        }

        public ITimeSheetRepository TimeSheets => null;

        public ITrainingCourseRepository TrainingCourses
        {
            get
            {
                if (_trainingCourses != null)
                    return _trainingCourses;

                _trainingCourses = new TrainingCourseRepository(Context);
                return _trainingCourses;
            }
        }

        public IEvaluationRepository Evaluations
        {
            get
            {
                if (_evaluations != null)
                    return _evaluations;

                _evaluations = new EvaluationRepository(Context);
                return _evaluations;
            }
        }

        public IExtraWorkRepository ExtraWorks
        {
            get
            {
                if (_extraWorks != null)
                    return _extraWorks;

                _extraWorks = new ExtraworkRepository(Context);
                return _extraWorks;
            }
        }

        public ISelfCoursesRepository SelfCourses
        {
            get
            {
                if (_selfCourses != null)
                    return _selfCourses;

                _selfCourses = new SelfCoursesRepository(Context);
                return _selfCourses;
            }
        }

        public IEndServicesRepository EndServices
        {
            get
            {
                if (_endServices != null)
                    return _endServices;

                _endServices = new EndServicesRepository(Context);
                return _endServices;
            }
        }

        public ISituationResolveJobRepository SituationResolveJobs
        {
            get
            {
                if (_situationResolveJobs != null)
                    return _situationResolveJobs;

                _situationResolveJobs = new SituationResolveJobRepository(Context);
                return _situationResolveJobs;
            }
        }

        public IBankRepository Banks
        {
            get
            {
                if (_banks != null)
                    return _banks;

                _banks = new BankRepository(Context);
                return _banks;
            }
        }

        public IBankBranchRepository BankBranches
        {
            get
            {
                if (_bankBranches != null)
                    return _bankBranches;

                _bankBranches = new BankBranchRepository(Context);
                return _bankBranches;
            }
        }

        public ICountryRepository Countries
        {
            get
            {
                if (_countries != null)
                    return _countries;

                _countries = new CountryRepository(Context);
                return _countries;
            }
        }

        public ICityRepository Cities
        {
            get
            {
                if (_cities != null)
                    return _cities;

                _cities = new CityRepository(Context);
                return _cities;
            }
        }

        public IAbsenceRepository Absences
        {
            get
            {
                if (_absences != null)
                    return _absences;

                _absences = new AbsenceRepository(Context);
                return _absences;
            }
        }

        public ITransferRepository Transfers
        {
            get
            {
                if (_transfers != null)
                    return _transfers;

                _transfers = new TransferRepository(Context);
                return _transfers;
            }
        }

        public ICorporationRepository Corporations
        {
            get
            {
                if (_corporations != null)
                    return _corporations;

                _corporations = new CorporationRepository(Context);
                return _corporations;
            }
        }

        public IDelegationRepository Delegations
        {
            get
            {
                if (_delegations != null)
                    return _delegations;

                _delegations = new DelegationRepository(Context);
                return _delegations;
            }
        }

        public IPremiumRepository Premiums
        {
            get
            {
                if (_premiums != null)
                    return _premiums;

                _premiums = new PremiumRepository(Context);
                return _premiums;
            }
        }

        public ISalaryRepository Salaries
        {
            get
            {
                if (_salaries != null)
                    return _salaries;

                _salaries = new SalaryRepository(Context);
                return _salaries;
            }
        }

        public ISettingRepository Settings
        {
            get
            {
                if (_settings != null)
                    return _settings;

                _settings = new SettingRepository(Context);
                return _settings;
            }
        }

        public IAdvancePaymentRepository AdvancePayments
        {
            get
            {
                if (_advancePayments != null)
                    return _advancePayments;

                _advancePayments = new AdvancePaymentRepository(Context);
                return _advancePayments;
            }
        }

        public IExactSpecialtyRepository ExactSpecialties
        {
            get
            {
                if (_exactSpecialties != null)
                    return _exactSpecialties;

                _exactSpecialties = new ExactSpecialtyRepository(Context);
                return _exactSpecialties;
            }
        }

        public ICenterRepository Centers
        {
            get
            {
                if (_centers != null)
                    return _centers;

                _centers = new CenterRepository(Context);
                return _centers;
            }
        }

        public IHolidayRepository Holidays
        {
            get
            {
                if (_holidays != null)
                    return _holidays;

                _holidays = new HolidayRepository(Context);
                return _holidays;
            }
        }


        public ITrainingRepository Trainings
        {
            get
            {
                if (_trainings != null)
                    return _trainings;

                _trainings = new TrainingRepository(Context);
                return _trainings;
            }
        }

        public IRequestedQualificationRepository RequestedQualifications
        {
            get
            {
                if (_requestedQualifications != null)
                    return _requestedQualifications;

                _requestedQualifications = new RequestedQualificationRepository(Context);
                return _requestedQualifications;
            }
        }
        public IDevelopmentStateRepository DevelopmentStates
        {
            get
            {
                if (_developmentStates != null)
                    return _developmentStates;

                _developmentStates = new DevelopmentStateRepository(Context);
                return _developmentStates;
            }
        }
        public IDevelopmentTypeARepository DevelopmentTypeAs
        {
            get
            {
                if (_developmentTypeAs != null)
                    return _developmentTypeAs;

                _developmentTypeAs = new DevelopmentTypeARepository(Context);
                return _developmentTypeAs;
            }
        }
        public IDevelopmentTypeBRepository DevelopmentTypeBs
        {
            get
            {
                if (_developmentTypeBs != null)
                    return _developmentTypeBs;

                _developmentTypeBs = new DevelopmentTypeBRepository(Context);
                return _developmentTypeBs;
            }
        }
        public IDevelopmentTypeCRepository DevelopmentTypeCs
        {
            get
            {
                if (_developmentTypeCs != null)
                    return _developmentTypeCs;

                _developmentTypeCs = new DevelopmentTypeCRepository(Context);
                return _developmentTypeCs;
            }
        }
        public IDevelopmentTypeDRepository DevelopmentTypeDs
        {
            get
            {
                if (_developmentTypeDs != null)
                    return _developmentTypeDs;

                _developmentTypeDs = new DevelopmentTypeDRepository(Context);
                return _developmentTypeDs;
            }
        }

        public IDocumentTypeRepository DocumentTypes
        {
            get
            {
                if (_documentTypes != null)
                    return _documentTypes;

                _documentTypes = new DocumentTypeRepository(Context);
                return _documentTypes;
            }
        }

        public IDocumentRepository Documents
        {
            get
            {
                if (_documents != null)
                    return _documents;

                _documents = new DocumentRepository(Context);
                return _documents;
            }
        }

        public IDocumentImageRepository DocumentImages
        {
            get
            {
                if (_documentImages != null)
                    return _documentImages;

                _documentImages = new DocumentImageRepository(Context);
                return _documentImages;
            }
        }

        public ISalaryUnitRepository SalaryUnits
        {
            get
            {
                if (_salaryUnits != null)
                    return _salaryUnits;

                _salaryUnits = new SalaryUnitRepository(Context);
                return _salaryUnits;
            }
        }

        public ICompanyInfoRepository CompanyInfo
        {
            get
            {
                if (_companyInfo != null)
                    return _companyInfo;

                _companyInfo = new CompanyInfoRepository(Context);
                return _companyInfo;
            }
        }
        public ICoachRepository Coaches
        {
            get
            {
                if (_coaches != null)
                    return _coaches;

                _coaches = new CoachRepository(Context);
                return _coaches;
            }
        }
        public ICourseRepository Courses
        {
            get
            {
                if (_courses != null)
                    return _courses;

                _courses = new CourseRepository(Context);
                return _courses;
            }
        }

        public iHistorySubsended HistorySubsended
        {
            get
            {
                if (_HistorySubsended != null)
                    return _HistorySubsended;

                _HistorySubsended = new HistorySubsendedRepository(Context);
                return _HistorySubsended;
            }
        }
    }
}
