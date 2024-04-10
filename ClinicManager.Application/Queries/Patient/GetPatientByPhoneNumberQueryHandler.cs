using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.ValueObjects;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Queries.Patient
{
    public class GetPatientByPhoneNumberQueryHandler : IRequestHandler<GetPatientByPhoneNumberQuery, Result<PatientViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPatientByPhoneNumberQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PatientViewModel>> Handle(GetPatientByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var phoneNumberObjectValue = new PhoneNumber(request.PhoneNumber);

            var patient = await _unitOfWork.Patients.GetByPhoneNumberAsync(phoneNumberObjectValue);

            if (patient is null)
                return Result<PatientViewModel>.NotFound("Paciente não encontrado.");

            var result =  _mapper.Map<PatientViewModel>(patient);

            return Result<PatientViewModel>.Success(result,"Busca realizada com sucesso!");
        }
    }
}
