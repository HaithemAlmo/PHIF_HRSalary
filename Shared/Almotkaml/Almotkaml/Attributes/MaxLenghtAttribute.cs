using Almotkaml.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.Attributes
{
    public class MaxLenghtAttribute : ValidationAttribute
    {
        private readonly int _length;
        private readonly string _errorMessage = SharedMessages.MaxLength;

        public MaxLenghtAttribute(int length)
        {
            _length = length;
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
                return ValidationResult.Success;

            var s = value as string;

            if (s == null || s.Length > _length)
                return new ValidationResult(string.Format(_errorMessage, _length, "{0}"));

            return ValidationResult.Success;
        }
    }
}