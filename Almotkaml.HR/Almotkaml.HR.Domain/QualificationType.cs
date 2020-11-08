using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class QualificationType
    {
        public static QualificationType New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var qualificationType = new QualificationType()
            {
                Name = name,
            };


            return qualificationType;
        }
        private QualificationType()
        {

        }
        public int QualificationTypeId { get; private set; }
        public string Name { get; private set; }
        public ICollection<Qualification> Qualifications { get; } = new HashSet<Qualification>();
        //public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }
    }
}