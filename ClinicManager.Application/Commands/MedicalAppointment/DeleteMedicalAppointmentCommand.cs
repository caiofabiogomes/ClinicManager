using ClinicManager.Application.Abstractions;
using MediatR;

namespace ClinicManager.Application.Commands.MedicalAppointment
{
    public class DeleteMedicalAppointmentCommand : IRequest<Result<Guid>>
    {
        public DeleteMedicalAppointmentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
