using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Specialty
    {
        public static Specialty New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var specialty = new Specialty()
            {
                Name = name,
            };


            return specialty;
        }
        private Specialty()
        {

        }
        public int SpecialtyId { get; private set; }
        public string Name { get; private set; }
        public ICollection<SubSpecialty> SubSpecialties { get; } = new HashSet<SubSpecialty>();

        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }
    }
}