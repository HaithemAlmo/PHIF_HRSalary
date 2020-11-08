using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class CurrentSituation
    {
        public static CurrentSituation New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var currentSituation = new CurrentSituation()
            {
                Name = name,
                SituationEssential = CauseOfEndService.UnKnown,
        };

            return currentSituation;
        }

        private CurrentSituation()
        {

        }
        public int CurrentSituationId { get; private set; }
        public string Name { get; private set; }
        public CauseOfEndService SituationEssential { get; internal set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;
        }

    }
}