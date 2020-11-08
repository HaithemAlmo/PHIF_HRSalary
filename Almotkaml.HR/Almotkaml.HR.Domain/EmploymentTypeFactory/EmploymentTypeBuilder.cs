namespace Almotkaml.HR.Domain.EmploymentTypeFactory
{
    public class EmploymentTypeBuilder : INameHolder, IDesignationResolutionNumberHolder
        , IDesignationResolutionDateHolder, IDesignationIssueHolder, IContractDateHolder
        , IContractDurationHolder, IBuild
    {

        internal EmploymentTypeBuilder() { }
        private EmploymentType EmploymentType { get; } = new EmploymentType();


        public IDesignationResolutionNumberHolder WithName(string name)
        {
            Check.NotEmpty(name, nameof(name));
            EmploymentType.Name = name;
            return this;
        }

        public IDesignationResolutionDateHolder WithDesignationResolutionNumber(bool designationResolutionNumber)
        {
            EmploymentType.DesignationResolutionNumber = designationResolutionNumber;
            return this;
        }

        public IDesignationIssueHolder WithDesignationResolutionDate(bool designationResolutionDate)
        {
            EmploymentType.DesignationResolutionDate = designationResolutionDate;
            return this;
        }

        public IContractDateHolder WithDesignationIssue(bool designationIssue)
        {
            EmploymentType.DesignationIssue = designationIssue;
            return this;
        }

        public IContractDurationHolder WithContractDate(bool contractDate)
        {
            EmploymentType.ContractDate = contractDate;
            return this;
        }

        public IBuild WithContractDuration(bool contractDuration)
        {
            EmploymentType.ContractDuration = contractDuration;
            return this;
        }

        public EmploymentType Biuld()
        {
            return EmploymentType;
        }

    }

}