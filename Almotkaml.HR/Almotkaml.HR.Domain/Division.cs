using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Division
    {
        public static Division New(string name, int departmentId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(departmentId, nameof(departmentId));

            var division = new Division()
            {
                Name = name,
                DepartmentId = departmentId
            };


            return division;
        }
        public static Division New(string name, Department department)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(department, nameof(department));

            var division = new Division()
            {
                Name = name,
                Department = department
            };


            return division;
        }
        private Division()
        {

        }
        public int DivisionId { get; private set; }
        public string Name { get; private set; }
        public int DepartmentId { get; private set; }
        public Department Department { get; private set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public ICollection<Unit> Units { get; } = new HashSet<Unit>();
        public void Modify(string name, int departmentId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(departmentId, nameof(departmentId));

            Name = name;
            DepartmentId = departmentId;
            if (DepartmentId != departmentId)
                Department = null;

        }
        public void Modify(string name, Department department)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(department, nameof(department));

            Name = name;
            Department = department;

        }

    }
}