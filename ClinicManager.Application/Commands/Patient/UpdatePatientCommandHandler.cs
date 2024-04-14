using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.Patient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, Result<PatientViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePatientCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PatientViewModel>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(request.Id);

            if (patient is null)
                return Result<PatientViewModel>.NotFound("Doctor not found");

            patient.Update(request.FirstName, request.LastName, request.DateOfBirth, request.PhoneNumber, request.Email, request.Cpf, request.BloodType, request.Address,request.Height, request.Weight);

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<PatientViewModel>(patient);

            return Result<PatientViewModel>.Success(result);
        }
    }
}
