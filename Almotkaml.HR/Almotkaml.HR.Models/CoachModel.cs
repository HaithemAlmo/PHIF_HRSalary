using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class CoachIndexModel
    {
        public IEnumerable<CoachGridRow> CoachGrid { get; set; } = new HashSet<CoachGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

    }

    public class CoachFormModel
    {
        public int CoachId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Name))]
        public string Name { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CoachType))]
        public CoachType CoachType { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Name))]
        public int? EmployeeId { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid = new HashSet<EmployeeGridRow>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Phone))]
        public string Phone { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Email))]
        public string Email { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Note))]
        public string Note { get; set; }
        public bool CanSubmit { get; set; }
    }

    public class CoachGridRow
    {
        public int CoachId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
    public class CoachListItem
    {
        public int CoachId { get; set; }
        public string Name { get; set; }
    }
}