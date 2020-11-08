using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class EvaluationModel
    {
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public IEnumerable<EvaluationGrirgRow> EvaluationGrird { get; set; } = new HashSet<EvaluationGrirgRow>();
        public IEnumerable<EvaluationGrirgRow> Grid { get; set; } = new HashSet<EvaluationGrirgRow>();
        public IEnumerable<EvaluationGrirgRow> Grid2 { get; set; } = new HashSet<EvaluationGrirgRow>();
        public IEnumerable<EvaluationGrirgRow> Grid3 { get; set; } = new HashSet<EvaluationGrirgRow>();
        public int EvaluationId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }

        public IEnumerable<EmployeeGridRow> EmployeeGrid = new HashSet<EmployeeGridRow>();
        public string EmployeeName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 6, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Grade))]
        public Grade Grade { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(0, 100, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Ratio))]
        public double Ratio { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1900, 2100, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Year))]
        public int Year { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Date))]
        public string Date { get; set; }
        public bool CanSubmit { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateDegree))]
        public string DateDegree { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.DegreeNow))]
        public int DegreeNow { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Note))]
        public string Note { get; set; }
    }


    public class EvaluationGrirgRow
    {
        public int EvaluationId { get; set; }
        public string EmployeeName { get; set; }
        public Grade Grade { get; set; }
        public double Ratio { get; set; }
        public int Year { get; set; }
        public string Date { get; set; }

    }


}
