namespace Almotkaml.HR.Domain.EmploymentTypeFactory
{
    public class EmploymentTypeModifier
    {
        internal EmploymentTypeModifier(EmploymentType employmentType)
        {
            EmploymentType = employmentType;
        }
        private EmploymentType EmploymentType { get; }

        public EmploymentTypeModifier Name(string name)
        {
            Check.NotEmpty(name, nameof(name));
            EmploymentType.Name = name;
            return this;
        }

        public EmploymentTypeModifier DesignationResolutionNumber(bool designationResolutionNumber)
        {
            EmploymentType.DesignationResolutionNumber = designationResolutionNumber;
            return this;
        }

        public EmploymentTypeModifier DesignationResolutionDate(bool designationResolutionDate)
        {
            EmploymentType.DesignationResolutionDate = designationResolutionDate;
            return this;
        }

        public EmploymentTypeModifier DesignationIssue(bool designationIssue)
        {
            EmploymentType.DesignationIssue = designationIssue;
            return this;
        }

        public EmploymentTypeModifier ContractDate(bool contractDate)
        {
            EmploymentType.ContractDate = contractDate;
            return this;
        }

        public EmploymentTypeModifier ContractDuration(bool contractDuration)
        {
            EmploymentType.ContractDuration = contractDuration;
            return this;
        }

        public EmploymentType Confirm()
        {
            return EmploymentType;
        }
    }
}