using System;

namespace Almotkaml.HR.Domain.EmployeeFactory
{
    public class EmployeeBuilder : IFirstNameHolder, IFatherNameHolder, IGrandfatherNameHolder, ILastNameHolder,
        IMotherNameHolder, IGenderHolder, IBirthDateHolder, IBirthPlaceHolder, INationalNumberHolder, IReligionHolder,
        INationalityHolder, IWifeNationalityHolder, IPlaceHolder, IAddressHolder, IPhoneHolder, IEmailHolder,
        ISocialStatusHolder, IChildernCountHolder, IBloodTypeHolder, IIsActiveHolder,IBookletHolder, IPassportHolder
        , IIdentificationCardHolder, IImagePathHolder, IContactInfoHolder, IBuild
    {

        internal EmployeeBuilder() { }
        private Employee Employee { get; } = new Employee();

        public IFatherNameHolder WithFirstName(string firstName, string englishFirstName)
        {
            Check.NotEmpty(firstName, nameof(firstName));
            Employee.FirstName = firstName;
            Employee.EnglishFirstName = englishFirstName;

            return this;
        }

        public IGrandfatherNameHolder WithFatherName(string fatherName, string englishFatherName)
        {
            Employee.FatherName = fatherName;
            Employee.EnglishFatherName = englishFatherName;

            return this;
        }

        public ILastNameHolder WithGrandfatherName(string grandfatherName, string englishGrandfatherName)
        {
            Employee.GrandfatherName = grandfatherName;
            Employee.EnglishGrandfatherName = englishGrandfatherName;

            return this;
        }

        public IMotherNameHolder WithLastName(string lastName, string englishLastName)
        {
            Employee.LastName = lastName;
            Employee.EnglishLastName = englishLastName;

            return this;
        }

        public IGenderHolder WithMotherName(string motherName)
        {
            Employee.MotherName = motherName;

            return this;
        }

        public IBirthDateHolder WithGender(Gender gender)
        {
            Employee.Gender = gender;

            return this;
        }

        public IBirthPlaceHolder WithBirthDate(DateTime birthDate)
        {
            Employee.BirthDate = birthDate;

            return this;
        }

        public INationalNumberHolder WithBirthPlace(string birthPlace)
        {
            Employee.BirthPlace = birthPlace;
            return this;
        }

        public IReligionHolder WithNationalNumber(string nationalNumber)
        {
            Employee.NationalNumber = nationalNumber;
            return this;
        }

        public INationalityHolder WithReligion(Religion religion)
        {
            Employee.Religion = religion;
            return this;
        }

        public IWifeNationalityHolder WithNationalityId(int? nationalityId)
        {
            if (nationalityId == 0)
                nationalityId = null;

            Employee.NationalityId = nationalityId;
            //Employee.Nationality = null;
            return this;
        }

        public IWifeNationalityHolder WithNationality(Nationality nationality)
        {
            Check.NotNull(nationality, nameof(nationality));
            Employee.NationalityId = nationality.NationalityId;
            Employee.Nationality = nationality;
            return this;
        }
        public IPlaceHolder WithWifeNationalityId(int? wifeNationalityId)
        {
            if (wifeNationalityId == 0)
                wifeNationalityId = null;

            Employee.WifeNationalityId = wifeNationalityId;
            //Employee.Nationality = null;
            return this;
        }

        public IPlaceHolder WithWifeNationality(Nationality wifeNationality)
        {
            Check.NotNull(wifeNationality, nameof(wifeNationality));
            Employee.WifeNationalityId = wifeNationality.NationalityId;
            Employee.WifeNationality = wifeNationality;
            return this;
        }

        public IAddressHolder WithPlaceId(int? placeId)
        {
            if (placeId == 0)
                placeId = null;

            Employee.PlaceId = placeId;
            return this;
        }

        public IAddressHolder WithPlace(Place place)
        {
            Employee.PlaceId = place.PlaceId;
            Employee.Place = place;
            return this;
        }

        public IPhoneHolder WithAddress(string address)
        {
            Employee.Address = address;
            return this;
        }

        public IEmailHolder WithPhone(string phone)
        {
            Employee.Phone = phone;
            return this;
        }

        public ISocialStatusHolder WithEmail(string email)
        {
            Employee.Email = email;
            return this;
        }

        public IChildernCountHolder WithSocialStatus(SocialStatus socialStatus)
        {
            Employee.SocialStatus = socialStatus;
            return this;
        }

        public IBloodTypeHolder WithChildernCount(int? childernCount)
        {
            if (childernCount == 0)
                childernCount = null;

            Employee.ChildernCount = childernCount;
            return this;
        }

        public IIsActiveHolder WithBloodType(BloodType bloodType)
        {
            Employee.BloodType = bloodType;
            return this;
        }

        public IBookletHolder WithIsActive(bool IsActive)
        {
            Employee.IsActive = IsActive;
            return this;
        }

        public IPassportHolder WithBooklet(Booklet booklet)
        {
            Check.NotNull(booklet, nameof(booklet));
            Employee.Booklet = booklet;
            return this;
        }

        public IIdentificationCardHolder WithPassport(Passport passport)
        {
            Check.NotNull(passport, nameof(passport));
            Employee.Passport = passport;
            return this;
        }

        public IImagePathHolder WithIdentificationCard(IdentificationCard identificationCard)
        {
            Check.NotNull(identificationCard, nameof(identificationCard));
            Employee.IdentificationCard = identificationCard;
            return this;

        }
        public IContactInfoHolder WithImage(byte[] image)
        {
            Employee.Image = image;
            return this;
        }

        public IBuild WithContactInfo(ContactInfo contactInfo)
        {
            Check.NotNull(contactInfo, nameof(contactInfo));
            Employee.ContactInfo = contactInfo;
            return this;
        }

        public Employee Biuld()
        {
            Employee.IsActive = true;
            return Employee;
        }

    }

}