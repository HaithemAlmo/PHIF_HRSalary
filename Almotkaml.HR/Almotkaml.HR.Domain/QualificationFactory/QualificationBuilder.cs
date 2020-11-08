using System;

namespace Almotkaml.HR.Domain.QualificationFactory
{
    public class QualificationBuilder : IEmployeeIdHolder, IQualificationTypeIdHolder, IDateHolder
        , IGraduationCountryHolder, INameDonorFoundationHolder, IExactSpecialtyIdHolder,
        IAquiredSpecialtyHolder, IDonorFoundationTypeHolder, IGradeHolder, IBuild
    {

        internal QualificationBuilder() { }
        private Qualification Qualification { get; } = new Qualification();

        public IQualificationTypeIdHolder WithEmployeeId(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            Qualification.EmployeeId = employeeId;
            return this;
        }

        public IQualificationTypeIdHolder WithEmployee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            Qualification.EmployeeId = employee.EmployeeId;
            Qualification.Employee = employee;
            return this;
        }

        public IDateHolder WithQualificationTypeId(int qualificationTypeId)
        {
            Check.MoreThanZero(qualificationTypeId, nameof(qualificationTypeId));
            Qualification.QualificationTypeId = qualificationTypeId;
            return this;
        }

        public IDateHolder WithQualificationType(QualificationType qualificationType)
        {
            Check.NotNull(qualificationType, nameof(qualificationType));
            Qualification.QualificationTypeId = qualificationType.QualificationTypeId;
            Qualification.QualificationType = qualificationType;
            return this;
        }

        public IGraduationCountryHolder WithDate(DateTime date)
        {
            Check.IsValidDate(date, nameof(date));
            Qualification.Date = date;
            return this;
        }

        public INameDonorFoundationHolder WithGraduationCountry(string graduationCountry)
        {
            Qualification.GraduationCountry = graduationCountry;
            return this;
        }

        public IExactSpecialtyIdHolder WithNameDonorFoundation(string nameDonorFoundation)
        {
            Qualification.NameDonorFoundation = nameDonorFoundation;
            return this;
        }

        public IAquiredSpecialtyHolder WithSpecialtyId(int? specialtyId)
        {
            Qualification.SpecialtyId = specialtyId;
            return this;
        }

        public IAquiredSpecialtyHolder WithSpecialty(Specialty specialty)
        {
            Qualification.Specialty = specialty;
            Qualification.SpecialtyId = specialty?.SpecialtyId;
            return this;
        }

        public IAquiredSpecialtyHolder WithSubSpecialtyId(int? subSpecialtyId)
        {
            Qualification.SubSpecialtyId = subSpecialtyId;
            return this;
        }

        public IAquiredSpecialtyHolder WithSubSpecialty(SubSpecialty subSpecialty)
        {
            Qualification.SubSpecialty = subSpecialty;
            Qualification.SubSpecialtyId = subSpecialty?.SubSpecialtyId;
            return this;
        }

        public IAquiredSpecialtyHolder WithExactSpecialtyId(int? exactSpecialtyId)
        {
            Qualification.ExactSpecialtyId = exactSpecialtyId;
            return this;
        }

        public IAquiredSpecialtyHolder WithExactSpecialty(ExactSpecialty exactSpecialty)
        {
            Qualification.ExactSpecialtyId = exactSpecialty?.ExactSpecialtyId;
            Qualification.ExactSpecialty = exactSpecialty;
            return this;
        }
        public IDonorFoundationTypeHolder WithAquiredSpecialty(string aquiredSpecialty)
        {
            Qualification.AquiredSpecialty = aquiredSpecialty;
            return this;
        }
        public IGradeHolder WithDonorFoundationType(DonorFoundationType donorFoundationType)
        {
            Qualification.DonorFoundationType = donorFoundationType;
            return this;
        }

        public IBuild WithGrade(Grade grade)
        {
            Qualification.Grade = grade;
            return this;
        }

        public Qualification Biuld()
        {
            Qualification.CheckState();

            return Qualification;
        }

    }

}