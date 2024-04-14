using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.ValueObjects;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Queries.Patient
{
    public class GetPatientByCpfQueryHandler : IRequestHandler<GetPatientByCpfQuery, Result<PatientViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPatientByCpfQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PatientViewModel>> Handle(GetPatientByCpfQuery request, CancellationToken cancellationToken)
        {
            var cpfObjectValue = new Cpf(request.Cpf);

            var patient = await _unitOfWork.Patients.GetByCpfAsync(cpfObjectValue);

            if (patient == null) 
                return Result<PatientViewModel>.NotFound("Paciente não encontrado!"); 

            var result = _mapper.Map<PatientViewModel>(patient);

            return Result<PatientViewModel>.Success(result);
        }
    } 
}
