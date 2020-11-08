using Almotkaml.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.Attributes
{
    public class PastDateAttribute : ValidationAttribute
    {
        private readonly string _errorMessage = SharedMessages.InvalidPastDate;

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            DateTime dateTime;

            if (value == null)
                return new ValidationResult(_errorMessage);

            if (!TryConvert.ToDate(value.ToString(), out dateTime))
                return new ValidationResult(_errorMessage);

            return dateTime > DateTime.Now ? new ValidationResult(_errorMessage) : ValidationResult.Success;
        }
    }
}
