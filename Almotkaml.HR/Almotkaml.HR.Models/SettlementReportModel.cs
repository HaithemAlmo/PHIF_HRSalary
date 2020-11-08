using Almotkaml.Attributes;
using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class SettlementReportModel
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
        public IEnumerable<SettlementReportGridRow> Grid { get; set; } = new HashSet<SettlementReportGridRow>();
        [Date]
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles),
            Name = nameof(SharedTitles.FromDate))]
        public string DateFrom { get; set; }
        public IEnumerable<DepartmentListItem> DepartmentList { get; set; } = new HashSet<DepartmentListItem>();
        public IEnumerable<DivisionListItem> DivisionList { get; set; } = new HashSet<DivisionListItem>();
        [Date]
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles),
            Name = nameof(SharedTitles.ToDate))]
        public string DateTo { get; set; }
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Settlement))]
        public CauseOfEndService CauseOfEndService { get; set; }

        public string GetCauseOfEndService()
        {
            switch (CauseOfEndService)
            {
                case CauseOfEndService.Death:
                    return Title.Deaths;
                case CauseOfEndService.EndCollaborator:
                    return Title.EndCollaborators;
                case CauseOfEndService.EndDelegation:
                    return Title.EndDelegations;
                case CauseOfEndService.EndEmptied:
                    return Title.EndEmptieds;
                case CauseOfEndService.EndService:
                    return Title.EndServices;
                case CauseOfEndService.Quit:
                    return Title.Quits;
                case CauseOfEndService.RetireOptional:
                    return Title.RetireOptionals;
                case CauseOfEndService.Retirement:
                    return Title.RetireOptionals;
                case CauseOfEndService.EndOut:
                    return Title.EndOut;
                default:
                    return "";
            }
        }
    }


    public class SettlementReportGridRow
    {
        public string MoneyNumber { get; set; }
        public string Current { get; set; }
        public string NumberApp { get; set; }
        public string DateApp { get; set; }
        public string DirectleyDate { get; set; }       //تاريخ المباشرة
        public int? DegreeNow { get; set; }             //تاريخ الدرجة
        public string Employeer { get; set; }           //اسم الموظف
        public string JobTiTle { get; set; }            //المسمى الوظيفي
        public string Notes { get; set; }               //ملاحظات

        public string JobClass { get; set; }
        public string JobNumber { get; set; }           //الرقم الوظيفي
        public string Name { get; set; }
        public string Center { get; set; }              // المركز
        public string Department { get; set; }          //الادارة 
        public string Division { get; set; }            //القسم
        public string Unit { get; set; }                //الوحدة
        public string NationalNumber { get; set; }      //رقم الوطني

        
        public string Qualification { get; set; }       //الموهل العلمي
        
        public string DecisionDate { get; set; }        //تاريخ انهاء الخدمة
        public string DecisionNumber { get; set; }      //رقم القرار
        
        public string Cause { get; set; }               // سبب انهاء الخدمة
        public CauseOfEndService CauseOfEndService { get; set; } // سبب انهاء الخدمة
        public string GetCauseOfEndService()
        {
            switch (CauseOfEndService)
            {
                case CauseOfEndService.Death:
                    return Title.Deaths;
                case CauseOfEndService.EndCollaborator:
                    return Title.EndCollaborators;
                case CauseOfEndService.EndDelegation:
                    return Title.EndDelegations;
                case CauseOfEndService.EndEmptied:
                    return Title.EndEmptieds;
                case CauseOfEndService.EndService:
                    return Title.EndServices;
                case CauseOfEndService.Quit:
                    return Title.Quits;
                case CauseOfEndService.RetireOptional:
                    return Title.RetireOptionals;
                case CauseOfEndService.Retirement:
                    return Title.RetireOptionals;
                case CauseOfEndService.EndOut:
                    return Title.EndOut;
                default:
                    return "";
            }
        }
    }
}
