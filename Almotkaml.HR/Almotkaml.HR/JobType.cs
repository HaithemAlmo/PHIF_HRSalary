using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum JobType
    {
        /// <summary>
        /// عقد
        /// </summary>
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Contract))]
        Contract = 1,
        /// <summary>
        /// تعين
        /// </summary>
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Designation))]
        Designation = 2,
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.Delegation))]
        //Delegation = 3,//ندب
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.Transfer))]
        //Transfer = 4,
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.Loaning))]
        //Loaning = 4,//اعارة
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.BenefitFromServices))]
        //BenefitFromServices = 6,
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.Emptied))]
        //Emptied = 7, // تفرغ
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.Collaborator))]
        //Collaborator = 8,//متعاون
    }
}