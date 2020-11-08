using Almotkaml.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.Attributes
{
    public class SelectedAttribute : ValidationAttribute
    {
        private readonly string _errorMessage = SharedMessages.ShouldSelected;

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
                return ValidationResult.Success;

            var stringValue = value as string;

            if (string.IsNullOrWhiteSpace(stringValue))
                return new ValidationResult(_errorMessage);

            return ((int?)null).GetValueOrDefault() == 0 ? new ValidationResult(_errorMessage) : ValidationResult.Success;
        }
    }
}