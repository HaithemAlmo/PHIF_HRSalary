using Almotkaml.HR.Domain.JobInfoFactory;
using System;


namespace Almotkaml.HR.Domain
{
    public class JobInfo
    {
        //public static IEmploymentValuesHolder New()
        //{
        //    return new JobInfoBuilder();
        //}

        protected internal JobInfo()
        {

        }

        internal JobInfo(Employee employee)
        {
            Employee = employee;
        }
        public SiutiontnType? Situons { get; internal set; }

        public int? SituionsNumber { get; internal set; }
        public Employee Employee { get; set; }
        //public long JobInfoId { get; internal set; }
        //public int EmployeeId { get; internal set; }
        //public Employee Employee { get; internal set; }
        //public EmploymentType EmploymentType { get; internal set; }
        //public int EmploymentTypeId { get; internal set; }
        public Adjective Adjective { get; internal set; }
        public string OldJobNumber { get; internal set; }
        public EmploymentValues EmploymentValues { get; internal set; }
        public DateTime? DirectlyDate { get; internal set; } // تاريخ المباشرة
        public int? Degree { get; internal set; } // درجة التوظيف
        public int? JobId { get; internal set; }
        public JobType JobType { get; internal set; }
        public Job Job { get; internal set; }
        public string DegreeNote { get; set; }
        public int? JobClassValu { get; internal set; }
        public JobClass JobClassV { get; set; }

        public int? ClassificationOnWorkId { get; set; }
        public ClassificationOnWork ClassificationOnWork { get; internal set; }
        public int? ClassificationOnSearchingId { get; internal set; }
        public ClassificationOnSearching ClassificationOnSearching { get; internal set; }
        public int JobNumber { get; internal set; } // الرقم الوظيفي 
        public int? JobNumberLIC { get; internal set; }      //الرقم الوظيفي للتأمين  
        public int? JobNumberApproved { get; internal set; } // ر.و لدى الملاك الوظيفي
        //public SituationResolveJob SituationResolveJob { get; internal set; } // تسوية الوضع الوظيفي
        public int? CurrentSituationId { get; internal set; }
        public CurrentSituation CurrentSituation { get; internal set; } // الوضع الحالي
        //public string ResolveResolutionNumber { get; internal set; } // رقم قرار للتسوية الوظيفية
        //public DateTime? ResolveResolutionDate { get; internal set; } // تاريخ قرار التسوية الوضيفية
        public int? UnitId { get; internal set; }
        public Unit Unit { get; internal set; }
             
        public int? DegreeNow { get; internal set; }
        public DateTime? DateDegreeNow { get; internal set; } // تاريخ الدرجة
        public DateTime? DateMeritDegreeNow { get; internal set; } // تاريخ استحقاق الدرجة
        public int? Bouns { get; internal set; } // العلاوات
        public int? Bounshr { get; internal set; } // العلاوات
        public DateTime? DateBounshr { get; internal set; }

        public DateTime? DateBouns { get; internal set; } // تاريخ العلاوة
        public DateTime? DateMeritBouns { get; internal set; } // تاريخ استحقاق العلاوة
        public DateTime? DateBounsLast { get; internal set; } // تاريخ العلاوة

        public int? AdjectiveEmployeeId { get; internal set; }
        public AdjectiveEmployee AdjectiveEmployee { get; internal set; }
        public int? StaffingId { get; internal set; }

        public Staffing Staffing { get; internal set; } // الملاك الوظيفي
        //public int? SerialNumber { get; internal set; }
        public int? StaffingClassificationId { get; internal set; } // تصنيف الملاك الوظيفي
        public StaffingClassification StaffingClassification { get; internal set; } // تصنيف الملاك الوظيفي
        public int? VacationBalance { get; internal set; }
        //public FinancialData FinancialData { get; internal set; }
        //HAM
        public int? VacationBalanceYear { get; internal set; }
        public int? VacationBalanceEmergency { get; internal set; }//رصيد الاجازة الطارئة
        public int? VacationBalanceAlhaju { get; internal set; }//رصيد اجازة الحج
        public int? VacationBalanceMarriage { get; internal set; }//رصيد اجازة الزواج
        public int? VacationBalanceSickNew { get; internal set; }//رصيد الاجازة المرضية
    //    public int? VacationSickLeaveNew { get; internal set; }//رصيد الاجازة المرضية

        //HAM
        public SalayClassification? SalayClassification { get; internal set; }
        public string Notes { get; internal set; }
        public string GetJobNumber() => JobNumberLIC.ToString();
        public int ExpDate => Int32.Parse((DateTime.Now.Year - DirectlyDate.Value.Year).ToString());
        public LeaderType? leaderType  { get; set; }
        public Redirection Redirection { get; set; }
        public string RedirectionNote { get; set; }
        public string HealthStatus { get; set; }
        public string CurrentClassification { get; set; }
    
