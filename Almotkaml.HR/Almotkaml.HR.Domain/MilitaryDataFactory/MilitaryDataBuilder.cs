using System;

namespace Almotkaml.HR.Domain.MilitaryDataFactory
{
    public class MilitaryDataBuilder : IAdjectiveMilitaryHolder, IMilitaryNumberHolder
        , ISubunitHolder, IRankHolder, IGranduationDateHolder, IMotherUnitHolder, ICollegeHolder, IBuild
    {

        internal MilitaryDataBuilder() { }
        private MilitaryData MilitaryData { get; } = new MilitaryData();

        //public IAdjectiveMilitaryHolder WithEmployeeId(int employeeId)
        //{
        //    Check.MoreThanZero(employeeId, nameof(employeeId));
        //    MilitaryData.EmployeeId = employeeId;
        //    return this;
        //}

        //public IAdjectiveMilitaryHolder WithEmployee(Employee employee)
        //{
        //    Check.NotNull(employee, nameof(employee));
        //    MilitaryData.EmployeeId = employee.EmployeeId;
        //    MilitaryData.Employee = employee;
        //    return this;
        //}

        public IMilitaryNumberHolder WithAdjectiveMilitary(AdjectiveMilitary adjectiveMilitary)
        {
            MilitaryData.AdjectiveMilitary = adjectiveMilitary;
            return this;
        }

        public ISubunitHolder WithMilitaryNumber(string militaryNumber)
        {
            MilitaryData.MilitaryNumber = militaryNumber;
            return this;
        }

        public IRankHolder WithSubunit(string subunit)
        {
            MilitaryData.Subunit = subunit;
            return this;
        }

        public IGranduationDateHolder WithRank(string rank)
        {
            return this;
        }

        public IMotherUnitHolder WithGranduationDate(DateTime? granduationDate)
        {
            MilitaryData.GranduationDate = granduationDate;
            return this;
        }

        public ICollegeHolder WithMotherUnit(string motherUnit)
        {
            MilitaryData.MotherUnit = motherUnit;
            return this;
        }

        public IBuild WithCollege(string college)
        {
            MilitaryData.College = college;
            return this;
        }
        public MilitaryData Biuld()
        {
            return MilitaryData;
        }

    }

}