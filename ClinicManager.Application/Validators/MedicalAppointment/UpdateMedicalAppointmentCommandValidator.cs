using ClinicManager.Application.Commands.MedicalAppointment;
using FluentValidation;

namespace ClinicManager.Application.Validators.MedicalAppointment
{
    public class UpdateMedicalAppointmentCommandValidator : AbstractValidator<UpdateMedicalAppointmentCommand>
    {
        public UpdateMedicalAppointmentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().Must(x => x != Guid.Empty).WithMessage("Id is required");

            RuleFor(x => x.DoctorId)
               .NotEmpty().Must(x => x != Guid.Empty).WithMessage("DoctorId is required");

            RuleFor(x => x.PatientId)
                .NotEmpty().Must(x => x != Guid.Empty).WithMessage("PatientId is required");

            RuleFor(x => x.ServiceNoteId)
                .NotEmpty().Must(x => x != Guid.Empty).WithMessage("ServiceNote is required");

            RuleFor(x => x.MedicalInsurance)
                .NotEmpty().WithMessage("MedicalInsurance is required");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("StartDate is required");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("EndDate is required");

            RuleFor(x => x.MedicalAppointmentType)
                .NotEmpty().WithMessage("MedicalAppointmentType is required");
        }
    }
}
