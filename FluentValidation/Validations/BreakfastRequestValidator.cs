using FluentValidation.DTOs;

namespace FluentValidation.Validations
{
    public class BreakfastRequestValidator:AbstractValidator<BreakfastDto>
    {
        public BreakfastRequestValidator()
        {
            RuleFor(b=> b.Name).Length(6,10);
        }
    }
}
