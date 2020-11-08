using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Job
    {
        public static Job New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var job = new Job()
            {
                Name = name,
            };


            return job;
        }
        private Job()
        {

        }
        public int JobId { get; private set; }
        public string Name { get; private set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }
    }
}