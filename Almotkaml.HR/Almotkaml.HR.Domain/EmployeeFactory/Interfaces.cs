using System;

namespace Almotkaml.HR.Domain.EmployeeFactory
{
    public interface IFirstNameHolder
    {
        IFatherNameHolder WithFirstName(string firstName, string englishFirstName);
    }

    public interface IFatherNameHolder
    {
        IGrandfatherNameHolder WithFatherName(string fatherName, string englishFatherName);
    }

    public interface IGrandfatherNameHolder
    {
        ILastNameHolder WithGrandfatherName(string grandfatherName, string englishGrandfatherName);
    }

    public interface ILastNameHolder
    {
        IMotherNameHolder WithLastName(string lastName, string englishLastName);
    }

    public interface IMotherNameHolder
    {
        IGenderHolder WithMotherName(string motherName);
    }

    public interface IGenderHolder
    {
        IBirthDateHolder WithGender(Gender gender);
    }

    public interface IBirthDateHolder
    {
        IBirthPlaceHolder WithBirthDate(DateTime birthDate);
    }

    public interface IBirthPlaceHolder
    {
        INationalNumberHolder WithBirthPlace(string birthPlace);
    }

    public interface INationalNumberHolder
    {
        IReligionHolder WithNationalNumber(string nationalNumber);
    }

    public interface IReligionHolder
    {
        INationalityHolder WithReligion(Religion religion);
    }

    public interface INationalityHolder
    {
        IWifeNationalityHolder WithNationalityId(int? nationalityId);
        IWifeNationalityHolder WithNationality(Nationality nationality);
    }
    public interface IWifeNationalityHolder
    {
        IPlaceHolder WithWifeNationalityId(int? wifeNationalityId);
        IPlaceHolder WithWifeNationality(Nationality wifeNationality);
    }

    public interface IPlaceHolder
    {
        IAddressHolder WithPlaceId(int? placeId);
        IAddressHolder WithPlace(Place place);
    }

    public interface IAddressHolder
    {
        IPhoneHolder WithAddress(string address);
    }

    public interface IPhoneHolder
    {
        IEmailHolder WithPhone(string phone);
    }

    public interface IEmailHolder
    {
        ISocialStatusHolder WithEmail(string email);
    }

    public interface ISocialStatusHolder
    {
        IChildernCountHolder WithSocialStatus(SocialStatus socialStatus);
    }

    public interface IChildernCountHolder
    {
        IBloodTypeHolder WithChildernCount(int? childernCount);
    }

    public interface IBloodTypeHolder
    {
        IIsActiveHolder WithBloodType(BloodType bloodType);
    }

    public interface IIsActiveHolder
    {
        IBookletHolder WithIsActive(bool isActive);
    }

    public interface IBookletHolder
    {
        IPassportHolder WithBooklet(Booklet booklet);
    }

    public interface IPassportHolder
    {
        IIdentificationCardHolder WithPassport(Passport passport);
    }

    public interface IIdentificationCardHolder
    {
        IImagePathHolder WithIdentificationCard(IdentificationCard identificationCard);
    }
    public interface IImagePathHolder
    {
        IContactInfoHolder WithImage(byte[] image);
    }
    public interface IContactInfoHolder
    {
        IBuild WithContactInfo(ContactInfo contactInfo);
    }

    public interface IBuild
    {
        Employee Biuld();
    }
}