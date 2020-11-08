using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Unit
    {
        public static Unit New(string name, int divisionId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(divisionId, nameof(divisionId));

            var unit = new Unit()
            {
                Name = name,
                DivisionId = divisionId
            };


            return unit;
        }
        public static Unit New(string name, Division division)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(division, nameof(division));

            var unit = new Unit()
            {
                Name = name,
                Division = division
            };


            return unit;
        }
        private Unit()
        {

        }
        public int UnitId { get; private set; }
        public string Name { get; private set; }
        public int DivisionId { get; private set; }
        public Division Division { get; private set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name, int divisionId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(divisionId, nameof(divisionId));

            Name = name;
            DivisionId = divisionId;
            if (DivisionId != divisionId)
                Division = null;

        }
        public void Modify(string name, Division division)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(division, nameof(division));

            Name = name;
            Division = division;

        }

    }
}