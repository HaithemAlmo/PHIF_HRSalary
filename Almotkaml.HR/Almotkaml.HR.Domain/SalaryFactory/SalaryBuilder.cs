using System;

namespace Almotkaml.HR.Domain.SalaryFactory
{
    public class SalaryBuilder : IMonthDateHolder, IEmployeeHolder, IJobNumberHolder, IAbsenceDaysHolder
        , IExtraValueHolder, IExtraGeneralValueHolder, IBankBranchHolder, IBondNumberHolder, IFileNumberHolder
        , IBasicSalaryHolder, IAdvancePremiumInsideHolder, IAdvancePremiumOutsideHolder, ISanctionHolder, IAccumulatedValueHolder, IRewindValueHolder
        , ISalaryPremiumHolder, IBuild
    {

        internal SalaryBuilder()
        {
        }

        private Salary Salary { get; } = new Salary();

        public IEmployeeHolder WithMonthDate(DateTime monthDate)
        {
            Salary.MonthDate = monthDate;
            return this;
        }

        public IJobNumberHolder WithEmployee(Employee employee)
        {
            Salary.Employee = employee;
            Salary.EmployeeId = employee.EmployeeId;

            return this;
        }

        public IJobNumberHolder WithEmployee(int employeeId)
        {
            Salary.EmployeeId = employeeId;
            return this;
        }

        public IAbsenceDaysHolder WithJobNumber(string jobNumber)
        {
            Salary.JobNumber = jobNumber;
            return this;
        }

        public IExtraValueHolder WithAbsenceDays(int absenceDays)
        {
            Salary.AbsenceDays = absenceDays;
            return this;
        }

        public IExtraGeneralValueHolder WithExtraValue(decimal extraValue)
        {
            Salary.ExtraValue = extraValue;
            return this;
        }

        public IBankBranchHolder WithExtraGeneralValue(decimal extraGeneralValue)
        {
            Salary.ExtraGeneralValue = extraGeneralValue;
            return this;
        }

        public IBondNumberHolder WithBankBranch(BankBranch bankBranch)
        {
            Salary.BankBranch = bankBranch;
            Salary.BankBranchId = bankBranch.BankBranchId;
            return this;
        }

        public IBondNumberHolder WithBankBranch(int bankBranchId)
        {
            Salary.BankBranchId = bankBranchId;
            return this;
        }

        public IFileNumberHolder WithBondNumber(string bondNumber)
        {
            Salary.BondNumber = bondNumber;
            return this;
        }

        public IBasicSalaryHolder WithFileNumber(string fileNumber)
        {
            Salary.FileNumber = fileNumber;
            return this;
        }

        public IAdvancePremiumInsideHolder WithBasicSalary(decimal basicSalary)
        {
            Salary.BasicSalary = basicSalary;
            return this;
        }

        public IAdvancePremiumOutsideHolder WithAdvancePremiumInside(decimal advancePremiumInside)
        {
            Salary.AdvancePremiumInside = advancePremiumInside;
            return this;
        }

        public ISanctionHolder WithAdvancePremiumOutside(decimal advancePremiumOutside)
        {
            Salary.AdvancePremiumOutside = advancePremiumOutside;
            return this;
        }

        public IAccumulatedValueHolder WithSanction(decimal sanction)
        {
            Salary.Sanction = sanction;
            return this;
}
        public IRewindValueHolder WithAccumulatedValue(decimal accumulatedValue)
        {
            Salary.AccumulatedValue = accumulatedValue; ;
            return this;
        }
        public ISalaryPremiumHolder WithRewindValue(decimal rewindValue)
        {
            Salary.RewindValue = rewindValue; ;
            return this;
        }

        public IBuild WithSalaryPremium(Employee employee)
        {
            foreach (var premium in employee.Premiums)
            {
                Salary.SalaryPremiums.Add(new SalaryPremium()
                {
                    PremiumId = premium.PremiumId,
                    Premium = premium.Premium,
                    Salary = Salary,
                    Value = premium.Value,
                    IsAdvansePremmium= premium.Premium?.ISAdvancePremmium ??0,
                    IsTemporary= premium.Premium?.IsTemporary??0,
                });
            }
            return this;
        }
        public Salary Biuld()
        {
            Salary.IsClose = true;
            return Salary;
        }
    }
}