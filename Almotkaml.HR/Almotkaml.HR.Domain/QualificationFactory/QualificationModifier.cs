using System;

namespace Almotkaml.HR.Domain.QualificationFactory
{
    public class QualificationModifier
    {
        internal QualificationModifier(Qualification qualification)
        {
            Qualification = qualification;
        }
        private Qualification Qualification { get; }
        public QualificationModifier Employee(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            Qualification.EmployeeId = employeeId;
            return this;
        }

        public QualificationModifier Employee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            Qualification.EmployeeId = employee.EmployeeId;
            Qualification.Employee = employee;
            return this;
        }

        public QualificationModifier QualificationType(int qualificationTypeId)
        {
            Check.MoreThanZero(qualificationTypeId, nameof(qualificationTypeId));
            Qualification.QualificationTypeId = qualificationTypeId;
            return this;
        }

        public QualificationModifier QualificationType(QualificationType qualificationType)
        {
            Check.NotNull(qualificationType, nameof(qualificationType));
            Qualification.QualificationTypeId = qualificationType.QualificationTypeId;
            Qualification.QualificationType = qualificationType;
            return this;
        }

        public QualificationModifier Date(DateTime date)
        {
            Qualification.Date = date;
            return this;
        }

        public QualificationModifier GraduationCountry(string graduationCountry)
        {
            Qualification.GraduationCountry = graduationCountry;
            return this;
        }

        public QualificationModifier NameDonorFoundation(string nameDonorFoundation)
        {
            Qualification.NameDonorFoundation = nameDonorFoundation;
            return this;
        }

        public QualificationModifier Specialty(SpecialityType type, int? id)
        {
            Qualification.Specialty = null;
            Qualification.SubSpecialty = null;
            Qualification.ExactSpecialty = null;

            switch (type)
            {
                case SpecialityType.Speciality:
                    Qualification.SpecialtyId = id;
                    Qualification.SubSpecialtyId = null;
                    Qualification.ExactSpecialtyId = null;
                    break;
                case SpecialityType.SubSpeciality:
                    Qualification.SpecialtyId = null;
                    Qualification.SubSpecialtyId = id;
                    Qualification.ExactSpecialtyId = null;
                    break;
                case SpecialityType.ExactSpeciality:
                    Qualification.SpecialtyId = null;
                    Qualification.SubSpecialtyId = null;
                    Qualification.ExactSpecialtyId = id;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            return this;
        }

        public QualificationModifier Specialty(Specialty specialty)
        {
            Qualification.SpecialtyId = specialty.SpecialtyId;
            Qualification.Specialty = specialty;
            return this;
        }
        public QualificationModifier Specialty(SubSpecialty subSpecialty)
        {
            Qualification.SubSpecialtyId = subSpecialty.SubSpecialtyId;
            Qualification.SubSpecialty = subSpecialty;
            return this;
        }
        public QualificationModifier Specialty(ExactSpecialty exactSpecialty)
        {
            Qualification.ExactSpecialtyId = exactSpecialty.ExactSpecialtyId;
            Qualification.ExactSpecialty = exactSpecialty;
            return this;
        }

        public QualificationModifier AquiredSpecialty(string aquiredSpecialty)
        {
            Qualification.AquiredSpecialty = aquiredSpecialty;
            return this;
        }
        public QualificationModifier DonorFoundationType(DonorFoundationType donorFoundationType)
        {
            Qualification.DonorFoundationType = donorFoundationType;
            return this;
        }

        public QualificationModifier Grade(Grade grade)
        {
            Qualification.Grade = grade;
            return this;
        }

        public Qualification Confirm()
        {
            Qualification.CheckState();

            return Qualification;
        }
    }
}