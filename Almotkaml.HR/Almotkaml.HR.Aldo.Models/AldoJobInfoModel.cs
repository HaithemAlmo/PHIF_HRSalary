using Almotkaml.HR.Models;
using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Aldo.Models
{
    public class AldoJobInfoModel : JobInfoModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobClass))]
        public JobClass JobClass { get; set; }
        public override string GetJobNumber() => (int)JobClass + JobNumber.ToString();
    }
}
