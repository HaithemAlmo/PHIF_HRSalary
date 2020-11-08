using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class AdjectiveEmployeeType
    {
        public static AdjectiveEmployeeType New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var adjectiveEmployeeType = new AdjectiveEmployeeType()
            {
                Name = name,
            };


            return adjectiveEmployeeType;
        }
        private AdjectiveEmployeeType()
        {

        }
        public int AdjectiveEmployeeTypeId { get; private set; }
        public string Name { get; private set; }
        public ICollection<AdjectiveEmployee> AdjectiveEmployees { get; set; } = new HashSet<AdjectiveEmployee>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }
    }
}