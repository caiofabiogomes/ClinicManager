using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.Patient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Result<PatientViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PatientViewModel>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Core.Entities.Patient(request.FirstName, request.LastName, request.DateOfBirth,request.PhoneNumber, request.Email, request.Cpf, request.BloodType, request.Address,request.Height,request.Weight);

            await _unitOfWork.Patients.AddAsync(patient);

            await _unitOfWork.CompleteAsync();

            var result = new PatientViewModel(patient.FirstName, patient.LastName, patient.DateOfBirth, patient.PhoneNumber, patient.Email, patient.Cpf, patient.BloodType, patient.Address, patient.Height, patient.Weight, patient.Id, patient.CreatedAt);

            return Result<PatientViewModel>.Success(result,"Paciente criado com sucesso!");
        }
    }
}
