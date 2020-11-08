using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Domain
{
    public class StaffingClassification
    {
        public static StaffingClassification New(string name, int staffingId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(staffingId, nameof(staffingId));

            var staffingClassification = new StaffingClassification()
            {
                Name = name,
                StaffingId = staffingId,
            };


            return staffingClassification;
        }
        public static StaffingClassification New(string name, Staffing staffing)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(staffing, nameof(staffing));

            var staffingClassification = new StaffingClassification()
            {
                Name = name,
                Staffing = staffing,
            };


            return staffingClassification;
        }

        private StaffingClassification()
        {

        }
        public int StaffingClassificationId { get; private set; }
        public string Name { get; private set; }
        public int StaffingId { get; private set; }
        public Staffing Staffing { get; private set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        //public ICollection<Job> Jobs { get; } = new HashSet<Job>();


        public void Modify(string name, int staffingId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(staffingId, nameof(staffingId));

            Name = name;
            StaffingId = staffingId;
           // Staffing = null;

        }
        public void Modify(string name, Staffing staffing)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(staffing, nameof(staffing));

            Name = name;
            Staffing = staffing;

        }

    }
}
