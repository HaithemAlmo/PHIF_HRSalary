using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class TrainingDetailGridRow
    {
        public int TrainingDetailId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }

    public class TrainingDetailForm
    {
        public int TrainingDetailId { get; set; }
        public int TrainingId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
        public string EmployeeName { get; set; }
        public IEnumerable<TrainingDetailGridRow> TrainingDetailGrid { get; set; } = new HashSet<TrainingDetailGridRow>();
    }
}