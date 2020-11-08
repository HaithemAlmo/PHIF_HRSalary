using System;

namespace Almotkaml.HR.Domain
{
    public class EmploymentValues
    {
        internal EmploymentValues()
        {

        }

        public EmploymentValues(string designationResolutionNumber, DateTime? designationResolutionDate,
            string designationIssue, DateTime? contractDateFrom, DateTime? contractDateTo, DateTime? delegationDate,
            string delegationSide, DateTime? transferDate, string transferSide, DateTime? loaningDate, string loaningSide
            , DateTime? benefitFromServicesDate, string benefitFromServicesSide
            , DateTime? emptiedDate, string emptiedSide
            , DateTime? collaboratorDate, string collaboratorSide
            )
        {
            DesignationResolutionNumber = designationResolutionNumber;
            DesignationResolutionDate = designationResolutionDate;
            DesignationIssue = designationIssue;
            ContractDateFrom = contractDateFrom;
            ContractDateTo = contractDateTo;
            //ContractDuration = contractDuration;
            DelegationDate = delegationDate;
            DelegationSide = delegationSide;
            //DelegationResolutionNumber = delegationResolutionNumber;
            TransferDate = transferDate;
            TransferSide = transferSide;
            LoaningDate = loaningDate;
            LoaningSide = loaningSide;
            BenefitFromServicesDate = benefitFromServicesDate;
            BenefitFromServicesSide = benefitFromServicesSide;
            EmptiedDate = emptiedDate;
            EmptiedSide = emptiedSide;
            CollaboratorDate = collaboratorDate;
            CollaboratorSide = collaboratorSide;
        }
        internal EmploymentValues(JobInfo jobInfo)
        {
            JobInfo = jobInfo;
        }
        public JobInfo JobInfo { get; set; }
        public string DesignationResolutionNumber { get; set; } // رقم القرار للتعيين
        public DateTime? DesignationResolutionDate { get; set; }// تاريح القرار للتعيين
        public string DesignationIssue { get; set; } // جهة الصدور للتعيين
        public DateTime? ContractDateFrom { get; set; }// تاريخ العقد من
        public DateTime? ContractDateTo { get; set; }// تاريخ العقد الى 
        //public string ContractDuration { get; set; } //مدة العقد
        public DateTime? DelegationDate { get; set; }
        public string DelegationSide { get; set; }//جهة المنتدب منها
        //public string DelegationResolutionNumber { get; set; }// رقم القرار للندب
        public DateTime? TransferDate { get; set; }
        public string TransferSide { get; set; }
        public DateTime? LoaningDate { get; set; }
        public string LoaningSide { get; set; }
        public DateTime? BenefitFromServicesDate { get; set; }
        public string BenefitFromServicesSide { get; set; }
        public DateTime? EmptiedDate { get; set; }
        public string EmptiedSide { get; set; }
        public DateTime? CollaboratorDate { get; set; }
        public string CollaboratorSide { get; set; }
    }
}