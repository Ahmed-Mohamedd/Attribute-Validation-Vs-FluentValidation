using System.ComponentModel.DataAnnotations;

namespace FluentValidation.Helpers
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field|AttributeTargets.Parameter)]
    public class FutureAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value , ValidationContext context)
        {
            return value is DateTime dateTime && dateTime > DateTime.Now ?
                ValidationResult.Success
                :new ValidationResult("Date must be in future");
        }
    }
}
