using Almotkaml.HR.Domain.QualificationFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class Qualification
    {
        public static IEmployeeIdHolder New()
        {
            return new QualificationBuilder();
        }

        internal Qualification()
        {

        }
        public int QualificationId { get; internal set; }
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public int QualificationTypeId { get; internal set; }
        public QualificationType QualificationType { get; internal set; }
        public DateTime Date { get; internal set; }
        public string GraduationCountry { get; internal set; }
        public string NameDonorFoundation { get; internal set; }
        public int? SpecialtyId { get; internal set; }
        public Specialty Specialty { get; internal set; }
        public int? SubSpecialtyId { get; internal set; }
        public SubSpecialty SubSpecialty { get; internal set; }
        public int? ExactSpecialtyId { get; internal set; }
        public ExactSpecialty ExactSpecialty { get; internal set; }
        public string AquiredSpecialty { get; internal set; } // التخصص المكتسب
        public DonorFoundationType DonorFoundationType { get; internal set; }// نوع الجهة المانحة
        public Grade Grade { get; internal set; }
        public QualificationModifier Modify()
        {
            return new QualificationModifier(this);
        }
        public string GetQualificationName() => QualificationType.Name;
        internal void CheckState()
        {
            var speciality = SpecialtyId != null || Specialty != null ? 1 : 0;
            var subSpeciality = SubSpecialtyId != null || SubSpecialty != null ? 1 : 0;
            var exactSpeciality = ExactSpecialtyId != null || ExactSpecialty != null ? 1 : 0;

            if (speciality + subSpeciality + exactSpeciality != 1)
                throw new Exception("speciality + subSpeciality + exactSpeciality != 1");
        }
    }
}