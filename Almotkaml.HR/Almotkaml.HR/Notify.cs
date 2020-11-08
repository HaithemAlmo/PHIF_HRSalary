// ReSharper disable InconsistentNaming

using Almotkaml.Attributes;
using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public class Notify
    {
        public bool Course_Create { get; set; }
        public bool Course_Edit { get; set; }
        public bool Course_Delete { get; set; }
        public bool Coach_Create { get; set; }
        public bool Coach_Edit { get; set; }
        public bool Coach_Delete { get; set; }
        public bool ClassificationOnWork_Create { get; set; }
        public bool ClassificationOnWork_Edit { get; set; }
        public bool ClassificationOnWork_Delete { get; set; }
        public bool ClassificationOnSearching_Create { get; set; }
        public bool ClassificationOnSearching_Edit { get; set; }
        public bool ClassificationOnSearching_Delete { get; set; }
        public bool SalaryUnit_Save { get; set; }
        [Phrase(typeof(Notifications), nameof(AdjectiveEmployeeType_Create))]
        public bool AdjectiveEmployeeType_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(AdjectiveEmployeeType_Edit))]
        public bool AdjectiveEmployeeType_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(AdjectiveEmployeeType_Delete))]
        public bool AdjectiveEmployeeType_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(AdjectiveEmployee_Create))]
        public bool AdjectiveEmployee_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(AdjectiveEmployee_Edit))]
        public bool AdjectiveEmployee_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(AdjectiveEmployee_Delete))]
        public bool AdjectiveEmployee_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Branch_Create))]
        public bool Branch_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Branch_Edit))]
        public bool Branch_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Branch_Delete))]
        public bool Branch_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(ContractType_Create))]
        public bool ContractType_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(ContractType_Edit))]
        public bool ContractType_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(ContractType_Delete))]
        public bool ContractType_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(CurrentSituation_Create))]
        public bool CurrentSituation_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(CurrentSituation_Edit))]
        public bool CurrentSituation_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(CurrentSituation_Delete))]
        public bool CurrentSituation_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Department_Create))]
        public bool Department_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Department_Edit))]
        public bool Department_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Department_Delete))]
        public bool Department_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Employee_Create))]
        public bool Employee_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Employee_Edit))]
        public bool Employee_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Employee_Delete))]
        public bool Employee_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(EmploymentType_Create))]
        public bool EmploymentType_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(EmploymentType_Edit))]
        public bool EmploymentType_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(EmploymentType_Delete))]
        public bool EmploymentType_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Job_Create))]
        public bool Job_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Job_Edit))]
        public bool Job_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Job_Delete))]
        public bool Job_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Vacation_Create))]
        public bool Vacation_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Vacation_Edit))]
        public bool Vacation_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Vacation_Delete))]
        public bool Vacation_Delete { get; set; }
        public bool Vacation_BalancYear { get; set; }

        [Phrase(typeof(Notifications), nameof(VacationType_Create))]
        public bool VacationType_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(VacationType_Edit))]
        public bool VacationType_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(VacationType_Delete))]
        public bool VacationType_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Division_Create))]
        public bool Division_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Division_Edit))]
        public bool Division_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Division_Delete))]
        public bool Division_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Nationality_Create))]
        public bool Nationality_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Nationality_Edit))]
        public bool Nationality_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Nationality_Delete))]
        public bool Nationality_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Note_Create))]
        public bool Note_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Note_Edit))]
        public bool Note_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Note_Delete))]
        public bool Note_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Place_Create))]
        public bool Place_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Place_Edit))]
        public bool Place_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Place_Delete))]
        public bool Place_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Qualification_Create))]
        public bool Qualification_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Qualification_Edit))]
        public bool Qualification_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Qualification_Delete))]
        public bool Qualification_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(QualificationType_Create))]
        public bool QualificationType_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(QualificationType_Edit))]
        public bool QualificationType_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(QualificationType_Delete))]
        public bool QualificationType_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Reward_Create))]
        public bool Reward_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Reward_Edit))]
        public bool Reward_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Reward_Delete))]
        public bool Reward_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(RewardType_Create))]
        public bool RewardType_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(RewardType_Edit))]
        public bool RewardType_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(RewardType_Delete))]
        public bool RewardType_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Sanction_Create))]
        public bool Sanction_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Sanction_Edit))]
        public bool Sanction_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Sanction_Delete))]
        public bool Sanction_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(SanctionType_Create))]
        public bool SanctionType_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(SanctionType_Edit))]
        public bool SanctionType_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(SanctionType_Delete))]
        public bool SanctionType_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Specialty_Create))]
        public bool Specialty_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Specialty_Edit))]
        public bool Specialty_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Specialty_Delete))]
        public bool Specialty_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Staffing_Create))]
        public bool Staffing_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Staffing_Edit))]
        public bool Staffing_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Staffing_Delete))]
        public bool Staffing_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(StaffingType_Create))]
        public bool StaffingType_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(StaffingType_Edit))]
        public bool StaffingType_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(StaffingType_Delete))]
        public bool StaffingType_Delete { get; set; }
        [Phrase(typeof(Notifications), nameof(StaffingClassification_Create))]
        public bool StaffingClassification_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(StaffingClassification_Edit))]
        public bool StaffingClassification_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(StaffingClassification_Delete))]
        public bool StaffingClassification_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(SubSpecialty_Create))]
        public bool SubSpecialty_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(SubSpecialty_Edit))]
        public bool SubSpecialty_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(SubSpecialty_Delete))]
        public bool SubSpecialty_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(TrainingCourse_Create))]
        public bool TrainingCourse_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(TrainingCourse_Edit))]
        public bool TrainingCourse_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(TrainingCourse_Delete))]
        public bool TrainingCourse_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Unit_Create))]
        public bool Unit_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Unit_Edit))]
        public bool Unit_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Unit_Delete))]
        public bool Unit_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(User_Create))]
        public bool User_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(User_Edit))]
        public bool User_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(User_Delete))]
        public bool User_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(UserGroup_Create))]
        public bool UserGroup_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(UserGroup_Edit))]
        public bool UserGroup_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(UserGroup_Delete))]
        public bool UserGroup_Delete { get; set; }


        [Phrase(typeof(Notifications), nameof(TimeSheet_Create))]
        public bool TimeSheet_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(TimeSheet_Edit))]
        public bool TimeSheet_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(TimeSheet_Delete))]
        public bool TimeSheet_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Evaluation_Create))]
        public bool Evaluation_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Evaluation_Edit))]
        public bool Evaluation_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Evaluation_Delete))]
        public bool Evaluation_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Extrawork_Create))]
        public bool Extrawork_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Extrawork_Edit))]
        public bool Extrawork_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Extrawork_Delete))]
        public bool Extrawork_Delete { get; set; }


        [Phrase(typeof(Notifications), nameof(SelfCourse_Create))]
        public bool SelfCourse_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(SelfCourse_Edit))]
        public bool SelfCourse_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(SelfCourse_Delete))]
        public bool SelfCourse_Delete { get; set; }


        [Phrase(typeof(Notifications), nameof(EndServices_Create))]
        public bool EndServices_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(EndServices_Edit))]
        public bool EndServices_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(EndServices_Delete))]
        public bool EndServices_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Bank_Create))]
        public bool Bank_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Bank_Edit))]
        public bool Bank_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Bank_Delete))]
        public bool Bank_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(BankBranch_Create))]
        public bool BankBranch_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(BankBranch_Edit))]
        public bool BankBranch_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(BankBranch_Delete))]
        public bool BankBranch_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Bouns_Add))]
        public bool Bouns_Add { get; set; }

        [Phrase(typeof(Notifications), nameof(Degree_Add))]
        public bool Degree_Add { get; set; }


        [Phrase(typeof(Notifications), nameof(SituationResolveJob_Create))]
        public bool SituationResolveJob_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(SituationResolveJob_Edit))]
        public bool SituationResolveJob_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(SituationResolveJob_Delete))]
        public bool SituationResolveJob_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(City_Create))]
        public bool City_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(City_Edit))]
        public bool City_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(City_Delete))]
        public bool City_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Country_Create))]
        public bool Country_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Country_Edit))]
        public bool Country_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Country_Delete))]
        public bool Country_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Absence_Create))]
        public bool Absence_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Absence_Edit))]
        public bool Absence_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Absence_Delete))]
        public bool Absence_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Transfer_Create))]
        public bool Transfer_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Transfer_Edit))]
        public bool Transfer_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Transfer_Delete))]
        public bool Transfer_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Corporation_Create))]
        public bool Corporation_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Corporation_Edit))]
        public bool Corporation_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Corporation_Delete))]
        public bool Corporation_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Delegation_Create))]
        public bool Delegation_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Delegation_Edit))]
        public bool Delegation_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Delegation_Delete))]
        public bool Delegation_Delete { get; set; }

        public bool DevelopmentTypeA_Create { get; set; }

        public bool DevelopmentTypeA_Edit { get; set; }

        public bool DevelopmentTypeA_Delete { get; set; }

        public bool DevelopmentTypeB_Create { get; set; }

        public bool DevelopmentTypeB_Edit { get; set; }

        public bool DevelopmentTypeB_Delete { get; set; }
        public bool DevelopmentTypeC_Create { get; set; }
        public bool DevelopmentTypeC_Edit { get; set; }
        public bool DevelopmentTypeC_Delete { get; set; }
        public bool DevelopmentTypeD_Create { get; set; }
        public bool DevelopmentTypeD_Edit { get; set; }
        public bool DevelopmentTypeD_Delete { get; set; }
        public bool DevelopmentTypeE_Create { get; set; }
        public bool DevelopmentTypeE_Edit { get; set; }
        public bool DevelopmentTypeE_Delete { get; set; }
        public bool Training_Create { get; set; }
        public bool Training_Edit { get; set; }
        public bool Training_Delete { get; set; }
        public bool DevelopmentState_Create { get; set; }
        public bool DevelopmentState_Edit { get; set; }
        public bool DevelopmentState_Delete { get; set; }
        public bool RequestedQualification_Create { get; set; }
        public bool RequestedQualification_Edit { get; set; }
        public bool RequestedQualification_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Premium_Create))]
        public bool Premium_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Premium_Edit))]
        public bool Premium_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Premium_Delete))]
        public bool Premium_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Salary_Freeze))]
        public bool Salary_Freeze { get; set; }

        [Phrase(typeof(Notifications), nameof(Salary_Allow))]
        public bool Salary_Allow { get; set; }

        [Phrase(typeof(Notifications), nameof(Salary_Close))]
        public bool Salary_Close { get; set; }

        [Phrase(typeof(Notifications), nameof(Salary_Update))]
        public bool Salary_Update { get; set; }

        [Phrase(typeof(Notifications), nameof(Salary_Spent))]
        public bool Salary_Spent { get; set; }

        [Phrase(typeof(Notifications), nameof(Salary_Edit))]
        public bool Salary_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Salary_Delete))]
        public bool Salary_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(AdvancePayment_Create))]
        public bool AdvancePayment_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(AdvancePayment_Edit))]
        public bool AdvancePayment_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(AdvancePayment_Delete))]
        public bool AdvancePayment_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(SalaryInfo_Save))]
        public bool SalaryInfo_Save { get; set; }

        [Phrase(typeof(Notifications), nameof(ExactSpecialty_Create))]
        public bool ExactSpecialty_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(ExactSpecialty_Edit))]
        public bool ExactSpecialty_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(ExactSpecialty_Delete))]
        public bool ExactSpecialty_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Holiday_Create))]
        public bool Holiday_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Holiday_Edit))]
        public bool Holiday_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Holiday_Delete))]
        public bool Holiday_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Center_Create))]
        public bool Center_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Center_Edit))]
        public bool Center_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Center_Delete))]
        public bool Center_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(Salary_OldSalary))]
        public bool Salary_OldSalary { get; set; }

        [Phrase(typeof(Notifications), nameof(Salary_Suspend))]
        public bool Salary_Suspend { get; set; }

        [Phrase(typeof(Notifications), nameof(Salary_Unsuspend))]
        public bool Salary_Unsuspend { get; set; }


        //[Phrase(typeof(Notifications), nameof(AddSupsended))]
        //[Display(ResourceType = typeof(Titles), Name = nameof(Notifications.Suspsended))]
        public bool AddSupsended { get; set; }


        [Phrase(typeof(Notifications), nameof(CompanyInfo_Update))]
        [Display(ResourceType = typeof(Titles), Name = nameof(Titles.Edit))]
        public bool CompanyInfo_Update { get; set; }


        [Phrase(typeof(Notifications), nameof(Setting_Update))]
        [Display(ResourceType = typeof(Titles), Name = nameof(Titles.Edit))]
        public bool Setting_Update { get; set; }

        [Phrase(typeof(Notifications), nameof(Document_Create))]
        public bool Document_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(Document_Edit))]
        public bool Document_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(Document_Delete))]
        public bool Document_Delete { get; set; }

        [Phrase(typeof(Notifications), nameof(DocumentType_Create))]
        public bool DocumentType_Create { get; set; }

        [Phrase(typeof(Notifications), nameof(DocumentType_Edit))]
        public bool DocumentType_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(DocumentType_Delete))]
        public bool DocumentType_Delete { get; set; }
        [Phrase(typeof(Notifications), nameof(Employee_Settlement))]
        public bool Employee_Settlement { get; set; }
        [Phrase(typeof(Notifications), nameof(Employee_Promotion))]
        public bool Employee_Promotion { get; set; }
        [Phrase(typeof(Notifications), nameof(Degree_Edit))]
        public bool Degree_Edit { get; set; }

        [Phrase(typeof(Notifications), nameof(AdvancePremium_FreezeState))]
        public bool AdvancePremium_FreezeState { get; set; }
        [Phrase(typeof(Notifications), nameof(DEAdvancePremium_FreezeState))]
        public bool DEAdvancePremium_FreezeState { get; set; }
    }
}
