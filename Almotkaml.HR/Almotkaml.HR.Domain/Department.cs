using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Department
    {
        public static Department New(string name, int centerId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(centerId, nameof(centerId));

            var department = new Department()
            {
                Name = name,
                CenterId = centerId,
            };


            return department;
        }
        public static Department New(string name, Center center)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(center, nameof(center));

            var department = new Department()
            {
                Name = name,
                Center = center
            };


            return department;
        }

        private Department()
        {

        }
        public int DepartmentId { get; private set; }
        public string Name { get; private set; }
        public int CenterId { get; private set; }
        public Center Center { get; private set; }
        public void Modify(string name, int centerId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(centerId, nameof(centerId));

            Name = name;
            CenterId = centerId;
            Center = null;

        }
        public void Modify(string name, Center center)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(center, nameof(center));

            Name = name;
            Center = center;

        }
        public ICollection<Division> Divisions { get; set; } = new HashSet<Division>();
    }
}