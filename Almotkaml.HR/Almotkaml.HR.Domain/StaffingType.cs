using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class StaffingType
    {
        public static StaffingType New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var staffingType = new StaffingType()
            {
                Name = name,
            };


            return staffingType;
        }
        private StaffingType()
        {

        }
        public int StaffingTypeId { get; private set; }
        public string Name { get; private set; }
        public ICollection<Staffing> Staffings { get; } = new HashSet<Staffing>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }

    }
}