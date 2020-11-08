using System;

namespace Almotkaml.HR.Domain.AbsenceFactory
{
    public class AbsenceBuilder : IAbsenceTypeHolder, IDateHolder, IDeductionMonthHolder, IDeductionYearHolder
        , INoteHolder, IDayHolder, IEmployeeIdHolder, IBuild
    {

        internal AbsenceBuilder() { }
        private Absence Absence { get; } = new Absence();


        public IDateHolder WithAbsenceType(AbsenceType absenceType)
        {
            Absence.AbsenceType = absenceType;
            return this;
        }


        public IDeductionMonthHolder WithDate(DateTime date)
        {
            Absence.Date = date;
            return this;
        }

        public IDeductionYearHolder WithDeductionMonth(int deductionMonth)
        {
            Absence.DeductionMonth = deductionMonth;
            return this;
        }


        public INoteHolder WithDeductionYear(int deductionYear)
        {
            Absence.DeductionYear = deductionYear;
            return this;
        }

        public IDayHolder WithNote(string note)
        {
            Absence.Note = note;
            return this;
        }

        public IBuild WithEmployeeId(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            Absence.EmployeeId = employeeId;
            return this;
        }

        public IBuild WithEmployee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            Absence.EmployeeId = employee.EmployeeId;
            Absence.Employee = employee;
            return this;
        }

        public Absence Biuld()
        {
            return Absence;
        }

        public IEmployeeIdHolder WithDay(int Day)
        {
            Check.MoreThanZero(Day, nameof(Day));

            Absence.AbsenceDay = Day;
            return this;

        }
    }

}