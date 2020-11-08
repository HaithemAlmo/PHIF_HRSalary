using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Nationality
    {
        public static Nationality New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var nationality = new Nationality()
            {
                Name = name,
            };


            return nationality;
        }
        private Nationality()
        {

        }
        public int NationalityId { get; private set; }
        public string Name { get; private set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }
    }
}