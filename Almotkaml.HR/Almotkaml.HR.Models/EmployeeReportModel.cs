using Almotkaml.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;
using System;

namespace Almotkaml.HR.Models
{
    public class EmployeeReportModel

    {
        public IEnumerable<EmployeeCheck> ee { get; set; } = new HashSet<EmployeeCheck> ();
         public class EmployeeCheck
        {
            public bool LibyanOrForeignerCheck { get; set; }

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
            public bool BouncDateFromCheck { get; set; }
            public bool BouncDateToCheck { get; set; }
            public bool BouncMtriDatefromCheck { get; set; }
            public bool BouncMtriDateToCheck { get; set; }
            public bool DegreeCheck { get; set; }
            public bool DegreeNowCheck { get; set; }
            public bool EvaluationCheck { get; set; }

            public bool DirectlydateFromCheck { get; set; }
            public bool DirectlyDatetoCheck { get; set; }
            public bool ContracetDatetoCheck { get; set; }
            public bool NotesCheck { get; set; }
            public bool BranchCheck { get; set; }
            public bool GenderCheck { get; set; }
            public bool NationalityNumberCheck { get; set; }
            public bool IdentityCardPlaceCheck { get; set; }
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
            /// <summary>
            /// //
            /// </summary>
            public bool AdressClosestCheck { get; set; }
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
            public bool ContracetDateFromCheck { get; set; }
        }
        public class QualificationTypeListItem2
        {
            public int QualificationTypeId { get; set; }
            public string Name { get; set; }
        }
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
        public bool AgeFromTo { get; set; }

        public bool AddressCheck { get; set; }
        public bool MunicipalBranchCheck { get; set; }
        public bool StreetCheck { get; set; }
        public bool NameMotherCheck { get; set; }
        public bool ForgenCheck { get; set; }

        public bool BouncCheck { get; set; }
        public bool BouncDateFromCheck { get; set; }
        public bool BouncDateToCheck { get; set; }
        public bool BouncMtriDatefromCheck { get; set; }
        public bool BouncMtriDateToCheck { get; set; }
        public bool DegreeCheck { get; set; }
        public bool DegreeNowCheck { get; set; }
        public bool EvaluationCheck { get; set; }

        public bool DirectlydateFromCheck { get; set; }
        public bool DirectlyDatetoCheck { get; set; }
        public bool ContracetDatetoCheck { get; set; }
        public bool NotesCheck { get; set; }
        public bool BranchCheck { get; set; }
        public bool GenderCheck { get; set; }
        public bool NationalityNumberCheck { get; set; }
        public bool IdentityCardPlaceCheck { get; set; }
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
        /// <summary>
        /// //
        /// </summary>
        public bool cityCheck { get; set; }
        public bool EndedEmpCheck { get; set; }
        /// 
        public bool PlaceCheck { get; set; }

