using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Almotkaml.HR.EntityCore;
using Almotkaml.HR;

namespace Almotkaml.HR.EntityCore.Migrations
{
    [DbContext(typeof(HrDbContext))]
    [Migration("20170415215306_SituationResolveJob")]
    partial class SituationResolveJob
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Almotkaml.HR.Domain.Activity", b =>
                {
                    b.Property<long>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdjectiveEmployeeId");

                    b.Property<int?>("AdjectiveEmployeeTypeId");

                    b.Property<int?>("BankBranchId");

                    b.Property<int?>("BankId");

                    b.Property<int?>("BranchId");

                    b.Property<int?>("CurrentSituationId");

                    b.Property<DateTime>("DateTime");

                    b.Property<int?>("DepartmentId");

                    b.Property<int?>("DivisionId");

                    b.Property<int?>("EmployeeId");

                    b.Property<int?>("EndServicesId");

                    b.Property<int?>("EvaluationId");

                    b.Property<long?>("ExtraworkId");

                    b.Property<int>("FiredBy_UserId");

                    b.Property<int?>("JobId");

                    b.Property<int?>("NationalityId");

                    b.Property<int?>("PlaceId");

                    b.Property<int?>("QualificationId");

                    b.Property<int?>("QualificationTypeId");

                    b.Property<int?>("RewardId");

                    b.Property<int?>("RewardTypeId");

                    b.Property<int?>("SanctionId");

                    b.Property<int?>("SanctionTypeId");

                    b.Property<int?>("SelfCoursesId");

                    b.Property<int?>("SituationResolveJobId");

                    b.Property<int?>("SpecialtyId");

                    b.Property<int?>("StaffingId");

                    b.Property<int?>("StaffingTypeId");

                    b.Property<int?>("SubSpecialtyId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int?>("UnitId");

                    b.Property<int?>("UserGroupId");

                    b.Property<int?>("VacationTypeId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("ActivityId");

                    b.HasIndex("AdjectiveEmployeeId");

                    b.HasIndex("AdjectiveEmployeeTypeId");

                    b.HasIndex("BankBranchId");

                    b.HasIndex("BankId");

                    b.HasIndex("BranchId");

                    b.HasIndex("CurrentSituationId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EndServicesId");

                    b.HasIndex("EvaluationId");

                    b.HasIndex("ExtraworkId");

                    b.HasIndex("FiredBy_UserId");

                    b.HasIndex("JobId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("QualificationId");

                    b.HasIndex("QualificationTypeId");

                    b.HasIndex("RewardId");

                    b.HasIndex("RewardTypeId");

                    b.HasIndex("SanctionId");

                    b.HasIndex("SanctionTypeId");

                    b.HasIndex("SelfCoursesId");

                    b.HasIndex("SituationResolveJobId");

                    b.HasIndex("SpecialtyId");

                    b.HasIndex("StaffingId");

                    b.HasIndex("StaffingTypeId");

                    b.HasIndex("SubSpecialtyId");

                    b.HasIndex("UnitId");

                    b.HasIndex("UserGroupId");

                    b.HasIndex("VacationTypeId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.AdjectiveEmployee", b =>
                {
                    b.Property<int>("AdjectiveEmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdjectiveEmployeeTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("AdjectiveEmployeeId");

                    b.HasIndex("AdjectiveEmployeeTypeId");

                    b.ToTable("AdjectiveEmployees");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.AdjectiveEmployeeType", b =>
                {
                    b.Property<int>("AdjectiveEmployeeTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("AdjectiveEmployeeTypeId");

                    b.ToTable("AdjectiveEmployeeTypes");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Bank", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("BankId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.BankBranch", b =>
                {
                    b.Property<int>("BankBranchId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BankId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("BankBranchId");

                    b.HasIndex("BankId");

                    b.ToTable("BankBranches");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Booklet", b =>
                {
                    b.Property<int>("BookletId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CivilRegistry")
                        .HasMaxLength(128);

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("FamilyNumber")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("IssueDate");

                    b.Property<string>("IssuePlace")
                        .HasMaxLength(128);

                    b.Property<string>("Number")
                        .HasMaxLength(128);

                    b.Property<string>("RegistrationNumber")
                        .HasMaxLength(128);

                    b.HasKey("BookletId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Booklets");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("BranchId");

                    b.ToTable("Branchs");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.CurrentSituation", b =>
                {
                    b.Property<int>("CurrentSituationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("CurrentSituationId");

                    b.ToTable("CurrentSituations");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Division", b =>
                {
                    b.Property<int>("DivisionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DivisionId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(1000);

                    b.Property<int?>("AdjectiveEmployeeId");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("BirthPlace")
                        .HasMaxLength(128);

                    b.Property<int>("BloodType");

                    b.Property<int?>("ChildernCount");

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<string>("EnglishFatherName")
                        .HasMaxLength(128);

                    b.Property<string>("EnglishFirstName")
                        .HasMaxLength(128);

                    b.Property<string>("EnglishGrandfatherName")
                        .HasMaxLength(128);

                    b.Property<string>("EnglishLastName")
                        .HasMaxLength(128);

                    b.Property<string>("FatherName")
                        .HasMaxLength(128);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("Gender");

                    b.Property<string>("GrandfatherName")
                        .HasMaxLength(128);

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("JobId");

                    b.Property<string>("LastName")
                        .HasMaxLength(128);

                    b.Property<string>("MotherName")
                        .HasMaxLength(1000);

                    b.Property<long?>("NationalNumber");

                    b.Property<int?>("NationalityId");

                    b.Property<string>("Phone")
                        .HasMaxLength(128);

                    b.Property<int?>("PlaceId");

                    b.Property<int>("Religion");

                    b.Property<int>("SocialStatus");

                    b.Property<int?>("SubSpecialtyId");

                    b.Property<int?>("UnitId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("EmployeeId");

                    b.HasIndex("AdjectiveEmployeeId");

                    b.HasIndex("JobId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("SubSpecialtyId");

                    b.HasIndex("UnitId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.EmploymentValues", b =>
                {
                    b.Property<int>("EmploymentValuesId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BenefitFromServicesDate");

                    b.Property<string>("BenefitFromServicesSide")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("CollaboratorDate");

                    b.Property<string>("CollaboratorSide")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("ContractDateFrom");

                    b.Property<DateTime?>("ContractDateTo");

                    b.Property<DateTime?>("DelegationDate");

                    b.Property<string>("DelegationSide")
                        .HasMaxLength(1000);

                    b.Property<string>("DesignationIssue")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("DesignationResolutionDate");

                    b.Property<string>("DesignationResolutionNumber")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("EmptiedDate");

                    b.Property<string>("EmptiedSide")
                        .HasMaxLength(1000);

                    b.Property<int?>("JobInfoId");

                    b.Property<DateTime?>("LoaningDate");

                    b.Property<string>("LoaningSide")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("TransferDate");

                    b.Property<string>("TransferSide")
                        .HasMaxLength(1000);

                    b.HasKey("EmploymentValuesId");

                    b.HasIndex("JobInfoId")
                        .IsUnique();

                    b.ToTable("EmploymentValues");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.EndServices", b =>
                {
                    b.Property<int>("EndServicesId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CauseOfEndService");

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Note")
                        .HasMaxLength(1000);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("EndServicesId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("EndServiceses");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Evaluation", b =>
                {
                    b.Property<int>("EvaluationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("Grade");

                    b.Property<double?>("Ratio");

                    b.Property<int?>("Year");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("EvaluationId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Extrawork", b =>
                {
                    b.Property<long>("ExtraworkId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("DecisionNumber");

                    b.Property<int>("EmployeeId");

                    b.Property<decimal>("TimeCount");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("ExtraworkId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Extraworks");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.FinancialData", b =>
                {
                    b.Property<int>("FinancialDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BankBranchId");

                    b.Property<string>("BondNumber")
                        .HasMaxLength(128);

                    b.Property<string>("FinancialNumber")
                        .HasMaxLength(128);

                    b.Property<int?>("JobInfoId");

                    b.Property<decimal?>("Salary");

                    b.Property<string>("SecurityNumber")
                        .HasMaxLength(128);

                    b.HasKey("FinancialDataId");

                    b.HasIndex("BankBranchId");

                    b.HasIndex("JobInfoId")
                        .IsUnique();

                    b.ToTable("FinancialDatas");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.IdentificationCard", b =>
                {
                    b.Property<int>("IdentificationCardId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime?>("IssueDate");

                    b.Property<string>("IssuePlace")
                        .HasMaxLength(128);

                    b.Property<string>("Number")
                        .HasMaxLength(128);

                    b.HasKey("IdentificationCardId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("IdentificationCards");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.JobInfo", b =>
                {
                    b.Property<int>("JobInfoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdjectiveEmployeeId");

                    b.Property<int?>("Bouns");

                    b.Property<int?>("CurrentSituationId");

                    b.Property<DateTime?>("DateBouns");

                    b.Property<DateTime?>("DateDegreeNow");

                    b.Property<DateTime?>("DateMeritBouns");

                    b.Property<DateTime?>("DateMeritDegreeNow");

                    b.Property<int?>("Degree");

                    b.Property<int?>("DegreeNow");

                    b.Property<DateTime?>("DirectlyDate");

                    b.Property<int?>("EmployeeId");

                    b.Property<int?>("JobId");

                    b.Property<string>("JobNumber")
                        .HasMaxLength(128);

                    b.Property<int?>("JobNumberApproved");

                    b.Property<int>("JobType");

                    b.Property<int?>("NoteId");

                    b.Property<DateTime?>("ResolveResolutionDate");

                    b.Property<string>("ResolveResolutionNumber")
                        .HasMaxLength(128);

                    b.Property<int?>("SerialNumber");

                    b.Property<int?>("StaffingId");

                    b.Property<int?>("UnitId");

                    b.Property<int?>("VacationBalance");

                    b.HasKey("JobInfoId");

                    b.HasIndex("AdjectiveEmployeeId");

                    b.HasIndex("CurrentSituationId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("JobId");

                    b.HasIndex("StaffingId");

                    b.HasIndex("UnitId");

                    b.ToTable("JobInfos");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.MilitaryData", b =>
                {
                    b.Property<int>("MilitaryDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdjectiveMilitary");

                    b.Property<string>("College")
                        .HasMaxLength(128);

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime?>("GranduationDate");

                    b.Property<string>("MilitaryNumber")
                        .HasMaxLength(128);

                    b.Property<string>("MotherUnit")
                        .HasMaxLength(128);

                    b.Property<string>("Rank")
                        .HasMaxLength(128);

                    b.Property<string>("Subunit")
                        .HasMaxLength(128);

                    b.HasKey("MilitaryDataId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("MilitaryDatas");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Nationality", b =>
                {
                    b.Property<int>("NationalityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("NationalityId");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Notification", b =>
                {
                    b.Property<long>("NotificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ActivityId");

                    b.Property<bool>("IsRead");

                    b.Property<int>("Receiver_UserId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("NotificationId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("Receiver_UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Passport", b =>
                {
                    b.Property<int>("PassportId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AutoNumber")
                        .HasMaxLength(128);

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime?>("IssueDate");

                    b.Property<string>("IssuePlace")
                        .HasMaxLength(128);

                    b.Property<string>("Number")
                        .HasMaxLength(128);

                    b.HasKey("PassportId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Passports");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BranchId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("PlaceId");

                    b.HasIndex("BranchId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Qualification", b =>
                {
                    b.Property<int>("QualificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("GraduationCountry");

                    b.Property<string>("NameDonorFoundation");

                    b.Property<int>("QualificationTypeId");

                    b.Property<int?>("SubSpecialtyId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("QualificationId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("QualificationTypeId");

                    b.HasIndex("SubSpecialtyId");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.QualificationType", b =>
                {
                    b.Property<int>("QualificationTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("QualificationTypeId");

                    b.ToTable("QualificationTypes");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Reward", b =>
                {
                    b.Property<int>("RewardId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("EfficiencyEstimate");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Note");

                    b.Property<int>("RewardTypeId");

                    b.Property<string>("Value");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("RewardId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RewardTypeId");

                    b.ToTable("Rewards");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.RewardType", b =>
                {
                    b.Property<int>("RewardTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("RewardTypeId");

                    b.ToTable("RewardTypes");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Sanction", b =>
                {
                    b.Property<int>("SanctionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cause");

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("SanctionTypeId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("SanctionId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SanctionTypeId");

                    b.ToTable("Sanctions");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.SanctionType", b =>
                {
                    b.Property<int>("SanctionTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("SanctionTypeId");

                    b.ToTable("SanctionTypes");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.SelfCourses", b =>
                {
                    b.Property<int>("SelfCoursesId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseName");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Duration");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("Place");

                    b.Property<string>("Result");

                    b.Property<int>("SubSpecialtyId");

                    b.Property<string>("TrainingCenter");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("SelfCoursesId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SubSpecialtyId");

                    b.ToTable("SelfCourses");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.SituationResolveJob", b =>
                {
                    b.Property<int>("SituationResolveJobId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Boun");

                    b.Property<int>("BounNow");

                    b.Property<DateTime>("DateDegreeLast");

                    b.Property<DateTime>("DecisionDate");

                    b.Property<string>("DecisionNumber");

                    b.Property<int>("Degree");

                    b.Property<int>("DegreeNow");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("SituationResolveJobId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("SituationResolveJobs");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("SpecialtyId");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Staffing", b =>
                {
                    b.Property<int>("StaffingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("StaffingTypeId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("StaffingId");

                    b.HasIndex("StaffingTypeId");

                    b.ToTable("Staffings");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.StaffingType", b =>
                {
                    b.Property<int>("StaffingTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("StaffingTypeId");

                    b.ToTable("StaffingTypes");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.SubSpecialty", b =>
                {
                    b.Property<int>("SubSpecialtyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("SpecialtyId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("SubSpecialtyId");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("SubSpecialties");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DivisionId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("UnitId");

                    b.HasIndex("DivisionId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("UserGroupId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.Property<string>("_Notify")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.UserGroup", b =>
                {
                    b.Property<int>("UserGroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.Property<string>("_Permissions")
                        .IsRequired();

                    b.HasKey("UserGroupId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.VacationType", b =>
                {
                    b.Property<int>("VacationTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Days");

                    b.Property<int>("DiscountPercentage");

                    b.Property<bool>("Essential");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("VacationTypeId");

                    b.ToTable("VacationTypes");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Activity", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.AdjectiveEmployee")
                        .WithMany("Activities")
                        .HasForeignKey("AdjectiveEmployeeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.AdjectiveEmployeeType")
                        .WithMany("Activities")
                        .HasForeignKey("AdjectiveEmployeeTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.BankBranch")
                        .WithMany("Activities")
                        .HasForeignKey("BankBranchId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Bank")
                        .WithMany("Activities")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Branch")
                        .WithMany("Activities")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.CurrentSituation")
                        .WithMany("Activities")
                        .HasForeignKey("CurrentSituationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Department")
                        .WithMany("Activities")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Division")
                        .WithMany("Activities")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Employee")
                        .WithMany("Activities")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.EndServices")
                        .WithMany("Activities")
                        .HasForeignKey("EndServicesId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Evaluation")
                        .WithMany("Activities")
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Extrawork")
                        .WithMany("Activities")
                        .HasForeignKey("ExtraworkId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.User", "FiredBy_User")
                        .WithMany("Activities")
                        .HasForeignKey("FiredBy_UserId");

                    b.HasOne("Almotkaml.HR.Domain.Job")
                        .WithMany("Activities")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Nationality")
                        .WithMany("Activities")
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Place")
                        .WithMany("Activities")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Qualification")
                        .WithMany("Activities")
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.QualificationType")
                        .WithMany("Activities")
                        .HasForeignKey("QualificationTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Reward")
                        .WithMany("Activities")
                        .HasForeignKey("RewardId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.RewardType")
                        .WithMany("Activities")
                        .HasForeignKey("RewardTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Sanction")
                        .WithMany("Activities")
                        .HasForeignKey("SanctionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.SanctionType")
                        .WithMany("Activities")
                        .HasForeignKey("SanctionTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.SelfCourses")
                        .WithMany("Activities")
                        .HasForeignKey("SelfCoursesId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.SituationResolveJob")
                        .WithMany("Activities")
                        .HasForeignKey("SituationResolveJobId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Specialty")
                        .WithMany("Activities")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Staffing")
                        .WithMany("Activities")
                        .HasForeignKey("StaffingId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.StaffingType")
                        .WithMany("Activities")
                        .HasForeignKey("StaffingTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.SubSpecialty")
                        .WithMany("Activities")
                        .HasForeignKey("SubSpecialtyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.Unit")
                        .WithMany("Activities")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.UserGroup")
                        .WithMany("Activities")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Almotkaml.HR.Domain.VacationType")
                        .WithMany("Activities")
                        .HasForeignKey("VacationTypeId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.AdjectiveEmployee", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.AdjectiveEmployeeType", "AdjectiveEmployeeType")
                        .WithMany("AdjectiveEmployees")
                        .HasForeignKey("AdjectiveEmployeeTypeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.BankBranch", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Bank", "Bank")
                        .WithMany("BankBranchs")
                        .HasForeignKey("BankId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Booklet", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithOne("Booklet")
                        .HasForeignKey("Almotkaml.HR.Domain.Booklet", "EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Division", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Department", "Department")
                        .WithMany("Divisions")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Employee", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.AdjectiveEmployee")
                        .WithMany("Employees")
                        .HasForeignKey("AdjectiveEmployeeId");

                    b.HasOne("Almotkaml.HR.Domain.Job")
                        .WithMany("Employees")
                        .HasForeignKey("JobId");

                    b.HasOne("Almotkaml.HR.Domain.Nationality", "Nationality")
                        .WithMany("Employees")
                        .HasForeignKey("NationalityId");

                    b.HasOne("Almotkaml.HR.Domain.Place", "Place")
                        .WithMany("Employees")
                        .HasForeignKey("PlaceId");

                    b.HasOne("Almotkaml.HR.Domain.SubSpecialty")
                        .WithMany("Employees")
                        .HasForeignKey("SubSpecialtyId");

                    b.HasOne("Almotkaml.HR.Domain.Unit")
                        .WithMany("Employees")
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.EmploymentValues", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.JobInfo", "JobInfo")
                        .WithOne("EmploymentValues")
                        .HasForeignKey("Almotkaml.HR.Domain.EmploymentValues", "JobInfoId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.EndServices", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithOne("EndedServices")
                        .HasForeignKey("Almotkaml.HR.Domain.EndServices", "EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Evaluation", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("Evaluations")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Extrawork", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("Extraworks")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.FinancialData", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.BankBranch", "BankBranch")
                        .WithMany()
                        .HasForeignKey("BankBranchId");

                    b.HasOne("Almotkaml.HR.Domain.JobInfo", "JobInfo")
                        .WithOne("FinancialData")
                        .HasForeignKey("Almotkaml.HR.Domain.FinancialData", "JobInfoId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.IdentificationCard", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithOne("IdentificationCard")
                        .HasForeignKey("Almotkaml.HR.Domain.IdentificationCard", "EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.JobInfo", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.AdjectiveEmployee", "AdjectiveEmployee")
                        .WithMany()
                        .HasForeignKey("AdjectiveEmployeeId");

                    b.HasOne("Almotkaml.HR.Domain.CurrentSituation", "CurrentSituation")
                        .WithMany()
                        .HasForeignKey("CurrentSituationId");

                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithOne("JobInfo")
                        .HasForeignKey("Almotkaml.HR.Domain.JobInfo", "EmployeeId");

                    b.HasOne("Almotkaml.HR.Domain.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId");

                    b.HasOne("Almotkaml.HR.Domain.Staffing", "Staffing")
                        .WithMany()
                        .HasForeignKey("StaffingId");

                    b.HasOne("Almotkaml.HR.Domain.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.MilitaryData", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithOne("MilitaryData")
                        .HasForeignKey("Almotkaml.HR.Domain.MilitaryData", "EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Notification", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Activity", "Activity")
                        .WithMany("Notifications")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Almotkaml.HR.Domain.User", "Receiver_User")
                        .WithMany("Notifications")
                        .HasForeignKey("Receiver_UserId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Passport", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithOne("Passport")
                        .HasForeignKey("Almotkaml.HR.Domain.Passport", "EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Place", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Branch", "Branch")
                        .WithMany("Places")
                        .HasForeignKey("BranchId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Qualification", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("Qualifications")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Almotkaml.HR.Domain.QualificationType", "QualificationType")
                        .WithMany("Qualifications")
                        .HasForeignKey("QualificationTypeId");

                    b.HasOne("Almotkaml.HR.Domain.SubSpecialty", "SubSpecialty")
                        .WithMany("Qualifications")
                        .HasForeignKey("SubSpecialtyId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Reward", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("Rewards")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Almotkaml.HR.Domain.RewardType", "RewardType")
                        .WithMany("Rewards")
                        .HasForeignKey("RewardTypeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Sanction", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("Sanctions")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Almotkaml.HR.Domain.SanctionType", "SanctionType")
                        .WithMany("Sanctions")
                        .HasForeignKey("SanctionTypeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.SelfCourses", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("SelfCourseses")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Almotkaml.HR.Domain.SubSpecialty", "SubSpecialty")
                        .WithMany()
                        .HasForeignKey("SubSpecialtyId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.SituationResolveJob", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("SituationResolveJobs")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Staffing", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.StaffingType", "StaffingType")
                        .WithMany("Staffings")
                        .HasForeignKey("StaffingTypeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.SubSpecialty", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Specialty", "Specialty")
                        .WithMany("SubSpecialties")
                        .HasForeignKey("SpecialtyId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Unit", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Division", "Division")
                        .WithMany("Units")
                        .HasForeignKey("DivisionId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.User", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.UserGroup", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId");
                });
        }
    }
}
