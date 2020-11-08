namespace Almotkaml.HR.Domain
{
    public class DevelopmentTypeD
    {
        public static DevelopmentTypeD New(string name, int developmentTypeCId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(developmentTypeCId, nameof(developmentTypeCId));

            var developmentTypeD = new DevelopmentTypeD()
            {
                Name = name,
                DevelopmentTypeCId = developmentTypeCId,
            };


            return developmentTypeD;
        }
        public static DevelopmentTypeD New(string name, DevelopmentTypeC developmentTypeC)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(developmentTypeC, nameof(developmentTypeC));

            var developmentTypeD = new DevelopmentTypeD()
            {
                Name = name,
                DevelopmentTypeC = developmentTypeC,
            };


            return developmentTypeD;
        }
        private DevelopmentTypeD()
        {

        }
        public int DevelopmentTypeDId { get; set; }
        public string Name { get; set; }
        public DevelopmentTypeC DevelopmentTypeC { get; set; }
        public int DevelopmentTypeCId { get; set; }
        public void Modify(string name, int developmentTypeCId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(developmentTypeCId, nameof(developmentTypeCId));

            Name = name;
            DevelopmentTypeCId = developmentTypeCId;
            DevelopmentTypeC = null;

        }

        public void Modify(string name, DevelopmentTypeC developmentTypeC)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(developmentTypeC, nameof(developmentTypeC));
            Name = name;
            DevelopmentTypeC = developmentTypeC;

        }
    }
}