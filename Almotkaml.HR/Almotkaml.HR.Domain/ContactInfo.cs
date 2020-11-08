namespace Almotkaml.HR.Domain
{
    public class ContactInfo
    {
        internal ContactInfo()
        {

        }
        internal ContactInfo(Employee employee)
        {
            Employee = employee;
        }

        public static ContactInfo New(string phone, string note, string nearKindr, string relativeRelation
            , string nearPoint, string address, string workAddress)
        {
            var contactInfo = new ContactInfo()
            {
                Phone = phone,
                Note = note,
                NearKindr = nearKindr,
                RelativeRelation = relativeRelation,
                NearPoint = nearPoint,
                WorkAddress = workAddress,
                Address = address,
            };
            return contactInfo;
        }
        public Employee Employee { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public string NearKindr { get; set; }
        public string RelativeRelation { get; set; }
        public string NearPoint { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }
    }
}