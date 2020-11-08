using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Almotkaml.HR.EntityCore;

namespace Almotkaml.HR.EntityCore.Migrations
{
    [DbContext(typeof(HrDbContext))]
    [Migration("20170410200325_AddSubSpecialty")]
    partial class AddSubSpecialty
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

                    b.Property<int?>("BranchId");

                    b.Property<int?>("CurrentSituationId");

                    b.Property<DateTime>("DateTime");

                    b.Property<int?>("DepartmentId");

                    b.Property<int?>("DivisionId");

                    b.Property<int>("FiredBy_UserId");

                    b.Property<int?>("JobId");

                    b.Property<int?>("NationalityId");

                    b.Property<int?>("PlaceId");

                    b.Property<int?>("QualificationTypeId");

                    b.Property<int?>("RewardId");

                    b.Property<int?>("RewardTypeId");

                    b.Property<int?>("SanctionId");

                    b.Property<int?>("SanctionTypeId");

                    b.Property<int?>("SpecialtyId");

                    b.Property<int?>("StaffingId");

                    b.Property<int?>("StaffingTypeId");

                    b.Property<int?>("SubSpecialtyId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int?>("UnitId");

                    b.Property<int?>("UserGroupId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("ActivityId");

                    b.HasIndex("AdjectiveEmployeeId");

                    b.HasIndex("AdjectiveEmployeeTypeId");

                    b.HasIndex("BranchId");

                    b.HasIndex("CurrentSituationId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("FiredBy_UserId");

                    b.HasIndex("JobId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("QualificationTypeId");

                    b.HasIndex("RewardId");

                    b.HasIndex("RewardTypeId");

                    b.HasIndex("SanctionId");

                    b.HasIndex("SanctionTypeId");

                    b.HasIndex("SpecialtyId");

                    b.HasIndex("StaffingId");

                    b.HasIndex("StaffingTypeId");

                    b.HasIndex("SubSpecialtyId");

                    b.HasIndex("UnitId");

                    b.HasIndex("UserGroupId");

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
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.AdjectiveEmployee", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.AdjectiveEmployeeType", "AdjectiveEmployeeType")
                        .WithMany("AdjectiveEmployees")
                        .HasForeignKey("AdjectiveEmployeeTypeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Division", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Department", "Department")
                        .WithMany("Divisions")
                        .HasForeignKey("DepartmentId");
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

            modelBuilder.Entity("Almotkaml.HR.Domain.Place", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.Branch", "Branch")
                        .WithMany("Places")
                        .HasForeignKey("BranchId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Reward", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.RewardType", "RewardType")
                        .WithMany("Rewards")
                        .HasForeignKey("RewardTypeId");
                });

            modelBuilder.Entity("Almotkaml.HR.Domain.Sanction", b =>
                {
                    b.HasOne("Almotkaml.HR.Domain.SanctionType", "SanctionType")
                        .WithMany("Sanctions")
                        .HasForeignKey("SanctionTypeId");
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
