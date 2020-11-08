using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private HrDbContext Context { get; }

        public EmployeeRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public override IEnumerable<Employee> GetAll()
        {
            return Context.Employees
                .Include(e => e.JobInfo)
                .ThenInclude(s => s.EmploymentValues)

                .Include(s => s.SalaryInfo)
                .Include(e => e.JobInfo)
                .ThenInclude(s => s.CurrentSituation)
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center)
                .Include(e => e.MilitaryData)
                .Include(e => e.SalaryInfo)
                .Include(e => e.Absences)
                .Include(e => e.AdvancePayments)
                .Include(e => e.Premiums)
                .Include(e => e.Extraworks)
                .Where(e => e.IsActive);

        }
        public IEnumerable<Employee> GetGride()
        {
            return Context.Employees
                   .Include(e => e.JobInfo)
                   .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center);
        }
        public IEnumerable<Employee> GetAllNew()
        {
            return Context.Employees
                 .Include(e => e.JobInfo)
                 .ThenInclude(s => s.EmploymentValues)

                 .Include(s => s.SalaryInfo)
                 .Include(e => e.JobInfo)
                 .ThenInclude(s => s.CurrentClassification)
                 .Include(e => e.JobInfo)
                 .ThenInclude(j => j.Unit)
                 .ThenInclude(u => u.Division)
                 .ThenInclude(d => d.Department)
                 .ThenInclude(d => d.Center)
                 .Include(e => e.MilitaryData)
                 .Include(e => e.SalaryInfo)
                 .Include(e => e.Absences)
                 .Include(e => e.AdvancePayments)
                 .Include(e => e.Premiums)
                 .Include(e => e.Extraworks)
                 .Where(e => e.IsActive);

        }

        public Employee GetEmployeeNameById(int id)
            => Context.Employees
                .Include(j => j.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center)
                .FirstOrDefault(e => e.EmployeeId == id);

        public IEnumerable<Employee> GetRetirementEmployee()
            => Context.Employees
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center)
                .Where(e => (e.Gender == Gender.Male && DateTime.Now.Year - e.BirthDate.Value.Year >= 65)
                           || (e.Gender == Gender.Female && DateTime.Now.Year - e.BirthDate.Value.Year >= 60));

        public override Employee Find(object id)
        {
            var employee = Context.Employees
                .Include(e => e.Premiums)
                .Include(e => e.Booklet)
                .Include(e => e.Passport)
                .Include(e => e.ContactInfo)
                .Include(e => e.IdentificationCard)
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.EmploymentValues)
                .Include(e => e.JobInfo)
                .Include(j => j.SalaryInfo)
                .ThenInclude(f => f.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center)
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.AdjectiveEmployee)
                .ThenInclude(a => a.AdjectiveEmployeeType)
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.ClassificationOnSearching)
                .Include(e => e.JobInfo)
                .ThenInclude(s => s.CurrentSituation)
                .Include(e => e.JobInfo)

                .ThenInclude(j => j.ClassificationOnWork)
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.Staffing)
                .ThenInclude(j => j.StaffingType)
                .Include(e => e.MilitaryData)
                .Include(e => e.Place)
                .ThenInclude(e => e.Branch)

                .FirstOrDefault(e => e.EmployeeId == (int)id);

            if (employee == null)
                return null;

            if (employee.MilitaryData == null)
                employee.MilitaryData = Activator.CreateInstance(typeof(MilitaryData), true) as MilitaryData;

            if (employee.JobInfo == null)
                employee.JobInfo = Activator.CreateInstance(typeof(JobInfo), true) as JobInfo;

            //if (employee.SalaryInfo == null)
            //    employee.SalaryInfo = Activator.CreateInstance(typeof(SalaryInfo), true) as SalaryInfo;

            return employee;
        }
        public IEnumerable<Employee> GetEmployeeBounshr() => Context.Employees
        .Include(e => e.JobInfo)
        .ThenInclude(j => j.Unit)
        .ThenInclude(u => u.Division)
        .ThenInclude(d => d.Department)
        .Where(
            e =>
                e.IsActive == true &&
                    (
                    e.JobInfo.DateBounshr <= DateTime.Now
                   ) &&
                e.IsActive && e.JobInfo.Bounshr != 0 && e.JobInfo.Bounshr != null &&
                e.JobInfo.JobType == JobType.Designation);
        public IEnumerable<Employee> GetEmployeeBouns() => Context.Employees
            .Include(e => e.JobInfo)
            .ThenInclude(j => j.Unit)
            .ThenInclude(u => u.Division)
            .ThenInclude(d => d.Department)
            .Where(
                e => e.IsActive == true &&
                    (
                    e.JobInfo.DateBouns < e.JobInfo.DateBounshr
                   ) &&
                    e.IsActive && e.JobInfo.Bouns != 0 && e.JobInfo.Bouns != null && e.JobInfo.Bouns < e.JobInfo.Bounshr &&
                    e.JobInfo.JobType == JobType.Designation);

        public IEnumerable<Employee> GetEmployeeDegree() => Context.Employees
            .Include(e => e.Passport)
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center).Include(e => e.JobInfo)
            .ThenInclude(j => j.Job)
            .Where(
                e => e.IsActive &&
                        ((e.JobInfo.DegreeNow < 10 &&
                        e.JobInfo.DateDegreeNow.Value.AddYears(4) <= DateTime.Now)
                //&& e.JobInfo.Bouns >= 4
                        ||
                        ((e.JobInfo.DegreeNow == 10 || e.JobInfo.DegreeNow == 11) &&
                        e.JobInfo.DateDegreeNow.Value.AddYears(5) <= DateTime.Now)
                        //&& e.JobInfo.Bouns >= 5
                        ||
                        (e.JobInfo.DegreeNow > 11 &&
                        e.JobInfo.DateDegreeNow.Value.AddYears(7) <= DateTime.Now)
                || (e.JobInfo.DegreeNow >= 1 &&
                        e.JobInfo.DateDegreeNow.Value.AddYears(10) <= DateTime.Now)) &&
                        //&& e.JobInfo.Bouns >= 1) 


                        e.JobInfo.JobType == JobType.Designation);


        public IEnumerable<Employee> GetEmployeeWithoutSaraies(DateTime monthDate) => Context.Employees
            .Include(e => e.SalaryInfo)
            .Include(e => e.JobInfo)
            .Include(e => e.Premiums)
            .Where(e => e.Salaries.All(s => s.MonthDate != monthDate));
        public IEnumerable<EmployeePremium> GetEmployeePremium() => Context.EmployeePremiums
        .Include(e => e.Premium)
              .Include(e => e.AdvancePayment)
        .Include(e => e.Employee)
            .ThenInclude(s => s.Premiums)
               .Include(e => e.Employee)
            .ThenInclude(s => s.AdvancePayments)

       ;
        public IEnumerable<AdvancePayment> GetEmployeeAdvance() => Context.AdvancePayments
       .Include(e => e.Premium)
       //  .ThenInclude(s => s.AdvancePayments)
       .Include(e => e.Employee)
           .ThenInclude(s => s.Premiums)
              .Include(e => e.Employee)
           .ThenInclude(s => s.AdvancePayments)

      ;

        public IEnumerable<EmployeePremium> GetTemEmployeePremiumBy(int employeeId)
      {
        var pr = Context.EmployeePremiums
            .Include(e => e.Premium)
            .Include(e => e.Employee)
            .Where(e => e.EmployeeId == employeeId && e.Premium.ISAdvancePremmium == ISAdvancePremmium.ISNotAdvance && e.Premium.IsTemporary == IsTemporary.IsNotTemporary).OrderBy(a => a.PremiumId);
           return pr;
}
       
       public IEnumerable<AdvancePayment> GetEmployeeAdvanceBy(int employeeId) => Context.AdvancePayments
            .Include(e => e.Premium)
            .Include(e => e.Employee)
            .Where(e => e.EmployeeId == employeeId && e.Premium.ISAdvancePremmium == ISAdvancePremmium.ISAdvance).OrderBy(a => a.PremiumId);
       
        

        public void AddSalaryInfo(SalaryInfo salaryInfo) => Context.Add(salaryInfo);
        public void RemoveMilitaryData(MilitaryData militaryData)
             => Context.Remove(militaryData);

        public MilitaryData FindMilitaryData(int employeeId)
            => Context.MilitaryDatas
                .Include(e => e.Employee)
                .FirstOrDefault(m => m.Employee.EmployeeId == employeeId);

        public int EmployeesDeserveBounsCount()
            => Context.Employees
                .Count(
                      e => e.IsActive == true &&
                    (
                    e.JobInfo.DateBouns < e.JobInfo.DateBounshr
                   ) &&
                    e.IsActive && e.JobInfo.Bouns != 0 && e.JobInfo.Bouns != null && e.JobInfo.Bouns < e.JobInfo.Bounshr &&
                    e.JobInfo.JobType == JobType.Designation);

        public int EmployeesDeserveBounshrCount()
       => Context.Employees
          .Count(
                         e =>
                e.IsActive == true &&
                    (
                    e.JobInfo.DateBounshr <= DateTime.Now
                   ) &&
                e.IsActive && e.JobInfo.Bounshr != 0 && e.JobInfo.Bounshr != null &&
                e.JobInfo.JobType == JobType.Designation);

        public int EmployeesDeserveDegreeCount()
            => Context.Employees
                .Count(
                    e => e.IsActive &&
                         ((e.JobInfo.DegreeNow < 10 &&
                           e.JobInfo.DateDegreeNow.Value.AddYears(4) <= DateTime.Now &&
                           e.JobInfo.Bouns >= 4)
                          ||
                          (e.JobInfo.DegreeNow == 10 &&
                           e.JobInfo.DateDegreeNow.Value.AddYears(5) <= DateTime.Now &&
                           e.JobInfo.Bouns >= 5)
                          ||
                          (e.JobInfo.DegreeNow >= 11 &&
                           e.JobInfo.DateDegreeNow.Value.AddYears(1) <= DateTime.Now &&
                           e.JobInfo.Bouns >= 1)) &&
                           e.JobInfo.JobType == JobType.Designation);

        public int EmployeesWithoutJobInfoCount()
            => Context.Employees.Count(e => e.JobInfo == null);

        public int EmployeesWithoutSalaryInfoCount()
            => Context.Employees.Count(e => e.SalaryInfo.BasicSalary == 0 || e.SalaryInfo == null);

        public IEnumerable<SalaryInfo> GettSalaryInfo()
         => Context.SalaryInfos
            .Include(s => s.Employee)
            .ThenInclude(s => s.JobInfo)
            .Where(s => s.BasicSalary == 0 && s.Employee.JobInfo.DegreeNow != null && s.Employee.JobInfo.SalayClassification == SalayClassification.Default);

        public byte[] GetImageById(int employeeId)
            => Context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId)?.Image;

        //public bool IsFiftyOrDirectlyTwentyYear(int employeeId)
        //{
        //    return Context.Employees
        //            .Include(e => e.JobInfo)
        //            .ThenInclude(j => j.Unit)
        //            .ThenInclude(u => u.Division)
        //            .ThenInclude(d => d.Department)
        //            .ThenInclude(d => d.Center)
        //            .Any(e => e.IsActive && (DateTime.Now.Year - e.BirthDate.Value.Year >= 50
        //            || DateTime.Now.Year - e.JobInfo.DirectlyDate.Value.Year >= 20)
        //            && e.EmployeeId == employeeId);
        //}

        public int VacationBalanc(int employeeId)
        {
            var year = DateTime.Now.Year;

            var employee = Context.Employees
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center)
                .Any(e => e.IsActive && (year - e.BirthDate.Value.Year >= 50
                           || year - e.JobInfo.DirectlyDate.Value.Year >= 20)
                          && e.EmployeeId == employeeId);

            return employee ? 45 : 30;
        }
        public int VacationBalanc2(int employeeId)
        {
            var year = DateTime.Now.Year;

            var employee = Context.Employees
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center)
               .Any(e => e.IsActive
                          && e.EmployeeId == employeeId);

            return employee ? 12 : 12;
        }
        public IEnumerable<Employee> GetEmployeeReport(EmployeeReportDto employeeReport)
        {
            var employees = Context.Employees
                .Include(e => e.Premiums)
                .Include(e => e.Booklet)
                .Include(e => e.Passport)
                .Include(e => e.ContactInfo)
                .Include(e => e.IdentificationCard)
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.EmploymentValues)
                .Include(e => e.JobInfo)
                .Include(j => j.SalaryInfo)
                .ThenInclude(f => f.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center)
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.AdjectiveEmployee)
                .ThenInclude(a => a.AdjectiveEmployeeType)
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.ClassificationOnSearching)
                .Include(e => e.JobInfo)
                .ThenInclude(j => j.ClassificationOnWork)
                .Include(e => e.JobInfo)
                .ThenInclude(s => s.CurrentSituation)
                .Include(s => s.Nationality)
                .Include(e => e.JobInfo)
                // .Include(k => k.CurrentSituations)  

                .ThenInclude(j => j.Staffing)
                .ThenInclude(j => j.StaffingType)
                .Include(e => e.MilitaryData)
                .Include(e => e.Place)
                .ThenInclude(e => e.Branch)
                .Include(z => z.Evaluations)
                .Where(s => s.IsActive == true)
                .AsQueryable();

            if (employeeReport.FirstName != null)
            {
                employees = employees.Where(e => e.FirstName == employeeReport.FirstName);
            }
            if (employeeReport.FatherName != null)
            {
                employees = employees.Where(e => e.FatherName == employeeReport.FatherName);
            }
            if (employeeReport.GrandfatherName != null)
            {
                employees = employees.Where(e => e.GrandfatherName == employeeReport.GrandfatherName);
            }
            if (employeeReport.LastName != null)
            {
                employees = employees.Where(e => e.LastName == employeeReport.LastName);
            }
            if (employeeReport.EnglishFirstName != null)
            {
                employees = employees.Where(e => e.EnglishFirstName == employeeReport.EnglishFirstName);
            }
            if (employeeReport.EnglishFatherName != null)
            {
                employees = employees.Where(e => e.EnglishFatherName == employeeReport.EnglishFatherName);
            }
            if (employeeReport.EnglishGrandfatherName != null)
            {
                employees = employees.Where(e => e.EnglishGrandfatherName == employeeReport.EnglishGrandfatherName);
            }
            if (employeeReport.EnglishLastName != null)
            {
                employees = employees.Where(e => e.EnglishLastName == employeeReport.EnglishLastName);
            }
            if (employeeReport.MotherName != null)
            {
                employees = employees.Where(e => e.MotherName == employeeReport.MotherName);
            }
            if (employeeReport.Gender != null)
            {
                employees = employees.Where(e => e.Gender == employeeReport.Gender);
            }
            if (employeeReport.BirthDateFrom != null && employeeReport.BirthDateTo != null)
            {
                employees = employees.Where(e => e.BirthDate >= employeeReport.BirthDateFrom && e.BirthDate <= employeeReport.BirthDateTo);
            }
            if (employeeReport.BirthPlace != null)
            {
                employees = employees.Where(e => e.BirthPlace == employeeReport.BirthPlace);
            }
            if (employeeReport.NationalNumber != null)
            {
                employees = employees.Where(e => e.NationalNumber == employeeReport.NationalNumber);
            }
            if (employeeReport.Religion >= 0)
            {
                employees = employees.Where(e => e.Religion == employeeReport.Religion);
            }
            if (employeeReport.NationalityId > 0)
            {
                employees = employees.Where(e => e.NationalityId == employeeReport.NationalityId);
            }
            if (employeeReport.BranchId > 0)
            {
                employees = employees.Where(e => e.Place.BranchId == employeeReport.BranchId);
            }
            if (employeeReport.PlaceId > 0)
            {
                employees = employees.Where(e => e.PlaceId == employeeReport.PlaceId);
            }
            if (employeeReport.Address != null)
            {
                employees = employees.Where(e => e.Address == employeeReport.Address);
            }
            if (employeeReport.Phone != null)
            {
                employees = employees.Where(e => e.Phone == employeeReport.Phone);
            }
            if (employeeReport.Email != null)
            {
                employees = employees.Where(e => e.Email == employeeReport.Email);
            }
            if (employeeReport.SocialStatus != null)
            {
                employees = employees.Where(e => e.SocialStatus == employeeReport.SocialStatus);
            }
            if (employeeReport.ChildernCount > 0)
            {
                employees = employees.Where(e => e.ChildernCount == employeeReport.ChildernCount);
            }
            if (employeeReport.LibyanOrForeigner != null)
            {
                employees = employees.Where(e => e.LibyanOrForeigner == employeeReport.LibyanOrForeigner);
            }
            if (employeeReport.BloodType != null)
            {
                employees = employees.Where(e => e.BloodType == employeeReport.BloodType);
            }
            if (employeeReport.BookletNumber != null)
            {
                employees = employees.Where(e => e.Booklet.Number == employeeReport.BookletNumber);
            }
            if (employeeReport.BookletFamilyNumber != null)
            {
                employees = employees.Where(e => e.Booklet.FamilyNumber == employeeReport.BookletFamilyNumber);
            }
            if (employeeReport.BookletRegistrationNumber != null)
            {
                employees = employees.Where(e => e.Booklet.RegistrationNumber == employeeReport.BookletRegistrationNumber);
            }
            if (employeeReport.BookletIssueDate != null)
            {
                employees = employees.Where(e => e.Booklet.IssueDate == employeeReport.BookletIssueDate);
            }
            if (employeeReport.BookletIssuePlace != null)
            {
                employees = employees.Where(e => e.Booklet.IssuePlace == employeeReport.BookletIssuePlace);
            }
            if (employeeReport.BookletCivilRegistry != null)
            {
                employees = employees.Where(e => e.Booklet.CivilRegistry == employeeReport.BookletCivilRegistry);
            }
            if (employeeReport.PassportNumber != null)
            {
                employees = employees.Where(e => e.Passport.Number == employeeReport.PassportNumber);
            }
            if (employeeReport.PassportAutoNumber != null)
            {
                employees = employees.Where(e => e.Passport.AutoNumber == employeeReport.PassportAutoNumber);
            }
            if (employeeReport.PassportIssueDateFrom != null && employeeReport.PassportIssueDateTo != null)
            {
                employees = employees.Where(e => e.Passport.IssueDate >= employeeReport.PassportIssueDateFrom && e.Passport.IssueDate <= employeeReport.PassportIssueDateTo);
            }
            if (employeeReport.PassportIssuePlace != null)
            {
                employees = employees.Where(e => e.Passport.IssuePlace == employeeReport.PassportIssuePlace);
            }
            if (employeeReport.IdentificationCardNumber != null)
            {
                employees = employees.Where(e => e.IdentificationCard.Number == employeeReport.IdentificationCardNumber);
            }
            if (employeeReport.IdentificationCardIssueDateFrom != null && employeeReport.IdentificationCardIssueDateTo != null)
            {
                employees = employees.Where(e => e.IdentificationCard.IssueDate >= employeeReport.IdentificationCardIssueDateFrom
                              && e.IdentificationCard.IssueDate <= employeeReport.IdentificationCardIssueDateTo);
            }
            if (employeeReport.IdentificationCardIssuePlace != null)
            {
                employees = employees.Where(e => e.IdentificationCard.IssuePlace == employeeReport.IdentificationCardIssuePlace);
            }
            if (employeeReport.ContactInfoPhone != null)
            {
                employees = employees.Where(e => e.ContactInfo.Phone == employeeReport.ContactInfoPhone);
            }
            if (employeeReport.ContactInfoNote != null)
            {
                employees = employees.Where(e => e.ContactInfo.Note == employeeReport.ContactInfoNote);
            }
            if (employeeReport.ContactInfoNearKindr != null)
            {
                employees = employees.Where(e => e.ContactInfo.NearKindr == employeeReport.ContactInfoNearKindr);
            }
            if (employeeReport.ContactInfoRelativeRelation != null)
            {
                employees = employees.Where(e => e.ContactInfo.RelativeRelation == employeeReport.ContactInfoRelativeRelation);
            }
            if (employeeReport.ContactInfoNearPoint != null)
            {
                employees = employees.Where(e => e.ContactInfo.NearPoint == employeeReport.ContactInfoNearPoint);
            }
            if (employeeReport.ContactInfoAddress != null)
            {
                employees = employees.Where(e => e.ContactInfo.Address == employeeReport.ContactInfoAddress);
            }
            if (employeeReport.ContactInfoWorkAddress != null)
            {
                employees = employees.Where(e => e.ContactInfo.WorkAddress == employeeReport.ContactInfoWorkAddress);
            }
            if (employeeReport.DirectlyDateFrom != null && employeeReport.DirectlyDateTo != null)
            {
                employees = employees.Where(e => e.JobInfo.DirectlyDate >= employeeReport.DirectlyDateFrom && e.JobInfo.DirectlyDate <= employeeReport.DirectlyDateTo);
            }
            if (employeeReport.JobId > 0)
            {
                employees = employees.Where(e => e.JobInfo.JobId == employeeReport.JobId);
            }
            if (employeeReport.JobType > 0)
            {
                employees = employees.Where(e => e.JobInfo.JobType == employeeReport.JobType);
            }
            if (employeeReport.JobNumber != null)
            {
                employees = employees.Where(e => e.JobInfo.JobClassValu.ToString() + e.JobInfo.JobNumber.ToString() == employeeReport.JobNumber);
            }
           
            if (employeeReport.JobNumberApproved > 0)
            {
                employees = employees.Where(e => e.JobInfo.JobNumberApproved == employeeReport.JobNumberApproved);
            }
            var sss = employeeReport.CurrentSituationList.Where(d => d.IsSelected).ToList();

            if (employeeReport.CurrentSituationList.Count(d => d.IsSelected) > 0)

            {
                employees = employees.Where(e => sss.Any(s => s.CurrentSituationId.Equals(e.JobInfo.CurrentSituationId)));
                //employees = employees.Where(e => e.JobInfo.CurrentSituation.CurrentSituationId ==1);
            }

            if (employeeReport.UnitId > 0)
            {
                employees = employees.Where(e => e.JobInfo.UnitId == employeeReport.UnitId);
            }
            if (employeeReport.DivisionId > 0)
            {
                employees = employees.Where(e => e.JobInfo.Unit.DivisionId == employeeReport.DivisionId);
            }
            if (employeeReport.DepartmentId > 0)
            {
                employees = employees.Where(e => e.JobInfo.Unit.Division.DepartmentId == employeeReport.DepartmentId);
            }
            if (employeeReport.DegreeNow > 0)
            {
                employees = employees.Where(e => e.JobInfo.DegreeNow == employeeReport.DegreeNow);
            }
            if (employeeReport.DateDegreeNowFrom != null && employeeReport.DateDegreeNowTo != null)
            {
                employees = employees.Where(e => e.JobInfo.DateDegreeNow >= employeeReport.DateDegreeNowFrom
                        && e.JobInfo.DateDegreeNow <= employeeReport.DateDegreeNowTo);
            }
            if (employeeReport.DateMeritDegreeNowFrom != null && employeeReport.DateMeritDegreeNowTo != null)
            {
                employees = employees.Where(e => e.JobInfo.DateMeritDegreeNow >= employeeReport.DateMeritDegreeNowFrom
                        && e.JobInfo.DateMeritDegreeNow <= employeeReport.DateMeritDegreeNowTo);
            }
            if (employeeReport.Bouns > 0)
            {
                employees = employees.Where(e => e.JobInfo.Bouns == employeeReport.Bouns);
            }
            if (employeeReport.DateBounsFrom != null && employeeReport.DateBounsTo != null)
            {
                employees = employees.Where(e => e.JobInfo.DateBouns >= employeeReport.DateBounsFrom
                        && e.JobInfo.DateBouns <= employeeReport.DateBounsTo);
            }
            if (employeeReport.DateMeritBouns != null)
            {
                employees = employees.Where(e => e.JobInfo.DateMeritBouns == employeeReport.DateMeritBouns);
            }
            if (employeeReport.AdjectiveEmployeeId > 0)
            {
                employees = employees.Where(e => e.JobInfo.AdjectiveEmployeeId == employeeReport.AdjectiveEmployeeId);
            }
            if (employeeReport.AdjectiveEmployeeTypeId > 0)
            {
                employees = employees.Where(e => e.JobInfo.AdjectiveEmployee.AdjectiveEmployeeTypeId == employeeReport.AdjectiveEmployeeTypeId);
            }
            if (employeeReport.StaffingId > 0)
            {
                employees = employees.Where(e => e.JobInfo.StaffingId == employeeReport.StaffingId);
            }
            if (employeeReport.StaffingTypeId > 0)
            {
                employees = employees.Where(e => e.JobInfo.Staffing.StaffingTypeId == employeeReport.StaffingTypeId);
            }
            if (employeeReport.CenterId > 0)
            {
                employees = employees.Where(e => e.JobInfo.Unit.Division.Department.CenterId == employeeReport.CenterId);
            }
            if (employeeReport.ClassificationOnSearchingId > 0)
            {
                employees = employees.Where(e => e.JobInfo.ClassificationOnSearchingId == employeeReport.ClassificationOnSearchingId);
            }
            if (employeeReport.ClassificationOnWorkId > 0)
            {
                employees = employees.Where(e => e.JobInfo.ClassificationOnWorkId == employeeReport.ClassificationOnWorkId);
            }
            if (employeeReport.VacationBalance > 0)
            {
                employees = employees.Where(e => e.JobInfo.VacationBalance == employeeReport.VacationBalance);
            }
            if (employeeReport.JobInfoNotes != null)
            {
                employees = employees.Where(e => e.JobInfo.Notes == employeeReport.JobInfoNotes);
            }
            if (employeeReport.AdjectiveMilitary > 0)
            {
                employees = employees.Where(e => e.MilitaryData.AdjectiveMilitary == employeeReport.AdjectiveMilitary);
            }
            if (employeeReport.MilitaryNumber != null)
            {
                employees = employees.Where(e => e.MilitaryData.MilitaryNumber == employeeReport.MilitaryNumber);
            }
            if (employeeReport.Subunit != null)
            {
                employees = employees.Where(e => e.MilitaryData.Subunit == employeeReport.Subunit);
            }
            if (employeeReport.Rank != null)
            {
                employees = employees.Where(e => e.MilitaryData.Rank == employeeReport.Rank);
            }
            if (employeeReport.GranduationDateFrom != null && employeeReport.GranduationDateTo != null)
            {
                employees = employees.Where(e => e.MilitaryData.GranduationDate >= employeeReport.GranduationDateFrom
                   && e.MilitaryData.GranduationDate >= employeeReport.GranduationDateTo);
            }
            if (employeeReport.MotherUnit != null)
            {
                employees = employees.Where(e => e.MilitaryData.MotherUnit == employeeReport.MotherUnit);
            }
            if (employeeReport.College != null)
            {
                employees = employees.Where(e => e.MilitaryData.College == employeeReport.College);
            }

            return employees;
        }

        // تقرير القوة العمومية 16_11_2019
        public IEnumerable<ManPowerReportGridRow> GetEmployeeReport2()
        {
            //.Include(e => e.JobInfo)
            var ManPowerReport = Context.JobInfos
                .Include(d => d.AdjectiveEmployee)
                .ThenInclude(d => d.AdjectiveEmployeeType)
                .Include(d => d.StaffingClassification)
                .Where(d => d.StaffingClassification != null && d.AdjectiveEmployee.AdjectiveEmployeeType != null)
                .ToList()
                .GroupBy(d => new { d.AdjectiveEmployee.Name })
             .Select(d => new ManPowerReportGridRow
             {
                 AdjectiveEmployeeType = d.Key.Name,

                 PhDCount = d.Count(s => s.StaffingClassification?.Name == "دكتوراه"),
                 MasterCount = d.Count(s => s.StaffingClassification?.Name == "ماجستير"),
                 AssistantCount = d.Count(s => s.StaffingClassification?.Name == "مساعد"),
                 CraftsmanCount = d.Count(s => s.StaffingClassification?.Name == "حرفي"),
                 DiplomaCount = d.Count(s => s.StaffingClassification?.Name == "دبلوم دراسات"),
                 EngCount = d.Count(s => s.StaffingClassification?.Name == "مهندسون" || s.StaffingClassification?.Name == "أخصائيون"),
                 OperationalCount = d.Count(s => s.StaffingClassification?.Name == "تشغيلي"),
                 AdministrativeCount = d.Count(s => s.StaffingClassification?.Name == "إداري"),
                 WriterAdmCount = d.Count(s => s.StaffingClassification?.Name == "كاتب"),
                 FinancialCount = d.Count(s => s.StaffingClassification?.Name == "مالي"),
                 BookkeeperCount = d.Count(s => s.StaffingClassification?.Name == "كاتب حسابات"),
                 JuristCount = d.Count(s => s.StaffingClassification?.Name == "قانوني"),
                 AlternateCount = d.Count(s => s.StaffingClassification?.Name == "مناوب"),
                 DailyTimeCount = d.Count(s => s.StaffingClassification?.Name == "دوام يومي"),
                 OccSafEngCount = d.Count(s => s.StaffingClassification?.Name == "مهندس سلامة مهنية"),
                 TechnicalSafEngCount = d.Count(s => s.StaffingClassification?.Name == "فني سلامة مهنية"),
                 literalityEngCount = d.Count(s => s.StaffingClassification?.Name == "مهندس حرفي"),
                 AssistantlitCountCount = d.Count(s => s.StaffingClassification?.Name == "مساعد حرفي"),
                 OperationallitCount = d.Count(s => s.StaffingClassification?.Name == "تشغيلي حرفي"),
                 ServicesCount = d.Count(s => s.StaffingClassification?.Name == "خدمات"),
                 OfficerCount = d.Count(s => s.StaffingClassification?.Name == "ضابط"),
                 WarrantOfficerCount = d.Count(s => s.StaffingClassification?.Name == "ضابط صف"),
                 SoldiersCount = d.Count(s => s.StaffingClassification?.Name == "جندي"),
                 CMilitaryACount = d.Count(s => s.StaffingClassification?.Name == "مرتبات عسكرية"),
                 CStandardACount = d.Count(s => s.StaffingClassification?.Name == "مرتبات وزارة المالية"),


             }
             );

            return ManPowerReport;
        }
        public virtual int GetJobNumber()
        {
            var number = 1001;

            var max = Context.JobInfos
                          .Max(e => e.JobNumber) + 1;

            return max < number ? number : max;
        }

        public IEnumerable<Employee> GetEmployeeWithoutSalaries(DateTime monthDate, int currentSituationId)
            => Context.Employees

                .Include(e => e.JobInfo)
                .ThenInclude(j => j.EmploymentValues)

                .Where(e => e.JobInfo.CurrentSituationId == currentSituationId || e.JobInfo.EmploymentValues.ContractDateTo < monthDate);

        public int EmployeesCount()

           => Context.Employees
                .Select(s => s.EmployeeId).Count();

        public IEnumerable<EmployeePremium> GettAllEmplyeeePremmium() => Context.EmployeePremiums


            .Include(e => e.Premium)
            .Include(e => e.Employee)
            .Where(s => s.PremiumId == 1);
        public bool NumIsExisted(int jobNumLIC) => Context.JobInfos
   .Any(u => u.JobNumberLIC == jobNumLIC);

        public bool NumIsExisted(int jobNumber, int jobNumLIC) => Context.JobInfos
    .Any(u => u.JobNumberLIC == jobNumLIC && u.JobNumber != jobNumber);

        public IEnumerable<AdvancePayment> GetEmployeeAdvanceBy1(int employeeId) => Context.AdvancePayments
            .Include(e => e.Premium)
            .Include(e => e.Employee)
            .Where(e => e.EmployeeId == employeeId);

        public IEnumerable<AdvancePayment> GettAllEmplyeeeAdvancse() => Context.AdvancePayments
             .Include(e => e.Premium)
            .Include(e => e.Employee)
            .Where(s => s.PremiumId == 1);

      
    }
}