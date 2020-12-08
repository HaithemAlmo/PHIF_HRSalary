using System;

namespace Almotkaml.HR.Domain
{
    public interface IEntrantsAndReviewersIdHolder
    {
        IMonthWorkHolder WithEntrantsAndReviewersId(int entrantsAndReviewersId);
       // IMonthWorkHolder WithEntrantsAndReviewersId(EntrantsAndReviewers  entrantsAndReviewersId);
    }
    public interface IMonthWorkHolder
    {
        IYearWorkHolder WithMonthWork(int monthWork);
    }
    public interface IYearWorkHolder
    {
        IDataEntryCountHolder WithYearWork(int yearWork);
    }
    public interface IDataEntryCountHolder
    {
        IDataEntryBalanceHolder WithDataEntryCount(int dataEntryCount);
    }
    public interface IDataEntryBalanceHolder
    {
        IFirstReviewCountHolder WithDataEntryBalance(decimal  dataEntryBalance);
    }
    public interface IFirstReviewCountHolder
    {
        IFirstReviewBalanceHolder WithFirstReviewCount(int firstReviewCount);
    }
    public interface IFirstReviewBalanceHolder
    {
        IAccommodationReviewCountHolder WithFirstReviewBalance(decimal firstReviewBalance);
    }
    public interface IAccommodationReviewCountHolder
    {
        IAccommodationReviewBalanceHolder WithAccommodationReviewCount(int accommodationReviewCount);
    }
    public interface IAccommodationReviewBalanceHolder
    {
        IClincReviewCountHolder WithAccommodationReviewBalance(decimal accommodationReviewBalance);
    }
    public interface IClincReviewCountHolder
    {
        IClincReviewBalanceHolder WithClincReviewCount(int clincReviewCount);
    }
    public interface IClincReviewBalanceHolder
    {
        ITotalBalanceHolder WithClincReviewBalance(decimal clincReviewBalance);
    }
    public interface ITotalBalanceHolder
    {
        INoteHolder WithTotalBalance(decimal totalBalance);
    }
    public interface INoteHolder
    {
        IIsPaidHolder WithNote(string note);
    }
    public interface IIsPaidHolder
    {
        IBuild WithIsPaid(bool  IsPaid);
    }


    public interface IBuild
    {
        TechnicalAffairsDepartment Biuld();
    }
}