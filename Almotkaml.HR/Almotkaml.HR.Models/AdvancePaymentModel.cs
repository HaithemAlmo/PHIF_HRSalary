using Almotkaml.HR.Models.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class AdvancePaymentModel
    {
        public int HiddenJobnumber { get; set; }

        public IEnumerable<CenterListItem> CenterList { get; set; } = new HashSet<CenterListItem>();
        public IEnumerable<DepartmentListItem> DepartmentList { get; set; } = new HashSet<DepartmentListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CostCenter))]
        public int? CenterId { get; set; }
        public IEnumerable<AdvancePaymentGridRow> AdvancePaymentGrid { get; set; } = new HashSet<AdvancePaymentGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int AdvancePaymentId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Unit))]
        public int? UnitId { get; set; }
        public IEnumerable<UnitListItem> UnitList { get; set; } = new HashSet<UnitListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Division))]
        public int? DivisionId { get; set; }
        public IEnumerable<DivisionListItem> DivisionList { get; set; } = new HashSet<DivisionListItem>();
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Department))]
        public int? DepartmentId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobNumber))]
        public string Jobnumber { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid = new HashSet<EmployeeGridRow>();
        public IEnumerable<EmployeeReportGridRow> Grid { get; set; } = new HashSet<EmployeeReportGridRow>();


        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string EmployeeName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Value))]
        public decimal Value { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.InstallmentValue))]
        public decimal InstallmentValue { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DeductionDate))]
        public string DeductionDate { get; set; } // تاريخ بدء الخصم

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Date))]
        public string Date { get; set; }


        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsInside))]
        public bool IsInside { get; set; }
        public AdvanceDetectionReportModel AdvanceDetectionReportModel { get; set; } = new AdvanceDetectionReportModel();
        public EmployeeAdvanceDetectionReportModel EmployeeAdvanceDetectionReportModel { get; set; }
                        = new EmployeeAdvanceDetectionReportModel();
        public IEnumerable<AdvanseNameListItem> AdvanseNameList { get; set; } = new HashSet<AdvanseNameListItem>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.NameAdvanse))]
        public int AdvanseNameID { get; set; }
    }
    public class AdvanseNameListItem
    {
        public int AdvanseNameID { get; set; }

        public string Name { get; set; }
    }
    public class Grid
    {
        public string EmployeeName { get; set; }
        public string jobNumber { get; set; }
        public string Center { get; set; }
        public string Div { get; set; }

    }
    public class AdvancePaymentGridRow
    {
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public int EmployeeID { get; set; }

        public int AdvancePaymentId { get; set; }
        public string EmployeeName { get; set; }
        public decimal Value { get; set; }
        public decimal AllValue { get; set; }
        public string PremiumName { get; set; }
        public string jobnumber { get; set; }

        public decimal InstallmentValue { get; set; }
        public string DeductionDate { get; set; } // تاريخ بدء الخصم
        public string IsInside { get; set; }
        public string Date { get; set; }
    }

}
