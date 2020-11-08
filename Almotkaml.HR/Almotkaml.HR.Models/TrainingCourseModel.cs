using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class TrainingCourseIndexModel
    {
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public IEnumerable<TrainingCourseGridRow> TrainingCourseGrid { get; set; } = new HashSet<TrainingCourseGridRow>();

    }

    public class TrainingCourseGridRow
    {
        public int TrainingCourseId { get; set; }
        public string Name { get; set; }
        public string ExecutingAgency { get; set; }
        public PlaceCourse PlaceCourse { get; set; }
        public string SpecialtyName { get; set; }
        public string Date { get; set; }
        public string Result { get; set; }
    }



    public class TrainingCourseFormModel
    {
        public int TrainingCourseId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CourseName))]
        public string Name { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExecutingAgency))]
        public string ExecutingAgency { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.PlaceCourse))]
        public PlaceCourse PlaceCourse { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Specialty))]
        public int SpecialtyId { get; set; }
        public IEnumerable<SpecialtyListItem> SpecialtyList { get; set; } = new HashSet<SpecialtyListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Result))]
        public string Result { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Date))]
        public string Date { get; set; }

        public IEnumerable<TrainingCourseGridRow> TrainingCourseGridRows { get; set; } = new HashSet<TrainingCourseGridRow>();
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public bool CanSubmit { get; set; }

    }


}