        public bool AdressClosestCheck { get; set; }
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
        public bool ContracetDateFromCheck { get; set; }
        public IEnumerable<EmployeeReportGridRow> Grid { get; set; } = new HashSet<EmployeeReportGridRow>();
        public IEnumerable<ManPowerReportGridRow> ManPowerReportGrid { get; set; } = new HashSet<ManPowerReportGridRow>();
        public IEnumerable<QualificationTypeListItem2> QualificationTypeList { get; set; } =
            new HashSet<QualificationTypeListItem2>();
        public int? QualificationTypeId { get; set; }
        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.QualificationType))]
        public string Name { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.FirstName))]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.FatherName))]
        public string FatherName { get; set; }

        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.GrandfatherName))]
        
        public string GrandfatherName { get; set; }
        [Display(ResourceType = typeof(Title),
        Name = nameof(Title.NameReport))]
        public string NameReport { get; set; }
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.LastName))]
        public string LastName { get; set; }
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.EnglishFirstName))]
        public string EnglishFirstName { get; set; }

        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.EnglishFatherName))]
        public string EnglishFatherName { get; set; }

        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.EnglishGrandfatherName))]
        public string EnglishGrandfatherName { get; set; }

        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.EnglishLastName))]
        public string EnglishLastName { get; set; }

        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.MotherName))]
        public string MotherName { get; set; }

        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Gender))]
        public Gender? Gender { get; set; }

        [Date]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.BirthDateFrom))]
        public string BirthDateFrom { get; set; }
        [Date]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.BirthDateTo))]
        public string BirthDateTo { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.BirthPlace))]
        public string BirthPlace { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.NationalNumber))]
        public string NationalNumber { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Religion))]
        public Religion? Religion { get; set; }
        public IEnumerable<NationalityListItem> NationalityList { get; set; } = new HashSet<NationalityListItem>();

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Nationality))]
        public int? NationalityId { get; set; }

        public IEnumerable<BranchListItem> BranchList { get; set; } = new HashSet<BranchListItem>();

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Branch))]
        public int? BranchId { get; set; }

        public IEnumerable<PlaceListItem> PlaceList { get; set; } = new HashSet<PlaceListItem>();

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Place))]
        public int? PlaceId { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Address))]
        public string Address { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Phone))]
        public string Phone { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Email))]
        public string Email { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.SocialStatus))]
        public SocialStatus? SocialStatus { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.ChildernCount))]
        public int? ChildernCount { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.LibyanOrForeigner))]
        public LibyanOrForeigner? LibyanOrForeigner { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BloodType))]
        public BloodType? BloodType { get; set; }
        public BookletModel Booklet { get; set; }
        public PassportModel Passport { get; set; }
        public IdentificationCardModel IdentificationCard { get; set; }
        public ContactInfoModel ContactInfo { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ClampDegree))]
        public ClampDegree? ClampDegree { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ClampDegree))]
        public ClampDegree? ClampDegreeNow { get; set; }
        public EmploymentValuesModel EmploymentValues { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SalayClassification))]
        public SalayClassification? SalayClassification { get; set; }
        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DirectlyDateFrom))]
        public string DirectlyDateFrom { get; set; } // تاريخ المباشرة
        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DirectlyDateTo))]
        public string DirectlyDateTo { get; set; } // تاريخ المباشرة
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Degree))]
        public int? Degree { get; set; } // درجة التوظيف
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Job))]
        public int? JobId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobType))]
        public JobType JobType { get; set; }
        public IEnumerable<JobListItem> JobList { get; set; } = new HashSet<JobListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobNumber))]
        public string JobNumber { get; set; } // الرقم الوظيفي 
      //  public IEnumerable<JobListItem> JobList { get; set; } = new HashSet<JobListItem>();
      
        public int? JobNumberApproved { get; set; } // ر.و لدى الملاك الوظيفي
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CurrentSituationId))]
        public int? CurrentSituationId { get; set; }
        public IEnumerable<CurrentSituationListItem> CurrentSituationList { get; set; } =
            new HashSet<CurrentSituationListItem>();
        public IList<CurrentSituationListItem> CurrentSituationList2 { get; set; } =
        new List<CurrentSituationListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Unit))]
        public int? UnitId { get; set; }
        public IEnumerable<UnitListItem> UnitList { get; set; } = new HashSet<UnitListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Division))]
        public int? DivisionId { get; set; }
        public IEnumerable<DivisionListItem> DivisionList { get; set; } = new HashSet<DivisionListItem>();


        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Department))]
        public int? DepartmentId { get; set; }

        public IEnumerable<DepartmentListItem> DepartmentList { get; set; } = new HashSet<DepartmentListItem>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.DegreeNow))]
        public int? DegreeNow { get; set; }
        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateDegreeNowFrom))]
        public string DateDegreeNowFrom { get; set; } // تاريخ الدرجة
        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateDegreeNowTo))]
        public string DateDegreeNowTo { get; set; } // تاريخ الدرجة
        public int? DegreeLastResolutionNumber { get; set; }// رقم قرار اخر درجة
        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateMeritDegreeNowFrom))]
        public string DateMeritDegreeNowFrom { get; set; } // تاريخ استحقاق الدرجة
        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateMeritDegreeNowTo))]
        public string DateMeritDegreeNowTo { get; set; } // تاريخ استحقاق الدرجة

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Bouns))]
        public int? Bouns { get; set; } // العلاوات

        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateBounsFrom))]
        public string DateBounsFrom { get; set; } // تاريخ العلاوة
        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateBounsTo))]
        public string DateBounsTo { get; set; } // تاريخ العلاوة
        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateMeritBounsFrom))]
        public string DateMeritBounsFrom { get; set; } // تاريخ استحقاق العلاوة
        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateMeritBounsTo))]
        public string DateMeritBounsTo { get; set; } // تاريخ استحقاق العلاوة
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AdjectiveEmployee))]
        public int? AdjectiveEmployeeId { get; set; }
        public IEnumerable<AdjectiveEmployeeListItem> AdjectiveEmployeeList { get; set; }
            = new HashSet<AdjectiveEmployeeListItem>();
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.AdjectiveEmployeeType))]
        public int? AdjectiveEmployeeTypeId { get; set; }

        public IEnumerable<AdjectiveEmployeeTypeListItem> AdjectiveEmployeeTypeList { get; set; }
            = new HashSet<AdjectiveEmployeeTypeListItem>();
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Staffing))]
        public int? StaffingId { get; set; }
        public IEnumerable<StaffingListItem> StaffingList { get; set; } = new HashSet<StaffingListItem>();
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.StaffingType))]
        public int? StaffingTypeId { get; set; }
        public IEnumerable<StaffingTypeListItem> StaffingTypeList { get; set; } = new HashSet<StaffingTypeListItem>();
        public IEnumerable<NoteListItem> NoteList { get; set; } = new HashSet<NoteListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Center))]
        public int? CenterId { get; set; }
        public IEnumerable<CenterListItem> CenterList { get; set; } = new HashSet<CenterListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ClassificationOnSearching))]
        public int? ClassificationOnSearchingId { get; set; }
        public IEnumerable<ClassificationOnSearchingListItem> ClassificationOnSearchingList { get; set; }
            = new HashSet<ClassificationOnSearchingListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ClassificationOnWork))]
        public int? ClassificationOnWorkId { get; set; }
        public IEnumerable<ClassificationOnWorkListItem> ClassificationOnWorkList { get; set; }
            = new HashSet<ClassificationOnWorkListItem>();
        public IEnumerable<QualificationTypeListItem> QualificationTypeList2 { get; set; } =
                 new HashSet<QualificationTypeListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationBalance))]
        public int? VacationBalance { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Notes))]
        public string Notes { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.AdjectiveMilitary))]
        public AdjectiveMilitary AdjectiveMilitary { get; set; }


        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.MilitaryNumber))]
        public string MilitaryNumber { get; set; }


        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Subunit))]
        public string Subunit { get; set; }


        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Rank))]
        public string Rank { get; set; }

        [Date]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.GranduationDateFrom))]
        public string GranduationDateFrom { get; set; }
        [Date]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.GranduationDateTo))]
        public string GranduationDateTo { get; set; }


        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.MotherUnit))]
        public string MotherUnit { get; set; }


        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.College))]
        public string College { get; set; }
        [Display(ResourceType = typeof(Title),
        Name = nameof(Title.IdentificationCardIssueDateFrom))]
        public string IdentificationCardIssueDateFrom { get; set; }
        [Display(ResourceType = typeof(Title),
        Name = nameof(Title.IdentificationCardIssueDateTo))]
        public string IdentificationCardIssueDateTo { get; set; }
        [Display(ResourceType = typeof(Title),
        Name = nameof(Title.PassportIssueDateFrom))]
        public string PassportIssueDateFrom { get; set; }
        [Display(ResourceType = typeof(Title),
        Name = nameof(Title.PassportIssueDateTo))]
        public string PassportIssueDateTo { get; set; }
        [Display(ResourceType = typeof(Title),
      Name = nameof(Title.Evaluation))]
        public string Evaluation { get; set; }
        [Display(ResourceType = typeof(Title),
      Name = nameof(Title.EvaluationDate))]
        public int? EvaluationDate { get; set; }
        [Display(ResourceType = typeof(Title),
     Name = nameof(Title.EvaluationDate2))]
        public int? EvaluationDate2 { get; set; }
        [Display(ResourceType = typeof(Title),
    Name = nameof(Title.EvaluationDate3))]
        public int? EvaluationDate3 { get; set; }
        public Grade grade { get; set; }

        public string NationaltyMother { get; set; }
        public bool NationaltyMotherCheck { get; set; }
        public string DonorFoundation { get; set; }
        public bool DonorFoundationCheck { get; set; }
        public bool EvaloitionDateCheck { get; set; }
        public bool EvaloitionDateCheck2 { get; set; }
        public bool EvaloitionDateCheck3 { get; set; }

    }

    public class EmployeeReportGridRow
    {
        public string TafKeet { get; set; }
        public string word { get; set; }
        public string Date { get; set; }
        public decimal Value { get; set; }
        public decimal Rest { get; set; }
        public decimal InstallmentValue { get; set; }
        public string DeductionDate { get; set; }

        public string IsclodseMessage { get; set; }
        public string DateSubsended { get; set; }
        public string dateSalary { get; set; }

        public bool Isubsended { get; set; }
        public SalaryPremiumListItem salarypremium { get; set; }
        //public TemSalaryPremiumListItem salarypremium { get; set; }
        public DiscountOrBoun DiscountOrBoun { get; set; }
        public string PremiumumName { get; set; }
        public decimal ValuePremiumum { get; set; }
        public string DiscountName { get; set; }
        public decimal ValueDiscountm { get; set; }
        public int AdvancePaymentId { get; set; }
        public int choldrenCount { get; set; }
       
        public decimal SocialSecurityFund { get; set; }
        public int Boun { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal MawadaFund { get; set; }
        public string AdvancePaymentName { get; set; }
        public decimal AdvancePaymentValue { get; set; }
        public decimal SalaryTotal { get; set; }
        public decimal TaxSum { get; set; }
        public string DateSalary { get; set; }

        public decimal FinalSalaryLegal { get; set; }

        public decimal AdvancePaymentOutside { get; set; }
        public decimal AdvancePaymentInside { get; set; }
        public GuaranteeType GuaranteeType { get; set; }
        public decimal AdvancePremium { get; set; }
        public decimal ShareSum { get; set; }
        public string CostCenterName { get; set; }
        public int CostCenterId { get; set; }
        public string Tafkeet { get; set; }
        public decimal SituationOnNet { get; set; }
        public int EmployeeStat { get; set; }
        public decimal ExtraWorkConst { get; set; }
        public decimal SituationOnTotal { get; set; }
        public int BankBranchId { get; set; }
        public int BankId { get; set; }
        public string JobNumber { get; set; }
     
        public string EmployeeID { get; set; }
        public int JobNumberAdvance { get; set; }

        public string Name { get; set; }
        public decimal SafeShare { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Absence { get; set; }
        public decimal SickVacation { get; set; }
        public decimal WithoutPay { get; set; }
        public decimal Sanction { get; set; }
        public decimal ExtraWork { get; set; }
        public decimal ExtraWorkVacation { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal SolidarityFund { get; set; }
        public decimal EmployeeShare { get; set; }
        public decimal CompanyShare { get; set; }
        public decimal SubjectSalary { get; set; }
        public decimal JihadTax { get; set; }
        public decimal IncomeTax { get; set; }                 // ضريبة الدخل
        public decimal GroupLife { get; set; }                       //الحياة الجماعي
        public decimal AdvancePayment { get; set; }               // السلف
        public decimal ExemptionTax { get; set; }
        public decimal PrepaidSalary { get; set; }
        public decimal AdvancePremiumInside { get; set; }
        public decimal AdvancePremiumOutside { get; set; }
        public decimal NetSalary { get; set; }
        public decimal StampTax { get; set; }
        public string BounName { get; set; }
        public decimal BounValue { get; set; }
        public string SecurityNumber { get; set; }
        public string FinancialNumber { get; set; }
        public decimal ExtraWorkFixed { get; set; }
        public decimal ExtraGeneralValue { get; set; }
        public decimal ExtraValue { get; set; }
        public string BondNumber { get; set; }
        public string EmployeeName { get; set; }
        public decimal FinalSalaryCertified { get; set; }

        public string BankName { get; set; }

        public decimal FinalySalary { get; set; }
        public string BankBranchName { get; set; }
        public int EvaluationDate { get; set; }
        public int EvaluationDate2 { get; set; }
        public int EvaluationDate3 { get; set; }

        public string NationaltyMother { get; set; }
        public string BookFamilySourceNumber { get; set; }

        public DateTime? DateQualification { get; set; }
        public string DegreeNote { get; set; }
        public string DonorFoundation { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public Grade Evaluation { get; set; }
        public Grade Evaluation2 { get; set; }
        public Grade Evaluation3 { get; set; }
        public double EvaluationRatio { get; set; }
        public double EvaluationRatio2 { get; set; }
        public double EvaluationRatio3 { get; set; }
        public string QualificationTypeId { get; set; }

        public string Qualification { get; set; }
        public string EnglishFirstName { get; set; }
        public string EnglishLastName { get; set; }
        public string FatherName { get; set; }
        public string FirstName { get; set; }
        public string GrandfatherName { get; set; }
        public string LastName { get; set; }
        public string EnglishFatherName { get; set; }
        public string EnglishGrandfatherName { get; set; }
        public string MotherName { get; set; }
        public Gender Gender { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string NationalNumber { get; set; }
        public Religion Religion { get; set; }
        public string NationalityName { get; set; }
        public string BranchName { get; set; }
        public string PlaceName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public SocialStatus SocialStatus { get; set; }
        public int ChildernCount { get; set; }
        public LibyanOrForeigner LibyanOrForeigner { get; set; }
        public BloodType BloodType { get; set; }
        public string BookletNumber { get; set; }
        public string BookletFamilyNumber { get; set; }
        public string BookletRegistrationNumber { get; set; }
        public string BookletIssueDate { get; set; }
        public string BookletIssuePlace { get; set; }
        public string BookletCivilRegistry { get; set; }
        public string PassportNumber { get; set; }
        public string PassportAutoNumber { get; set; }
        public string PassportIssueDate { get; set; }
        public string PassportIssuePlace { get; set; }
        public string IdentificationCardNumber { get; set; }
        public string IdentificationCardIssueDate { get; set; }
        public string IdentificationCardIssuePlace { get; set; }
        public string ContactInfoPhone { get; set; }
        public string ContactInfoNote { get; set; }
        public string ContactInfoNearKindr { get; set; }
        public string ContactInfoRelativeRelation { get; set; }
        public string ContactInfoNearPoint { get; set; }
        public string ContactInfoAddress { get; set; }
        public string ContactInfoWorkAddress { get; set; }
        public string DirectlyDate { get; set; } // تاريخ المباشرة
        public int Degree { get; set; } // درجة التوظيف
        public string JobName { get; set; }
        public JobType JobType { get; set; }
        public int JobNumberApproved { get; set; } // ر.و لدى الملاك الوظيفي
        public string CurrentSituationName { get; set; }
        public string UnitName { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
        public int DegreeNow { get; set; }
        public string DateDegreeNow { get; set; } // تاريخ الدرجة
        public int DegreeLastResolutionNumber { get; set; }// رقم قرار اخر درجة
        public string DateMeritDegreeNow { get; set; } // تاريخ استحقاق الدرجة
        public int Bouns { get; set; } // العلاوات
        public int Bounshr { get; set; } // العلاوات

        public string DateBouns { get; set; } // تاريخ العلاوة
        public string DateMeritBouns { get; set; } // تاريخ استحقاق العلاوة
        public string AdjectiveEmployeeName { get; set; }
        public string AdjectiveEmployeeTypeName { get; set; }
        public string StaffingName { get; set; }
        public string StaffingTypeName { get; set; }
        public string CenterName { get; set; }
        public string ClassificationOnSearchingName { get; set; }
        public string ClassificationOnWorkName { get; set; }
        public int VacationBalance { get; set; }
        public string JobInfoNotes { get; set; }
        public AdjectiveMilitary AdjectiveMilitary { get; set; }
        public string MilitaryNumber { get; set; }
        public string Subunit { get; set; }
        public string Rank { get; set; }
        public string GranduationDate { get; set; }
        public string MotherUnit { get; set; }
        public string College { get; set; }
        public string DateOfAppointmentDecision { get; set; }   // تاريخ قرار التعين
        public string NumberOfAppointmentDecision { get; set; } // رقم قرار التعين

        public decimal Clamp { get; set; }                        //هيئات قضائية
        public decimal Subsistence { get; set; }                       // اعاشة
        public decimal Premium { get; set; }                  //مكافئات

        public decimal AccumulatedValue { get; set; } //المتراكم

        public decimal RewindValue { get; set; } //الترجيع
        public decimal Discound { get; set; }
        public decimal AllBouns { get; set; }
        public IEnumerable<PremiumCheckListItemReport> PremiumListReport { get; set; } = new HashSet<PremiumCheckListItemReport>();


    }

    public class ManPowerReportGridRow
    {
        public string AdjectiveEmployeeType { get; set; }
        //ملاك فني
        public int PhDCount { get; set; }
        public int MasterCount { get; set; }
        public int DiplomaCount { get; set; }
        public int EngCount { get; set; }
        public int AssistantCount { get; set; }
        public int CraftsmanCount { get; set; }
        public int OperationalCount { get; set; }
        //ملاك إداري
        public int AdministrativeCount { get; set; }
        public int WriterAdmCount { get; set; }
        public int FinancialCount { get; set; }
        public int BookkeeperCount { get; set; }
        public int JuristCount { get; set; }
        //الخدمات العامة
        public int AlternateCount { get; set; }
        public int DailyTimeCount { get; set; }
        public int OccSafEngCount { get; set; }//مهندسون سلامة مهنية
        public int TechnicalSafEngCount { get; set; }//فني سلامة مهنية
        //الخدمات العامة الحرفية
        public int literalityEngCount { get; set; }//مهندسون الخدمات الحرفية
        public int AssistantlitCountCount { get; set; }//مساعد الخدمات الحرفية
        public int OperationallitCount { get; set; }//تشغيلي الخدمات الحرفية
        public int ServicesCount { get; set; }
        //الملاك من المدنيون و العسكريون
        public int OfficerCount { get; set; }
        public int WarrantOfficerCount { get; set; }
        public int SoldiersCount { get; set; }
        public int CMilitaryACount { get; set; }//مدنيون يتقاضون مرتباتهم من حسابات عسكرية
        public int CStandardACount { get; set; }//مدنيون يتقاضون مرتباتهم من وزارة المالية

    }
}