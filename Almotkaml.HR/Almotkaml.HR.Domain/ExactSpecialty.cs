using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class ExactSpecialty
    {
        public static ExactSpecialty New(string name, int subSpecialtyId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(subSpecialtyId, nameof(subSpecialtyId));

            var exactSpecialty = new ExactSpecialty()
            {
                Name = name,
                SubSpecialtyId = subSpecialtyId
            };

            return exactSpecialty;
        }
        public static ExactSpecialty New(string name, SubSpecialty subSpecialty)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(subSpecialty, nameof(subSpecialty));

            var exactSpecialty = new ExactSpecialty()
            {
                Name = name,
                SubSpecialty = subSpecialty
            };

            return exactSpecialty;
        }
        private ExactSpecialty()
        {

        }
        public int ExactSpecialtyId { get; private set; }
        public string Name { get; private set; }
        public int SubSpecialtyId { get; private set; }
        public SubSpecialty SubSpecialty { get; private set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public ICollection<Qualification> Qualifications { get; } = new HashSet<Qualification>();
        public void Modify(string name, int subSpecialtyId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(subSpecialtyId, nameof(subSpecialtyId));

            Name = name;
            SubSpecialtyId = subSpecialtyId;
            if (SubSpecialtyId != subSpecialtyId)
                SubSpecialty = null;

        }
        public void Modify(string name, SubSpecialty subSpecialty)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(subSpecialty, nameof(subSpecialty));

            Name = name;
            SubSpecialty = subSpecialty;

        }

    }
}