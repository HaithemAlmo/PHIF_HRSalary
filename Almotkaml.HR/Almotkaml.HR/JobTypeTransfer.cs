using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum JobTypeTransfer
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Delegation))]
        Delegation = 1,//ندب
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Collaborator))]
        Collaborator = 2,//متعاون
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Emptied))]
        EmptiedPart = 3, // تفرغ جزئي
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmptiedFull))]
        EmptiedFull = 4, // تفرغ كامل

    }
}