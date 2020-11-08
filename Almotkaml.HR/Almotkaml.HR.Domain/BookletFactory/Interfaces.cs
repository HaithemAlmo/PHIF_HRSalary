using System;

namespace Almotkaml.HR.Domain.BookletFactory
{
    public interface INumberHolder
    {
        IFamilyNumberHolder WithNumber(string number);
    }
    public interface IFamilyNumberHolder
    {
        IRegistrationNumberHolder WithFamilyNumber(string familyNumber);
    }
    public interface IRegistrationNumberHolder
    {
        IIssueDateHolder WithRegistrationNumber(string registrationNumber);
    }
    public interface IIssueDateHolder
    {
        IIssuePlaceHolder WithIssueDate(DateTime? issueDate);
    }
    public interface IIssuePlaceHolder
    {
        ICivilRegistryHolder WithIssuePlace(string issuePlace);
    }
    public interface ICivilRegistryHolder
    {
        IBuild WithCivilRegistry(string civilRegistry);
    }

    public interface IBuild
    {
        Booklet Biuld();
    }
}