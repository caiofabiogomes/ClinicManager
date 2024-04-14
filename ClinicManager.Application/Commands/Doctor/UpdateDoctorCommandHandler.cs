using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.Doctor
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, Result<DoctorViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDoctorCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<DoctorViewModel>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(request.Id);

            if (doctor is null)
                return Result<DoctorViewModel>.NotFound("Doctor not found");

            doctor.Update(request.FirstName, request.LastName, request.DateOfBirth, request.PhoneNumber, request.Email, request.Cpf, request.BloodType, request.Specialty, request.Crm, request.Address);

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<DoctorViewModel>(doctor);

            return Result<DoctorViewModel>.Success(result);
        }
    }
}
