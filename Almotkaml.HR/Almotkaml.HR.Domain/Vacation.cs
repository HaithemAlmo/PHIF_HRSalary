using System;

namespace Almotkaml.HR.Domain
{
    public class Vacation
    {
        //public static Vacation New(DateTime dateFrom, DateTime dateTo, int vacationTypeId, int employeeId)
        //{
        //    Check.MoreThanZero(vacationTypeId, nameof(vacationTypeId));
        //    Check.MoreThanZero(employeeId, nameof(employeeId));

        //    if (dateFrom < dateTo)
        //        throw new Exception("date from less than date to ...");
        //    /////////////
        //    var friday = DayOfWeek.Friday;////////////////////
        //    var saturday = DayOfWeek.Saturday;////////////////////

        //    var countFriday = CountDays(friday, dateFrom, dateTo);

        //    var countSaturday = CountDays(saturday, dateFrom, dateTo);

        //    var vacationType = new VacationType();

        //    if (vacationType.Essential)
        //        Employee.JobInfo.VacationBalance.Value = vacationType.Days - countFriday - countSaturday;
        //    else
        //        days = days - countFriday;
        //    //////////////
        //    var vacation = new Vacation()
        //    {
        //        DateFrom = dateFrom,
        //        DateTo = dateTo,
        //        VacationTypeId = vacationTypeId,
        //        EmployeeId = employeeId,
        //    };


        //    return vacation;
        //}

        //public static Vacation New(DateTime dateFrom, DateTime dateTo, int days, int balance, VacationType vacationType, Employee employee)
        //{
        //    Check.MoreThanZero(days, nameof(days));
        //    Check.NotNull(vacationType, nameof(vacationType));
        //    Check.NotNull(employee, nameof(employee));

        //    if (dateFrom < dateTo)
        //        throw new Exception("date from less than date to ...");
        //    /////////////
        //    //Day(days, dateFrom, dateTo);
        //    //////////////

        //    var vacation = new Vacation()
        //    {
        //        DateFrom = dateFrom,
        //        DateTo = dateTo,
        //        //Days = days,
        //        VacationType = vacationType,
        //        Employee = employee,
        //        EmployeeId = employee.EmployeeId
        //    };


        //    return vacation;
        //}

        internal Vacation()
        {

        }
        public long VacationId { get; private set; }
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public DateTime DateFrom { get; internal set; }
        public DateTime DateTo { get; internal set; }
        public int VacationTypeId { get; internal set; }
        public VacationType VacationType { get; internal set; }
        public string DecisionNumber { get; internal set; }
        public string Note { get; internal set; }
        public int? CountKids { get; internal set; }
        public int DeductionMonth { get; internal set; }
        public int DeductionYear { get; internal set; }
        //    public int SickDays { get; internal set; }


        public DateTime? DecisionDate { get; internal set; }
        public bool Place { get; internal set; }
        public int GetDays(DateTime dateFrom, DateTime dateTo)
        {
            var friday = DayOfWeek.Friday;////////////////////
            var saturday = DayOfWeek.Saturday;//////////////////////

            var countFriday = JobInfo.CountDays(friday, dateFrom, dateTo);
            var countSaturday = JobInfo.CountDays(saturday, dateFrom, dateTo);

            var countHoliday = countFriday + countSaturday;

            var day = dateTo - dateFrom;

            var days = (int)day.TotalDays + 1;

            return days - countHoliday; ;
        }//Ham
        public int GetDays(DateTime dateFrom, DateTime dateTo,int vacationId)
        {
            var friday = DayOfWeek.Friday;////////////////////
            var saturday = DayOfWeek.Saturday;//////////////////////

            var countFriday = JobInfo.CountDays(friday, dateFrom, dateTo);
            var countSaturday = JobInfo.CountDays(saturday, dateFrom, dateTo);

            var countHoliday = countFriday + countSaturday;

            var day = dateTo - dateFrom;

            var days = (int)day.TotalDays + 1;
            if (vacationId == (int)VacationEssential.Year)
            {
                days = days - countHoliday;
            }

            return days; 
        }//Ham
        public int GetDays2(DateTime dateFrom, DateTime dateTo)
        {
            //الإجازات تشمل الجمعة والسبت
            var day = dateTo - dateFrom;

            var days = (int)day.TotalDays + 1;

            return days ;
        }//Ham

      
        //public void Modify4(int countdayVact)
        //{
        //    EmergencyCountDay = countdayVact;

