using Almotkaml.Attributes;
using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class QualificationModel
    {
        public IEnumerable<QualificationGridRow> QualificationGrid { get; set; } =
            new HashSet<QualificationGridRow>();

        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }


        public int QualificationId { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedMessages),
        //    ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        //[Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
        //    ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.Employee))]

        public int EmployeeId { get; set; }

        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.QualificationType))]

        public int QualificationTypeId { get; set; }

        public IEnumerable<QualificationTypeListItem> QualificationTypeList { get; set; } =
            new HashSet<QualificationTypeListItem>();

        [Date]
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.GranduationDate))]
        public string Date { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string EmployeeName { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.GraduationCountry))]
        public string GraduationCountry { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.NameDonorFoundation))]
        public string NameDonorFoundation { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Specialty))]
        public int SpecialtyId { get; set; }

        public IEnumerable<SpecialtyListItem> SpecialtyList { get; set; } = new HashSet<SpecialtyListItem>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExactSpecialty))]
        public int? ExactSpecialtyId { get; set; }

        public IEnumerable<ExactSpecialtyListItem> ExactSpecialtyList { get; set; } =
            new HashSet<ExactSpecialtyListItem>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.SubSpecialty))]
        public int? SubSpecialtyId { get; set; }

        public IEnumerable<SubSpecialtyListItem> SubSpecialtyList { get; set; } = new HashSet<SubSpecialtyListItem>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.AquiredSpecialty))]
        public string AquiredSpecialty { get; set; } // التخصص المكتسب

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DonorFoundationType))]
        public DonorFoundationType DonorFoundationType { get; set; } // نوع الجهة المانحة

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.QualificationGrade))]
        public Grade Grade { get; set; }
        public bool CanSubmit { get; set; }


        public SpecialityType GetRequestedType()
        {
            if (ExactSpecialtyId > 0)
                return SpecialityType.ExactSpeciality;

            if (SubSpecialtyId > 0)
                return SpecialityType.SubSpeciality;

            return SpecialityType.Speciality;
        }
    }

    public class QualificationGridRow
    {
        public int QualificationId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int QualificationTypeId { get; set; }
        public string QualificationTypeName { get; set; }
        public string Date { get; set; }
        public string GraduationCountry { get; set; }
        public string NameDonorFoundation { get; set; }
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; }
        public int SubSpecialtyId { get; set; }
        public string SubSpecialtyName { get; set; }
        public int ExactSpecialtyId { get; set; }
        public string ExactSpecialtyName { get; set; }
        public string AquiredSpecialty { get; set; } // التخصص المكتسب
    }

    public class QualificationListItem
    {
        public int QualificationId { get; set; }
        public string Name { get; set; }
    }


}
