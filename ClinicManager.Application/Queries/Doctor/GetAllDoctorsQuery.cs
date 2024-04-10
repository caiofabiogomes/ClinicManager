using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.Doctor
{
    public class GetAllDoctorsQuery : IRequest<Result<List<DoctorViewModel>>>
    {
    }
}
