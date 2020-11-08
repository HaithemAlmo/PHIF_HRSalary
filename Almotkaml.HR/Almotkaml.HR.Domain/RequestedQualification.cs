namespace Almotkaml.HR.Domain
{
    public class RequestedQualification
    {
        public static RequestedQualification New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var requestedQualification = new RequestedQualification()
            {
                Name = name,
            };


            return requestedQualification;
        }

        private RequestedQualification()
        {

        }
        public int RequestedQualificationId { get; set; }
        public string Name { get; set; }
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }
    }
}