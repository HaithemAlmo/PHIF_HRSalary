namespace Almotkaml.HR.Domain
{
    public class DocumentType
    {
        public static DocumentType New(string name, bool haveDecisionNumber, bool haveDecisionYear, bool haveExpireDate)
        {
            Check.NotEmpty(name, nameof(name));

            return new DocumentType()
            {
                Name = name,
                HaveDecisionYear = haveDecisionYear,
                HaveDecisionNumber = haveDecisionNumber,
                HaveExpireDate = haveExpireDate
            };
        }

        private DocumentType() { }

        public int DocumentTypeId { get; private set; }
        public string Name { get; private set; }
        public bool HaveDecisionNumber { get; private set; }
        public bool HaveDecisionYear { get; private set; }
        public bool HaveExpireDate { get; private set; }

        public void Modify(string name, bool haveDecisionNumber, bool haveDecisionYear, bool haveExpireDate)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;
            HaveDecisionYear = haveDecisionYear;
            HaveDecisionNumber = haveDecisionNumber;
            HaveExpireDate = haveExpireDate;
        }
    }
}