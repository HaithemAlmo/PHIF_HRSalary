using System;

namespace Almotkaml.HR.Domain.MilitaryDataFactory
{
    public class MilitaryDataModifier
    {
        internal MilitaryDataModifier(MilitaryData militaryData)
        {
            MilitaryData = militaryData;
        }
        private MilitaryData MilitaryData { get; }
        //public MilitaryDataModifier Employee(int employeeId)
        //{
        //    Check.MoreThanZero(employeeId, nameof(employeeId));
        //    MilitaryData.EmployeeId = employeeId;
        //    return this;
        //}

        //public MilitaryDataModifier Employee(Employee employee)
        //{
        //    Check.NotNull(employee, nameof(employee));
        //    MilitaryData.EmployeeId = employee.EmployeeId;
        //    MilitaryData.Employee = employee;
        //    return this;
        //}

        public MilitaryDataModifier AdjectiveMilitary(AdjectiveMilitary adjectiveMilitary)
        {
            MilitaryData.AdjectiveMilitary = adjectiveMilitary;
            return this;
        }

        public MilitaryDataModifier MilitaryNumber(string militaryNumber)
        {
            MilitaryData.MilitaryNumber = militaryNumber;
            return this;
        }

        public MilitaryDataModifier Subunit(string subunit)
        {
            MilitaryData.Subunit = subunit;
            return this;
        }

        public MilitaryDataModifier Rank(string rank)
        {
            MilitaryData.Rank = rank;
            return this;
        }

        public MilitaryDataModifier GranduationDate(DateTime? granduationDate)
        {
            MilitaryData.GranduationDate = granduationDate;
            return this;
        }

        public MilitaryDataModifier MotherUnit(string motherUnit)
        {
            MilitaryData.MotherUnit = motherUnit;
            return this;
        }

        public MilitaryDataModifier College(string college)
        {
            MilitaryData.College = college;
            return this;
        }

        public MilitaryData Confirm()
        {
            return MilitaryData;
        }

    }
}