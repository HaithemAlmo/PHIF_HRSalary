using Almotkaml.Erp.Accounting.Repository;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.App_Business.General;
using Almotkaml.HR.Business.App_Business.MainSettings;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using Almotkaml.HR.Repository;

namespace Almotkaml.HR.Business
{
    public class HumanResource : Application<LoginModel, IUnitOfWork, ApplicationManager, User, ApplicationUser, IApplicationUser, ISettings, Permission, ICompanyInfo>
        , IHumanResource
    {
        private readonly AppConfig _erAppConfig;
        private IEndServicesBusiness _endServices;
        private IBounsBusiness _bouns;
        private IDegreeBusiness _degree;
        private IBankBusiness _bank;
        private IBankBranchBusiness _bankBranch;
        private ISituationResolveJobBusiness _situationResolveJob;
        private ICountryBusiness _country;
        private ICityBusiness _city;
        private IAbsenceBusiness _absence;
        private ITransferBusiness _transfer;
        private ICorporationBusiness _corporation;
        private IDelegationBusiness _delegation;
        private ISettingsBusiness _setting;
        private IPremiumBusiness _premium;
        private ISalaryBusiness _salary;
        private IAdvancePaymentBusiness _advancePayment;
        private ISalaryInfoBusiness _salaryInfo;
        private IExactSpecialtyBusiness _exactSpecialty;
        private ICenterBusiness _center;
        private IOldSalaryBusiness _oldSalary;
        private ISocialSecurityFundReportBusiness _socialSecurityFundReport;
        private ISolidarityFundReportBusiness _solidarityFundReport;
        private ITaxReportBusiness _taxReport;
        private IAdvancePaymentReportBusiness _advancePaymentReport;
        private IHolidayBusiness _holiday;
        private ICompanyInfoBusiness _companyInfo;
        private IHomeBusiness _home;
        private IBackUpRestoreBusiness _backUpRestore;
        private IRequestedQualificationBusiness _requestedQualification;
        private IDocumentTypeBusiness _documentType;
        private IUserActivityBusiness _userActivity;
        private IUserBusiness _user;
        private IUserGroupBusiness _userGroup;
        private IAdjectiveEmployeeBusiness _adjectiveEmployee;
        private IAdjectiveEmployeeTypeBusiness _adjectiveEmployeeType;
        private IBranchBusiness _branch;
        private ICurrentSituationBusiness _currentSituation;
        private IDepartmentBusiness _department;
        private IDivisionBusiness _division;
        private IEmployeeBusiness _employee;
        private IEmploymentTypeBusiness _employmentType;
        private IJobBusiness _job;
        private IClassificationOnSearchingBusiness _classificationOnSearching;
        private IClassificationOnWorkBusiness _classificationOnWork;
        private INationalityBusiness _nationality;
        private IPlaceBusiness _place;
        private IQualificationBusiness _qualification;
        private IQualificationTypeBusiness _qualificationType;
        private IRewardBusiness _reward;
        private IRewardTypeBusiness _rewardType;
        private ISanctionBusiness _sanction;
        private ISanctionTypeBusiness _sanctionType;
        private ISpecialtyBusiness _specialty;
        private IStaffingBusiness _staffing;
        private IStaffingTypeBusiness _staffingType;
        private IStaffingClassificationBusiness _StaffingClassification;
        private ISubSpecialtyBusiness _subSpecialty;
        private IUnitBusiness _unit;
        private IVacationBusiness _vacation;
        private IVacationTypeBusiness _vacationType;
        private IExtraWorkBusiness _extraWork;
        private ISelfCoursesBusiness _selfCourses;
        private IEvaluationBusiness _evaluation;
        private ITrainingCourseBusiness _trainingCourse;
        private IAccountBusiness _account;
        private ITrainingBusiness _training;
        private IDevelopmentStateBusiness _developmentState;
        private IDevelopmentTypeABusiness _developmentTypeA;
        private IDevelopmentTypeBBusiness _developmentTypeB;
        private IDevelopmentTypeCBusiness _developmentTypeC;
        private IDevelopmentTypeDBusiness _developmentTypeD;
        //private IDevelopmentTypeEBusiness _developmentTypeE;
        private ISalaryUnitBusiness _salaryUnit;
        private IRetirementBusiness _retirement;
        private ICoachBusiness _coach;
        private ICourseBusiness _course;
        private IEmployeeReportBusiness _employeeReport;
        private ISettlementReportBusiness _settlementReport;
        private ISettlementVacationReportBusiness _settlementVacationReport;
        private ISettlementAbsenceReportBusiness _settlementAbsenceReport;
        private ISalarySettlementReportBusiness _salarySettlementReport;
        private IDiscountSettlementReportBusiness _discountSettlementReport;
        private IPremiumSettlementReportBusiness _premiumSettlementReport;

        private IErpUnitOfWork _erpUnitOfWork;

        public HumanResource(StartUp<LoginModel> startUp, AppConfig erAppConfig) : base(startUp)
        {
            Check.NotNull(erAppConfig, nameof(erAppConfig));
            _erAppConfig = erAppConfig;
        }

        public HumanResource(StartUp<IApplicationUser, ISettings, ICompanyInfo> startUp, AppConfig erAppConfig) : base(startUp)
        {
            Check.NotNull(erAppConfig, nameof(erAppConfig));
            _erAppConfig = erAppConfig;
        }

        public override void Dispose()
        {
            _erpUnitOfWork?.Dispose();
            base.Dispose();
        }

        public IErpUnitOfWork ErpUnitOfWork
        {
            get
            {
                if (_erpUnitOfWork != null)
                    return _erpUnitOfWork;

                _erpUnitOfWork = ObjectCreator.Create<IErpUnitOfWork>(_erAppConfig.RepositoryType, _erAppConfig, 0);
                return _erpUnitOfWork;
            }
        }

        public IAccountBusiness Account
        {
            get
            {
                if (_account != null)
                    return _account;

                _account = new AccountBusiness(this);
                return _account;
            }
        }



        public IUserBusiness User
        {
            get
            {
                if (_user != null)
                    return _user;

                _user = new UserBusiness(this);
                return _user;
            }
        }

        public IUserGroupBusiness UserGroup
        {
            get
            {
                if (_userGroup != null)
                    return _userGroup;

                _userGroup = new UserGroupBusiness(this);
                return _userGroup;
            }
        }

        public IAdjectiveEmployeeBusiness AdjectiveEmployee
        {
            get
            {
                if (_adjectiveEmployee != null)
                    return _adjectiveEmployee;

                _adjectiveEmployee = new AdjectiveEmployeeBusiness(this);
                return _adjectiveEmployee;
            }
        }

        public IAdjectiveEmployeeTypeBusiness AdjectiveEmployeeType
        {
            get
            {
                if (_adjectiveEmployeeType != null)
                    return _adjectiveEmployeeType;

                _adjectiveEmployeeType = new AdjectiveEmployeeTypeBusiness(this);
                return _adjectiveEmployeeType;
            }
        }


        public IBranchBusiness Branch
        {
            get
            {
                if (_branch != null)
                    return _branch;

                _branch = new BranchBusiness(this);
                return _branch;
            }
        }


        public ICurrentSituationBusiness CurrentSituation
        {
            get
            {
                if (_currentSituation != null)
                    return _currentSituation;

                _currentSituation = new CurrentSituationBusiness(this);
                return _currentSituation;
            }
        }

        public IDepartmentBusiness Department
        {
            get
            {
                if (_department != null)
                    return _department;

                _department = new DepartmentBusiness(this);
                return _department;
            }
        }


        public IDivisionBusiness Division
        {
            get
            {
                if (_division != null)
                    return _division;

                _division = new DivisionBusiness(this);
                return _division;
            }
        }


        public virtual IEmployeeBusiness Employee
        {
            get
            {
                if (_employee != null)
                    return _employee;

                _employee = new EmployeeBusiness(this);
                return _employee;
            }
        }


        public IEmploymentTypeBusiness EmploymentType
        {
            get
            {
                if (_employmentType != null)
                    return _employmentType;

                _employmentType = new EmploymentTypeBusiness(this);
                return _employmentType;
            }
        }

        public IJobBusiness Job
        {
            get
            {
                if (_job != null)
                    return _job;

                _job = new JobBusiness(this);
                return _job;
            }
        }
        public IClassificationOnWorkBusiness ClassificationOnWork
        {
            get
            {
                if (_classificationOnWork != null)
                    return _classificationOnWork;

                _classificationOnWork = new ClassificationOnWorkBusiness(this);
                return _classificationOnWork;
            }
        }
        public IClassificationOnSearchingBusiness ClassificationOnSearching
        {
            get
            {
                if (_classificationOnSearching != null)
                    return _classificationOnSearching;

                _classificationOnSearching = new ClassificationOnSearchingBusiness(this);
                return _classificationOnSearching;
            }
        }

        //public IJobInfoBusiness JobInfo { get; }
        //public IMilitaryDataBusiness MilitaryData { get; }

        public INationalityBusiness Nationality
        {
            get
            {
                if (_nationality != null)
                    return _nationality;

                _nationality = new NationalityBusiness(this);
                return _nationality;
            }
        }

        public IPlaceBusiness Place
        {
            get
            {
                if (_place != null)
                    return _place;

                _place = new PlaceBusiness(this);
                return _place;
            }
        }


        public IQualificationBusiness Qualification
        {
            get
            {
                if (_qualification != null)
                    return _qualification;

                _qualification = new QualificationBusiness(this);
                return _qualification;
            }
        }


        public IQualificationTypeBusiness QualificationType
        {
            get
            {
                if (_qualificationType != null)
                    return _qualificationType;

                _qualificationType = new QualificationTypeBusiness(this);
                return _qualificationType;
            }
        }



        public IRewardBusiness Reward
        {
            get
            {
                if (_reward != null)
                    return _reward;

                _reward = new RewardBusiness(this);
                return _reward;
            }
        }


        public IRewardTypeBusiness RewardType
        {
            get
            {
                if (_rewardType != null)
                    return _rewardType;

                _rewardType = new RewardTypeBusiness(this);
                return _rewardType;
            }
        }

        public ISanctionBusiness Sanction
        {
            get
            {
                if (_sanction != null)
                    return _sanction;

                _sanction = new SanctionBusiness(this);
                return _sanction;
            }
        }


        public ISanctionTypeBusiness SanctionType
        {
            get
            {
                if (_sanctionType != null)
                    return _sanctionType;

                _sanctionType = new SanctionTypeBusiness(this);
                return _sanctionType;
            }
        }


        public ISpecialtyBusiness Specialty
        {
            get
            {
                if (_specialty != null)
                    return _specialty;

                _specialty = new SpecialtyBusiness(this);
                return _specialty;
            }
        }


        public IStaffingBusiness Staffing
        {
            get
            {
                if (_staffing != null)
                    return _staffing;

                _staffing = new StaffingBusiness(this);
                return _staffing;
            }
        }


        public IStaffingTypeBusiness StaffingType
        {
            get
            {
                if (_staffingType != null)
                    return _staffingType;

                _staffingType = new StaffingTypeBusiness(this);
                return _staffingType;
            }
        }

        public IStaffingClassificationBusiness StaffingClassification
        {
            get
            {
                if (_StaffingClassification != null)
                    return _StaffingClassification;

                _StaffingClassification = new StaffingClassificationBusiness(this);
                return _StaffingClassification;
            }
        }
        public ISubSpecialtyBusiness SubSpecialty
        {
            get
            {
                if (_subSpecialty != null)
                    return _subSpecialty;

                _subSpecialty = new SubSpecialtyBusiness(this);
                return _subSpecialty;
            }
        }


        public IUnitBusiness Unit
        {
            get
            {
                if (_unit != null)
                    return _unit;

                _unit = new UnitBusiness(this);
                return _unit;
            }
        }


        public IVacationBusiness Vacation
        {
            get
            {
                if (_vacation != null)
                    return _vacation;

                _vacation = new VacationBusiness(this);
                return _vacation;
            }
        }


        public IVacationTypeBusiness VacationType
        {
            get
            {
                if (_vacationType != null)
                    return _vacationType;

                _vacationType = new VacationTypeBusiness(this);
                return _vacationType;
            }
        }


        public IExtraWorkBusiness ExtraWork
        {
            get
            {
                if (_extraWork != null)
                    return _extraWork;

                _extraWork = new ExtraWorkBusiness(this);
                return _extraWork;
            }
        }


        public ISelfCoursesBusiness SelfCourses
        {
            get
            {
                if (_selfCourses != null)
                    return _selfCourses;

                _selfCourses = new SelfCoursesBusiness(this);
                return _selfCourses;
            }
        }


        public IEvaluationBusiness Evaluation
        {
            get
            {
                if (_evaluation != null)
                    return _evaluation;

                _evaluation = new EvaluationBusiness(this);
                return _evaluation;
            }
        }


        public ITrainingCourseBusiness TrainingCourse
        {
            get
            {
                if (_trainingCourse != null)
                    return _trainingCourse;

                _trainingCourse = new TrainingCourseBusiness(this);
                return _trainingCourse;
            }
        }


        public IEndServicesBusiness EndServices
        {
            get
            {
                if (_endServices != null)
                    return _endServices;

                _endServices = new EndServiceBusiness(this);
                return _endServices;
            }
        }

        public IBounsBusiness Bouns
        {
            get
            {
                if (_bouns != null)
                    return _bouns;

                _bouns = new BounsBusiness(this);
                return _bouns;
            }
        }


        public IDegreeBusiness Degree
        {
            get
            {
                if (_degree != null)
                    return _degree;

                _degree = new DegreeBusiness(this);
                return _degree;
            }
        }


        public IBankBusiness Bank
        {
            get
            {
                if (_bank != null)
                    return _bank;

                _bank = new BankBusiness(this);
                return _bank;
            }
        }


        public IBankBranchBusiness BankBranch
        {
            get
            {
                if (_bankBranch != null)
                    return _bankBranch;

                _bankBranch = new BankBranchBusiness(this);
                return _bankBranch;
            }
        }


        public ISituationResolveJobBusiness SituationResolveJob
        {
            get
            {
                if (_situationResolveJob != null)
                    return _situationResolveJob;

                _situationResolveJob = new SituationResolveJobBusiness(this);
                return _situationResolveJob;
            }
        }


        public ICountryBusiness Country
        {
            get
            {
                if (_country != null)
                    return _country;

                _country = new CountryBusiness(this);
                return _country;
            }
        }


        public ICityBusiness City
        {
            get
            {
                if (_city != null)
                    return _city;

                _city = new CityBusiness(this);
                return _city;
            }
        }


        public IAbsenceBusiness Absence
        {
            get
            {
                if (_absence != null)
                    return _absence;

                _absence = new AbsenceBusiness(this);
                return _absence;
            }
        }


        public ITransferBusiness Transfer
        {
            get
            {
                if (_transfer != null)
                    return _transfer;

                _transfer = new TransferBusiness(this);
                return _transfer;
            }
        }


        public ICorporationBusiness Corporation
        {
            get
            {
                if (_corporation != null)
                    return _corporation;

                _corporation = new CorporationBusiness(this);
                return _corporation;
            }
        }


        public IDelegationBusiness Delegation
        {
            get
            {
                if (_delegation != null)
                    return _delegation;

                _delegation = new DelegationBusiness(this);
                return _delegation;
            }
        }


        public ISettingsBusiness Setting
        {
            get
            {
                if (_setting != null)
                    return _setting;

                _setting = new SettingsBusiness(this);
                return _setting;
            }
        }


        public IPremiumBusiness Premium
        {
            get
            {
                if (_premium != null)
                    return _premium;

                _premium = new PremiumBusiness(this);
                return _premium;
            }
        }


        public ISalaryBusiness Salary
        {
            get
            {
                if (_salary != null)
                    return _salary;

                _salary = new SalaryBusiness(this);
                return _salary;
            }
        }


        public IAdvancePaymentBusiness AdvancePayment
        {
            get
            {
                if (_advancePayment != null)
                    return _advancePayment;

                _advancePayment = new AdvancePaymentBusiness(this);
                return _advancePayment;
            }
        }


        public ISalaryInfoBusiness SalaryInfo
        {
            get
            {
                if (_salaryInfo != null)
                    return _salaryInfo;

                _salaryInfo = new SalaryInfoBusiness(this);
                return _salaryInfo;
            }
        }


        public IExactSpecialtyBusiness ExactSpecialty
        {
            get
            {
                if (_exactSpecialty != null)
                    return _exactSpecialty;

                _exactSpecialty = new ExactSpecialtyBusiness(this);
                return _exactSpecialty;
            }
        }


        public ICenterBusiness Center
        {
            get
            {
                if (_center != null)
                    return _center;

                _center = new CenterBusiness(this);
                return _center;
            }
        }


        public IOldSalaryBusiness OldSalary
        {
            get
            {
                if (_oldSalary != null)
                    return _oldSalary;

                _oldSalary = new OldSalaryBusiness(this);
                return _oldSalary;
            }
        }


        public ISocialSecurityFundReportBusiness SocialSecurityFundReport
        {
            get
            {
                if (_socialSecurityFundReport != null)
                    return _socialSecurityFundReport;

                _socialSecurityFundReport = new SocialSecurityFundReportBusiness(this);
                return _socialSecurityFundReport;
            }
        }


        public ISolidarityFundReportBusiness SolidarityFundReport
        {
            get
            {
                if (_solidarityFundReport != null)
                    return _solidarityFundReport;

                _solidarityFundReport = new SolidarityFundReportBusiness(this);
                return _solidarityFundReport;
            }
        }


        public ITaxReportBusiness TaxReport
        {
            get
            {
                if (_taxReport != null)
                    return _taxReport;

                _taxReport = new TaxReportBusiness(this);
                return _taxReport;
            }
        }



        public IAdvancePaymentReportBusiness AdvancePaymentReport
        {
            get
            {
                if (_advancePaymentReport != null)
                    return _advancePaymentReport;

                _advancePaymentReport = new AdvancePaymentReportBusiness(this);
                return _advancePaymentReport;
            }
        }

        public IHolidayBusiness Holiday
        {
            get
            {
                if (_holiday != null)
                    return _holiday;

                _holiday = new HolidayBusiness(this);
                return _holiday;
            }
        }


        public ICompanyInfoBusiness CompanyInfo
        {
            get
            {
                if (_companyInfo != null)
                    return _companyInfo;

                _companyInfo = new CompanyInfoBusiness(this);
                return _companyInfo;
            }
        }


        public IHomeBusiness Home
        {
            get
            {
                if (_home != null)
                    return _home;

                _home = new HomeBusiness(this);
                return _home;
            }
        }


        public IBackUpRestoreBusiness BackUpRestore
        {
            get
            {
                if (_backUpRestore != null)
                    return _backUpRestore;

                _backUpRestore = new BackUpRestoreBusiness(this);
                return _backUpRestore;
            }
        }

        public IRequestedQualificationBusiness RequestedQualification
        {
            get
            {
                if (_requestedQualification != null)
                    return _requestedQualification;

                _requestedQualification = new RequestedQualificationBusiness(this);
                return _requestedQualification;
            }
        }
        public IDevelopmentStateBusiness DevelopmentState
        {
            get
            {
                if (_developmentState != null)
                    return _developmentState;

                _developmentState = new DevelopmentStateBusiness(this);
                return _developmentState;
            }
        }
        public ITrainingBusiness Training
        {
            get
            {
                if (_training != null)
                    return _training;

                _training = new TrainingBusiness(this);
                return _training;
            }
        }
        public IDevelopmentTypeABusiness DevelopmentTypeA
        {
            get
            {
                if (_developmentTypeA != null)
                    return _developmentTypeA;

                _developmentTypeA = new DevelopmentTypeABusiness(this);
                return _developmentTypeA;
            }
        }
        public IDevelopmentTypeBBusiness DevelopmentTypeB
        {
            get
            {
                if (_developmentTypeB != null)
                    return _developmentTypeB;

                _developmentTypeB = new DevelopmentTypeBBusiness(this);
                return _developmentTypeB;
            }
        }
        public IDevelopmentTypeCBusiness DevelopmentTypeC
        {
            get
            {
                if (_developmentTypeC != null)
                    return _developmentTypeC;

                _developmentTypeC = new DevelopmentTypeCBusiness(this);
                return _developmentTypeC;
            }
        }
        public IDevelopmentTypeDBusiness DevelopmentTypeD
        {
            get
            {
                if (_developmentTypeD != null)
                    return _developmentTypeD;

                _developmentTypeD = new DevelopmentTypeDBusiness(this);
                return _developmentTypeD;
            }
        }

        //public IDevelopmentTypeEBusiness DevelopmentTypeE
        //{
        //    get
        //    {
        //        if (_developmentTypeE != null)
        //            return _developmentTypeE;

        //        _developmentTypeE = new DevelopmentTypeEBusiness(this);
        //        return _developmentTypeE;
        //    }
        //}

        public IDocumentTypeBusiness DocumentType
        {
            get
            {
                if (_documentType != null)
                    return _documentType;

                _documentType = new DocumentTypeBusiness(this);
                return _documentType;
            }
        }

        public ISalaryUnitBusiness SalaryUnit
        {
            get
            {
                if (_salaryUnit != null)
                    return _salaryUnit;

                _salaryUnit = new SalaryUnitBusiness(this);
                return _salaryUnit;
            }
        }
        public IRetirementBusiness Retirement
        {
            get
            {
                if (_retirement != null)
                    return _retirement;

                _retirement = new RetirementBusiness(this);
                return _retirement;
            }
        }
        public ICoachBusiness Coach
        {
            get
            {
                if (_coach != null)
                    return _coach;

                _coach = new CoachBusiness(this);
                return _coach;
            }
        }
        public ICourseBusiness Course
        {
            get
            {
                if (_course != null)
                    return _course;

                _course = new CourseBusiness(this);
                return _course;
            }
        }
        public IEmployeeReportBusiness EmployeeReport
        {
            get
            {
                if (_employeeReport != null)
                    return _employeeReport;

                _employeeReport = new EmployeeReportBusiness(this);
                return _employeeReport;
            }
        }

        public IUserActivityBusiness UserActivity
        {
            get
            {
                if (_userActivity != null)
                    return _userActivity;

                _userActivity = new UserActivityBusiness(this);
                return _userActivity;
            }
        }
        public ISettlementReportBusiness SettlementReport
        {
            get
            {
                if (_settlementReport != null)
                    return _settlementReport;

                _settlementReport = new SettlementReportBusiness(this);
                return _settlementReport;
            }
        }
        public ISettlementVacationReportBusiness SettlementVacationReport
        {
            get
            {
                if (_settlementVacationReport != null)
                    return _settlementVacationReport;

                _settlementVacationReport = new SettlementVacationReportBusiness(this);
                return _settlementVacationReport;
            }
        }

        public ISettlementAbsenceReportBusiness SettlementAbsenceReport
        {
            get
            {
                if (_settlementAbsenceReport != null)
                    return _settlementAbsenceReport;

                _settlementAbsenceReport = new SettlementAbsenceReportBusiness(this);
                return _settlementAbsenceReport;
            }
        }

        public ISalarySettlementReportBusiness SalarySettlementReport
        {
            get
            {
                if (_salarySettlementReport != null)
                    return _salarySettlementReport;

                _salarySettlementReport = new SalarySettlementReportBusiness(this);
                return _salarySettlementReport;
            }
        }
        public IDiscountSettlementReportBusiness DiscountSettlementReport
        {
            get
            {
                if (_discountSettlementReport != null)
                    return _discountSettlementReport;

                _discountSettlementReport = new DiscountSettlementReportBusiness(this);
                return _discountSettlementReport;
            }
        }
        public IPremiumSettlementReportBusiness PremiumSettlementReport
        {
            get
            {
                if (_premiumSettlementReport != null)
                    return _premiumSettlementReport;

                _premiumSettlementReport = new PremiumSettlementReportBusiness(this);
                return _premiumSettlementReport;
            }
        }

    }
}
