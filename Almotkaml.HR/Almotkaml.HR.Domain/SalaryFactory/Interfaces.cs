using System;

namespace Almotkaml.HR.Domain.SalaryFactory
{
    public interface IMonthDateHolder
    {
        IEmployeeHolder WithMonthDate(DateTime monthDate);
    }
    public interface IEmployeeHolder
    {
        IJobNumberHolder WithEmployee(Employee employee);
        IJobNumberHolder WithEmployee(int employeeId);
    }
    public interface IJobNumberHolder
    {
        IAbsenceDaysHolder WithJobNumber(string jobNumber);
    }
    public interface IAbsenceDaysHolder
    {
        IExtraValueHolder WithAbsenceDays(int absenceDays);
    }
    public interface IExtraValueHolder
    {
        IExtraGeneralValueHolder WithExtraValue(decimal extraValue);
    }
    public interface IExtraGeneralValueHolder
    {
        IBankBranchHolder WithExtraGeneralValue(decimal extraGeneralValue);
    }
    public interface IBankBranchHolder
    {
        IBondNumberHolder WithBankBranch(BankBranch bankBranch);
        IBondNumberHolder WithBankBranch(int bankBranchId);
    }
    public interface IBondNumberHolder
    {
        IFileNumberHolder WithBondNumber(string bondNumber);
    }
    public interface IFileNumberHolder
    {
        IBasicSalaryHolder WithFileNumber(string fileNumber);
    }
    public interface IBasicSalaryHolder
    {
        IAdvancePremiumInsideHolder WithBasicSalary(decimal basicSalary);
    }
    public interface IAdvancePremiumInsideHolder
    {
        IAdvancePremiumOutsideHolder WithAdvancePremiumInside(decimal advancePremiumInside);
    }
    public interface IAdvancePremiumOutsideHolder
    {
        ISanctionHolder WithAdvancePremiumOutside(decimal advancePremiumOutside);
    }
    public interface ISanctionHolder
    {
        IAccumulatedValueHolder WithSanction(decimal sanction);
    }
    //--****////
    public interface   IAccumulatedValueHolder
    {
        IRewindValueHolder WithAccumulatedValue(decimal AccumulatedValue);
    }
    public interface  IRewindValueHolder
    {
        ISalaryPremiumHolder WithRewindValue(decimal RewindValue);
    }

    public interface ISalaryPremiumHolder
    {
        IBuild WithSalaryPremium(Employee employee);
    }
    public interface ISalaryCheck
    {
        IBuild WithSalaryPremium(Employee employee);
    }
    public interface ISalaryTotal
    {
        IBuild WithSalaryPremium(Employee employee);
    }


    public interface IBuild
    {
        Salary Biuld();
    }
}