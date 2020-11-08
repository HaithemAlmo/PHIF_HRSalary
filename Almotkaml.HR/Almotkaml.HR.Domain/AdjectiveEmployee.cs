using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class AdjectiveEmployee
    {
        public static AdjectiveEmployee New(string name, int adjectiveEmployeeTypeId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(adjectiveEmployeeTypeId, nameof(adjectiveEmployeeTypeId));

            var adjectiveEmployee = new AdjectiveEmployee()
            {
                Name = name,
                AdjectiveEmployeeTypeId = adjectiveEmployeeTypeId
            };


            return adjectiveEmployee;
        }
        public static AdjectiveEmployee New(string name, AdjectiveEmployeeType adjectiveEmployeeType)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(adjectiveEmployeeType, nameof(adjectiveEmployeeType));

            var adjectiveEmployee = new AdjectiveEmployee()
            {
                Name = name,
                AdjectiveEmployeeTypeId = adjectiveEmployeeType.AdjectiveEmployeeTypeId,
                AdjectiveEmployeeType = adjectiveEmployeeType
            };


            return adjectiveEmployee;
        }

        private AdjectiveEmployee()
        {

        }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public int AdjectiveEmployeeId { get; private set; }
        public string Name { get; private set; }
        public int AdjectiveEmployeeTypeId { get; set; }
        public AdjectiveEmployeeType AdjectiveEmployeeType { get; set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name, int adjectiveEmployeeTypeId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(adjectiveEmployeeTypeId, nameof(adjectiveEmployeeTypeId));

            Name = name;
            AdjectiveEmployeeTypeId = adjectiveEmployeeTypeId;
            if (AdjectiveEmployeeTypeId != adjectiveEmployeeTypeId)
                AdjectiveEmployeeType = null;

        }
        public void Modify(string name, AdjectiveEmployeeType adjectiveEmployeeType)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(adjectiveEmployeeType, nameof(adjectiveEmployeeType));

            Name = name;
            AdjectiveEmployeeTypeId = adjectiveEmployeeType.AdjectiveEmployeeTypeId;
            AdjectiveEmployeeType = adjectiveEmployeeType;

        }

    }
}