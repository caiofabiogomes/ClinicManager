using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.Doctor
{
    public class GetDoctorByIdQuery : IRequest<Result<DoctorViewModel>>
    {
        public GetDoctorByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
