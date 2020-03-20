using FluentValidation;
using HolidaysCalendar.Api.Resources;

namespace HolidaysCalendar.Api.Validators
{
    public class SaveTypeResourceValidator : AbstractValidator<SaveTypeResource>
    {
        public SaveTypeResourceValidator()
        {
            RuleFor(saveTypeResource => saveTypeResource.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}