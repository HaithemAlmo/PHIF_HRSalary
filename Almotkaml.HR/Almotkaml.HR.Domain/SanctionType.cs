using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class SanctionType
    {
        public static SanctionType New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var sanctionType = new SanctionType()
            {
                Name = name,
            };


            return sanctionType;
        }
        private SanctionType()
        {

        }
        public int SanctionTypeId { get; private set; }
        public string Name { get; private set; }
        public ICollection<Sanction> Sanctions { get; } = new HashSet<Sanction>();
        //public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }

    }
}