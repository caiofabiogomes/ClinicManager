using ClinicManager.Application.Commands.ServiceNote;
using FluentValidation;

namespace ClinicManager.Application.Validators.ServiceNote
{
    public class UpdateServiceNoteCommandValidator : AbstractValidator<UpdateServiceNoteCommand>
    {
        public UpdateServiceNoteCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().Must(x => x != Guid.Empty).WithMessage("Id is required");

            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.DurationTime)
                .NotEmpty().WithMessage("DurationTime is required")
                .Must(x => x > 0).WithMessage("Duration Time must be greater than 0");

            RuleFor(x => x.ValueOfServiceNote)
                .NotEmpty().WithMessage("Value of service note is required")
                .Must(x => x > 0).WithMessage("Value of service note must be greater than 0");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required");
        }
    }
}
