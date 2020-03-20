using FluentValidation;
using HolidaysCalendar.Api.Resources;

namespace HolidaysCalendar.Api.Validators
{
    public class SaveRequestResourceValidator : AbstractValidator<SaveRequestResource>
    {
        public SaveRequestResourceValidator()
        {
            RuleFor(saveRequestRecource => saveRequestRecource.StartDate)
                .NotEmpty();
            RuleFor(saveRequestRecource => saveRequestRecource.EndDate)
                .NotEmpty();
            
            RuleFor(saveRequestRecource => saveRequestRecource.TypeId)
                .NotEmpty()
                .WithMessage("'Type Id' must not be 0.");

            RuleFor(saveRequestRecource => saveRequestRecource.StatusId)
                .NotEmpty()
                .WithMessage("'Status Id' must not be 0.");
        }
    }
}