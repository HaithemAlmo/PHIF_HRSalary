using Almotkaml.HR.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class EmployeeIndexModel
    {

        [Display(ResourceType = typeof(Title),
        Name = nameof(Title.Department))]
        public int? DepartmentId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CostCenter))]
        public int? CenterId { get; set; }
        public IEnumerable<CenterListItem> CenterList { get; set; } = new HashSet<CenterListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Unit))]
        public int? UnitId { get; set; }
        public IEnumerable<UnitListItem> UnitList { get; set; } = new HashSet<UnitListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Division))]
        public int? DivisionId { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
        public IEnumerable<DepartmentListItem> DepartmentList { get; set; } = new HashSet<DepartmentListItem>();
        public IEnumerable<DivisionListItem> DivisionList { get; set; } = new HashSet<DivisionListItem>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
    public class EmployeeGridRow
    {
        public int EmployeeId { get; set; }
        public string JobNumber { get; set; }
  
        public string ArabicFullName { get; set; }
        public string NationalNumber { get; set; }
        public string CenterName { get; set; }
        public string DepartmentName { get; set; }
    }
    public class EmployeeFormModel
    {
        public IEnumerable<CenterListItem> CenterList { get; set; } = new HashSet<CenterListItem>();

        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
        public IEnumerable<DepartmentListItem> DepartmentList { get; set; } = new HashSet<DepartmentListItem>();
        public IEnumerable<DivisionListItem> DivisionList { get; set; } = new HashSet<DivisionListItem>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public EmployeeIndexModel EmployeeIndexModel2 { get; set; } = new EmployeeIndexModel();
        public JobInfoDegreeModel JobInfoDegreeModel { get; set; } = new JobInfoDegreeModel();
        public JobInfoModel JobInfoModel { get; set; } = new JobInfoModel();
        public MilitaryDataModel MilitaryDataModel { get; set; } = new MilitaryDataModel();
        public PersonalModel PersonalModel { get; set; } = new PersonalModel();
        public DocumentModel DocumentModel { get; set; } = new DocumentModel();
        public QualificationModel QualificationModel { get; set; } = new QualificationModel();

        public SituationResolveJobModel SituationResolveJobModel { get; set; } = new SituationResolveJobModel();
        //public SalaryInfoModel SalaryInfoModel { get; set; }
    }
    public class PassportModel
    {
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Number))]
        public string Number { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.AutoNumber))]
        public string AutoNumber { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.IssueDate))]
        public string IssueDate { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.IssuePlace))]

        public string IssuePlace { get; set; }
        public string ExpirationDate { get; set; }
    }
    public class IdentificationCardModel
    {
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Number))]
        public string Number { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.IssueDate))]
        public string IssueDate { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.IssuePlace))]
        public string IssuePlace { get; set; }
    }
    public class BookletModel
    {

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Number))]
        public string Number { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.BookletFamilyNumber))]
        public string FamilyNumber { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.BookletRegistrationNumber))]
        public string RegistrationNumber { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.IssueDate))]
        public string IssueDate { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.IssuePlace))]
        public string IssuePlace { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.CivilRegistry))]
        public string CivilRegistry { get; set; }
    }
    public class ContactInfoModel
    {

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Phone))]
        public string Phone { get; set; }
        [Display(ResourceType = typeof(Title),
              Name = nameof(Title.Note))]
        public string Note { get; set; }
        [Display(ResourceType = typeof(Title),
               Name = nameof(Title.NearKindr))]
        public string NearKindr { get; set; }
        [Display(ResourceType = typeof(Title),
             Name = nameof(Title.RelativeRelation))]
        public string RelativeRelation { get; set; }
        [Display(ResourceType = typeof(Title),
             Name = nameof(Title.NearPoint))]
        public string NearPoint { get; set; }
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Address))]
        public string Address { get; set; }
        [Display(ResourceType = typeof(Title),
              Name = nameof(Title.WorkAddress))]
        public string WorkAddress { get; set; }
    }
    public class TemporaryPremmiumListItem
    {
        public int PremiumId { get; set; }
        public decimal Value { get; set; }
        public decimal AllValue { get; set; }
        public decimal PartOfvalue { get; set; }
        public int ISAdvance { get; set; }
        public int Valuinspect { get; set; }
        public int EmployeeId { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }

    }
    public class NotTemporaryPremmiumListE
    {
        public int PremiumId { get; set; }
        public decimal Value { get; set; }
        public decimal AllValue { get; set; }
        public decimal PartOfvalue { get; set; }
        public int ISAdvance { get; set; }
        public int Valuinspect { get; set; }
        public int EmployeeId { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }

    }
    public class EmployeePremiumListItem
    {
        public int PremiumId { get; set; }
        public decimal Value { get; set; }
        public decimal AllValue { get; set; }
        public decimal PartOfvalue { get; set; }
        public int ISAdvance { get; set; }
        public int Valuinspect { get; set; }
        public int EmployeeID { get; set; }

        public ISAdvancePremmium ISAdvancePremmium { get; set; }

    }
    public class EmployeeAdvancePymentListItem
    {



        //public int PremiumId { get; set; }
        //public decimal Value { get; set; }
       
        //public int EmployeeID { get; set; }

        //  public ISAdvancePremmium ISAdvancePremmium { get; set; }
      //  public int AdvancePaymentId { get; set; }
        public int EmployeeID { get; set; }
       // public Employee Employee { get; set; }
        public int PremiumId { get; set; }

       // public Premium Premium { get; set; }
        public decimal Value { get; set; }
        public decimal AllValue { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public IsFrozen IsFrozen { get; set; }

        //public DateTime DeductionDate { get; set; } // تاريخ بدء الخصم
        //public DateTime Date { get; set; } // تاريخ بدء الخصم
    }
}