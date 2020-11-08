using System;

namespace Almotkaml.HR.Domain.QualificationFactory
{
    public interface IEmployeeIdHolder
    {
        IQualificationTypeIdHolder WithEmployeeId(int employeeId);
        IQualificationTypeIdHolder WithEmployee(Employee employee);
    }
    public interface IQualificationTypeIdHolder
    {
        IDateHolder WithQualificationTypeId(int qualificationTypeId);
        IDateHolder WithQualificationType(QualificationType qualificationType);
    }

    public interface IDateHolder
    {
        IGraduationCountryHolder WithDate(DateTime date);
    }
    public interface IGraduationCountryHolder
    {
        INameDonorFoundationHolder WithGraduationCountry(string graduationCountry);
    }
    public interface INameDonorFoundationHolder
    {
        IExactSpecialtyIdHolder WithNameDonorFoundation(string nameDonorFoundation);
    }
    public interface IExactSpecialtyIdHolder
    {
        IAquiredSpecialtyHolder WithSpecialtyId(int? specialtyId);
        IAquiredSpecialtyHolder WithSpecialty(Specialty specialty);
        IAquiredSpecialtyHolder WithSubSpecialtyId(int? subSpecialtyId);
        IAquiredSpecialtyHolder WithSubSpecialty(SubSpecialty subSpecialty);
        IAquiredSpecialtyHolder WithExactSpecialtyId(int? exactSpecialtyId);
        IAquiredSpecialtyHolder WithExactSpecialty(ExactSpecialty exactSpecialty);
    }
    public interface IAquiredSpecialtyHolder
    {
        IDonorFoundationTypeHolder WithAquiredSpecialty(string aquiredSpecialty);
    }
    public interface IDonorFoundationTypeHolder
    {
        IGradeHolder WithDonorFoundationType(DonorFoundationType donorFoundationType);
    }
    public interface IGradeHolder
    {
        IBuild WithGrade(Grade grade);
    }

    public interface IBuild
    {
        Qualification Biuld();
    }
}