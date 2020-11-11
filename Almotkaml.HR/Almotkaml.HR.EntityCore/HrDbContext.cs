using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.EntityCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Almotkaml.HR.EntityCore
{
    public class HrDbContext : DbContext
    {
        private readonly string _connectionString;
        internal int LoggedInUserId { get; set; }
        public HrDbContext() { }
        public HrDbContext(string connectionString, int loggedInUserId)
        {
            _connectionString = connectionString;
            LoggedInUserId = loggedInUserId;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelCreating(modelBuilder);
        }

        protected virtual void ModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>(Configurations.ConfigureUserGroup);
            modelBuilder.Entity<User>(Configurations.ConfigureUser);
            modelBuilder.Entity<Activity>(Configurations.ConfigureActivity);
            modelBuilder.Entity<Notification>(Configurations.ConfigureNotification);
            modelBuilder.Entity<Department>(Configurations.ConfigureDepartment);
            modelBuilder.Entity<Division>(Configurations.ConfigureDivision);
            modelBuilder.Entity<Job>(Configurations.ConfigureJob);
            modelBuilder.Entity<Place>(Configurations.ConfigurePlace);
            modelBuilder.Entity<Branch>(Configurations.ConfigureBranch);
            modelBuilder.Entity<AdjectiveEmployee>(Configurations.ConfigureAdjectiveEmployee);
            modelBuilder.Entity<AdjectiveEmployeeType>(Configurations.ConfigureAdjectiveEmployeeType);
            modelBuilder.Entity<Nationality>(Configurations.ConfigureNationality);
            modelBuilder.Entity<Unit>(Configurations.ConfigureUnit);
            modelBuilder.Entity<CurrentSituation>(Configurations.ConfigureCurrentSituation);
            modelBuilder.Entity<QualificationType>(Configurations.ConfigureQualificationType);
            modelBuilder.Entity<RewardType>(Configurations.ConfigureRewardType);
            modelBuilder.Entity<SanctionType>(Configurations.ConfigureSanctionType);
            modelBuilder.Entity<Specialty>(Configurations.ConfigureSpecialty);
            modelBuilder.Entity<StaffingType>(Configurations.ConfigureStaffingType);
            modelBuilder.Entity<Staffing>(Configurations.ConfigureStaffing);
            modelBuilder.Entity<SubSpecialty>(Configurations.ConfigureSubSpecialty);
            modelBuilder.Entity<Employee>(Configurations.ConfigureEmployee);
            modelBuilder.Entity<IdentificationCard>(Configurations.ConfigureIdentificationCard);
            modelBuilder.Entity<Booklet>(Configurations.ConfigureBooklet);
            modelBuilder.Entity<Passport>(Configurations.ConfigurePassport);
            modelBuilder.Entity<MilitaryData>(Configurations.ConfigureMilitaryData);
            modelBuilder.Entity<JobInfo>(Configurations.ConfigureJobInfo);
            modelBuilder.Entity<EmploymentValues>(Configurations.ConfigureEmploymentValues);
            modelBuilder.Entity<Extrawork>(Configurations.ConfigureExtrawork);
            modelBuilder.Entity<Evaluation>(Configurations.ConfigureEvaluation);
            modelBuilder.Entity<SelfCourses>(Configurations.ConfigureSelfCourses);
            modelBuilder.Entity<Qualification>(Configurations.ConfigureQualification);
            modelBuilder.Entity<Reward>(Configurations.ConfigureReward);
            modelBuilder.Entity<Sanction>(Configurations.ConfigureSanction);
            modelBuilder.Entity<EndServices>(Configurations.ConfigureEndServices);
            modelBuilder.Entity<Bank>(Configurations.ConfigureBank);
            modelBuilder.Entity<BankBranch>(Configurations.ConfigureBankBranch);
            modelBuilder.Entity<VacationType>(Configurations.ConfigureVacationType);
            modelBuilder.Entity<SituationResolveJob>(Configurations.ConfigureSituationResolveJob);
            modelBuilder.Entity<Country>(Configurations.ConfigureCountry);
            modelBuilder.Entity<EntrantsAndReviewers>(Configurations.ConfigureEntrantsAndReviewers);
            modelBuilder.Entity<City>(Configurations.ConfigureCity);
            modelBuilder.Entity<Absence>(Configurations.ConfigureAbsence);
            modelBuilder.Entity<Transfer>(Configurations.ConfigureTransfer);
            modelBuilder.Entity<Corporation>(Configurations.ConfigureCorporation);
            modelBuilder.Entity<Delegation>(Configurations.ConfigureDelegation);
            modelBuilder.Entity<Vacation>(Configurations.ConfigureVacation);
            modelBuilder.Entity<SalaryInfo>(Configurations.ConfigureSalaryInfo);
            modelBuilder.Entity<Salary>(Configurations.ConfigureSalary);
            modelBuilder.Entity<SalaryPremium>(Configurations.ConfigureSalaryPremium);
            modelBuilder.Entity<TemporaryPremium>(Configurations.ConfigureTemporaryPremium);
            modelBuilder.Entity<Premium>(Configurations.ConfigurePremium);
            modelBuilder.Entity<EmployeePremium>(Configurations.ConfigureEmployeePremium);
            modelBuilder.Entity<AdvancePayment>(Configurations.ConfigureAdvancePayment);
            modelBuilder.Entity<TrainingCourse>(Configurations.ConfigureTrainingCourse);
            modelBuilder.Entity<Setting>(Configurations.ConfigureSetting);
            modelBuilder.Entity<Center>(Configurations.ConfigureCenter);
            modelBuilder.Entity<ExactSpecialty>(Configurations.ConfigureExactSpecialty);
            modelBuilder.Entity<Holiday>(Configurations.ConfigureHoliday);
            modelBuilder.Entity<Info>(Configurations.ConfigureInfo);
            modelBuilder.Entity<ContactInfo>(Configurations.ConfigureContactInfo);
            modelBuilder.Entity<DevelopmentState>(Configurations.ConfigureDevelopmentState);
            modelBuilder.Entity<DevelopmentTypeA>(Configurations.ConfigureDevelopmentTypeA);
            modelBuilder.Entity<DevelopmentTypeB>(Configurations.ConfigureDevelopmentTypeB);
            modelBuilder.Entity<DevelopmentTypeC>(Configurations.ConfigureDevelopmentTypeC);
            modelBuilder.Entity<DevelopmentTypeD>(Configurations.ConfigureDevelopmentTypeD);
            modelBuilder.Entity<RequestedQualification>(Configurations.ConfigureRequestedQualification);
            modelBuilder.Entity<Training>(Configurations.ConfigureTraining);
            modelBuilder.Entity<DocumentType>(Configurations.ConfigureDocumentType);
            modelBuilder.Entity<Document>(Configurations.ConfigureDocument);
            modelBuilder.Entity<DocumentImage>(Configurations.ConfigureDocumentImage);
            modelBuilder.Entity<TrainingDetail>(Configurations.ConfigureTrainingDetail);
            modelBuilder.Entity<SalaryUnit>(Configurations.ConfigureSalaryUnit);
            modelBuilder.Entity<ClassificationOnWork>(Configurations.ConfigureClassificationOnWork);
            modelBuilder.Entity<ClassificationOnSearching>(Configurations.ConfigureClassificationOnSearching);
            modelBuilder.Entity<Coach>(Configurations.ConfigureCoach);
            modelBuilder.Entity<Course>(Configurations.ConfigureCourse);

            //modelBuilder.Ignore<ClassificationOnSearching>();
            //modelBuilder.Ignore<DevelopmentState>();
            //modelBuilder.Ignore<DevelopmentTypeA>();
            //modelBuilder.Ignore<DevelopmentTypeB>();
            //modelBuilder.Ignore<DevelopmentTypeC>();
            //modelBuilder.Ignore<DevelopmentTypeD>();
            //modelBuilder.Ignore<DevelopmentTypeE>();
            //modelBuilder.Ignore<RequestedQualification>();
            //modelBuilder.Ignore<Training>();
            //modelBuilder.Ignore<Holiday>();
            //modelBuilder.Ignore<ExactSpecialty>();
            modelBuilder.Ignore<TrainingCourse>();
            //modelBuilder.Ignore<SalaryInfo>();
            //modelBuilder.Ignore<Salary>();
            //modelBuilder.Ignore<SalaryPremium>();
            //modelBuilder.Ignore<TemporaryPremium>();
            //modelBuilder.Ignore<Premium>();
            //modelBuilder.Ignore<EmployeePremium>();
            //modelBuilder.Ignore<AdvancePayment>();
            //modelBuilder.Ignore<Setting>();
            //modelBuilder.Ignore<Delegation>();
            //modelBuilder.Ignore<SituationResolveJob>();
            //modelBuilder.Ignore<TrainingCenter>();
            //modelBuilder.Ignore<Transfer>();
            //modelBuilder.Ignore<Absence>();
            //modelBuilder.Ignore<City>();
            //modelBuilder.Ignore<Country>();
            modelBuilder.Ignore<Note>();
            //modelBuilder.Ignore<EmploymentValues>();
            //modelBuilder.Ignore<FinancialData>();
            //modelBuilder.Ignore<JobInfo>();
            //modelBuilder.Ignore<MilitaryData>();
            //modelBuilder.Ignore<Passport>();
            //modelBuilder.Ignore<Booklet>();
            //modelBuilder.Ignore<IdentificationCard>();
            //modelBuilder.Ignore<Employee>();
            //modelBuilder.Ignore<BankBranch>();
            //modelBuilder.Ignore<Bank>();
            //modelBuilder.Ignore<EndServices>();
            //modelBuilder.Ignore<Sanction>();
            //modelBuilder.Ignore<Reward>();
            //modelBuilder.Ignore<Qualification>();
            //modelBuilder.Ignore<SelfCourses>();
            //modelBuilder.Ignore<Evaluation>();
            //modelBuilder.Ignore<Extrawork>();
            //modelBuilder.Ignore<SubSpecialty>();
            //modelBuilder.Ignore<Staffing>();
            //modelBuilder.Ignore<StaffingType>();
            //modelBuilder.Ignore<Specialty>();
            //modelBuilder.Ignore<SanctionType>();
            //modelBuilder.Ignore<RewardType>();
            //modelBuilder.Ignore<QualificationType>();
            //modelBuilder.Ignore<CurrentSituation>();
            //modelBuilder.Ignore<Unit>();
            //modelBuilder.Ignore<Nationality>();
            //modelBuilder.Ignore<AdjectiveEmployeeType>();
            //modelBuilder.Ignore<AdjectiveEmployee>();
            //modelBuilder.Ignore<Vacation>();
            //modelBuilder.Ignore<VacationType>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString == null)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=AlmotkamlHrSalaryPHIF; Integrated security=true;");
                return;
            }
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            SaveUserGroups();
            SaveUsers();

            // Added Entries
            var addedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);

            foreach (var entry in addedEntries)
            {
                if (entry.Properties.Any(p => p.Metadata.Name == Configurations.DateCreated))
                    entry.Property(Configurations.DateCreated).CurrentValue = DateTime.UtcNow;

                if (entry.Properties.Any(p => p.Metadata.Name == Configurations.CreatedBy))
                    entry.Property(Configurations.CreatedBy).CurrentValue = LoggedInUserId;
            }


            // Modified Entries
            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);

            foreach (var entry in modifiedEntries)
            {
                if (entry.Properties.Any(p => p.Metadata.Name == Configurations.DateModified))
                    entry.Property(Configurations.DateModified).CurrentValue = DateTime.UtcNow;

                if (entry.Properties.Any(p => p.Metadata.Name == Configurations.ModifiedBy))
                    entry.Property(Configurations.ModifiedBy).CurrentValue = LoggedInUserId;
            }

            // Deleted Entries

            return base.SaveChanges();
        }
         public DbSet<SalaryCertified> SalaryCertified { get; set; }
        public DbSet<HistorySubsended> HistorySubsended { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<AdjectiveEmployee> AdjectiveEmployees { get; set; }
        public DbSet<AdjectiveEmployeeType> AdjectiveEmployeeTypes { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<CurrentSituation> CurrentSituations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobInfo> JobInfos { get; set; }
        public DbSet<MilitaryData> MilitaryDatas { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<QualificationType> QualificationTypes { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<RewardType> RewardTypes { get; set; }
        public DbSet<Sanction> Sanctions { get; set; }
        public DbSet<SanctionType> SanctionTypes { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Staffing> Staffings { get; set; }
        public DbSet<StaffingType> StaffingTypes { get; set; }
        public DbSet<StaffingClassification> StaffingClassifications { get; set; }
        public DbSet<SubSpecialty> SubSpecialties { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }
        public DbSet<Booklet> Booklets { get; set; }
        public DbSet<IdentificationCard> IdentificationCards { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<EmploymentValues> EmploymentValues { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<SelfCourses> SelfCourses { get; set; }
        public DbSet<Extrawork> Extraworks { get; set; }
        public DbSet<EndServices> EndServiceses { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<SituationResolveJob> SituationResolveJobs { get; set; }
        public DbSet<Country> Countries { get; set; }
       
        public DbSet<EntrantsAndReviewers> EntrantsAndReviewerss { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Delegation> Delegations { get; set; }
        public DbSet<SalaryInfo> SalaryInfos { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<SalaryPremium> SalaryPremiums { get; set; }
        public DbSet<TemporaryPremium> TemporaryPremiums { get; set; }
        public DbSet<Premium> Premiums { get; set; }
        public DbSet<EmployeePremium> EmployeePremiums { get; set; }
        public DbSet<AdvancePayment> AdvancePayments { get; set; }
        public DbSet<TrainingCourse> TrainingCourses { get; set; }
        public DbSet<ExactSpecialty> ExactSpecialties { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<DevelopmentState> DevelopmentStates { get; set; }
        public DbSet<DevelopmentTypeA> DevelopmentTypeAs { get; set; }
        public DbSet<DevelopmentTypeB> DevelopmentTypeBs { get; set; }
        public DbSet<DevelopmentTypeC> DevelopmentTypeCs { get; set; }
        public DbSet<DevelopmentTypeD> DevelopmentTypeDs { get; set; }
        //public DbSet<DevelopmentTypeE> DevelopmentTypeEs { get; set; }
        public DbSet<RequestedQualification> RequestedQualifications { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingDetail> TrainingDetails { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentImage> DocumentImages { get; set; }
        public DbSet<SalaryUnit> SalaryUnits { get; set; }
        public DbSet<ClassificationOnWork> ClassificationOnWorks { get; set; }
        public DbSet<ClassificationOnSearching> ClassificationOnSearchings { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Course> Courses { get; set; }

        #region private
        private void SaveUserGroups()
        {
            var userGroupEntries = ChangeTracker
                .Entries<UserGroup>();

            foreach (var userGroup in userGroupEntries)
            {
                var permissions = userGroup.Entity.Permissions.ToSerializedObject();
                if (permissions != userGroup.Property<string>(Configurations.Column(nameof(UserGroup.Permissions))).CurrentValue)
                {
                    userGroup.Property<string>(Configurations.Column(nameof(UserGroup.Permissions))).CurrentValue = permissions;

                    if (userGroup.State == EntityState.Unchanged)
                        userGroup.State = EntityState.Modified;
                }
            }
        }
        private void SaveUsers()
        {
            var userEntries = ChangeTracker
                .Entries<User>();

            foreach (var user in userEntries)
            {
                var notify = user.Entity.Notify.ToSerializedObject();
                if (notify != user.Property<string>(Configurations.Column(nameof(User.Notify))).CurrentValue)
                {
                    user.Property<string>(Configurations.Column(nameof(User.Notify))).CurrentValue = notify;

                    var passwordProperty = user.Property(nameof(user.Entity.Password));

                    if (user.State == EntityState.Added || passwordProperty.OriginalValue != passwordProperty.CurrentValue)
                        user.Entity.SetValue(u => u.Password, user.Entity.Password.ToMd5());

                    if (user.State == EntityState.Unchanged)
                        user.State = EntityState.Modified;
                }
            }
        }

        #endregion
    }
}
