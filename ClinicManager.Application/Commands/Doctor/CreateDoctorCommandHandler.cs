using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.Doctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Result<DoctorViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DoctorViewModel>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = new ClinicManager.Core.Entities.Doctor(request.FirstName, request.LastName,request.DateOfBirth, request.PhoneNumber, request.Email, request.Cpf, request.BloodType, request.Specialty, request.Crm, request.Address);

            await _unitOfWork.Doctors.AddAsync(doctor);

            await _unitOfWork.CompleteAsync();

            var result = new DoctorViewModel(doctor);

            return Result<DoctorViewModel>.Success(result, "Doctor created successfully");
        }
    }
}
