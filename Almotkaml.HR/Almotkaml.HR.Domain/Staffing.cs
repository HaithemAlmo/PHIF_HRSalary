using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Staffing
    {
        public static Staffing New(string name, int staffingTypeId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(staffingTypeId, nameof(staffingTypeId));

            var staffing = new Staffing()
            {
                Name = name,
                StaffingTypeId = staffingTypeId,
            };


            return staffing;
        }
        public static Staffing New(string name, StaffingType staffingType)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(staffingType, nameof(staffingType));

            var staffing = new Staffing()
            {
                Name = name,
                StaffingType = staffingType
            };


            return staffing;
        }
        private Staffing()
        {

        }
        public int StaffingId { get; private set; }
        public string Name { get; private set; }
        public int StaffingTypeId { get; private set; }
        public StaffingType StaffingType { get; private set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public ICollection<StaffingClassification> StaffingClassification { get; } = new HashSet<StaffingClassification>();

        public void Modify(string name, int staffingTypeId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(staffingTypeId, nameof(staffingTypeId));

            Name = name;
            StaffingTypeId = staffingTypeId;
            StaffingType = null;

        }
        public void Modify(string name, StaffingType staffingType)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(staffingType, nameof(staffingType));

            Name = name;
            StaffingType = staffingType;

        }
    }
}