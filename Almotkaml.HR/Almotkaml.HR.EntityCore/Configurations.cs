using Almotkaml.HR.Domain;
using Almotkaml.HR.EntityCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Almotkaml.HR.EntityCore
{
    public static class Configurations
    {
        #region helpers
        public static string DateCreated => "_" + nameof(DateCreated);
        public static string DateModified => "_" + nameof(DateModified);
        public static string CreatedBy => "_" + nameof(CreatedBy);
        public static string ModifiedBy => "_" + nameof(ModifiedBy);
        public static string Column(string name) => "_" + name;
        public static int SmallField => 128;
        public static int MidField => 1000;
        public static int BigField => 4000;
        public static string DecimalField => "decimal(18,10)";
        private static void SharedConfigurations<TEntityBuilder>(TEntityBuilder entity)
            where TEntityBuilder : EntityTypeBuilder
        {
            entity.Property<DateTime>(DateCreated);
            entity.Property<DateTime>(DateModified);
            entity.Property<int>(CreatedBy);
            entity.Property<int>(ModifiedBy);
        }
        public static string ToMd5(this string value)
        {
            var x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(value);
            bs = x.ComputeHash(bs);
            var s = new StringBuilder();
            foreach (var b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        #endregion

        public static void ConfigureUserGroup(EntityTypeBuilder<UserGroup> userGroup)
        {
            userGroup.Property(g => g.Name).HasMaxLength(SmallField).IsRequired();
            userGroup.Ignore(g => g.Permissions);
            userGroup.Property<string>(Column(nameof(UserGroup.Permissions))).IsRequired();
            userGroup.HasMany(g => g.Users).WithOne(u => u.UserGroup).OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(userGroup);
        }

        public static void ConfigureUser(EntityTypeBuilder<User> user)
        {
            user.Property(u => u.UserName).HasMaxLength(SmallField).IsRequired();
            user.Property(u => u.Title).HasMaxLength(SmallField).IsRequired();
            user.Property(u => u.Password).HasMaxLength(SmallField).IsRequired();
            user.Ignore(u => u.Notify);
            user.Property<string>(Column(nameof(User.Notify))).IsRequired();
            user.HasOne(u => u.UserGroup).WithMany(g => g.Users).OnDelete(DeleteBehavior.Restrict);
            user.HasMany(u => u.Activities).WithOne(a => a.FiredBy_User).OnDelete(DeleteBehavior.Restrict);
            user.HasMany(u => u.Notifications).WithOne(n => n.Receiver_User).OnDelete(DeleteBehavior.Restrict);
            user.HasMany(a => a.Activities).WithOne().OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(user);
        }

        public static void ConfigureActivity(EntityTypeBuilder<Activity> activity)
        {
            activity.Property(a => a.Type).HasMaxLength(SmallField).IsRequired();
            activity.HasOne(a => a.FiredBy_User).WithMany(u => u.Activities).OnDelete(DeleteBehavior.Restrict);
            activity.HasMany(a => a.Notifications).WithOne(n => n.Activity).OnDelete(DeleteBehavior.Cascade);
        }

        public static void ConfigureNotification(EntityTypeBuilder<Notification> notification)
        {
            notification.HasOne(n => n.Receiver_User).WithMany(u => u.Notifications).OnDelete(DeleteBehavior.Restrict);
            notification.HasOne(n => n.Activity).WithMany(a => a.Notifications).OnDelete(DeleteBehavior.Cascade);
        }

        public static void ConfigureSetting(EntityTypeBuilder<Setting> setting)
        {
            setting.HasKey(s => s.Name);
            setting.Property(s => s.Value).HasMaxLength(MidField);
        }
        public static void ConfigureInfo(EntityTypeBuilder<Info> info)
        {
            info.HasKey(s => s.Name);
            info.Property(s => s.Value).HasMaxLength(MidField);
        }

        public static void ConfigureCenter(EntityTypeBuilder<Center> center)
        {
            center.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);
            center.HasMany(d => d.Departments)
                .WithOne(d => d.Center)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(center);
        }
        public static void ConfigureDepartment(EntityTypeBuilder<Department> department)
        {
            department.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);
            department.HasMany(d => d.Divisions)
                .WithOne(d => d.Department)
                .OnDelete(DeleteBehavior.Restrict);

            department.HasOne(d => d.Center)
                .WithMany(d => d.Departments)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(department);
        }

        public static void ConfigureDivision(EntityTypeBuilder<Division> division)
        {
            division.Property(a => a.Name).IsRequired();

            division.HasOne(d => d.Department)
                .WithMany(d => d.Divisions)
                .OnDelete(DeleteBehavior.Restrict);

            division.HasMany(d => d.Units)
                .WithOne(u => u.Division)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(division);
        }

        public static void ConfigureJob(EntityTypeBuilder<Job> job)
        {
            job.Property(j => j.Name).IsRequired().HasMaxLength(SmallField);
            job.HasMany(j => j.Employees).WithOne().OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(job);
        }

        public static void ConfigureClassificationOnWork(EntityTypeBuilder<ClassificationOnWork> classificationOnWork)
        {
            classificationOnWork.Property(j => j.Name).IsRequired().HasMaxLength(SmallField);
            classificationOnWork.HasMany(j => j.Employees).WithOne().OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(classificationOnWork);
        }
        public static void ConfigureClassificationOnSearching(EntityTypeBuilder<ClassificationOnSearching> classificationOnSearching)
        {
            classificationOnSearching.Property(j => j.Name).IsRequired().HasMaxLength(SmallField);
            classificationOnSearching.HasMany(j => j.Employees).WithOne().OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(classificationOnSearching);
        }

        public static void ConfigurePlace(EntityTypeBuilder<Place> place)
        {
            place.Property(p => p.Name).IsRequired().HasMaxLength(SmallField);
            place.HasOne(p => p.Branch)
                .WithMany(b => b.Places)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(place);
            place.HasMany(j => j.Employees).WithOne(e => e.Place).OnDelete(DeleteBehavior.Restrict);
        }

        public static void ConfigureBranch(EntityTypeBuilder<Branch> branch)
        {
            branch.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);

            branch.HasMany(b => b.Places)
                .WithOne(b => b.Branch)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(branch);

        }

        public static void ConfigureAdjectiveEmployee(EntityTypeBuilder<AdjectiveEmployee> adjectiveEmployee)
        {
            adjectiveEmployee.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);
            adjectiveEmployee.HasOne(a => a.AdjectiveEmployeeType)
                .WithMany(a => a.AdjectiveEmployees)
                .OnDelete(DeleteBehavior.Restrict);
            adjectiveEmployee.Ignore(b => b.Employees);

            SharedConfigurations(adjectiveEmployee);
            adjectiveEmployee.HasMany(j => j.Employees).WithOne().OnDelete(DeleteBehavior.Restrict);
        }

        public static void ConfigureAdjectiveEmployeeType(EntityTypeBuilder<AdjectiveEmployeeType> adjectiveEmployeeType)
        {
            adjectiveEmployeeType.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);
            adjectiveEmployeeType.HasMany(b => b.AdjectiveEmployees)
                .WithOne(b => b.AdjectiveEmployeeType)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(adjectiveEmployeeType);
        }

        public static void ConfigureNationality(EntityTypeBuilder<Nationality> nationality)
        {
            nationality.Property(m => m.Name).IsRequired().HasMaxLength(SmallField);

            SharedConfigurations(nationality);
            nationality.HasMany(n => n.Employees)
                .WithOne(e => e.Nationality)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public static void ConfigureUnit(EntityTypeBuilder<Unit> unit)
        {
            unit.Property(u => u.Name).IsRequired().HasMaxLength(SmallField);
            unit.HasOne(p => p.Division)
                .WithMany(b => b.Units)
                .OnDelete(DeleteBehavior.Restrict);
            unit.Ignore(b => b.Employees);

            SharedConfigurations(unit);
            unit.HasMany(u => u.Employees).WithOne().OnDelete(DeleteBehavior.Restrict);
        }




        public static void ConfigureCurrentSituation(EntityTypeBuilder<CurrentSituation> currentSituation)
        {
            currentSituation.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);
            currentSituation.HasMany(d => d.Employees)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
            currentSituation.Ignore(b => b.Employees);

            SharedConfigurations(currentSituation);
        }
        public static void ConfigureQualificationType(EntityTypeBuilder<QualificationType> qualificationType)
        {
            qualificationType.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);
            qualificationType.HasMany(q => q.Qualifications).WithOne(q => q.QualificationType).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(qualificationType);
        }
        public static void ConfigureRewardType(EntityTypeBuilder<RewardType> rewardType)
        {
            rewardType.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);
            rewardType.HasMany(r => r.Rewards).WithOne(r => r.RewardType).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(rewardType);
        }
        public static void ConfigureSanctionType(EntityTypeBuilder<SanctionType> sanctionType)
        {
            sanctionType.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);
            sanctionType.HasMany(s => s.Sanctions).WithOne(s => s.SanctionType).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(sanctionType);
        }
        public static void ConfigureSpecialty(EntityTypeBuilder<Specialty> specialty)
        {
            specialty.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);
            specialty.HasMany(s => s.SubSpecialties).WithOne(s => s.Specialty).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(specialty);
        }
        public static void ConfigureStaffingType(EntityTypeBuilder<StaffingType> staffingType)
        {
            staffingType.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);
            staffingType.HasMany(s => s.Staffings).WithOne(s => s.StaffingType).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(staffingType);
        }

        public static void ConfigureStaffing(EntityTypeBuilder<Staffing> staffing)
        {
            staffing.Property(s => s.Name).IsRequired().HasMaxLength(SmallField);
            staffing.HasMany(s => s.Employees).WithOne().OnDelete(DeleteBehavior.Restrict);
            staffing.HasOne(s => s.StaffingType).WithMany(s => s.Staffings).OnDelete(DeleteBehavior.Restrict);
            staffing.Ignore(b => b.Employees);

            SharedConfigurations(staffing);
        }

        public static void ConfigureStaffingClassification(EntityTypeBuilder<StaffingClassification> staffingClassification)
        {
            staffingClassification.Property(s => s.Name).IsRequired().HasMaxLength(SmallField);
            //staffingClassification.Ignore(s => s.Employees).WithOne().OnDelete(DeleteBehavior.Restrict);
            staffingClassification.HasOne(s => s.Staffing).WithMany(s => s.StaffingClassification).OnDelete(DeleteBehavior.Restrict);
            staffingClassification.Ignore(b => b.Employees);

            SharedConfigurations(staffingClassification);
        }

        public static void ConfigureSubSpecialty(EntityTypeBuilder<SubSpecialty> subSpecialty)
        {
            subSpecialty.Property(s => s.Name).IsRequired().HasMaxLength(SmallField);
            subSpecialty.HasOne(s => s.Specialty).WithMany(s => s.SubSpecialties).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(subSpecialty);
        }


        public static void ConfigureEmployee(EntityTypeBuilder<Employee> employee)
        {
            employee.Property(e => e.FirstName).IsRequired().HasMaxLength(SmallField);
            employee.Property(e => e.Address).HasMaxLength(MidField);
            employee.Property(e => e.BirthPlace).HasMaxLength(SmallField);
            employee.Property(e => e.Email).HasMaxLength(SmallField);
            employee.Property(e => e.EnglishFatherName).HasMaxLength(SmallField);
            employee.Property(e => e.EnglishFirstName).HasMaxLength(SmallField);
            employee.Property(e => e.EnglishGrandfatherName).HasMaxLength(SmallField);
            employee.Property(e => e.EnglishLastName).HasMaxLength(SmallField);
            employee.Property(e => e.FatherName).HasMaxLength(SmallField);
            employee.Property(e => e.GrandfatherName).HasMaxLength(SmallField);
            employee.Property(e => e.LastName).HasMaxLength(SmallField);
            employee.Property(e => e.Phone).HasMaxLength(SmallField);
            employee.Property(e => e.MotherName).HasMaxLength(MidField);

            employee.HasOne(e => e.Nationality)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.NationalityId)
                .OnDelete(DeleteBehavior.Restrict);

            employee.HasOne(e => e.Place)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.PlaceId)
                .OnDelete(DeleteBehavior.Restrict);

            employee.HasMany(a => a.Qualifications)
                .WithOne(q => q.Employee)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            employee.HasMany(a => a.Rewards)
                .WithOne(r => r.Employee)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            employee.HasMany(a => a.Sanctions)
                .WithOne(r => r.Employee)
                .HasForeignKey(r => r.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            employee.HasMany(a => a.Vacations)
                .WithOne(v => v.Employee)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            employee.HasMany(a => a.SituationResolveJobs)
                .WithOne(v => v.Employee)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            employee.HasOne(e => e.Booklet)
                .WithOne(b => b.Employee)
                .HasForeignKey<Booklet>("EmployeeId")
                .OnDelete(DeleteBehavior.Restrict);

            employee.HasOne(e => e.IdentificationCard)
                .WithOne(b => b.Employee)
                .HasForeignKey<IdentificationCard>("EmployeeId")
                .OnDelete(DeleteBehavior.Restrict);

            employee.HasOne(e => e.ContactInfo)
                .WithOne(b => b.Employee)
                .HasForeignKey<ContactInfo>("EmployeeId")
                .OnDelete(DeleteBehavior.Restrict);

            employee.HasOne(e => e.Passport)
                .WithOne(b => b.Employee)
                .HasForeignKey<Passport>("EmployeeId")
                .OnDelete(DeleteBehavior.Restrict);

            employee.HasOne(e => e.JobInfo)
                .WithOne(b => b.Employee)
                .HasForeignKey<JobInfo>("EmployeeId")
                .OnDelete(DeleteBehavior.Restrict);
            //employee.Ignore(e => e.JobInfo);

            employee.HasOne(e => e.MilitaryData)
                .WithOne(b => b.Employee)
                .HasForeignKey<MilitaryData>("EmployeeId")
                .OnDelete(DeleteBehavior.Restrict);

            employee.HasOne(e => e.SalaryInfo)
                .WithOne(b => b.Employee)
                .HasForeignKey<SalaryInfo>("EmployeeId")
                .OnDelete(DeleteBehavior.Restrict);

            employee.Ignore(t => t.TrainingCourses);

            SharedConfigurations(employee);
        }

        public static void ConfigureContactInfo(EntityTypeBuilder<ContactInfo> contactInfo)
        {
            contactInfo.Property<int>("ContactInfoId");
            contactInfo.HasKey("ContactInfoId");
            contactInfo.Property(b => b.NearKindr).HasMaxLength(SmallField);
            contactInfo.Property(b => b.Note).HasMaxLength(MidField);
            contactInfo.Property(b => b.Phone).HasMaxLength(SmallField);
            contactInfo.Property(b => b.RelativeRelation).HasMaxLength(SmallField);
            contactInfo.Property(b => b.NearPoint).HasMaxLength(SmallField);
            contactInfo.Property(b => b.WorkAddress).HasMaxLength(MidField);
            contactInfo.Property(b => b.Address).HasMaxLength(SmallField);
        }
        public static void ConfigureBooklet(EntityTypeBuilder<Booklet> booklet)
        {
            booklet.Property<int>("BookletId");
            booklet.HasKey("BookletId");
            booklet.Property(b => b.CivilRegistry).HasMaxLength(SmallField);
            booklet.Property(b => b.FamilyNumber).HasMaxLength(SmallField);
            booklet.Property(b => b.IssuePlace).HasMaxLength(SmallField);
            booklet.Property(b => b.Number).HasMaxLength(SmallField);
            booklet.Property(b => b.RegistrationNumber).HasMaxLength(SmallField);
        }
        public static void ConfigureIdentificationCard(EntityTypeBuilder<IdentificationCard> identificationCard)
        {
            identificationCard.Property<int>("IdentificationCardId");
            identificationCard.HasKey("IdentificationCardId");
            identificationCard.Property(i => i.IssuePlace).HasMaxLength(SmallField);
            identificationCard.Property(i => i.Number).HasMaxLength(SmallField);
        }
        public static void ConfigurePassport(EntityTypeBuilder<Passport> passport)
        {
            passport.Property<int>("PassportId");
            passport.HasKey("PassportId");
            passport.Property(i => i.IssuePlace).HasMaxLength(SmallField);
            passport.Property(i => i.Number).HasMaxLength(SmallField);
            passport.Property(i => i.AutoNumber).HasMaxLength(SmallField);
        }


        public static void ConfigureJobInfo(EntityTypeBuilder<JobInfo> jobInfo)
        {
            jobInfo.Property<int>("JobInfoId");
            jobInfo.HasKey("JobInfoId");

            jobInfo.HasOne(e => e.EmploymentValues)
                .WithOne(e => e.JobInfo)
                .HasForeignKey<EmploymentValues>("JobInfoId")
                .OnDelete(DeleteBehavior.Restrict);

            jobInfo.Property<int>("JobClass");

            jobInfo.Property(p => p.Notes).HasMaxLength(MidField);
            jobInfo.Property(p => p.RedirectionNote).HasMaxLength(MidField);

            //jobInfo.HasOne(e => e.FinancialData)
            //       .WithOne(e => e.JobInfo)
            //    .HasForeignKey<FinancialData>("JobInfoId")
            //    .OnDelete(DeleteBehavior.Restrict);
        }

        //public static void ConfigureFinancialData(EntityTypeBuilder<FinancialData> financialData)
        //{
        //    financialData.Property<int>("FinancialDataId");
        //    financialData.HasKey("FinancialDataId");
        //    financialData.Property(i => i.BondNumber).HasMaxLength(SmallField);
        //    financialData.Property(i => i.SecurityNumber).HasMaxLength(SmallField);
        //    financialData.Property(i => i.FinancialNumber).HasMaxLength(SmallField);
        //}
        public static void ConfigureMilitaryData(EntityTypeBuilder<MilitaryData> militaryData)
        {
            militaryData.Property<int>("MilitaryDataId");
            militaryData.HasKey("MilitaryDataId");
            militaryData.Property(i => i.College).HasMaxLength(SmallField);
            militaryData.Property(i => i.MilitaryNumber).HasMaxLength(SmallField);
            militaryData.Property(i => i.MotherUnit).HasMaxLength(SmallField);
            militaryData.Property(i => i.Rank).HasMaxLength(SmallField);
            militaryData.Property(i => i.Subunit).HasMaxLength(SmallField);
        }
        public static void ConfigureSalaryInfo(EntityTypeBuilder<SalaryInfo> salaryInfo)
        {
            salaryInfo.Property<int>("SalaryInfoId");
            salaryInfo.HasKey("SalaryInfoId");
            salaryInfo.Property(i => i.BondNumber).HasMaxLength(SmallField);
            salaryInfo.Property(i => i.FinancialNumber).HasMaxLength(SmallField);
            salaryInfo.Property(i => i.SecurityNumber).HasMaxLength(SmallField);
            salaryInfo.Property(i => i.FileNumber).HasMaxLength(SmallField);

            salaryInfo.HasOne(a => a.BankBranch)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
        public static void ConfigureEmploymentValues(EntityTypeBuilder<EmploymentValues> employmentValues)
        {
            employmentValues.Property<int>("EmploymentValuesId");
            employmentValues.HasKey("EmploymentValuesId");
            employmentValues.Property(i => i.DesignationIssue).HasMaxLength(SmallField);
            employmentValues.Property(i => i.DesignationResolutionNumber).HasMaxLength(SmallField);
            employmentValues.Property(i => i.DelegationSide).HasMaxLength(MidField);
            employmentValues.Property(i => i.TransferSide).HasMaxLength(MidField);
            employmentValues.Property(i => i.BenefitFromServicesSide).HasMaxLength(MidField);
            employmentValues.Property(i => i.CollaboratorSide).HasMaxLength(MidField);
            employmentValues.Property(i => i.LoaningSide).HasMaxLength(MidField);
            employmentValues.Property(i => i.EmptiedSide).HasMaxLength(MidField);
        }

        public static void ConfigureEmploymentType(EntityTypeBuilder<EmploymentType> employmentType)
        {
            employmentType.Property(e => e.Name).IsRequired();
            employmentType.HasMany(e => e.Employees).WithOne().OnDelete(DeleteBehavior.Restrict);
        }


        public static void ConfigureNote(EntityTypeBuilder<Note> note)
        {
        }


        public static void ConfigureQualification(EntityTypeBuilder<Qualification> qualification)
        {
            qualification.Property(q => q.EmployeeId).IsRequired();
            qualification.HasOne(e => e.Employee).WithMany(q => q.Qualifications).OnDelete(DeleteBehavior.Restrict);
            qualification.HasOne(t => t.QualificationType)
                .WithMany(q => q.Qualifications)
                .OnDelete(DeleteBehavior.Restrict);

            qualification.HasOne(q => q.Specialty)
                .WithMany()
                .HasForeignKey(q => q.SpecialtyId)
                .OnDelete(DeleteBehavior.Restrict);

            qualification.HasOne(q => q.SubSpecialty)
                .WithMany()
                .HasForeignKey(q => q.SubSpecialtyId)
                .OnDelete(DeleteBehavior.Restrict);

            qualification.HasOne(q => q.ExactSpecialty)
                .WithMany(q => q.Qualifications)
                .HasForeignKey(q => q.ExactSpecialtyId)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(qualification);

        }

        public static void ConfigureReward(EntityTypeBuilder<Reward> reward)
        {

            reward.HasOne(e => e.Employee).WithMany(q => q.Rewards).OnDelete(DeleteBehavior.Restrict);
            reward.HasOne(t => t.RewardType)
                .WithMany(q => q.Rewards)
                .OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(reward);

        }



        public static void ConfigureSanction(EntityTypeBuilder<Sanction> sanction)
        {

            sanction.HasOne(e => e.Employee).WithMany(q => q.Sanctions).HasForeignKey(s => s.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            sanction.HasOne(t => t.SanctionType)
                .WithMany(q => q.Sanctions)
                .OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(sanction);
        }


        public static void ConfigureEvaluation(EntityTypeBuilder<Evaluation> evaluation)
        {
            evaluation.Property(e => e.EmployeeId).IsRequired();
            evaluation.HasOne(e => e.Employee).WithMany(e => e.Evaluations).OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(evaluation);

        }

        public static void ConfigureExtrawork(EntityTypeBuilder<Extrawork> extrawork)
        {
            extrawork.Property(e => e.EmployeeId).IsRequired();
            extrawork.HasOne(e => e.Employee).WithMany(e => e.Extraworks).OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(extrawork);
        }

        public static void ConfigureSelfCourses(EntityTypeBuilder<SelfCourses> selfcourses)
        {
            selfcourses.Property(s => s.EmployeeId).IsRequired();
            selfcourses.HasOne(e => e.Employee).WithMany(s => s.SelfCourseses).OnDelete(DeleteBehavior.Restrict);
            selfcourses.HasOne(e => e.SubSpecialty).WithMany().OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(selfcourses);
        }

        public static void ConfigureEndServices(EntityTypeBuilder<EndServices> endServices)
        {
            endServices.Property(s => s.EmployeeId).IsRequired();
            endServices.Property(s => s.Cause).HasMaxLength(MidField);
            endServices.HasOne(e => e.Employee).WithOne(e => e.EndedServices).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(endServices);
        }
        public static void ConfigureBank(EntityTypeBuilder<Bank> bank)
        {
            bank.Property(s => s.Name).IsRequired().HasMaxLength(SmallField);
            bank.HasMany(e => e.BankBranchs).WithOne(e => e.Bank).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(bank);
        }

        public static void ConfigureBankBranch(EntityTypeBuilder<BankBranch> bankBranch)
        {
            bankBranch.Property(p => p.Name).IsRequired().HasMaxLength(SmallField);
            bankBranch.HasOne(p => p.Bank)
                .WithMany(b => b.BankBranchs)
                .OnDelete(DeleteBehavior.Restrict);

            bankBranch.Ignore(b => b.Employees);
            SharedConfigurations(bankBranch);

            //bankBranch.HasMany(j => j.Employees).WithOne(e => e.JobInfo.FinancialData.BankBranch).OnDelete(DeleteBehavior.Restrict);
        }

        public static void ConfigureVacationType(EntityTypeBuilder<VacationType> vacationType)
        {
            vacationType.Property(p => p.Name).IsRequired().HasMaxLength(SmallField);
            vacationType.HasMany(p => p.Vacations)
                .WithOne(b => b.VacationType)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(vacationType);
        }
        public static void ConfigureSituationResolveJob(EntityTypeBuilder<SituationResolveJob> situationResolveJob)
        {
            situationResolveJob.Property(p => p.EmployeeId).IsRequired();
            situationResolveJob.HasOne(p => p.Employee)
                .WithMany(b => b.SituationResolveJobs)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(situationResolveJob);
        }

        public static void ConfigureAbsence(EntityTypeBuilder<Absence> absence)
        {
            absence.Property(p => p.EmployeeId).IsRequired();
            absence.Property(p => p.Note).HasMaxLength(MidField);
            absence.HasOne(e => e.Employee).WithMany(q => q.Absences).HasForeignKey(s => s.EmployeeId).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(absence);
        }

        public static void ConfigureTransfer(EntityTypeBuilder<Transfer> transfer)
        {
            transfer.Property(p => p.EmployeeId).IsRequired();
            transfer.Property(p => p.SideName).HasMaxLength(MidField);
            transfer.HasOne(e => e.Employee).WithMany(q => q.Transfers).HasForeignKey(s => s.EmployeeId).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(transfer);
        }

        public static void ConfigureCorporation(EntityTypeBuilder<Corporation> corporation)
        {
            corporation.Property(p => p.Name).IsRequired().HasMaxLength(MidField);
            corporation.Property(p => p.Phone).HasMaxLength(MidField);
            corporation.Property(p => p.Address).HasMaxLength(MidField);
            corporation.Property(p => p.Email).HasMaxLength(MidField);
            corporation.Property(p => p.Note).HasMaxLength(MidField);

            corporation.HasOne(a => a.City).WithMany(c => c.Corporations).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(corporation);
        }
        public static void ConfigureCountry(EntityTypeBuilder<Country> country)
        {
            country.Property(s => s.Name).IsRequired().HasMaxLength(SmallField);
            country.HasMany(e => e.Cities).WithOne(e => e.Country).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(country);
        }

        public static void ConfigureCity(EntityTypeBuilder<City> city)
        {
            city.Property(p => p.Name).IsRequired().HasMaxLength(SmallField);
            city.HasOne(p => p.Country)
                .WithMany(b => b.Cities)
                .OnDelete(DeleteBehavior.Restrict);
            city.HasMany(c => c.Corporations)
                .WithOne(b => b.City)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(city);

            //City.HasMany(j => j.Employees).WithOne(e => e.JobInfo.FinancialData.City).OnDelete(DeleteBehavior.Restrict);
        }
        public static void ConfigureDelegation(EntityTypeBuilder<Delegation> delegation)
        {
            delegation.Property(p => p.Name).IsRequired().HasMaxLength(MidField);
            delegation.Property(p => p.SideName).HasMaxLength(MidField);
            delegation.Property(p => p.JobNumber).HasMaxLength(SmallField);
            delegation.Property(p => p.DelegationNumber).HasMaxLength(SmallField);
            delegation.HasOne(p => p.QualificationType)
                .WithMany()
                .IsRequired(false)
                .HasForeignKey(p => p.QualificationTypeId)
                .OnDelete(DeleteBehavior.SetNull);

            SharedConfigurations(delegation);
        }


        public static void ConfigureVacation(EntityTypeBuilder<Vacation> vacation)
        {
            vacation.Property(p => p.DecisionNumber).HasMaxLength(SmallField);

            SharedConfigurations(vacation);
        }
        public static void ConfigureAdvancePayment(EntityTypeBuilder<AdvancePayment> advancePayment)
        {
            advancePayment.HasOne(c => c.Employee)
              .WithMany(e => e.AdvancePayments)
              .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(advancePayment);
        }
        public static void ConfigureEmployeePremium(EntityTypeBuilder<EmployeePremium> employeePremium)
        {
            employeePremium.HasKey(s => new { s.PremiumId, s.EmployeeId });

            employeePremium.HasOne(c => c.Premium)
               .WithMany()
               .HasForeignKey(c => c.PremiumId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            employeePremium.HasOne(c => c.Employee)
               .WithMany(e => e.Premiums)
               .HasForeignKey(c => c.EmployeeId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(employeePremium);

        }
        public static void ConfigurePremium(EntityTypeBuilder<Premium> premium)
        {
            premium.Property(p => p.Name).IsRequired().HasMaxLength(SmallField);

            //premium.HasMany(a => a.Activities).WithOne().OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(premium);

        }
        public static void ConfigureTemporaryPremium(EntityTypeBuilder<TemporaryPremium> temporaryPremium)
        {
            temporaryPremium.Property(p => p.Name).IsRequired().HasMaxLength(SmallField);

            temporaryPremium.HasOne(c => c.Salary)
               .WithMany(t => t.TemporaryPremiums)
               .HasForeignKey(c => c.SalaryId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(temporaryPremium);

        }
        public static void ConfigureSalaryPremium(EntityTypeBuilder<SalaryPremium> salaryPremium)
        {
            salaryPremium.HasKey(s => new { s.PremiumId, s.SalaryId });

            salaryPremium.HasOne(c => c.Premium)
               .WithMany()
               .HasForeignKey(c => c.PremiumId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            salaryPremium.HasOne(c => c.Salary)
               .WithMany(s => s.SalaryPremiums)
               .HasForeignKey(c => c.SalaryId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
            SharedConfigurations(salaryPremium);
            //salaryPremium.HasOne(c => c.Salary)
            //              .WithMany()
            //              .HasForeignKey(c => c.SalaryId)
            //              .IsRequired()
            //              .OnDelete(DeleteBehavior.Restrict); SharedConfigurations(salaryPremium);
            //   salaryPremium.HasKey(s => new { s.PremiumId, s.SalaryId });

            //   salaryPremium.HasOne(c => c.Premium)
            //      .WithMany()
            //      .HasForeignKey(c => c.PremiumId)
            //      .IsRequired()
            //      .OnDelete(DeleteBehavior.Restrict);

            //   salaryPremium.HasOne(c => c.Salary)
            //      .WithMany(e => e.SalaryPremiums)
            //      .HasForeignKey(c => c.SalaryId)
            //      .IsRequired()
            //      .OnDelete(DeleteBehavior.Restrict);

            //SharedConfigurations(salaryPremium);

        }
        public static void ConfigureSalary(EntityTypeBuilder<Salary> salary)
        {
            salary.Property(p => p.BondNumber).IsRequired().HasMaxLength(SmallField);
            salary.Property(p => p.JobNumber).HasMaxLength(SmallField);
            salary.Property(p => p.SocialSecurityFundBondNumber).HasMaxLength(SmallField);
            salary.Property(p => p.SolidarityFundBondNumber).HasMaxLength(SmallField);
            salary.Property(p => p.TaxBondNumber).HasMaxLength(SmallField);
            salary.Property(p => p.SuspendedNote).HasMaxLength(MidField);
            salary.Property(i => i.FileNumber).HasMaxLength(SmallField);

            salary.HasMany(c => c.SalaryPremiums)
                .WithOne(b => b.Salary)
                 .HasForeignKey(g => g.SalaryId)
                .OnDelete(DeleteBehavior.Cascade);

            salary.HasMany(c => c.TemporaryPremiums)
                .WithOne(b => b.Salary)
                .HasForeignKey(t => t.SalaryId)
                .OnDelete(DeleteBehavior.Restrict);

            salary.HasOne(c => c.Employee)
                .WithMany(b => b.Salaries)
                .OnDelete(DeleteBehavior.Restrict);

            salary.HasOne(c => c.BankBranch)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            //salary.HasMany(a => a.Activities).WithOne().OnDelete(DeleteBehavior.SetNull);
            SharedConfigurations(salary);

        }

        public static void ConfigureExactSpecialty(EntityTypeBuilder<ExactSpecialty> exactSpecialty)
        {
            exactSpecialty.Property(u => u.Name).IsRequired().HasMaxLength(SmallField);
            exactSpecialty.HasOne(p => p.SubSpecialty)
                .WithMany(b => b.ExactSpecialties)
                .OnDelete(DeleteBehavior.Restrict);
            exactSpecialty.Ignore(b => b.Employees);

            SharedConfigurations(exactSpecialty);
            exactSpecialty.HasMany(u => u.Employees).WithOne().OnDelete(DeleteBehavior.Restrict);
        }
        public static void ConfigureHoliday(EntityTypeBuilder<Holiday> holiday)
        {
            holiday.Property(u => u.Name).IsRequired().HasMaxLength(SmallField);

            SharedConfigurations(holiday);
        }

        public static void ConfigureTrainingCourse(EntityTypeBuilder<TrainingCourse> trainingCourse)
        {
            trainingCourse.Property(p => p.Name).IsRequired().HasMaxLength(SmallField);
            trainingCourse.Property(p => p.ExecutingAgency).IsRequired().HasMaxLength(SmallField);
            trainingCourse.HasOne(s => s.SubSpecialty).WithOne().OnDelete(DeleteBehavior.Restrict);
            trainingCourse.Ignore(e => e.Employees);
        }


        public static void ConfigureEmployeeTrainingCourse(
            EntityTypeBuilder<EmployeeTrainingCourse> employeeTrainingCourse)
        {
            employeeTrainingCourse.HasKey(et => new { et.TrainingCourseId, et.EmployeeId });
            employeeTrainingCourse.HasOne(bs => bs.TrainingCourse).WithMany().HasForeignKey(bs => bs.TrainingCourseId);
            employeeTrainingCourse.HasOne(bs => bs.Employee).WithMany().HasForeignKey(bs => bs.EmployeeId);
        }
        public static void ConfigureDevelopmentState(EntityTypeBuilder<DevelopmentState> developmentState)
        {
            developmentState.Property(u => u.Name).IsRequired().HasMaxLength(SmallField);

            SharedConfigurations(developmentState);
        }
        public static void ConfigureRequestedQualification(EntityTypeBuilder<RequestedQualification> requestedQualification)
        {
            requestedQualification.Property(u => u.Name).IsRequired().HasMaxLength(SmallField);

            SharedConfigurations(requestedQualification);
        }
        public static void ConfigureDevelopmentTypeA(EntityTypeBuilder<DevelopmentTypeA> developmentTypeA)
        {
            developmentTypeA.Property(u => u.Name).IsRequired().HasMaxLength(SmallField);
            developmentTypeA.HasMany(d => d.DevelopmentTypeBs)
                .WithOne(d => d.DevelopmentTypeA)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(developmentTypeA);
        }
        public static void ConfigureDevelopmentTypeB(EntityTypeBuilder<DevelopmentTypeB> developmentTypeB)
        {
            developmentTypeB.Property(u => u.Name).IsRequired().HasMaxLength(SmallField);
            developmentTypeB.HasMany(d => d.DevelopmentTypeCs)
                .WithOne(d => d.DevelopmentTypeB)
                .OnDelete(DeleteBehavior.Restrict);

            developmentTypeB.HasOne(d => d.DevelopmentTypeA)
                .WithMany(d => d.DevelopmentTypeBs)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(developmentTypeB);
        }
        public static void ConfigureDevelopmentTypeC(EntityTypeBuilder<DevelopmentTypeC> developmentTypeC)
        {
            developmentTypeC.Property(u => u.Name).IsRequired().HasMaxLength(SmallField);
            developmentTypeC.HasMany(d => d.DevelopmentTypeDs)
                    .WithOne(d => d.DevelopmentTypeC)
                    .OnDelete(DeleteBehavior.Restrict);

            developmentTypeC.HasOne(d => d.DevelopmentTypeB)
                .WithMany(d => d.DevelopmentTypeCs)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(developmentTypeC);
        }
        public static void ConfigureDevelopmentTypeD(EntityTypeBuilder<DevelopmentTypeD> developmentTypeD)
        {
            developmentTypeD.Property(u => u.Name).IsRequired().HasMaxLength(SmallField);
            //developmentTypeD.HasMany(d => d.DevelopmentTypeEs)
            //        .WithOne(d => d.DevelopmentTypeD)
            //        .OnDelete(DeleteBehavior.Restrict);

            developmentTypeD.HasOne(d => d.DevelopmentTypeC)
                .WithMany(d => d.DevelopmentTypeDs)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(developmentTypeD);
        }
        //public static void ConfigureDevelopmentTypeE(EntityTypeBuilder<DevelopmentTypeE> developmentTypeE)
        //{
        //    developmentTypeE.Property(u => u.Name).IsRequired().HasMaxLength(SmallField);

        //    developmentTypeE.HasOne(d => d.DevelopmentTypeD)
        //        .WithMany(d => d.DevelopmentTypeEs)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    SharedConfigurations(developmentTypeE);
        //}

        public static void ConfigureTraining(EntityTypeBuilder<Training> training)
        {
            training.Property(u => u.DecisionNumber).HasMaxLength(SmallField);
            training.Property(u => u.ExecutingAgency).HasMaxLength(SmallField);
            training.Property(u => u.Subject).HasMaxLength(SmallField);

            training.HasOne(c => c.RequestedQualification)
                .WithMany()
                .HasForeignKey(c => c.RequestedQualificationId)
                .OnDelete(DeleteBehavior.Restrict);

            training.HasOne(c => c.DevelopmentState)
                .WithMany()
                .HasForeignKey(c => c.DevelopmentStateId)
                .OnDelete(DeleteBehavior.Restrict);

            training.HasOne(c => c.City)
                .WithMany()
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            training.HasOne(c => c.DevelopmentTypeD)
                .WithMany()
                .HasForeignKey(c => c.DevelopmentTypeDId)
                .OnDelete(DeleteBehavior.Restrict);

            training.HasOne(c => c.Corporation)
                .WithMany()
                .HasForeignKey(c => c.CorporationId)
                .OnDelete(DeleteBehavior.Restrict);

            training.HasOne(c => c.Course)
                .WithMany()
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            training.HasMany(d => d.TrainingDetails)
                .WithOne(d => d.Training)
                .HasForeignKey(d => d.TrainingId)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(training);
        }

        public static void ConfigureTrainingDetail(EntityTypeBuilder<TrainingDetail> trainingDetail)
        {
            trainingDetail.HasOne(c => c.Training)
                .WithMany(t => t.TrainingDetails)
                .HasForeignKey(c => c.TrainingId)
                .OnDelete(DeleteBehavior.Restrict);

            trainingDetail.HasOne(c => c.Employee)
                .WithMany()
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(trainingDetail);
        }

        public static void ConfigureDocumentType(EntityTypeBuilder<DocumentType> documentType)
        {
            documentType.Property(d => d.Name).IsRequired().HasMaxLength(SmallField);

            SharedConfigurations(documentType);
        }
        public static void ConfigureDocument(EntityTypeBuilder<Document> document)
        {
            document.Property(d => d.IssuePlace).HasMaxLength(SmallField);
            document.Property(d => d.Note).HasMaxLength(MidField);

            document.HasOne(d => d.DocumentType)
                .WithMany()
                .IsRequired()
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            document.HasOne(d => d.Employee)
                .WithMany(e => e.Documents)
                .IsRequired()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            document.HasMany(d => d.DocumentImages)
                .WithOne(d => d.Document)
                .IsRequired()
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(document);
        }

        public static void ConfigureDocumentImage(EntityTypeBuilder<DocumentImage> documentImage)
        {
            documentImage.Property(d => d.Image).IsRequired();

            documentImage.HasOne(d => d.Document)
                .WithMany(d => d.DocumentImages)
                .IsRequired()
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(documentImage);
        }
        public static void ConfigureSalaryUnit(EntityTypeBuilder<SalaryUnit> salaryUnit)
        {
            salaryUnit.Property(d => d.Degree).IsRequired();

            SharedConfigurations(salaryUnit);
        }
        public static void ConfigureCoach(EntityTypeBuilder<Coach> coach)
        {
            coach.Property(d => d.Email).HasMaxLength(SmallField);
            coach.Property(d => d.Name).HasMaxLength(SmallField);
            coach.Property(d => d.Phone).HasMaxLength(SmallField);
            coach.Property(d => d.Note).HasMaxLength(MidField);

            coach.HasOne(c => c.Employee)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(coach);
        }
        public static void ConfigureCourse(EntityTypeBuilder<Course> course)
        {
            course.Property(d => d.FoundationName).HasMaxLength(SmallField);
            course.Property(d => d.Name).HasMaxLength(SmallField);

            course.HasOne(c => c.City)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(course);
        }
    }
}
