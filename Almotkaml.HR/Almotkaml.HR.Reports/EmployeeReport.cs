using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Reports
{
    public class EmployeeReport
    {
        public string TafKeet { get; set; }

        public string Date { get; set; }
        public decimal Value { get; set; }
        public decimal Rest { get; set; }
        public decimal InstallmentValue { get; set; }
        public string DeductionDate { get; set; }
        public string EmployeeName { get; set; }


        public bool DegreeNoteCheck { get; set; }

        public int EvaluationDate2 { get; set; }
        public int EvaluationDate3 { get; set; }
        public bool EvaloitionDateCheck2 { get; set; }
        public bool EvaloitionDateCheck3 { get; set; }
        public int Id { get; set; }

        public bool BookFamilySourceNumberCheck { get; set; }
        public bool BirthPlaseCheck { get; set; }
        public bool EvaluationCheck { get; set; }
        public bool EvaluationDateCheck { get; set; }
        public string Evaluation2 { get; set; }
        public string Evaluation3 { get; set; }

        // public string staffingTypeid { get; set; }


        public string Evaluation { get; set; }
        public int EvaluationDate { get; set; }

        public DateTime? DateQualification { get; set; }

        public string DonorFoundation { get; set; }

        public string Specialty { get; set; }

        public string Qualification { get; set; }
        public string WorkPlase { get; set; }
        public string BirthPlase { get; set; }
        public string FullName { get; set; }
        public string DegreeNote { get; set; }
        public string NationaltyMother { get; set; }

        public string BookFamilySourceNumber { get; set; }
        public bool DateQualificationCheck { get; set; }

        public bool DonorFoundationCheck { get; set; }

        public bool SpecialtyCheck { get; set; }
        public bool degreeMtriDateCheck { get; set; }

        public bool QualificationCheck { get; set; }
        public bool FirstNameCheck { get; set; }
        public bool FatherNameCheck { get; set; }
        public bool GrenFtherCheck { get; set; }
        public bool LastNameCheck { get; set; }
        public bool FirstEnglishCheck { get; set; }
        public bool FatherEnglishCheck { get; set; }
        public bool GreanFatherEnglishCheck { get; set; }
        public bool LastEnglishCheck { get; set; }
        public bool NatinalityCheck { get; set; }
        public bool PalceBirthCheck { get; set; }
        public bool FormBirthCheck { get; set; }
        public bool ToBirthCheck { get; set; }
        public bool AddressCheck { get; set; }
        public bool MunicipalBranchCheck { get; set; }
        public bool StreetCheck { get; set; }
        public bool NameMotherCheck { get; set; }
        public bool ForgenCheck { get; set; }
        public bool BouncCheck { get; set; }
        public bool BouncCheckhr { get; set; }
        public bool BouncCheckDatehr { get; set; }
        public bool BouncDateFromCheck { get; set; }
        public bool BouncDateToCheck { get; set; }
        public bool BouncMtriDatefromCheck { get; set; }
        public bool BouncMtriDateToCheck { get; set; }
        public bool DegreeCheck { get; set; }
        public bool DegreeNowCheck { get; set; }

        public bool DirectlydateFromCheck { get; set; }
        public bool DirectlyDatetoCheck { get; set; }
        public bool ContracetDatetoCheck { get; set; }
        public bool NotesCheck { get; set; }
        public bool BranchCheck { get; set; }
        public bool GenderCheck { get; set; }
        public bool NationalityNumberCheck { get; set; }
        public bool ReligionCheck { get; set; }
        public bool SocialStatusCheck { get; set; }
        public bool ChildrenCheck { get; set; }
        public bool bloodTypeCheck { get; set; }
        public bool PhoneCheck { get; set; }
        public bool EmailCheck { get; set; }
        public bool IdentiyCardNumberCheck { get; set; }
        public bool IdentityDateCheck { get; set; }
        public bool IednttySourcePlaceCheck { get; set; }
        public bool PassportCheck { get; set; }
        public bool AutomatedFigureCheck { get; set; }
        public bool BirthDateCheck { get; set; }
        public bool PassportDateCheck { get; set; }
        public bool PassportSourcePlaceCheck { get; set; }
        public bool BookFamilyNumberCheck { get; set; }
        public bool EnrollmentNumberCheck { get; set; }
        public bool BoohFamilyNumberPaperCheck { get; set; }
        public bool BookFamilyDateCheck { get; set; }
        public bool BookFamilySourcePlaceCheck { get; set; }
        public bool CivilRegistryCheck { get; set; }
        public bool TheClosestRelativesCheck { get; set; }
        public bool RelativeRelationCheck { get; set; }
        public bool AdressCheck { get; set; }
        public bool WorkPlaceCheck { get; set; }
        public bool TheClosestAccessPointCheck { get; set; }
        public bool PhoneNumberClosestCheck { get; set; }
        public bool NotesClosestCheck { get; set; }
        public bool JobNumberCheck { get; set; }
        public bool CenterCheck { get; set; }
        public bool MangementCheck { get; set; }
        public bool DivisionCheck { get; set; }
        public bool UnitCheck { get; set; }
        public bool JobTitleCheck { get; set; }
        public bool TypeOfEmployerCheck { get; set; }
        public bool EmployerCheck { get; set; }
        public bool TypeJobCheck { get; set; }
        public bool TypeOfClassificationByOwnersCheck { get; set; }
        public bool ClassificationByOwnersCheck { get; set; }
        public bool ClassificationBasedOnThelistOfresearchersCheck { get; set; }
        public bool ClassificationBasedOnlaborlawCheck { get; set; }
        public bool CurrentSituationCheck { get; set; }
        public bool BalanceOfleaveCheck { get; set; }
        public bool IssuancOftheapointmentCheck { get; set; }
        public bool NumberOfAppointmentDecisionCheck { get; set; }
        public bool DateOfAppointmentDecisionCheck { get; set; }
        public bool SalaryClassificationCheck { get; set; }
        public bool ContracetDateCheck { get; set; }

        public bool SecurityCardNumberCheck { get; set; }

        public bool DateDegreeNowCheck { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrenFther { get; set; }
        public string LastName { get; set; }
        public string FirstEnglish { get; set; }
        public string FatherEnglish { get; set; }
        public string GreanFatherEnglish { get; set; }
        public string LastEnglish { get; set; }
        public string Natinality { get; set; }
        public string PalceBirth { get; set; }
        public DateTime FormBirth { get; set; }
        public DateTime ToBirth { get; set; }
        public string Address { get; set; }
        public string MunicipalBranch { get; set; }
        public string Street { get; set; }
        public string NameMother { get; set; }
        public string Forgen { get; set; }
        public int Bounc { get; set; }
        public int Bounchr { get; set; }
        public int BouncDatehr { get; set; }
        public string BirthDate { get; set; }
        public string BouncDateFrom { get; set; }
        public DateTime BouncDateTo { get; set; }
        public DateTime BouncMtriDatefrom { get; set; }
        public string degreeMtriDate { get; set; }
        public string BouncMtriDateTo { get; set; }
        public int Degree { get; set; }
        public int? DegreeNow { get; set; }

        public string DirectlydateFrom { get; set; }
        public DateTime DirectlyDateto { get; set; }
        public DateTime ContracetDateto { get; set; }
        public string Notes { get; set; }
        public string Branch { get; set; }
        public string Gender { get; set; }
        public string NationalityNumber { get; set; }
        public Religion Religion { get; set; }
        public string SocialStatus { get; set; }
        public int Children { get; set; }
        public string bloodType { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IdentiyCardNumber { get; set; }
        public string IdentityDate { get; set; }
        public string IednttySourcePlace { get; set; }
        public string Passport { get; set; }
        public string AutomatedFigure { get; set; }
        public string PassportDate { get; set; }
        public string PassportSourcePlace { get; set; }
        public string BookFamilyNumber { get; set; }
        public string EnrollmentNumber { get; set; }
        public string BoohFamilyNumberPaper { get; set; }
        public string BookFamilyDate { get; set; }
        public string BookFamilySourcePlace { get; set; }
        public string CivilRegistry { get; set; }
        public string TheClosestRelatives { get; set; }
        public string RelativeRelation { get; set; }
        public string Adress { get; set; }
        public string WorkPlace { get; set; }
        public string TheClosestAccessPoint { get; set; }
        public string PhoneNumberClosest { get; set; }
        public string NotesClosest { get; set; }
        public string SecurityCardNumber { get; set; }

        public string DateDegreeNow { get; set; }
        public string JobNumber { get; set; }
        public string Center { get; set; }
        public string Mangement { get; set; }
        public string Division { get; set; }
        public string Unit { get; set; }
        public string JobTitle { get; set; }
        public string TypeOfEmployer { get; set; }
        public string Employer { get; set; }
        public string TypeJob { get; set; }
        public string TypeOfClassificationByOwners { get; set; }
        public string ClassificationByOwners { get; set; }
        public string ClassificationBasedOnThelistOfresearchers { get; set; }
        public string ClassificationBasedOnlaborlaw { get; set; }
        public string CurrentSituation { get; set; }
        public int BalanceOfleave { get; set; }
        public string IssuancOftheapointment { get; set; }
        public string NumberOfAppointmentDecision { get; set; }
        public string DateOfAppointmentDecision { get; set; }
        public string SalaryClassification { get; set; }
        public DateTime ContracetDate { get; set; }
    }
}
