using FluentValidation;
using HolidaysCalendar.Api.Resources;

namespace HolidaysCalendar.Api.Validators
{
    public class SaveStatusResourceValidator : AbstractValidator<SaveStatusResource>
    {
        public SaveStatusResourceValidator()
        {
            RuleFor(saveStatusResource => saveStatusResource.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}