using Almotkaml.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.Attributes
{
    public class MoreThanZeroAttribute : ValidationAttribute
    {
        private readonly string _errorMessage = SharedMessages.InvalidNumber;

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
                return ValidationResult.Success;

            var number = value as decimal?;

            if (number == null || number.Value <= 0)
                return new ValidationResult(_errorMessage);

            return ValidationResult.Success;
        }
    }
}