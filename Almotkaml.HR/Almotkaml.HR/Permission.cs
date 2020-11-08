using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace Almotkaml.HR
{
    public class Permission : Notify
    {
        public bool AdjectiveEmployeeType { get; set; }
        public bool AdjectiveEmployee { get; set; }
        public bool Branch { get; set; }
        public bool ContractType { get; set; }
        public bool CurrentSituation { get; set; }
        public bool Department { get; set; }
        public bool Employee { get; set; }
        public bool EmploymentType { get; set; }
        public bool Job { get; set; }
        public bool Vacation { get; set; }
        public bool VacationType { get; set; }
        public bool Division { get; set; }
        public bool Nationality { get; set; }
        public bool Note { get; set; }
        public bool Place { get; set; }
        public bool Qualification { get; set; }
        public bool QualificationType { get; set; }
        public bool Reward { get; set; }
        public bool RewardType { get; set; }
        public bool Sanction { get; set; }
        public bool SanctionType { get; set; }
        public bool Specialty { get; set; }
        public bool Staffing { get; set; }
        public bool StaffingType { get; set; }
        public bool StaffingClassification { get; set; }
        public bool SubSpecialty { get; set; }
        public bool TrainingCourse { get; set; }
        public bool Unit { get; set; }
        public bool User { get; set; }
        public bool UserGroup { get; set; }
        public bool SalaryUnit { get; set; }

        public bool TimeSheet { get; set; }

        public bool Evaluation { get; set; }
        public bool Extrawork { get; set; }
        public bool SelfCourse { get; set; }

        public bool EndServices { get; set; }
        public bool Bank { get; set; }
        public bool BankBranch { get; set; }
        public bool Bouns { get; set; }
        public bool Retirement { get; set; }
        public bool Degree { get; set; }
        public bool SituationResolveJob { get; set; }
        public bool City { get; set; }
        public bool Country { get; set; }
        public bool Absence { get; set; }
        public bool Transfer { get; set; }
        public bool Corporation { get; set; }
        public bool Delegation { get; set; }
        public bool Premium { get; set; }
        public bool Setting { get; set; }
        public bool Salary { get; set; }
        public bool AdvancePayment { get; set; }
        public bool SalaryInfo { get; set; }
        public bool ExactSpecialty { get; set; }
        public bool Holiday { get; set; }
        public bool Center { get; set; }
        public bool UserActivity { get; set; }
        public bool AdvancePaymentReport { get; set; }
        public bool CompanyInfo { get; set; }

        [Display(ResourceType = typeof(Titles), Name = nameof(Titles.BackUp))]
        public bool BackUp { get; set; }

        [Display(ResourceType = typeof(Titles), Name = nameof(Titles.Restore))]
        public bool Restore { get; set; }
        public bool DevelopmentTypeA { get; set; }
        public bool DevelopmentTypeB { get; set; }
        public bool DevelopmentTypeC { get; set; }
        public bool DevelopmentTypeD { get; set; }
        public bool DevelopmentTypeE { get; set; }
        public bool Training { get; set; }
        public bool DevelopmentState { get; set; }
        public bool RequestedQualification { get; set; }
        public bool Document { get; set; }
        public bool DocumentType { get; set; }
        public bool ClassificationOnSearching { get; set; }
        public bool ClassificationOnWork { get; set; }
        public bool Coach { get; set; }
        public bool Course { get; set; }
        public bool EmployeeReport { get; set; }
        public bool SettlementReport { get; set; }
        public bool SettlementVacationReport { get; set; }
        public bool SettlementAbsenceReport { get; set; }
        public bool SalarySettlementReport { get; set; }
        public bool DiscountSettlementReport { get; set; }
        public bool PremiumSettlementReport { get; set; }
    }
}
