using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{

    public class SubSpecialty
    {
        public static SubSpecialty New(string name, int specialtyId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(specialtyId, nameof(specialtyId));

            var subSpecialty = new SubSpecialty()
            {
                Name = name,
                SpecialtyId = specialtyId
            };


            return subSpecialty;
        }
        public static SubSpecialty New(string name, Specialty specialty)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(specialty, nameof(specialty));

            var subSpecialty = new SubSpecialty()
            {
                Name = name,
                Specialty = specialty
            };


            return subSpecialty;
        }
        private SubSpecialty()
        {

        }
        public int SubSpecialtyId { get; private set; }
        public string Name { get; private set; }
        public int SpecialtyId { get; private set; }
        public Specialty Specialty { get; private set; }
        //public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        //public ICollection<Qualification> Qualifications { get; } = new HashSet<Qualification>();
        public ICollection<ExactSpecialty> ExactSpecialties { get; } = new HashSet<ExactSpecialty>();

        public void Modify(string name, int specialtyId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(specialtyId, nameof(specialtyId));

            Name = name;
            SpecialtyId = specialtyId;
            Specialty = null;

        }

        public void Modify(string name, Specialty specialty)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(specialty, nameof(specialty));

            Name = name;
            Specialty = specialty;

        }

    }
}