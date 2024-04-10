using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Queries.MedicalAppointment
{
    public class GetAllMedicalAppointmentsQueryHandler : IRequestHandler<GetAllMedicalAppointmentsQuery, Result<List<MedicalAppointmentViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllMedicalAppointmentsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }
        public async Task<Result<List<MedicalAppointmentViewModel>>> Handle(GetAllMedicalAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var medicalAppointments = await _unitOfWork.MedicalAppointments.GetAllAsync(); 

            var result = _mapper.Map<List<MedicalAppointmentViewModel>>(medicalAppointments);

            return Result<List<MedicalAppointmentViewModel>>.Success(result,"Busca realizada com sucesso!");
        }
    }
}
