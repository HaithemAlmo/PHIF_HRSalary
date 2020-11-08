namespace Almotkaml.HR.Domain
{
    public class TemporaryPremium
    {
        public static TemporaryPremium New(string name, bool isSubject, long salaryId, decimal value)
        {
            var temporaryPremium = new TemporaryPremium()
            {
                Name = name,
                IsSubject = isSubject,
                SalaryId = salaryId,
                Value = value
            };

            return temporaryPremium;
        }
        public static TemporaryPremium New(string name, bool isSubject, Salary salary, decimal value)
        {
            var temporaryPremium = new TemporaryPremium()
            {
                Name = name,
                IsSubject = isSubject,
                Salary = salary,
                Value = value
            };

            return temporaryPremium;
        }
        public int TemporaryPremiumId { get; set; }
        public string Name { get; set; }
        public bool IsSubject { get; set; }
        public long SalaryId { get; set; }
        public Salary Salary { get; set; }
        public decimal Value { get; set; }
        public void Modify(string name, bool isSubject, decimal value)
        {
            Name = name;
            IsSubject = isSubject;
            Value = value;
        }

    }
}