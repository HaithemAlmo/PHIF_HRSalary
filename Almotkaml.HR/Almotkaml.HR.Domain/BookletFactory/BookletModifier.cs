using System;

namespace Almotkaml.HR.Domain.BookletFactory
{
    public class BookletModifier
    {
        internal BookletModifier(Booklet booklet)
        {
            Booklet = booklet;
        }
        private Booklet Booklet { get; }
        public BookletModifier WithNumber(string number)
        {
            Booklet.Number = number;
            return this;
        }

        public BookletModifier WithFamilyNumber(string familyNumber)
        {
            Booklet.FamilyNumber = familyNumber;
            return this;
        }

        public BookletModifier WithRegistrationNumber(string registrationNumber)
        {
            Booklet.RegistrationNumber = registrationNumber;
            return this;
        }

        public BookletModifier WithIssueDate(DateTime? issueDate)
        {
            Booklet.IssueDate = issueDate;
            return this;
        }

        public BookletModifier WithIssuePlace(string issuePlace)
        {
            Booklet.IssuePlace = issuePlace;
            return this;
        }

        public BookletModifier WithCivilRegistry(string civilRegistry)
        {
            Booklet.CivilRegistry = civilRegistry;
            return this;
        }
        public Booklet Confirm()
        {
            return Booklet;
        }
    }
}