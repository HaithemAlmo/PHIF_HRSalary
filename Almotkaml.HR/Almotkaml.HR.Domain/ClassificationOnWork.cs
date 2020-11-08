using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class ClassificationOnWork
    {
        public static ClassificationOnWork New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var classificationOnWork = new ClassificationOnWork()
            {
                Name = name,
            };


            return classificationOnWork;
        }
        private ClassificationOnWork()
        {

        }
        public int ClassificationOnWorkId { get; private set; }
        public string Name { get; private set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }
    }
}