namespace Almotkaml.HR.Domain
{
    public class DevelopmentState
    {
        public static DevelopmentState New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var developmentState = new DevelopmentState()
            {
                Name = name,
            };


            return developmentState;
        }

        private DevelopmentState()
        {

        }

        public int DevelopmentStateId { get; set; }
        public string Name { get; set; }
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }

    }
}