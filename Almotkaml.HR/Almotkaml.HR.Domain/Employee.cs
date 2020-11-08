using Almotkaml.HR.Domain.EmployeeFactory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Domain
{
    public class Employee
    {
        public static IFirstNameHolder New()
        {
            return new EmployeeBuilder();
        }

        protected internal Employee()
        {
            Passport = new Passport(this);
        }
        public string BookFamilySourceNumber { get; set; }
        public string NationaltyMother { get; set; }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandfatherName { get; set; }
        public string LastName { get; set; }
        public string EnglishFirstName { get; set; }
        public string EnglishFatherName { get; set; }
        public string EnglishGrandfatherName { get; set; }
        public string EnglishLastName { get; set; }
        public string MotherName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string NationalNumber { get; set; }
        public Religion Religion { get; set; }
        public LibyanOrForeigner LibyanOrForeigner { get; set; }
        public int? NationalityId { get; set; }
        public Nationality Nationality { get; set; }
        public int? WifeNationalityId { get; set; }
        public Nationality WifeNationality { get; set; }
        public Place Place { get; set; }
        public int? PlaceId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public SocialStatus SocialStatus { get; set; }
        public int? ChildernCount { get; set; }
        public BloodType BloodType { get; set; }
        public Booklet Booklet { get; set; }
     
        public Passport Passport { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public IdentificationCard IdentificationCard { get; set; }
        //public long? JobInfoId { get; set; }
        public JobInfo JobInfo { get; set; }
        //public int? MilitaryDataId { get; set; }
        public MilitaryData MilitaryData { get; set; }
        public SalaryInfo SalaryInfo { get; set; }
        public byte[] Image { get; set; }
        public bool IsActive { get; internal set; }
        public ICollection<Qualification> Qualifications { get; set; } = new HashSet<Qualification>();
        public ICollection<TrainingCourse> TrainingCourses { get; set; } = new HashSet<TrainingCourse>(); //??????????????
        public ICollection<Sanction> Sanctions { get; set; } = new HashSet<Sanction>();
        public ICollection<Reward> Rewards { get; set; } = new HashSet<Reward>();
        public ICollection<Vacation> Vacations { get; set; } = new HashSet<Vacation>();
        public ICollection<Evaluation> Evaluations { get; set; } = new HashSet<Evaluation>();
        public ICollection<Extrawork> Extraworks { get; set; } = new HashSet<Extrawork>();
        public ICollection<SelfCourses> SelfCourseses { get; set; } = new HashSet<SelfCourses>();
        public ICollection<SituationResolveJob> SituationResolveJobs { get; set; } = new HashSet<SituationResolveJob>();
        public ICollection<Absence> Absences { get; set; } = new HashSet<Absence>();
        public ICollection<Transfer> Transfers { get; set; } = new HashSet<Transfer>();
        public ICollection<EmployeePremium> Premiums { get; set; } = new HashSet<EmployeePremium>();
        public ICollection<AdvancePayment> AdvancePayments { get; set; } = new HashSet<AdvancePayment>();
        public ICollection<Salary> Salaries { get; set; } = new HashSet<Salary>();
       // public ICollection<SalaryPremium> SalaryPremiums { get; set; } = new HashSet<SalaryPremium>();
        public ICollection<Document> Documents { get; } = new HashSet<Document>();
        public EndServices EndedServices { get; internal set; }
     //   public string JobNumberLIC { get; set; }

        public EmployeeModifier Modify()
        {
            return new EmployeeModifier(this);
        }

        public void Active() => IsActive = true;
        public void UnActive() => IsActive = false;
        public void EndServices(CauseOfEndService causeOfEndService, DateTime decisionDate, string cause, string decisionNumber)
        {
            Check.IsValidDate(decisionDate, nameof(decisionDate));

            EndedServices = new EndServices()
            {
                Employee = this,
                CauseOfEndService = causeOfEndService,
                EmployeeId = EmployeeId,
                Cause = cause,
                DecisionDate = decisionDate,
                DecisionNumber = decisionNumber,
            };
            // var a = (int)causeOfEndService;
            //JobInfo = new JobInfo()
            //{
            //    CurrentSituationId = (int)causeOfEndService,
            //};

            //var _currentSituationId = JobInfo.CurrentSituation.SituationEssential;
            JobInfo.CurrentSituationId = (int)causeOfEndService +1;
            IsActive = false;
        }
        public int? GetAge() => DateTime.Now.Year - BirthDate?.Year;

        public int GetYearlyVacationBalance(Settings settings)
            => settings.YearlyVacationRule.GetYearlyVacationBalance(this);
        
        public string GetFullName() => FirstName + " " + FatherName + " " + GrandfatherName + " " + LastName;
        /// <summary>
        /// حساب قيمة المرتب الاساسي
        /// </summary>
        /// <param name="salaryUnits"></param>
        /// <param name="salayClassification"></param>
        /// <returns></returns>
        public decimal GetBasicSalaryByDegree(IList<SalaryUnit> salaryUnits, JobInfo ExpDateo, SalayClassification salayClassification, LeaderType leadertype)
        {

            decimal LeaderBasicSalary = 0;
            ////var salaryUnit = salaryUnits.FirstOrDefault(s => s.Degree == JobInfo.DegreeNow
            ////        && s.SalayClassification == salayClassification);
            //if (JobInfo.JobType == JobType.Designation )
            //{
            //    var salaryUnit = salaryUnits.FirstOrDefault(s => s.Degree == JobInfo.DegreeNow
            //        && s.SalayClassification == SalayClassification.Default);
            //    if (salaryUnit == null)
            //        return 0;

            //    var boun = JobInfo.Bouns ?? 0;
            //    //if (boun >= 3)
            //    //    boun = 3;
            //    if(ExpDateo.ExpDate >= 1  && ExpDateo.ExpDate<6)
            //    {


            //    basicSalary = salaryUnit.BeginningValue + salaryUnit.PremiumValue * boun;
            //}
            //    if (ExpDateo.ExpDate >= 6 && ExpDateo.ExpDate < 11)
            //    {

            //        basicSalary = salaryUnit.BeginningValue + salaryUnit.PremiumValue1 * boun;
            //    }
            //    if (ExpDateo.ExpDate >=11 && ExpDateo.ExpDate < 16)
            //    {


            //        basicSalary = salaryUnit.BeginningValue + salaryUnit.PremiumValue2 * boun;
            //    }
            //    if (ExpDateo.ExpDate >= 16)
            //    {


            //        basicSalary = salaryUnit.BeginningValue + salaryUnit.PremiumValue3 * boun;
            //    }


            if (salayClassification == SalayClassification.Leader)
            {
                var salaryUnit = salaryUnits.Where(s => s.SalayClassification == salayClassification);
                var salaryUnit2 = salaryUnits.FirstOrDefault(s => s.SalayClassification == salayClassification);
                if (leadertype == LeaderType.HIF1)
                {
                    LeaderBasicSalary = salaryUnit2.HIF1;
                }
                if (leadertype == LeaderType.HIF2)
                {
                    LeaderBasicSalary = salaryUnit2.HIF2;
                }
                if (leadertype == LeaderType.HIF3)
                {
                    LeaderBasicSalary = salaryUnit2.HIF3;
                }
                if (leadertype == LeaderType.HIF4)
                {
                    LeaderBasicSalary = salaryUnit2.HIF4;
                }
                if (leadertype == LeaderType.HIF5)
                {
                    LeaderBasicSalary = salaryUnit2.HIF5;
                }
                if (leadertype == LeaderType.HIF6)
                {
                    LeaderBasicSalary = salaryUnit2.HIF6;
                }
                if (leadertype == LeaderType.HIF5)
                {
                    LeaderBasicSalary = salaryUnit2.HIF7;
                }
                if (leadertype == LeaderType.HIF8)
                {
                    LeaderBasicSalary = salaryUnit2.HIF8;
                }
                if (leadertype == LeaderType.HIF8)
                {
                    LeaderBasicSalary = salaryUnit2.HIF9;
                }
                if (leadertype == LeaderType.HIF10)
                {
                    LeaderBasicSalary = salaryUnit2.HIF10;
                }
                if (leadertype == LeaderType.HIF11)
                {
                    LeaderBasicSalary = salaryUnit2.HIF11;
                }
                if (leadertype == LeaderType.HIF12)
                {
                    LeaderBasicSalary = salaryUnit2.HIF12;
                }




            }
            //if (basicSalary > LeaderBasicSalary)
            //    return basicSalary;
            //else
            return LeaderBasicSalary;

        }
        public string GetSubsendedNote(IList<Salary> salarysubsended, DateTime date)
        {
            string subsended = "";
            if (JobInfo.JobType == JobType.Designation)
            {
                var getsubsended = salarysubsended.FirstOrDefault(s => s.JobNumber == JobInfo.JobNumber.ToString()
                    && s.MonthDate == date);

                if (getsubsended == null)
                    return "";


                subsended = getsubsended.SuspendedNote;
            }
            return subsended;
        }
        public bool GetSubsended(IList<Salary> salarysubsended,DateTime date)
        {
            bool subsended = false;
            if (JobInfo.JobType == JobType.Designation)
            {
                var getsubsended = salarysubsended.FirstOrDefault(s => s.JobNumber == JobInfo.JobNumber.ToString()
                    && s.MonthDate== date);

                if (getsubsended == null)
                    return false;


                subsended = getsubsended.IsSuspended;
            }
            return subsended;
        }
        public decimal GetExtraValueByDegree(IList<SalaryUnit> salaryUnits, SalayClassification salayClassification)
        {
            decimal extraValue = 0;
            if (JobInfo.JobType == JobType.Designation)
            {
                var salaryUnit = salaryUnits.FirstOrDefault(s => s.Degree == JobInfo.DegreeNow
                    && s.SalayClassification == salayClassification);

                if (salaryUnit == null)
                    return 0;

                if (salayClassification == SalayClassification.Clamp)
                {
                    var boun = JobInfo.Bouns ?? 0;
                    if (boun >= 10)
                        boun = 10;
                    extraValue = (salaryUnit.BeginningValue + salaryUnit.PremiumValue * boun) * 40 / 100;
                }
                else
                {
                    extraValue = salaryUnit.ExtraValue1;
                }
            }
            return extraValue;
        }
        public decimal GetExtraGeneralValueByDegree(IList<SalaryUnit> salaryUnits, SalayClassification salayClassification)
        {
            decimal extraGeneralValue = 0;
            if (JobInfo.JobType == JobType.Designation)
            {
                var salaryUnit = salaryUnits.FirstOrDefault(s => s.Degree == JobInfo.DegreeNow
                    && s.SalayClassification == salayClassification);

                if (salaryUnit == null)
                    return 0;

                extraGeneralValue = salayClassification == SalayClassification.Clamp ? 0 : salaryUnit.ExtraGeneralValue;
            }
            return extraGeneralValue;
        }
        public void RemoveSituationResolveJob(SituationResolveJob situationResolveJob)
        {
            JobInfo.Bouns = situationResolveJob.Boun;
            JobInfo.DateBouns = situationResolveJob.DateDegreeLast;
            JobInfo.DegreeNow = situationResolveJob.Degree;
            JobInfo.DateDegreeNow = situationResolveJob.DateDegreeLast;
            JobInfo.JobId = situationResolveJob.JobLastId;
            situationResolveJob.Employee = null;

            SituationResolveJobs.Remove(situationResolveJob);
        }
        public void Vacation(Vacation vacation, int holidayCount)
        {
            var friday = DayOfWeek.Friday;
            var saturday = DayOfWeek.Saturday;
            var countFridayOld = JobInfo.CountDays(friday, vacation.DateFrom, vacation.DateTo);
            var countSaturdayOld = JobInfo.CountDays(saturday, vacation.DateFrom, vacation.DateTo);

            var countHolidayOld = countFridayOld + countSaturdayOld;

            var dayOld = (int)(vacation.DateTo - vacation.DateFrom).TotalDays + 1;

            if (vacation.VacationType.VacationEssential == VacationEssential.Year)
            {
                JobInfo.VacationBalance += dayOld - countHolidayOld - holidayCount;
            }
        }
        public int GetVacationDays(DateTime dateFrom, DateTime dateTo, int holidayCount, int vacationTypeId)
        {
            var friday = DayOfWeek.Friday;
            var saturday = DayOfWeek.Saturday;
            var countFriday = JobInfo.CountDays(friday, dateFrom, dateTo);
            var countSaturday = JobInfo.CountDays(saturday, dateFrom, dateTo);

            var countHoliday = countFriday + countSaturday;

            var day = (int)(dateTo - dateFrom).TotalDays + 1;

            if (vacationTypeId == (int)VacationEssential.Year)
            {
                return day - countHoliday - holidayCount;
            }
            return day;
        }
        public int GetVacationDays2(DateTime dateFrom, DateTime dateTo, int holidayCount, int vacationTypeId)
        {
            var friday = DayOfWeek.Friday;
            var saturday = DayOfWeek.Saturday;

            var countFriday = JobInfo.CountDays(friday, dateFrom, dateTo);
            var countSaturday = JobInfo.CountDays(saturday, dateFrom, dateTo);

            var countHoliday = countFriday + countSaturday;

            var day = (int)(dateTo - dateFrom).TotalDays + 1;

            //if (vacationTypeId == (int)VacationEssential.Year)
            //{
            //    return day - countHoliday - holidayCount;
            //}
            return countHoliday;
        }
        public int GetVacationDays(DateTime dateFrom, DateTime dateTo, DateTime monthDate, int vacationTypeId)
        {
            var friday = DayOfWeek.Friday;
            var saturday = DayOfWeek.Saturday;
            var countFriday = JobInfo.CountDays(friday, dateFrom, dateTo);
            var countSaturday = JobInfo.CountDays(saturday, dateFrom, dateTo);
            int day = 0;
            var countHoliday = countFriday + countSaturday;

            if (dateFrom.Date.Month == monthDate.Date.Month && dateTo.Date.Month == monthDate.Date.Month)
            {
                day= (int)(dateTo - dateFrom).TotalDays + 1;

                if (vacationTypeId == (int)VacationEssential.Year)
                {
                    return day - countHoliday;
                }
            }
            else if(dateFrom.Date.Month == monthDate.Date.Month)
            {
                //if (DateTime.DaysInMonth(dateFrom.Date.year, dateFrom.Date.Month) == monthDate.Date.Month)
            }
            else if (dateTo.Date.Month == monthDate.Date.Month)
            {

            }
            return day;
        }
        public void AddSituationResolveJob(int degreeNow,/* int bounNow,*/ string decisionNumber, DateTime decisionDate,
            int jobNowId,string note)
        {
            SituationResolveJobs.Add(new SituationResolveJob()
            {
                Boun = JobInfo.Bouns,
                //BounNow = bounNow,
                DateDegreeLast = JobInfo.DateDegreeNow,
               // DateBounLast = JobInfo.DateBouns,
                DecisionDate =Convert.ToDateTime( JobInfo.DateDegreeNow),
                DecisionNumber = decisionNumber,
                Degree = JobInfo.DegreeNow,
                DegreeNow = degreeNow,
                Employee = this,
                EmployeeId = EmployeeId,
                JobLastId = JobInfo.JobId,
                JobLast = JobInfo.Job,
                JobNowId = jobNowId,
                Note=note ,
            });
           // JobInfo.Bouns = bounNow;
            JobInfo.DegreeNow = degreeNow;
            JobInfo.DateBouns = decisionDate;
            JobInfo.DateDegreeNow = decisionDate;
            JobInfo.JobId = jobNowId;
        }
    }

}






