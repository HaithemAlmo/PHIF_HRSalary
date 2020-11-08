using System;

namespace Almotkaml.HR.Domain.RewardFactory
{
    public interface IDateHolder
    {
        IEfficiencyEstimateHolder WithDate(DateTime date);
    }
    public interface IEfficiencyEstimateHolder
    {
        IValueHolder WithEfficiencyEstimate(string efficiencyEstimate);
    }
    public interface IValueHolder
    {
        IRewardTypeIdHolder WithValue(string value);
    }
    public interface IRewardTypeIdHolder
    {
        INoteHolder WithRewardTypeId(int rewardTypeId);
        INoteHolder WithRewardType(RewardType rewardType);
    }

    public interface INoteHolder
    {
        IEmployeeIdHolder WithNote(string note);
    }
    public interface IEmployeeIdHolder
    {
        IBuild WithEmployeeId(int employeeId);
        IBuild WithEmployee(Employee employee);
    }

    public interface IBuild
    {
        Reward Biuld();
    }
}