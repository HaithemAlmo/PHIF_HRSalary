using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class ClassificationOnSearching
    {
        public static ClassificationOnSearching New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var classificationOnSearching = new ClassificationOnSearching()
            {
                Name = name,
            };


            return classificationOnSearching;
        }
        private ClassificationOnSearching()
        {

        }
        public int ClassificationOnSearchingId { get; private set; }
        public string Name { get; private set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }
    }
}