        //}//
        public void Modify(DateTime dateFrom, DateTime dateTo, int vacationTypeId, bool place, string decisionNumber
            , DateTime decisionDate, int holidayCount,string note,int countkids, int deductionMonth, int deductionYear)
        {
            Check.MoreThanZero(vacationTypeId, nameof(vacationTypeId));
            if (dateTo < dateFrom)
                throw new Exception("date from less than date to ...");
            /////////////
            var friday = DayOfWeek.Friday;////////////////////
            var saturday = DayOfWeek.Saturday;////////////////////

            var countFriday = JobInfo.CountDays(friday, dateFrom, dateTo);
            var countSaturday = JobInfo.CountDays(saturday, dateFrom, dateTo);

            var countFridayOld = JobInfo.CountDays(friday, DateFrom, DateTo);
            var countSaturdayOld = JobInfo.CountDays(saturday, DateFrom, DateTo);

        

            var countHoliday = countFriday + countSaturday;

            var countHolidayOld = countFridayOld + countSaturdayOld;

            var dayOld = (int)(DateTo - DateFrom).TotalDays + 1;

            var days = (int)(dateTo - dateFrom).TotalDays + 1;

            if (VacationType.VacationEssential == VacationEssential.Year)
            {
                if (Employee.JobInfo.VacationBalance + dayOld - countHolidayOld < days)
                    throw new Exception("the days is more than Balance ...");
                
                //Employee.JobInfo.VacationBalance -= days - countHoliday - holidayCount;
                Place = place;
               
            }
            if (VacationType.VacationEssential == VacationEssential.alhaju )
            {
                if (Employee.JobInfo.VacationBalanceAlhaju  + dayOld - countHolidayOld < days)
                    throw new Exception("the days is more than Balance ...");

                //Employee.JobInfo.VacationBalance -= days - countHoliday - holidayCount;
                Place = place;

            }
            if (VacationType.VacationEssential == VacationEssential.marriage )
            {
                if (Employee.JobInfo.VacationBalanceMarriage  + dayOld - countHolidayOld < days)
                    throw new Exception("the days is more than Balance ...");

                //Employee.JobInfo.VacationBalance -= days - countHoliday - holidayCount;
                Place = place;

            }
            if (VacationType.VacationEssential == VacationEssential.Emergency )
            {
                if (Employee.JobInfo.VacationBalanceEmergency  + dayOld - countHolidayOld < days)
                    throw new Exception("the days is more than Balance ...");

                //Employee.JobInfo.VacationBalance -= days - countHoliday - holidayCount;
                Place = place;

            }
            //else
            //{
            //    days = days - VacationType.Days;

            //    if (days > 0)
            //        throw new Exception("the days is more than Vacation ...");
            //}
            if (VacationType.VacationEssential == VacationEssential.WithoutPay)
            {
                DecisionDate = decisionDate;
                DecisionNumber = decisionNumber;
                Place = place;
              
            }

            DateFrom = dateFrom;
            DateTo = dateTo;
            Note = note;
            VacationTypeId = vacationTypeId;
            CountKids = countkids;
            DeductionMonth = deductionMonth;
            DeductionYear = deductionYear;
            if (VacationTypeId != vacationTypeId)
                VacationType = null;


        }

        public void Modify2(DateTime dateFrom, DateTime dateTo, int vacationTypeId, bool place, string decisionNumber
           , DateTime decisionDate, int holidayCount, string note ,int countdaysvacation,int countkids,int deductionMonth, int deductionYear)
        {
            Check.MoreThanZero(vacationTypeId, nameof(vacationTypeId));
            if (dateTo < dateFrom)
                throw new Exception("date from less than date to ...");
            /////////////
            var friday = DayOfWeek.Friday;////////////////////
            var saturday = DayOfWeek.Saturday;////////////////////

            var countFriday = JobInfo.CountDays(friday, dateFrom, dateTo);
            var countSaturday = JobInfo.CountDays(saturday, dateFrom, dateTo);

            var countFridayOld = JobInfo.CountDays(friday, DateFrom, DateTo);
            var countSaturdayOld = JobInfo.CountDays(saturday, DateFrom, DateTo);



            var countHoliday = countFriday + countSaturday;

            var countHolidayOld = countFridayOld + countSaturdayOld;

            var dayOld = (int)(DateTo - DateFrom).TotalDays + 1;

            var days = (int)(dateTo - dateFrom).TotalDays + 1;

            //if (VacationType.VacationEssential == VacationEssential.Year)
            //{
            //    if (Employee.JobInfo.VacationBalance + dayOld - countHolidayOld < days)
            //        throw new Exception("the days is more than Balance ...");

            //    Employee.JobInfo.VacationBalance -= days - countHoliday - holidayCount;
            //    Place = place;

            //}
            if (VacationType.VacationEssential == VacationEssential.Year)
            {
                if (Employee.JobInfo.VacationBalance  + dayOld < countdaysvacation)
                    throw new Exception("the days is more than Balance ...");
                var dd = Employee.JobInfo.VacationBalance  + (dayOld - countHolidayOld);
                Employee.JobInfo.VacationBalance  = dd - countdaysvacation;
                //Employee.JobInfo.VacationBalanceEmergency  -= countdaysvacation;
                Place = place;


            }
            if (VacationType.VacationEssential == VacationEssential.Emergency )
            {
                if (Employee.JobInfo.VacationBalanceEmergency  + dayOld  < countdaysvacation)
                    throw new Exception("the days is more than Balance ...");
                var dd = Employee.JobInfo.VacationBalanceEmergency + (dayOld - countHolidayOld) ;
                Employee.JobInfo.VacationBalanceEmergency = dd - countdaysvacation;
                //Employee.JobInfo.VacationBalanceEmergency  -= countdaysvacation;
                Place = place;

            }
            if (VacationType.VacationEssential == VacationEssential.alhaju )
            {
                if (Employee.JobInfo.VacationBalanceAlhaju  + dayOld < countdaysvacation)
                    throw new Exception("the days is more than Balance ...");
                var dd = Employee.JobInfo.VacationBalanceAlhaju  + (dayOld - countHolidayOld);
                Employee.JobInfo.VacationBalanceAlhaju  = dd - countdaysvacation;
                //Employee.JobInfo.VacationBalanceEmergency  -= countdaysvacation;
                Place = place;

            }
            if (VacationType.VacationEssential == VacationEssential.marriage )
            {
                if (Employee.JobInfo.VacationBalanceMarriage  + dayOld < countdaysvacation)
                    throw new Exception("the days is more than Balance ...");
                var dd = Employee.JobInfo.VacationBalanceMarriage  + (dayOld - countHolidayOld);
                Employee.JobInfo.VacationBalanceMarriage  = dd - countdaysvacation;
                //Employee.JobInfo.VacationBalanceEmergency  -= countdaysvacation;
                Place = place;

            }
            if (VacationType.VacationEssential == VacationEssential.Sick )
            {
                if (Employee.JobInfo.VacationBalanceSickNew  + dayOld < countdaysvacation)
                    throw new Exception("the days is more than Balance ...");
                var dd = Employee.JobInfo.VacationBalanceSickNew + (dayOld - countHolidayOld);
                //Employee.JobInfo.VacationBalanceSick  = dd - countdaysvacation;
                //Employee.JobInfo.VacationBalanceEmergency  -= countdaysvacation;
                Place = place;

            }

            //else
            //{
            //    days = days - VacationType.Days;

            //    if (days > 0)
            //        throw new Exception("the days is more than Vacation ...");
            //}
            if (VacationType.VacationEssential == VacationEssential.WithoutPay)
            {
                DecisionDate = decisionDate;
                DecisionNumber = decisionNumber;
                Place = place;

            }

            DateFrom = dateFrom;
            DateTo = dateTo;
            Note = note;
            CountKids  = countkids;
            DeductionMonth = deductionMonth;
            DeductionYear = deductionYear;
            VacationTypeId = vacationTypeId;
            if (VacationTypeId != vacationTypeId)
                VacationType = null;


        }





