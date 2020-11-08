using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class DevelopmentTypeA
    {
        public static DevelopmentTypeA New(TrainingType trainingType, string name)
        {
            Check.NotEmpty(name, nameof(name));

            var developmentTypeA = new DevelopmentTypeA()
            {
                TrainingType = trainingType,
                Name = name,
            };


            return developmentTypeA;
        }

        private DevelopmentTypeA()
        {

        }
        public int DevelopmentTypeAId { get; set; }
        public string Name { get; set; }
        public TrainingType TrainingType { get; set; }
        public ICollection<DevelopmentTypeB> DevelopmentTypeBs { get; } = new HashSet<DevelopmentTypeB>();
        public void Modify(TrainingType trainingType, string name)
        {
            Check.NotEmpty(name, nameof(name));
            TrainingType = trainingType;
            Name = name;
        }
    }
}