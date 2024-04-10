using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Queries.MedicalAppointment
{
    public class GetMedicAppointmentByIdQueryHandler : IRequestHandler<GetMedicAppointmentByIdQuery, Result<MedicalAppointmentViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMedicAppointmentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<MedicalAppointmentViewModel>> Handle(GetMedicAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var medicalAppointment = await _unitOfWork.MedicalAppointments.GetByIdAsync(request.Id);

            if (medicalAppointment == null)
                return Result<MedicalAppointmentViewModel>.NotFound("Consulta não encontrada!");

            var result = _mapper.Map<MedicalAppointmentViewModel>(medicalAppointment);

            return Result<MedicalAppointmentViewModel>.Success(result);
        }
    }
}
