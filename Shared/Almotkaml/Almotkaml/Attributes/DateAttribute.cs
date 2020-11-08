using Almotkaml.Extensions;
using Almotkaml.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.Attributes
{
    public class DateAttribute : ValidationAttribute
    {
        private readonly string _errorMessage = SharedMessages.InvalidValue;

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
                return ValidationResult.Success;

            var dateString = value as string;

            if (dateString == null)
                return new ValidationResult(_errorMessage);

            var date = dateString.ToDateTime();

            return date.IsValid() ? ValidationResult.Success : new ValidationResult(_errorMessage);
        }
    }
}