        public void Modify(DateTime dateFrom, DateTime dateTo, VacationType vacationType, bool place
            , string decisionNumber, DateTime decisionDate, int holidayCount, int deductionMonth, int deductionYear)
        {
            Check.NotNull(vacationType, nameof(vacationType));
            if (dateFrom < dateTo)
                throw new Exception("date from less than date to ...");
            /////////////
            var friday = DayOfWeek.Friday;////////////////////
            var saturday = DayOfWeek.Saturday;////////////////////

            var countFriday = JobInfo.CountDays(friday, dateFrom, dateTo);
            var countSaturday = JobInfo.CountDays(saturday, dateFrom, dateTo);

            var countFridayOld = JobInfo.CountDays(friday, DateFrom, DateTo);
            var countSaturdayOld = JobInfo.CountDays(saturday, DateFrom, DateTo);

            var countHoliday = countFriday + countSaturday;

            var countHolidayOld = countFridayOld + countSaturdayOld;

            var dayOld = (int)(DateTo - DateFrom).TotalDays;

            var days = (int)(dateTo - dateFrom).TotalDays;

            if (VacationType.VacationEssential == VacationEssential.Year)
            {
                if (Employee.JobInfo.VacationBalance + dayOld - countHolidayOld < days)
                    throw new Exception("the days is more than Balance ...");

                Employee.JobInfo.VacationBalance -= days - countHoliday - holidayCount;
                Place = place;
            }
            //else
            //{
            //    days = days - VacationType.Days;

            //    if (days > 0)
            //        throw new Exception("the days is more than Vacation ...");
            //}
            if (VacationType.VacationEssential == VacationEssential.WithoutPay)
            {
                DecisionDate = decisionDate;
                DecisionNumber = decisionNumber;
                Place = place;
            }

            DateFrom = dateFrom;
            DateTo = dateTo;
            VacationTypeId = vacationType.VacationTypeId;
            VacationType = vacationType;
            DeductionMonth = deductionMonth;
            DeductionYear = deductionYear;
        }

        //internal static int CountDays(DayOfWeek day, DateTime start, DateTime end)
        //{
        //    var ts = end - start;                       // Total duration
        //    var count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
        //    var remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
        //    var sinceLastDay = end.DayOfWeek - day;   // Number of days since last [day]
        //    if (sinceLastDay < 0) sinceLastDay += 7;         // Adjust for negative days since last [day]

        //    // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
        //    if (remainder >= sinceLastDay) count++;

        //    return count;
        //}

        //internal void Day(int days, DateTime dateFrom, DateTime dateTo, DayOfWeek day = DayOfWeek.Friday)/////////////////////////
        //{
        //    var countFriday = CountDays(day, dateFrom, dateTo);

        //    var vacationType = new VacationType();

        //    if (vacationType.Days != 0 && !vacationType.VacationDiscount)
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