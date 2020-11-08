using Almotkaml.Attributes;
using Almotkaml.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class SelfCoursesModel
    {
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
      ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
      Name = nameof(Title.CourseArea))]
        public string CourseAreaId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
    ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
    Name = nameof(Title.PreciseField))]
        public string PreciseField { get; set; }

        public IEnumerable<SelfCoursesGridRows> SelfCoursesGrid { get; set; } = new HashSet<SelfCoursesGridRows>();

        public int SelfCourseId { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }

        public IEnumerable<EmployeeGridRow> EmployeeGrid = new HashSet<EmployeeGridRow>();
        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]

        [Display(ResourceType = typeof(Title), Name = nameof(Title.CourseName))]
        public string CourseName { get; set; }

        public string EmployeeName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, 2, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.PlaceCourse))]
        public PlaceCourse Place { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Specialty))]
        public int SpecialtyId { get; set; }
        public IEnumerable<SpecialtyListItem> SpecialtyListItems { get; set; } = new HashSet<SpecialtyListItem>();
        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SubSpecialty))]
        public int SubSpecialtyId { get; set; }
        public IEnumerable<SubSpecialtyListItem> SubSpecialtyListItems { get; set; } = new HashSet<SubSpecialtyListItem>();


        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Date))]
        public string Date { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Result))]
        public string Result { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Duration))]
        public string Duration { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]

        [Display(ResourceType = typeof(Title), Name = nameof(Title.TrainingCenter))]
        public string TrainingCenter { get; set; }
        public bool CanSubmit { get; set; }

    }
    public class SelfCoursesGridRows
    {
        public int SelfCourseId { get; set; }
        public string EmployeeName { get; set; }
        public string CourseName { get; set; }
        public PlaceCourse Place { get; set; }
        public string SpecialtyName { get; set; }
     
        
        public string SubSpecialtyName { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string Duration { get; set; }
        public string TrainingCenter { get; set; }


    }


}
