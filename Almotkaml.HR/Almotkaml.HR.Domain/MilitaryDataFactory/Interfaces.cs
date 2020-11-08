using System;

namespace Almotkaml.HR.Domain.MilitaryDataFactory
{
    //public interface IEmployeeIdHolder
    //{
    //    IAdjectiveMilitaryHolder WithEmployeeId(int employeeId);
    //    IAdjectiveMilitaryHolder WithEmployee(Employee employee);
    //}
    public interface IAdjectiveMilitaryHolder
    {
        IMilitaryNumberHolder WithAdjectiveMilitary(AdjectiveMilitary adjectiveMilitary);
    }
    public interface IMilitaryNumberHolder
    {
        ISubunitHolder WithMilitaryNumber(string militaryNumber);
    }
    public interface ISubunitHolder
    {
        IRankHolder WithSubunit(string subunit);
    }
    public interface IRankHolder
    {
        IGranduationDateHolder WithRank(string rank);
    }
    public interface IGranduationDateHolder
    {
        IMotherUnitHolder WithGranduationDate(DateTime? granduationDate);
    }
    public interface IMotherUnitHolder
    {
        ICollegeHolder WithMotherUnit(string motherUnit);
    }
    public interface ICollegeHolder
    {
        IBuild WithCollege(string college);
    }
    public interface IBuild
    {
        MilitaryData Biuld();
    }
}