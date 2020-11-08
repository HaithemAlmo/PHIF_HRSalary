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
    [Migration("20170819154204_ActivitesFixUp2")]
    partial class ActivitesFixUp2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Almotkaml.HR.Domain.Absence", b =>
                {
                    b.Property<int>("AbsenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AbsenceType");

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Note")
                        .HasMaxLength(1000);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("AbsenceId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Activity", b =>
                {
                    b.Property<long>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("FiredBy_UserId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("ActivityId");

                    b.HasIndex("FiredBy_UserId");

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

            modelBuilder.Entity("Almotkaml.HR.Domain.AdvancePayment", b =>
                {
                    b.Property<int>("AdvancePaymentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DeductionDate");

                    b.Property<int>("EmployeeId");

                    b.Property<decimal>("InstallmentValue");

                    b.Property<bool>("IsInside");

                    b.Property<decimal>("Value");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("AdvancePaymentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("AdvancePayments");
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

                    b.Property<int?>("AccountingManualId");

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

            modelBuilder.Entity("Almotkaml.HR.Domain.Center", b =>
                {
                    b.Property<int>("CenterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CostCenterId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("CenterId");

                    b.ToTable("Centers");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.ContactInfo", b =>
                {
                    b.Property<int>("ContactInfoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(128);

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("NearKindr")
                        .HasMaxLength(128);

                    b.Property<string>("NearPoint")
                        .HasMaxLength(128);

                    b.Property<string>("Note")
                        .HasMaxLength(1000);

                    b.Property<string>("Phone")
                        .HasMaxLength(128);

                    b.Property<string>("RelativeRelation")
                        .HasMaxLength(128);

                    b.Property<string>("WorkAddress")
                        .HasMaxLength(1000);

                    b.HasKey("ContactInfoId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
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

            modelBuilder.Entity("Almotkaml.HR.Domain.Delegation", b =>
                {
                    b.Property<int>("DelegationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("JobNumber")
                        .HasMaxLength(128);

                    b.Property<int>("JobTypeTransfer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("SideName")
                        .HasMaxLength(1000);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DelegationId");

                    b.ToTable("Delegations");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CenterId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DepartmentId");

                    b.HasIndex("CenterId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DevelopmentState", b =>
                {
                    b.Property<int>("DevelopmentStateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DevelopmentStateId");

                    b.ToTable("DevelopmentStates");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DevelopmentTypeA", b =>
                {
                    b.Property<int>("DevelopmentTypeAId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DevelopmentTypeAId");

                    b.ToTable("DevelopmentTypeAs");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DevelopmentTypeB", b =>
                {
                    b.Property<int>("DevelopmentTypeBId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DevelopmentTypeAId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DevelopmentTypeBId");

                    b.HasIndex("DevelopmentTypeAId");

                    b.ToTable("DevelopmentTypeBs");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DevelopmentTypeC", b =>
                {
                    b.Property<int>("DevelopmentTypeCId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DevelopmentTypeBId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DevelopmentTypeCId");

                    b.HasIndex("DevelopmentTypeBId");

                    b.ToTable("DevelopmentTypeCs");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DevelopmentTypeD", b =>
                {
                    b.Property<int>("DevelopmentTypeDId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DevelopmentTypeCId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DevelopmentTypeDId");

                    b.HasIndex("DevelopmentTypeCId");

                    b.ToTable("DevelopmentTypeDs");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DevelopmentTypeE", b =>
                {
                    b.Property<int>("DevelopmentTypeEId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DevelopmentTypeDId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DevelopmentTypeEId");

                    b.HasIndex("DevelopmentTypeDId");

                    b.ToTable("DevelopmentTypeEs");
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

            modelBuilder.Entity("Almotkaml.HR.Domain.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DecisionNumber");

                    b.Property<int?>("DecisionYear");

                    b.Property<int>("DocumentTypeId");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime?>("ExpireDate");

                    b.Property<DateTime>("IssueDate");

                    b.Property<string>("IssuePlace")
                        .HasMaxLength(128);

                    b.Property<string>("Note")
                        .HasMaxLength(1000);

                    b.Property<int>("Number");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DocumentId");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DocumentImage", b =>
                {
                    b.Property<int>("DocumentImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DocumentId");

                    b.Property<byte[]>("Image")
                        .IsRequired();

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DocumentImageId");

                    b.HasIndex("DocumentId");

                    b.ToTable("DocumentImages");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DocumentType", b =>
                {
                    b.Property<int>("DocumentTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("HaveDecisionNumber");

                    b.Property<bool>("HaveDecisionYear");

                    b.Property<bool>("HaveExpireDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DocumentTypeId");

                    b.ToTable("DocumentTypes");
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

                    b.Property<int?>("DivisionId");

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

                    b.Property<int?>("ExactSpecialtyId");

                    b.Property<string>("FatherName")
                        .HasMaxLength(128);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("Gender");

                    b.Property<string>("GrandfatherName")
                        .HasMaxLength(128);

                    b.Property<byte[]>("Image")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<int?>("JobId");

                    b.Property<string>("LastName")
                        .HasMaxLength(128);

                    b.Property<int>("LibyanOrForeigner");

                    b.Property<string>("MotherName")
                        .HasMaxLength(1000);

                    b.Property<string>("NationalNumber");

                    b.Property<int?>("NationalityId");

                    b.Property<string>("Phone")
                        .HasMaxLength(128);

                    b.Property<int?>("PlaceId");

                    b.Property<int>("Religion");

                    b.Property<int>("SocialStatus");

                    b.Property<int?>("UnitId");

                    b.Property<int?>("WifeNationalityId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("EmployeeId");

                    b.HasIndex("AdjectiveEmployeeId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("ExactSpecialtyId");

                    b.HasIndex("JobId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UnitId");

                    b.HasIndex("WifeNationalityId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.EmployeePremium", b =>
                {
                    b.Property<int>("PremiumId");

                    b.Property<int>("EmployeeId");

                    b.Property<decimal>("Value");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("PremiumId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeePremiums");
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

                    b.Property<string>("Cause")
                        .HasMaxLength(1000);

                    b.Property<int>("CauseOfEndService");

                    b.Property<DateTime>("DecisionDate");

                    b.Property<string>("DecisionNumber");

                    b.Property<int>("EmployeeId");

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

            modelBuilder.Entity("Almotkaml.HR.Domain.ExactSpecialty", b =>
                {
                    b.Property<int>("ExactSpecialtyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("SubSpecialtyId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("ExactSpecialtyId");

                    b.HasIndex("SubSpecialtyId");

                    b.ToTable("ExactSpecialties");
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

            modelBuilder.Entity("Almotkaml.HR.Domain.Holiday", b =>
                {
                    b.Property<int>("HolidayId")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("DayFrom");

                    b.Property<short>("DayTo");

                    b.Property<short>("MonthFrom");

                    b.Property<short>("MonthTo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("HolidayId");

                    b.ToTable("Holidays");
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

            modelBuilder.Entity("Almotkaml.HR.Domain.Premium", b =>
                {
                    b.Property<int>("PremiumId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsSubject");

                    b.Property<bool>("IsTemporary");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("PremiumId");

                    b.ToTable("Premiums");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Qualification", b =>
                {
                    b.Property<int>("QualificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AquiredSpecialty");

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<int?>("ExactSpecialtyId");

                    b.Property<string>("GraduationCountry");

                    b.Property<string>("NameDonorFoundation");

                    b.Property<int>("QualificationTypeId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("QualificationId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ExactSpecialtyId");

                    b.HasIndex("QualificationTypeId");

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

            modelBuilder.Entity("Almotkaml.HR.Domain.RequestedQualification", b =>
                {
                    b.Property<int>("RequestedQualificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("RequestedQualificationId");

                    b.ToTable("RequestedQualifications");
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

            modelBuilder.Entity("Almotkaml.HR.Domain.Salary", b =>
                {
                    b.Property<long>("SalaryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AbsenceDays");

                    b.Property<decimal>("AdvancePremiumInside");

                    b.Property<decimal>("AdvancePremiumOutside");

                    b.Property<int>("BankBranchId");

                    b.Property<decimal>("BasicSalary");

                    b.Property<string>("BondNumber")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<decimal>("ExtraWorkFixed");

                    b.Property<decimal>("ExtraWorkHoures");

                    b.Property<decimal>("ExtraWorkVacationHoures");

                    b.Property<bool>("IsClose");

                    b.Property<bool>("IsSuspended");

                    b.Property<string>("JobNumber")
                        .HasMaxLength(128);

                    b.Property<int>("Month");

                    b.Property<DateTime>("MonthDate");

                    b.Property<decimal>("PrepaidSalary");

                    b.Property<decimal>("Sanction");

                    b.Property<string>("SocialSecurityFundBondNumber")
                        .HasMaxLength(128);

                    b.Property<string>("SolidarityFundBondNumber")
                        .HasMaxLength(128);

                    b.Property<string>("SuspendedNote")
                        .HasMaxLength(1000);

                    b.Property<string>("TaxBondNumber")
                        .HasMaxLength(128);

                    b.Property<decimal>("WithoutPay");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("SalaryId");

                    b.HasIndex("BankBranchId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.SalaryInfo", b =>
                {
                    b.Property<int>("SalaryInfoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BankBranchId");

                    b.Property<decimal>("BasicSalary");

                    b.Property<string>("BondNumber")
                        .HasMaxLength(128);

                    b.Property<int?>("EmployeeId");

                    b.Property<decimal>("ExtraWorkFixed");

                    b.Property<string>("FinancialNumber")
                        .HasMaxLength(128);

                    b.Property<int>("GuaranteeType");

                    b.Property<string>("SecurityNumber")
                        .HasMaxLength(128);

                    b.HasKey("SalaryInfoId");

                    b.HasIndex("BankBranchId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("SalaryInfos");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.SalaryPremium", b =>
                {
                    b.Property<int>("PremiumId");

                    b.Property<long>("SalaryId");

                    b.Property<decimal>("Value");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("PremiumId", "SalaryId");

                    b.HasIndex("SalaryId");

                    b.ToTable("SalaryPremiums");
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

                    b.Property<int?>("Boun");

                    b.Property<int>("BounNow");

                    b.Property<DateTime?>("DateBounLast");

                    b.Property<DateTime?>("DateDegreeLast");

                    b.Property<DateTime>("DecisionDate");

                    b.Property<string>("DecisionNumber");

                    b.Property<int?>("Degree");

                    b.Property<int>("DegreeNow");

                    b.Property<int>("EmployeeId");

                    b.Property<int?>("JobLastId");

                    b.Property<int?>("JobNowId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("SituationResolveJobId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("JobLastId");

                    b.HasIndex("JobNowId");

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

            modelBuilder.Entity("Almotkaml.HR.Domain.TemporaryPremium", b =>
                {
                    b.Property<int>("TemporaryPremiumId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsSubject");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<long>("SalaryId");

                    b.Property<decimal>("Value");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("TemporaryPremiumId");

                    b.HasIndex("SalaryId");

                    b.ToTable("TemporaryPremiums");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Training", b =>
                {
                    b.Property<int>("TrainingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CityId");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("DecisionNumber")
                        .HasMaxLength(128);

                    b.Property<int>("DeducationType");

                    b.Property<int>("DevelopmentStateId");

                    b.Property<int>("DevelopmentTypeEId");

                    b.Property<int>("DonorFoundationType");

                    b.Property<string>("ExecutingAgency")
                        .HasMaxLength(128);

                    b.Property<string>("NameDonorFoundation")
                        .HasMaxLength(128);

                    b.Property<int>("RequestedQualificationId");

                    b.Property<string>("Subject")
                        .HasMaxLength(128);

                    b.Property<int>("TrainingCenterId");

                    b.Property<int>("TrainingType");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("TrainingId");

                    b.HasIndex("CityId");

                    b.HasIndex("DevelopmentStateId");

                    b.HasIndex("DevelopmentTypeEId");

                    b.HasIndex("RequestedQualificationId");

                    b.HasIndex("TrainingCenterId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.TrainingCenter", b =>
                {
                    b.Property<int>("TrainingCenterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(1000);

                    b.Property<int>("CityId");

                    b.Property<string>("Email")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Note")
                        .HasMaxLength(1000);

                    b.Property<string>("Phone")
                        .HasMaxLength(1000);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("TrainingCenterId");

                    b.HasIndex("CityId");

                    b.ToTable("TrainingCenters");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Transfer", b =>
                {
                    b.Property<int>("TransferId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("JobTypeTransfer");

                    b.Property<string>("SideName")
                        .HasMaxLength(1000);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("TransferId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Transfers");
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

            modelBuilder.Entity("Almotkaml.HR.Domain.Vacation", b =>
                {
                    b.Property<long>("VacationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<DateTime?>("DecisionDate");

                    b.Property<string>("DecisionNumber")
                        .HasMaxLength(128);

                    b.Property<int>("EmployeeId");

                    b.Property<bool>("Place");

                    b.Property<int>("VacationTypeId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("VacationId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VacationTypeId");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.VacationType", b =>
                {
                    b.Property<int>("VacationTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Days");

                    b.Property<int?>("DiscountPercentage");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("VacationEssential");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("VacationTypeId");

                    b.ToTable("VacationTypes");
                });

            modelBuilder.Entity("Almotkaml.HR.EntityCore.Entities.Info", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value")
                        .HasMaxLength(1000);

                    b.HasKey("Name");

                    b.ToTable("Info");
                });

            modelBuilder.Entity("Almotkaml.HR.EntityCore.Entities.Setting", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value")
                        .HasMaxLength(1000);

                    b.HasKey("Name");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Absence", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("Absences")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Activity", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.User", "FiredBy_User")
                        .WithMany("Activities")
                        .HasForeignKey("FiredBy_UserId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.AdjectiveEmployee", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.AdjectiveEmployeeType", "AdjectiveEmployeeType")
                        .WithMany("AdjectiveEmployees")
                        .HasForeignKey("AdjectiveEmployeeTypeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.AdvancePayment", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("AdvancePayments")
                        .HasForeignKey("EmployeeId");
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

            modelBuilder.Entity("Almotkaml.HR.Domain.City", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.ContactInfo", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithOne("ContactInfo")
                        .HasForeignKey("Almotkaml.HR.Domain.ContactInfo", "EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Department", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Center", "Center")
                        .WithMany("Departments")
                        .HasForeignKey("CenterId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DevelopmentTypeB", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.DevelopmentTypeA", "DevelopmentTypeA")
                        .WithMany("DevelopmentTypeBs")
                        .HasForeignKey("DevelopmentTypeAId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DevelopmentTypeC", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.DevelopmentTypeB", "DevelopmentTypeB")
                        .WithMany("DevelopmentTypeCs")
                        .HasForeignKey("DevelopmentTypeBId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DevelopmentTypeD", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.DevelopmentTypeC", "DevelopmentTypeC")
                        .WithMany("DevelopmentTypeDs")
                        .HasForeignKey("DevelopmentTypeCId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DevelopmentTypeE", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.DevelopmentTypeD", "DevelopmentTypeD")
                        .WithMany("DevelopmentTypeEs")
                        .HasForeignKey("DevelopmentTypeDId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Division", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Department", "Department")
                        .WithMany("Divisions")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Document", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId");

                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("Documents")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.DocumentImage", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Document", "Document")
                        .WithMany("DocumentImages")
                        .HasForeignKey("DocumentId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Employee", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.AdjectiveEmployee")
                        .WithMany("Employees")
                        .HasForeignKey("AdjectiveEmployeeId");

                    b.HasOne("Almotkaml.HR.Domain.Division")
                        .WithMany("Employees")
                        .HasForeignKey("DivisionId");

                    b.HasOne("Almotkaml.HR.Domain.ExactSpecialty")
                        .WithMany("Employees")
                        .HasForeignKey("ExactSpecialtyId");

                    b.HasOne("Almotkaml.HR.Domain.Job")
                        .WithMany("Employees")
                        .HasForeignKey("JobId");

                    b.HasOne("Almotkaml.HR.Domain.Nationality", "Nationality")
                        .WithMany("Employees")
                        .HasForeignKey("NationalityId");

                    b.HasOne("Almotkaml.HR.Domain.Place", "Place")
                        .WithMany("Employees")
                        .HasForeignKey("PlaceId");

                    b.HasOne("Almotkaml.HR.Domain.Unit")
                        .WithMany("Employees")
                        .HasForeignKey("UnitId");

                    b.HasOne("Almotkaml.HR.Domain.Nationality", "WifeNationality")
                        .WithMany()
                        .HasForeignKey("WifeNationalityId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.EmployeePremium", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("Premiums")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Almotkaml.HR.Domain.Premium", "Premium")
                        .WithMany()
                        .HasForeignKey("PremiumId");
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

            modelBuilder.Entity("Almotkaml.HR.Domain.ExactSpecialty", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.SubSpecialty", "SubSpecialty")
                        .WithMany("ExactSpecialties")
                        .HasForeignKey("SubSpecialtyId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Extrawork", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("Extraworks")
                        .HasForeignKey("EmployeeId");
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

                    b.HasOne("Almotkaml.HR.Domain.ExactSpecialty", "ExactSpecialty")
                        .WithMany("Qualifications")
                        .HasForeignKey("ExactSpecialtyId");

                    b.HasOne("Almotkaml.HR.Domain.QualificationType", "QualificationType")
                        .WithMany("Qualifications")
                        .HasForeignKey("QualificationTypeId");
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

            modelBuilder.Entity("Almotkaml.HR.Domain.Salary", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.BankBranch", "BankBranch")
                        .WithMany()
                        .HasForeignKey("BankBranchId");

                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("Salaries")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.SalaryInfo", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.BankBranch", "BankBranch")
                        .WithMany()
                        .HasForeignKey("BankBranchId");

                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithOne("SalaryInfo")
                        .HasForeignKey("Almotkaml.HR.Domain.SalaryInfo", "EmployeeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.SalaryPremium", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Premium", "Premium")
                        .WithMany()
                        .HasForeignKey("PremiumId");

                    b.HasOne("Almotkaml.HR.Domain.Salary", "Salary")
                        .WithMany("SalaryPremiums")
                        .HasForeignKey("SalaryId")
                        .OnDelete(DeleteBehavior.Cascade);
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

                    b.HasOne("Almotkaml.HR.Domain.Job", "JobLast")
                        .WithMany()
                        .HasForeignKey("JobLastId");

                    b.HasOne("Almotkaml.HR.Domain.Job", "JobNow")
                        .WithMany()
                        .HasForeignKey("JobNowId");
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

            modelBuilder.Entity("Almotkaml.HR.Domain.TemporaryPremium", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Salary", "Salary")
                        .WithMany("TemporaryPremiums")
                        .HasForeignKey("SalaryId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Training", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Almotkaml.HR.Domain.DevelopmentState", "DevelopmentState")
                        .WithMany()
                        .HasForeignKey("DevelopmentStateId");

                    b.HasOne("Almotkaml.HR.Domain.DevelopmentTypeE", "DevelopmentTypeE")
                        .WithMany()
                        .HasForeignKey("DevelopmentTypeEId");

                    b.HasOne("Almotkaml.HR.Domain.RequestedQualification", "RequestedQualification")
                        .WithMany()
                        .HasForeignKey("RequestedQualificationId");

                    b.HasOne("Almotkaml.HR.Domain.TrainingCenter", "TrainingCenter")
                        .WithMany()
                        .HasForeignKey("TrainingCenterId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.TrainingCenter", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.City", "City")
                        .WithMany("TrainingCenters")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Transfer", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("Transfers")
                        .HasForeignKey("EmployeeId");
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

            modelBuilder.Entity("Almotkaml.HR.Domain.Vacation", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Employee", "Employee")
                        .WithMany("Vacations")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Almotkaml.HR.Domain.VacationType", "VacationType")
                        .WithMany("Vacations")
                        .HasForeignKey("VacationTypeId");
                });
        }
    }
}
