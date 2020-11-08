using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum TrainingType
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Training))]
        Training = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Study))]
        Study = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Collaboration))]
        Collaboration = 2
    }
}