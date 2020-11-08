using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class DevelopmentTypeC
    {
        public static DevelopmentTypeC New(string name, int developmentTypeBId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(developmentTypeBId, nameof(developmentTypeBId));

            var developmentTypeC = new DevelopmentTypeC()
            {
                Name = name,
                DevelopmentTypeBId = developmentTypeBId,
            };


            return developmentTypeC;
        }
        public static DevelopmentTypeC New(string name, DevelopmentTypeB developmentTypeB)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(developmentTypeB, nameof(developmentTypeB));

            var developmentTypeC = new DevelopmentTypeC()
            {
                Name = name,
                DevelopmentTypeB = developmentTypeB,
            };


            return developmentTypeC;
        }
        private DevelopmentTypeC()
        {

        }
        public int DevelopmentTypeCId { get; set; }
        public string Name { get; set; }
        public DevelopmentTypeB DevelopmentTypeB { get; set; }
        public int DevelopmentTypeBId { get; set; }
        public ICollection<DevelopmentTypeD> DevelopmentTypeDs { get; } = new HashSet<DevelopmentTypeD>();
        public void Modify(string name, int developmentTypeBId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(developmentTypeBId, nameof(developmentTypeBId));

            Name = name;
            DevelopmentTypeBId = developmentTypeBId;
            DevelopmentTypeB = null;

        }

        public void Modify(string name, DevelopmentTypeB developmentTypeB)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(developmentTypeB, nameof(developmentTypeB));
            Name = name;
            DevelopmentTypeB = developmentTypeB;

        }
    }
}