        public JobInfoModifier Modify()
        {
            return new JobInfoModifier(this);
        }
        public void Modify(int? vacationBalanceYear, int balanc,int emergencycountday)
        {
            VacationBalanceYear = vacationBalanceYear;
            VacationBalance += balanc;
            VacationBalanceEmergency += emergencycountday;  //اضافة رصيد الاجازة الطارئة 12يوم في السنة
           
        }

        public void SetVacation(DateTime dateFrom, DateTime dateTo, int vacationTypeId, bool place
                                    , string decisionNumber, DateTime decisionDate, int holidayCount, string note ,int  countdaysvacation,int countkids, int deductionMonth, int deductionYear)
        {
            if (dateTo < dateFrom)
                throw new Exception("date from less than date to ...");

            var friday = DayOfWeek.Friday;////////////////////
            var saturday = DayOfWeek.Saturday;//////////////////////

            var countFriday = CountDays(friday, dateFrom, dateTo);
            var countSaturday = CountDays(saturday, dateFrom, dateTo);

            var countHoliday = countFriday + countSaturday;

            var day = dateTo - dateFrom;

            var days = (int)day.TotalDays + 1;
            //(int)VacationEssential.Year
            if (vacationTypeId == 5 )
            {
                if (VacationBalance < countdaysvacation)
                    throw new Exception("الايام اكبر من رصيد الاجازة ...");

                VacationBalance -= countdaysvacation;
            }
            if (vacationTypeId==7 )
            {
                if (VacationBalanceEmergency  < countdaysvacation)
                    throw new Exception("the days is more than Balance ...");
                //VacationBalanceEmergency -= days - countHoliday - holidayCount;
                VacationBalanceEmergency -= countdaysvacation;
            }
            if (vacationTypeId ==9)
            {
                if (VacationBalanceAlhaju  < countdaysvacation)
                    throw new Exception("the days is more than Balance ...");
                //VacationBalanceEmergency -= days - countHoliday - holidayCount;
                VacationBalanceAlhaju  -= countdaysvacation;
            }
            if (vacationTypeId == 10)
            {
                if (VacationBalanceMarriage  < countdaysvacation)
                    throw new Exception("the days is more than Balance ...");
                //VacationBalanceEmergency -= days - countHoliday - holidayCount;
                VacationBalanceMarriage  -= countdaysvacation;
            }
            if (vacationTypeId == 8)
            {
                if (VacationBalanceSickNew  < countdaysvacation)
                    throw new Exception("the days is more than Balance ...");
                //VacationBalanceEmergency -= days - countHoliday - holidayCount;
                VacationBalanceSickNew -= countdaysvacation;
            }

            //else
            //{
            //    days = days - vacationType.Days;

            //    if (days > 0)
            //        throw new Exception("the days is more than Vacation ...");
            //}


            var vacation = new Vacation()
            {
                Note = note,
                DateFrom = dateFrom,
                DateTo = dateTo,
                VacationTypeId = vacationTypeId,
                EmployeeId = Employee.EmployeeId,
                DecisionNumber = decisionNumber,
                DecisionDate = decisionDate,
                Place = place,
                DeductionMonth= deductionMonth,
                DeductionYear= deductionYear,
                CountKids = countkids,
            };

            Employee.Vacations.Add(vacation);
        }

        internal static int CountDays(DayOfWeek day, DateTime start, DateTime end)
        {
            var ts = end - start; // Total duration
            var count = (int)Math.Floor(ts.TotalDays / 7); // Number of whole weeks
            var remainder = (int)(ts.TotalDays % 7); // Number of remaining days
            var sinceLastDay = end.DayOfWeek - day; // Number of days since last [day]
            if (sinceLastDay < 0) sinceLastDay += 7; // Adjust for negative days since last [day]

            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay) count++;

            return count;
        }

        //internal void Day(int days, DateTime dateFrom, DateTime dateTo, DayOfWeek day = DayOfWeek.Friday)
        /////////////////////////
        //{
        //    var countFriday = CountDays(day, dateFrom, dateTo);

        //    var vacationType = new VacationType();

        //    if (vacationType.Days != 0)
        //    {
        //        days = days - vacationType.Days;

        //        if (days > 0)
        //            throw new Exception("the days is more than Vacation ...");

        //        Days = days;
        //    }
        //    else
        //    {
        //        Days = days - countFriday;
        //        VacationBalance -= days - countFriday;
        //    }
        //}


    }

}