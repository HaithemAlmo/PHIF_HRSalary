using Almotkaml.HR.Models;
using Almotkaml.HR.Models.Resources;
using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Staco.Models
{
    public class StacoPersonalModel : PersonalModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EnglishFirstName))]
        public override string EnglishFirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EnglishFatherName))]
        public override string EnglishFatherName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EnglishGrandfatherName))]
        public override string EnglishGrandfatherName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EnglishLastName))]
        public override string EnglishLastName { get; set; }


        public override void Validate(ModelState modelState)
        {
            base.Validate(modelState);

            if (string.IsNullOrWhiteSpace(IdentificationCard.Number) &&
                string.IsNullOrWhiteSpace(Passport.Number))
                modelState.AddError(m => IdentificationCard.Number,
                    ValidationMessages.CardNumberORPassportNumberMustSet);
        }
    }
}
