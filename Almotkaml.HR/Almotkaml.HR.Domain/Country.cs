using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Country
    {
        public static Country New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var country = new Country()
            {
                Name = name,
            };

            return country;
        }
        private Country()
        {

        }
        public int CountryId { get; private set; }
        public string Name { get; private set; }
        public ICollection<City> Cities { get; } = new HashSet<City>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;
        }
    }
}