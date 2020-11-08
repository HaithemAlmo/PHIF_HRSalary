using System;

namespace Almotkaml.HR.Domain.AbsenceFactory
{
    public class AbsenceModifier
    {
        internal AbsenceModifier(Absence absence)
        {
            Absence = absence;
        }
        private Absence Absence { get; }
        public AbsenceModifier AbsenceType(AbsenceType absenceType)
        {
            Absence.AbsenceType = absenceType;
            return this;
        }

        public AbsenceModifier Date(DateTime date)
        {
            Absence.Date = date;
            return this;
        }

        public AbsenceModifier DeductionMonth(int deductionMonth)
        {
            Absence.DeductionMonth = deductionMonth;
            return this;
        }

        public AbsenceModifier DeductionYear(int deductionYear)
        {
            Absence.DeductionYear = deductionYear;
            return this;
        }

        public AbsenceModifier Note(string note)
        {
            Absence.Note = note;
            return this;
        }
        public AbsenceModifier Days(int day)
        {
            Absence.AbsenceDay = day;
            return this;
        }
        //public AbsenceModifier EmployeeId(int employeeId)
        //{
        //    Check.MoreThanZero(employeeId, nameof(employeeId));
        //    Absence.EmployeeId = employeeId;
        //    return this;
        //}

        //public AbsenceModifier Employee(Employee employee)
        //{
        //    Check.NotNull(employee, nameof(employee));
        //    Absence.EmployeeId = employee.EmployeeId;
        //    Absence.Employee = employee;
        //    return this;
        //}
        public Absence Confirm()
        {
            return Absence;
        }
    }


}