using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.MedicalAppointment
{
    public class GetMedicAppointmentByIdQuery : IRequest<Result<MedicalAppointmentViewModel>>
    {
        public GetMedicAppointmentByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }

    }
}
