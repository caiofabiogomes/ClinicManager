using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.MedicalAppointment
{
    public class GetAllMedicalAppointmentsQuery : IRequest<Result<List<MedicalAppointmentViewModel>>>
    {

    }
}
