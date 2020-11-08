
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public class EmployeeReportDto

    {

        public IList<CurrentSituationListItem> CurrentSituationList { get; set; } = new List<CurrentSituationListItem>();
        public string DateOfAppointmentDecision { get; set; }
        public string EnglishName { get; set; }
        public int ChildrenCount { get; set; }
        public int ID { get; set; }
        public int ISadvanse { get; set; }


        public string  bloodType { get; set; }
        public int EvaluationDate2 { get; set; }
        public int EvaluationDate3 { get; set; }
        public int BankID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Islegal { get; set; }
        public int IsEndJob { get; set; }
        public bool ISsubsended { get; set; }

        public int EvaluationDate { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandfatherName { get; set; }
        public string LastName { get; set; }
        public string EnglishFirstName { get; set; }
        public string EnglishFatherName { get; set; }
        public string EnglishGrandfatherName { get; set; }
        public string EnglishLastName { get; set; }
        public string MotherName { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? BirthDateFrom { get; set; }
        public DateTime? BirthDateTo { get; set; }
        public string BirthPlace { get; set; }
        public string NationalNumber { get; set; }
        public Religion? Religion { get; set; }
        public int NationalityId { get; set; }
        public int BranchId { get; set; }
        public int PlaceId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public SocialStatus? SocialStatus { get; set; }
        public int ChildernCount { get; set; }
        public LibyanOrForeigner? LibyanOrForeigner { get; set; }
        public BloodType? BloodType { get; set; }
        public string BookletNumber { get; set; }
        public string BookletFamilyNumber { get; set; }
        public string BookletRegistrationNumber { get; set; }
        public DateTime? BookletIssueDate { get; set; }
        public string BookletIssuePlace { get; set; }
        public string BookletCivilRegistry { get; set; }
        public string PassportNumber { get; set; }
        public string PassportAutoNumber { get; set; }
        public DateTime? PassportIssueDateFrom { get; set; }
        public DateTime? PassportIssueDateTo { get; set; }
        public string PassportIssuePlace { get; set; }
        public string IdentificationCardNumber { get; set; }
        public DateTime? IdentificationCardIssueDateFrom { get; set; }
        public DateTime? IdentificationCardIssueDateTo { get; set; }
        public string IdentificationCardIssuePlace { get; set; }
        public string ContactInfoPhone { get; set; }
        public string ContactInfoNote { get; set; }
        public string ContactInfoNearKindr { get; set; }
        public string ContactInfoRelativeRelation { get; set; }
        public string ContactInfoNearPoint { get; set; }
        public string ContactInfoAddress { get; set; }
        public string ContactInfoWorkAddress { get; set; }
        public DateTime? DirectlyDateFrom { get; set; } // تاريخ المباشرة
        public DateTime? DirectlyDateTo { get; set; } // تاريخ المباشرة
        public int Degree { get; set; } // درجة التوظيف
        public int JobId { get; set; }
        public JobType? JobType { get; set; }
        public string JobNumber { get; set; }
   
        public int JobNumberInt { get; set; } // الرقم الوظيفي 
        // الرقم الوظيفي 
        public int JobNumberApproved { get; set; } // ر.و لدى الملاك الوظيفي
        public int CurrentSituationId { get; set; }
        public int UnitId { get; set; }
        public int DivisionId { get; set; }
        public int DepartmentId { get; set; }
        public int DegreeNow { get; set; }
        public DateTime? DateDegreeNowFrom { get; set; } // تاريخ الدرجة
        public DateTime? DateDegreeNowTo { get; set; } // تاريخ الدرجة
        public int DegreeLastResolutionNumber { get; set; }// رقم قرار اخر درجة
        public DateTime? DateMeritDegreeNowFrom { get; set; } // تاريخ استحقاق الدرجة
        public DateTime? DateMeritDegreeNowTo { get; set; } // تاريخ استحقاق الدرجة
        public int Bouns { get; set; } // العلاوات
        public DateTime? DateBounsFrom { get; set; } // تاريخ العلاوة
        public DateTime? DateBounsTo { get; set; } // تاريخ العلاوة
        public DateTime? DateMeritBouns { get; set; } // تاريخ استحقاق العلاوة
        public int AdjectiveEmployeeId { get; set; }
        public int AdjectiveEmployeeTypeId { get; set; }
        public int StaffingId { get; set; }
        public int StaffingTypeId { get; set; }
        public int CenterId { get; set; }
        public int ClassificationOnSearchingId { get; set; }
        public int ClassificationOnWorkId { get; set; }
        public int VacationBalance { get; set; }
        public string JobInfoNotes { get; set; }
        public AdjectiveMilitary? AdjectiveMilitary { get; set; }
        public string MilitaryNumber { get; set; }
        public string Subunit { get; set; }
        public string Rank { get; set; }
        public DateTime? GranduationDateFrom { get; set; }
        public DateTime? GranduationDateTo { get; set; }
        public string MotherUnit { get; set; }
        public string College { get; set; }
    }

    //public class CurrentSituationListItem
    //{
    //    public int CurrentSituationId { get; set; }
    //    public string Name { get; set; }
    //    public bool IsSelected { get; set; }
    //}
}