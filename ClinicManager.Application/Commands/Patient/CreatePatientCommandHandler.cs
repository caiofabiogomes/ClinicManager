using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.IServices;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.Patient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Result<PatientViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public CreatePatientCommandHandler(IUnitOfWork unitOfWork, 
            IMapper mapper, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<Result<PatientViewModel>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var patient = new Core.Entities.Patient(request.FirstName, request.LastName, request.DateOfBirth,
                request.PhoneNumber, request.Email, passwordHash, request.Cpf,
                request.BloodType, request.Address,request.Height,request.Weight);

            await _unitOfWork.Patients.AddAsync(patient);

            await _unitOfWork.CompleteAsync();

            var result =  _mapper.Map<PatientViewModel>(patient);

            return Result<PatientViewModel>.Success(result);
        }
    }
}
