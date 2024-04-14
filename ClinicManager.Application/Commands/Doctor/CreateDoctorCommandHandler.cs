using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.Doctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Result<DoctorViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDoctorCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<DoctorViewModel>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = new ClinicManager.Core.Entities.Doctor(request.FirstName, request.LastName,request.DateOfBirth, request.PhoneNumber, request.Email, request.Cpf, request.BloodType, request.Specialty, request.Crm, request.Address);

            await _unitOfWork.Doctors.AddAsync(doctor);

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<DoctorViewModel>(doctor);

            return Result<DoctorViewModel>.Success(result);
        }
    }
}
