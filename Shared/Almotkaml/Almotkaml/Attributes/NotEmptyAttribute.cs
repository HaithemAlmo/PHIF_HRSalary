using Almotkaml.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.Attributes
{
    public class NotEmptyAttribute : ValidationAttribute
    {
        private readonly string _errorMessage = SharedMessages.IsRequired;

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
                return new ValidationResult(_errorMessage);

            var stringValue = value as string;

            return string.IsNullOrWhiteSpace(stringValue) ? new ValidationResult(_errorMessage) : ValidationResult.Success;
        }
    }
}