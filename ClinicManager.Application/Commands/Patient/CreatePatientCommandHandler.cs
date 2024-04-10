using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.Patient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Result<PatientViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePatientCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PatientViewModel>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Core.Entities.Patient(request.FirstName, request.LastName, request.DateOfBirth,request.PhoneNumber, request.Email, request.Cpf, request.BloodType, request.Address,request.Height,request.Weight);

            await _unitOfWork.Patients.AddAsync(patient);

            await _unitOfWork.CompleteAsync();

            var result =  _mapper.Map<PatientViewModel>(patient);

            return Result<PatientViewModel>.Success(result,"Paciente criado com sucesso!");
        }
    }
}
