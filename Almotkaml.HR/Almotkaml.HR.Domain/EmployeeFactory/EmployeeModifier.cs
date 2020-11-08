using System;

namespace Almotkaml.HR.Domain.EmployeeFactory
{
    public class EmployeeModifier
    {
        internal EmployeeModifier(Employee employee)
        {
            Employee = employee;
        }
        private Employee Employee { get; }
        public EmployeeModifier FirstName(string firstName, string englishFirstName)
        {
            Check.NotEmpty(firstName, nameof(firstName));
            Employee.FirstName = firstName;
            Employee.EnglishFirstName = englishFirstName;

            return this;
        }

        public EmployeeModifier FatherName(string fatherName, string englishFatherName)
        {
            Employee.FatherName = fatherName;
            Employee.EnglishFatherName = englishFatherName;

            return this;
        }

        public EmployeeModifier GrandfatherName(string grandfatherName, string englishGrandfatherName)
        {
            Employee.GrandfatherName = grandfatherName;
            Employee.EnglishGrandfatherName = englishGrandfatherName;

            return this;
        }

        public EmployeeModifier LastName(string lastName, string englishLastName)
        {
            Employee.LastName = lastName;
            Employee.EnglishLastName = englishLastName;

            return this;
        }

        public EmployeeModifier MotherName(string motherName)
        {
            Employee.MotherName = motherName;

            return this;
        }

        public EmployeeModifier Gender(Gender gender)
        {
            Employee.Gender = gender;

            return this;
        }

        public EmployeeModifier BirthDate(DateTime birthDate)
        {
            Employee.BirthDate = birthDate;

            return this;
        }

        public EmployeeModifier BirthPlace(string birthPlace)
        {
            Employee.BirthPlace = birthPlace;
            return this;
        }

        public EmployeeModifier NationalNumber(string nationalNumber)
        {
            Employee.NationalNumber = nationalNumber;
            return this;
        }

        public EmployeeModifier Religion(Religion religion)
        {
            Employee.Religion = religion;
            return this;
        }

        public EmployeeModifier Nationality(int? nationalityId)
        {
            if (nationalityId == 0)
                nationalityId = null;

            Employee.NationalityId = nationalityId;
            Employee.Nationality = null;
            return this;
        }

        public EmployeeModifier Nationality(Nationality nationality)
        {
            Check.NotNull(nationality, nameof(nationality));
            Employee.NationalityId = nationality.NationalityId;
            Employee.Nationality = nationality;
            return this;
        }
        public EmployeeModifier WifeNationalityId(int? wifeNationalityId)
        {
            if (wifeNationalityId == 0)
                wifeNationalityId = null;

            Employee.WifeNationalityId = wifeNationalityId;
            //Employee.Nationality = null;
            return this;
        }

        public EmployeeModifier WifeNationality(Nationality wifeNationality)
        {
            Check.NotNull(wifeNationality, nameof(wifeNationality));
            Employee.WifeNationalityId = wifeNationality.NationalityId;
            Employee.WifeNationality = wifeNationality;
            return this;
        }

        public EmployeeModifier Place(int? placeId)
        {
            if (placeId == 0)
                placeId = null;

            Employee.PlaceId = placeId;
            return this;
        }

        public EmployeeModifier Place(Place place)
        {
            Employee.PlaceId = place.PlaceId;
            Employee.Place = place;
            return this;
        }

        public EmployeeModifier Address(string address)
        {
            Employee.Address = address;
            return this;
        }

        public EmployeeModifier Phone(string phone)
        {
            Employee.Phone = phone;
            return this;
        }

        public EmployeeModifier Email(string email)
        {
            Employee.Email = email;
            return this;
        }

        public EmployeeModifier SocialStatus(SocialStatus socialStatus)
        {
            Employee.SocialStatus = socialStatus;
            return this;
        }

        public EmployeeModifier ChildernCount(int? childernCount)
        {
            if (childernCount == 0)
                childernCount = null;

            Employee.ChildernCount = childernCount;
            return this;
        }

        public EmployeeModifier BloodType(BloodType bloodType)
        {
            Employee.BloodType = bloodType;
            return this;
        }

        public EmployeeModifier IsActive(bool IsActive)
        {
            Employee.IsActive = IsActive;
            return this;
        }
        public EmployeeModifier Booklet(Booklet booklet)
        {
            Check.NotNull(booklet, nameof(booklet));
            Employee.Booklet = booklet;
            return this;
        }

        public EmployeeModifier Passport(Passport passport)
        {
            Check.NotNull(passport, nameof(passport));
            Employee.Passport = passport;
            return this;
        }

        public EmployeeModifier IdentificationCard(IdentificationCard identificationCard)
        {
            Check.NotNull(identificationCard, nameof(identificationCard));
            Employee.IdentificationCard = identificationCard;
            return this;

        }
        public EmployeeModifier WithImage(byte[] image)
        {
            Employee.Image = image;
            return this;
        }
        public EmployeeModifier ContactInfo(ContactInfo contactInfo)
        {
            Check.NotNull(contactInfo, nameof(contactInfo));
            Employee.ContactInfo = contactInfo;
            return this;
        }

        public Employee Confirm()
        {
            return Employee;
        }
    }
}