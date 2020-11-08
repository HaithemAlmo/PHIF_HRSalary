using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class DevelopmentTypeB
    {
        public static DevelopmentTypeB New(string name, int developmentTypeAId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(developmentTypeAId, nameof(developmentTypeAId));

            var developmentTypeB = new DevelopmentTypeB()
            {
                Name = name,
                DevelopmentTypeAId = developmentTypeAId,
            };


            return developmentTypeB;
        }
        public static DevelopmentTypeB New(string name, DevelopmentTypeA developmentTypeA)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(developmentTypeA, nameof(developmentTypeA));

            var developmentTypeB = new DevelopmentTypeB()
            {
                Name = name,
                DevelopmentTypeA = developmentTypeA,
            };


            return developmentTypeB;
        }
        private DevelopmentTypeB()
        {

        }
        public int DevelopmentTypeBId { get; set; }
        public string Name { get; set; }
        public DevelopmentTypeA DevelopmentTypeA { get; set; }
        public int DevelopmentTypeAId { get; set; }
        public ICollection<DevelopmentTypeC> DevelopmentTypeCs { get; } = new HashSet<DevelopmentTypeC>();
        public void Modify(string name, int developmentTypeAId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(developmentTypeAId, nameof(developmentTypeAId));

            Name = name;
            DevelopmentTypeAId = developmentTypeAId;
            DevelopmentTypeA = null;

        }

        public void Modify(string name, DevelopmentTypeA developmentTypeA)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(developmentTypeA, nameof(developmentTypeA));
            Name = name;
            DevelopmentTypeA = developmentTypeA;

        }

    }
}