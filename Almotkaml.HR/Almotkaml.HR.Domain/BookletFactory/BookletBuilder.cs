using System;

namespace Almotkaml.HR.Domain.BookletFactory
{
    public class BookletBuilder : INumberHolder, IFamilyNumberHolder, IRegistrationNumberHolder, IIssueDateHolder, IIssuePlaceHolder, ICivilRegistryHolder, IBuild
    {

        internal BookletBuilder() { }
        private Booklet Booklet { get; } = new Booklet();

        public IFamilyNumberHolder WithNumber(string number)
        {
            Booklet.Number = number;
            return this;
        }

        public IRegistrationNumberHolder WithFamilyNumber(string familyNumber)
        {
            Booklet.FamilyNumber = familyNumber;
            return this;
        }

        public IIssueDateHolder WithRegistrationNumber(string registrationNumber)
        {
            Booklet.RegistrationNumber = registrationNumber;
            return this;
        }

        public IIssuePlaceHolder WithIssueDate(DateTime? issueDate)
        {
            Booklet.IssueDate = issueDate;
            return this;
        }

        public ICivilRegistryHolder WithIssuePlace(string issuePlace)
        {
            Booklet.IssuePlace = issuePlace;
            return this;
        }

        public IBuild WithCivilRegistry(string civilRegistry)
        {
            Booklet.CivilRegistry = civilRegistry;
            return this;
        }
        public Booklet Biuld()
        {
            return Booklet;
        }
    }

}