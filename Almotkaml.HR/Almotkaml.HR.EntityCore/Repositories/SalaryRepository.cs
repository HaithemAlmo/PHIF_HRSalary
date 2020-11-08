using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class SalaryRepository : Repository<Salary>, ISalaryRepository
    {
        private HrDbContext Context { get; }

        internal SalaryRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
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
                .ThenInclude(j => j.Staffing)
                .ThenInclude(j => j.StaffingType)
                .Include(e => e.MilitaryData)
                .Include(e => e.Place)
                .ThenInclude(e => e.Branch)
                .Include(z => z.Evaluations)
                .Include(s => s.Salaries)
                .Where(s=>s.IsActive==false)
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
            if (employeeReport.BankID > 0)
            {
                employees = employees.Where(e => e.SalaryInfo.BankBranch.BankId == employeeReport.BankID);
            }
            if (employeeReport.BranchId > 0)
            {
                employees = employees.Where(e => e.SalaryInfo.BankBranch.BankBranchId == employeeReport.BranchId);
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
            if (employeeReport.JobNumberInt != 0)
            {
                employees = employees.Where(e => e.JobInfo.JobNumber == employeeReport.JobNumberInt);
            }
            if (employeeReport.JobNumberApproved > 0)
            {
                employees = employees.Where(e => e.JobInfo.JobNumberApproved == employeeReport.JobNumberApproved);
            }
            if (employeeReport.CurrentSituationId > 0)
            {
                employees = employees.Where(e => e.JobInfo.CurrentSituationId == employeeReport.CurrentSituationId);
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

        // // //
        public override Salary Find(object id)
        {
            return Context.Salaries
                .Include(p => p.Employee)
                .ThenInclude(p => p.SalaryInfo)
                .Include(s => s.Employee)
                .ThenInclude(e => e.AdvancePayments)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Extraworks)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Absences)
                 .Include(s => s.Employee)
                .ThenInclude(e => e.Sanctions)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Premiums)
                .ThenInclude(a=> a.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Salaries)
                .Include(s => s.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(s => s.TemporaryPremiums)
                .Include(s => s.SalaryPremiums)
               
                .ThenInclude(s => s.Premium)
                 .Include(s => s.Employee)
                .ThenInclude(e => e.Vacations)
                .FirstOrDefault(s => s.SalaryId == (int)id);
        }

        
        public IEnumerable<SalaryPremium> GettAllSalaryPremmium() => Context.SalaryPremiums


                  .Include(e => e.Premium)
                  .Include(e => e.Salary)
                  .Where(s => s.PremiumId == 1);


        public IEnumerable<Salary> GetClosedSalary() => Context.Salaries
                .Include(p => p.Employee)
                .ThenInclude(p => p.SalaryInfo)
                .Include(s => s.Employee)
                .ThenInclude(e => e.AdvancePayments)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Extraworks)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Absences)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Premiums)
                .ThenInclude(a=>a.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Salaries)
                .Include(s => s.Employee)
                .ThenInclude(e => e.JobInfo)
                .Include(s => s.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(s => s.TemporaryPremiums)
                .Include(s => s.SalaryPremiums)
                .ThenInclude(s => s.Premium)     .Include(s => s.Employee)
                .ThenInclude(s => s.Vacations)
           
                .Where(s => s.IsClose);

        public IEnumerable<Salary> GetClosedSalaryByMonth(int year, int month)
         => Context.Salaries
                .Include(p => p.Employee)
                .ThenInclude(e => e.SalaryInfo)
                .Include(s => s.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(s => s.TemporaryPremiums)
                .Include(s => s.SalaryPremiums)
                .ThenInclude(s => s.Premium)
                .Where(s => s.IsClose && s.MonthDate.Year == year && s.MonthDate.Month == month);

        public IEnumerable<Salary> GetOpenedSalary() => Context.Salaries
                .Include(p => p.Employee)
                .ThenInclude(p => p.SalaryInfo)
                .Include(s => s.Employee)
                .ThenInclude(e => e.AdvancePayments)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Extraworks)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Absences)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Premiums)
                .ThenInclude(a => a.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Salaries)
                .Include(s => s.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(s => s.TemporaryPremiums)
                .Include(s => s.SalaryPremiums)
                .ThenInclude(s => s.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.JobInfo)
            // .Include(s => s.Emp)
            
                .Include(s => s.Employee)
                .ThenInclude(e => e.Vacations)
                .Where(s => s.IsClose == false && s.Employee.IsActive == true);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public IEnumerable<Salary> GetSalaryByMonth(int year, int month)
        {
            return Context.Salaries
                .Include(p => p.Employee)
                .ThenInclude(p => p.SalaryInfo)
                .Include(s => s.Employee)
                .ThenInclude(e => e.AdvancePayments)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Extraworks)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Absences)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Premiums)
                .ThenInclude(a => a.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Salaries)
                .Include(s => s.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(s => s.TemporaryPremiums)
                .Include(s => s.SalaryPremiums)
                .ThenInclude(s => s.Premium)
                .Where(a => a.MonthDate.Year == year &&
                            a.MonthDate.Month == month &&
                            a.Employee.IsActive==true);
        }
        public bool AdvancePremiumFreeze1() => Context.Salaries
               .Include(p => p.Employee)
               .ThenInclude(p => p.SalaryInfo)
                .Where(p => p.Employee.SalaryInfo.AdvancePremiumFreezeState).Any();

        public IEnumerable<SalaryPremium> GetTemSalaryPremiumBy(long salaryId)
        {
            return Context.SalaryPremiums
                .Include(e => e.Premium)
                .Include(e => e.Salary)
                .Where(e => e.SalaryId == salaryId 
                && e.IsAdvansePremmium==ISAdvancePremmium.ISNotAdvance
                && e.IsTemporary==IsTemporary.IsTemporary );
        }

        public override IEnumerable<Salary> GetAll()
        {
            return Context.Salaries
                .Include(p => p.Employee)
                .ThenInclude(p => p.SalaryInfo)
                .Include(s => s.SalaryPremiums)
                .ThenInclude(s => s.Premium);
        }
        //
        public IEnumerable<Salary> GetSalaryByEmployeeAndMonth(int year, int month, int salaryId)
        {
            return Context.Salaries
               .Include(p => p.Employee)
               .ThenInclude(p => p.SalaryInfo)
               .Include(s => s.Employee)
               .ThenInclude(e => e.AdvancePayments)
               .Include(s => s.Employee)
               .ThenInclude(e => e.Extraworks)
               .Include(s => s.Employee)
               .ThenInclude(e => e.Absences)
               .Include(s => s.Employee)
               .ThenInclude(e => e.Premiums)
                .ThenInclude(a => a.Premium)
               .Include(s => s.Employee)
               .ThenInclude(e => e.Salaries)
               .Include(s => s.BankBranch)
               .ThenInclude(b => b.Bank)
               .Include(s => s.TemporaryPremiums)
               .Include(s => s.SalaryPremiums)
               .ThenInclude(s => s.Premium)
               .Where(a => a.MonthDate.Year == year && a.MonthDate.Month == month && a.SalaryId == salaryId &&a.Employee.IsActive==true);
        }

        public IEnumerable<Salary> GetSalaryByEmployeeIdAndDate(int employeeId, DateTime dateFrom, DateTime dateTo)
        {
            return Context.Salaries
                .Include(p => p.Employee)
                .ThenInclude(p => p.SalaryInfo)
                .Include(p => p.Employee)
                .ThenInclude(p => p.JobInfo)
                .Include(s => s.Employee)
                .ThenInclude(e => e.AdvancePayments)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Extraworks)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Absences)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Premiums)
                .ThenInclude(a => a.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Salaries)
                .Include(s => s.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(s => s.TemporaryPremiums)
                .Include(s => s.SalaryPremiums)
                .ThenInclude(s => s.Premium)
                .Where(a => a.MonthDate >= new DateTime(dateFrom.Year, dateFrom.Month, 1)
                    && a.MonthDate <= new DateTime(dateTo.Year, dateTo.Month, 1)
                    && a.EmployeeId == employeeId && (a.AdvancePremiumInside > 0 || a.AdvancePremiumOutside > 0 && a.Employee.IsActive == false));
        }

        public IEnumerable<Salary> GetSalaryByDate(DateTime dateFrom, DateTime dateTo)
        {
            return Context.Salaries
                .Include(p => p.Employee)
                .ThenInclude(p => p.SalaryInfo)
                .Include(s => s.Employee)
                .ThenInclude(e => e.AdvancePayments)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Extraworks)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Absences)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Premiums)
                .ThenInclude(a => a.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Salaries)
                .Include(s => s.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(s => s.TemporaryPremiums)
                .Include(s => s.SalaryPremiums)
                .ThenInclude(s => s.Premium)
                .Where(a => a.MonthDate >= new DateTime(dateFrom.Year, dateFrom.Month, 1)
                    && a.MonthDate <= new DateTime(dateTo.Year, dateTo.Month, 1)
                         && (a.AdvancePremiumInside > 0 || a.AdvancePremiumOutside > 0 && a.Employee.IsActive == false));
        }
        public IEnumerable<Salary> GetSalaryByDateEndJob(DateTime dateFrom, DateTime dateTo)
        {
            return Context.Salaries
                .Include(p => p.Employee)
                .ThenInclude(p => p.SalaryInfo)
                .Include(s => s.Employee)
                .ThenInclude(e => e.AdvancePayments)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Extraworks)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Absences)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Premiums)
                .ThenInclude(a => a.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Salaries)
                .Include(s => s.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(s => s.TemporaryPremiums)
                .Include(s => s.SalaryPremiums)
                .ThenInclude(s => s.Premium)
                .Where(a => a.MonthDate >= new DateTime(dateFrom.Year, dateFrom.Month, 1)
                    && a.MonthDate <= new DateTime(dateTo.Year, dateTo.Month, 1)
                         && (a.IsClose==true));
        }
        public IEnumerable<Salary> GetSalaryAdvanceByEmployeeId(int employeeId)
        {
            return Context.Salaries
                .Include(s => s.Employee)
                .ThenInclude(e => e.AdvancePayments)
                .Where(s => s.EmployeeId == employeeId);
        }

        public IEnumerable<Salary> GetSalaryBy(DateTime date, int month)
        {
            return Context.Salaries
                .Include(p => p.Employee)
                .ThenInclude(p => p.SalaryInfo)
                .Include(s => s.Employee)
                .ThenInclude(e => e.AdvancePayments)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Extraworks)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Absences)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Premiums)
                .ThenInclude(a => a.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Salaries)
                .Include(s => s.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(s => s.TemporaryPremiums)
                .Include(s => s.SalaryPremiums)
                .ThenInclude(s => s.Premium)
                .Where(a => a.Date == date && a.Date.Month == month);
        }

        public Salary GetSalaryBy(int employeeId, DateTime date)
        {
            return Context.Salaries
                .Include(p => p.Employee)
                .ThenInclude(p => p.SalaryInfo)
                .Include(p => p.Employee)
                .ThenInclude(p => p.JobInfo)
                .Include(s => s.Employee)
                .ThenInclude(e => e.AdvancePayments)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Extraworks)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Absences)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Premiums)
                .ThenInclude(a => a.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Salaries)
                .Include(s => s.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(s => s.TemporaryPremiums)
                .Include(s => s.SalaryPremiums)
                .ThenInclude(s => s.Premium)
                .FirstOrDefault(a => a.MonthDate == new DateTime(date.Year, date.Month, 1)
                            && a.EmployeeId == employeeId);
        }

        public IEnumerable<Salary> GetSalaryBy(int employeeId, DateTime dateFrom, DateTime dateTo)
        {
            return Context.Salaries
                .Include(p => p.Employee)
                .ThenInclude(p => p.SalaryInfo)
                .Include(p => p.Employee)
                .ThenInclude(p => p.JobInfo)
                .Include(s => s.Employee)
                .ThenInclude(e => e.AdvancePayments)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Extraworks)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Absences)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Premiums)
                .ThenInclude(a => a.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Salaries)
                .Include(s => s.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(s => s.TemporaryPremiums)
                .Include(s => s.SalaryPremiums)
                .ThenInclude(s => s.Premium)
                .Where(a => a.MonthDate >= new DateTime(dateFrom.Year, dateFrom.Month, 1)
                            && a.MonthDate <= new DateTime(dateTo.Year, dateTo.Month, 1)
                            && a.EmployeeId == employeeId && a.Employee.IsActive == false);

        }

        public Salary GetLastSalary() => Context.Salaries
       .Include(p => p.Employee)
                .ThenInclude(p => p.SalaryInfo)
                .Include(s => s.Employee)
                .ThenInclude(e => e.AdvancePayments)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Extraworks)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Absences)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Premiums)
                .ThenInclude(a => a.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.Salaries)
                .Include(s => s.BankBranch)
                .ThenInclude(b => b.Bank)
                .Include(s => s.TemporaryPremiums)
                .Include(s => s.SalaryPremiums)
                .ThenInclude(s => s.Premium)
                .Include(s => s.Employee)
                .ThenInclude(e => e.JobInfo)
            .OrderByDescending(s => s.MonthDate)
            .FirstOrDefault();

        public Salary GetLastClosedSalary() => Context.Salaries
            .OrderByDescending(s => s.MonthDate)
            .FirstOrDefault(s => s.IsClose);

        public IEnumerable<TemporaryPremium> GetTemporaryPremium(long salaryId)
        {
            return Context.TemporaryPremiums
                .Where(t => t.SalaryId == salaryId);
        }

        public void RemoveTemporaryPremium(TemporaryPremium temporaryPremium) => Context.Remove(temporaryPremium);
        public void RemoveSalaryPremium(IEnumerable<SalaryPremium> salaryPremiums) => Context.RemoveRange(salaryPremiums);

        public TemporaryPremium FindTemporaryPremium(int temporaryPremiumId)
            => Context.TemporaryPremiums
                .Include(p => p.Salary)
                .FirstOrDefault(a => a.TemporaryPremiumId == temporaryPremiumId);


        public IEnumerable<EmployeePremium> GetNotTemEmployeePremiumBy(int employeeId)
        {
            var pr = Context.EmployeePremiums
            .Include(e => e.Premium)
            .Include(e => e.Employee)
            .Where(e => e.EmployeeId == employeeId /*&&e.Premium.ISAdvancePremmium==ISAdvancePremmium.ISNotAdvance &&e.IsTemporary==IsTemporary.IsNotTemporary*/ ).OrderBy(a => a.PremiumId);
            return pr;
        }

        //public IEnumerable<SalaryPremium> FindSalaryPremium(int premiumId, long salaryId)
        //    => Context.SalaryPremiums
        //        .Include(s => s.Premium)
        //        .Include(s => s.Premium)
        //        .Where(s => s.PremiumId == premiumId && s.SalaryId == salaryId);

        public bool TemporaryPremiumIsExisted(int temporaryPremiumId, long salaryId)
        {
            throw new NotImplementedException();
        }

        public bool TemporaryPremiumIsExisted(int temporaryPremiumId, long salaryId, int idToExcept)
        {
            throw new NotImplementedException();
        }

      

        public int SuspendedSalaryCount()
            => Context.Salaries
                .Count(s => !s.IsClose && s.IsSuspended);

        public IEnumerable<Salary> GetSerchSalaryAdvPayement(int BankId, int BankBranshId, int Year, int Month) => Context.Salaries

              .Include(p => p.Employee)

              .ThenInclude(p => p.SalaryInfo)
              .Include(s => s.Employee)
              .ThenInclude(e => e.AdvancePayments)
              .Include(s => s.Employee)
              .ThenInclude(e => e.Extraworks)
              .Include(s => s.Employee)
              .ThenInclude(e => e.Absences)
              .Include(s => s.Employee)
              .ThenInclude(e => e.Premiums)
                .ThenInclude(a => a.Premium)
              .Include(s => s.Employee)
              .ThenInclude(e => e.Salaries)
              .Include(s => s.BankBranch)
              .ThenInclude(b => b.Bank)
              .Include(s => s.TemporaryPremiums)
              .Include(s => s.SalaryPremiums)
              .ThenInclude(s => s.Premium)
              .Include(s => s.Employee)
              .ThenInclude(e => e.JobInfo)
               .ThenInclude(e => e.Job)
          .Include(s => s.Employee)
              .ThenInclude(e => e.JobInfo)
               //.ThenInclude(j=>j.Job)

               .ThenInclude(e => e.Unit)
               .ThenInclude(e => e.Division)


              .Where(s => s.IsClose == true &&   s.Employee.IsActive == false&&s.BankBranch.BankId == BankId && s.MonthDate.Year == Year && (s.AdvancePremiumInside >= 1 || s.AdvancePremiumOutside >= 1) && s.MonthDate.Month == Month && (s.AdvancePremiumInside >= 1 || s.AdvancePremiumOutside >= 1) && s.BankBranch.BankBranchId == BankBranshId || (s.IsClose == true && s.BankBranch.BankId == BankId && (s.AdvancePremiumInside >= 1 || s.AdvancePremiumOutside >= 1) && BankBranshId == 0 && s.MonthDate.Year == Year && s.MonthDate.Month == Month));

        public IEnumerable<SalaryPremium> GetSalaryPremium(int year, int month)
        {
            return Context.SalaryPremiums
                .Include(e => e.Premium)
                .Include(e => e.advancePayment)
                .Include(e => e.Salary)
                .Where(m => m.MonthDate.Month == month && m.MonthDate.Year == year)

              ;
        }

        public IEnumerable<AdvancePayment> GetSalaryAdvanceBy(int employeeId) => Context.AdvancePayments
          .Include(e => e.Premium)
          .Include(e => e.Employee)
          .Where(e => e.EmployeeId == employeeId && e.Premium.ISAdvancePremmium == ISAdvancePremmium.ISAdvance).OrderBy(a => a.PremiumId);

        public IEnumerable<SalaryPremium> GetSalaryPremiumBy(long salaryId) => Context.SalaryPremiums
          .Include(e => e.Premium)
            .Include(e => e.Salary)
            .Where(e => e.SalaryId == salaryId && e.Premium.ISAdvancePremmium == ISAdvancePremmium.ISNotAdvance && e.Premium.IsTemporary == IsTemporary.IsTemporary).OrderBy(a => a.PremiumId);


        public IEnumerable<Salary> GetSerchSalarySummary(int Year, int Month) => Context.Salaries

                 .Include(p => p.Employee)

                 .ThenInclude(p => p.SalaryInfo)
                 .Include(s => s.Employee)
                 .ThenInclude(e => e.AdvancePayments)
                 .Include(s => s.Employee)
                 .ThenInclude(e => e.Extraworks)
                 .Include(s => s.Employee)
                 .ThenInclude(e => e.Absences)
                 .Include(s => s.Employee)
                 .ThenInclude(e => e.Premiums)
                .ThenInclude(a => a.Premium)
                 .Include(s => s.Employee)
                 .ThenInclude(e => e.Salaries)
                 .Include(s => s.BankBranch)
                 .ThenInclude(b => b.Bank)
                 .Include(s => s.TemporaryPremiums)
                 .Include(s => s.SalaryPremiums)
                 .ThenInclude(s => s.Premium)
                 .Include(s => s.Employee)
                 .ThenInclude(e => e.JobInfo)
                  .ThenInclude(e => e.Job)
             .Include(s => s.Employee)
                 .ThenInclude(e => e.JobInfo)
                  //.ThenInclude(j=>j.Job)

                  .ThenInclude(e => e.Unit)
                  .ThenInclude(e => e.Division)


                    .Where(s => s.IsClose == true && s.Employee.IsActive == false &&  s.MonthDate.Year == Year && s.MonthDate.Month == Month || (s.IsClose == true && s.MonthDate.Year == Year && s.MonthDate.Month == Month));



        /// /// /// /// /// //// //

        public IEnumerable<Salary> GetSerchSalaryDifrancess(int BankId, int BankBranshId, int Year, int Month) => Context.Salaries

            .Include(p => p.Employee)

            .ThenInclude(p => p.SalaryInfo)
            .Include(s => s.Employee)
            .ThenInclude(e => e.AdvancePayments)
            .Include(s => s.Employee)
            .ThenInclude(e => e.Extraworks)
            .Include(s => s.Employee)
            .ThenInclude(e => e.Absences)
            .Include(s => s.Employee)
            .ThenInclude(e => e.Premiums)
            .ThenInclude(a => a.Premium)
            .Include(s => s.Employee)
            .ThenInclude(e => e.Salaries)
            .Include(s => s.BankBranch)
            .ThenInclude(b => b.Bank)
            .Include(s => s.TemporaryPremiums)
            .Include(s => s.SalaryPremiums)
            .ThenInclude(s => s.Premium)
            .Include(s => s.Employee)
            .ThenInclude(e => e.JobInfo)
             .ThenInclude(e => e.Job)
        .Include(s => s.Employee)
            .ThenInclude(e => e.JobInfo)
             //.ThenInclude(j=>j.Job)

             .ThenInclude(e => e.Unit)
             .ThenInclude(e => e.Division)


            .Where(s => s.IsClose == true && s.BankBranch.BankId == BankId && s.MonthDate.Year == Year && s.MonthDate.Month == Month && s.BankBranch.BankBranchId == BankBranshId && s.DifrancessSetting >= 1 || (s.IsClose == true && s.BankBranch.BankId == BankId && BankBranshId == 0 && s.MonthDate.Year == Year && s.MonthDate.Month == Month && s.DifrancessSetting >= 1));

        public IEnumerable<Salary> GetSerchSalary(int BankId, int BankBranshId, int Year, int Month) => Context.Salaries

              .Include(p => p.Employee)

              .ThenInclude(p => p.SalaryInfo)
              .Include(s => s.Employee)
              .ThenInclude(e => e.AdvancePayments)
              .Include(s => s.Employee)
              .ThenInclude(e => e.Extraworks)
              .Include(s => s.Employee)
              .ThenInclude(e => e.Absences)
              .Include(s => s.Employee)
              .ThenInclude(e => e.Premiums)
              .ThenInclude(a => a.Premium)
              .Include(s => s.Employee)
              .ThenInclude(e => e.Salaries)
              .Include(s => s.BankBranch)
              .ThenInclude(b => b.Bank)
              .Include(s => s.TemporaryPremiums)
              .Include(s => s.SalaryPremiums)
              .ThenInclude(s => s.Premium)
              .Include(s => s.Employee)
              .ThenInclude(e => e.JobInfo)
               .ThenInclude(e => e.Job)
          .Include(s => s.Employee)
              .ThenInclude(e => e.JobInfo)
               //.ThenInclude(j=>j.Job)

               .ThenInclude(e => e.Unit)
               .ThenInclude(e => e.Division)


              .Where(s => s.IsClose == true && s.BankBranch.BankId == BankId &&  s.Employee.IsActive == false&& s.MonthDate.Year == Year && s.MonthDate.Month == Month && s.BankBranch.BankBranchId == BankBranshId || (s.IsClose == true && s.BankBranch.BankId == BankId && BankBranshId == 0 && s.MonthDate.Year == Year && s.MonthDate.Month == Month));

        public IEnumerable<AdvancePayment> GetEmployeeAdvance() => Context.AdvancePayments
     .Include(e => e.Premium)
     //  .ThenInclude(s => s.AdvancePayments)
     .Include(e => e.Employee)
         .ThenInclude(s => s.Premiums)
            .Include(e => e.Employee)
         .ThenInclude(s => s.AdvancePayments)

    ;
        //public IEnumerable<AdvancePayment> GetSalaryAdvanceBy(int employeeId) => Context.AdvancePayments
        //  .Include(e => e.Premium)
        //  .Include(e => e.Employee)
        //  .Where(e => e.EmployeeId == employeeId && e.Premium.ISAdvancePremmium == ISAdvancePremmium.ISAdvance).OrderBy(a => a.PremiumId);


        public IEnumerable<Employee> GetEmployeeReportDate(EmployeeReportDto employeeReport)
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
                .ThenInclude(j => j.Staffing)
                .ThenInclude(j => j.StaffingType)
                .Include(e => e.MilitaryData)
                .Include(e => e.Place)
                .ThenInclude(e => e.Branch)
                .Include(z => z.Evaluations)
                .Include(s=>s.Salaries)
                 .Include(s => s.Sanctions)
                .Include(s=>s.AdvancePayments)
                .Where( a=>  a.IsActive == true)


                .AsQueryable();
          
                if (employeeReport.BankID > 0)
                {
                employees = employees.Where(s => s.SalaryInfo.BankBranch.BankId == employeeReport.BankID);
                }
                if (employeeReport.BranchId > 0)
                {
                employees = employees.Where(e => e.SalaryInfo.BankBranch.BankBranchId == employeeReport.BranchId && e.Salaries.FirstOrDefault().MonthDate.Date.Year == employeeReport.Year);
                }


                if (employeeReport.JobNumberInt != 0)
                {
                employees = employees.Where(e => e.JobInfo.JobNumber == 1002/*employeeReport.JobNumberInt*/);
                }

                if (employeeReport.UnitId > 0)
                {
                employees = employees.Where(e => e.JobInfo.UnitId == employeeReport.UnitId );
                }
                if (employeeReport.DivisionId > 0)
                {
                employees = employees.Where(e => e.JobInfo.Unit.DivisionId == employeeReport.DivisionId);
                }
                if (employeeReport.DepartmentId > 0)
                {
                employees = employees.Where(e => e.JobInfo.Unit.Division.DepartmentId == employeeReport.DepartmentId);
                }


                if (employeeReport.CenterId > 0)
                {
                employees = employees.Where(e => e.JobInfo.Unit.Division.Department.CenterId == employeeReport.CenterId);
                }

            
           

            return employees;




        }
    }
}