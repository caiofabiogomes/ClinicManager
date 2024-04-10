using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Queries.Doctor
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, Result<List<DoctorViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDoctorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<DoctorViewModel>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _unitOfWork.Doctors.GetAllAsync();

            var result = _mapper.Map<List<DoctorViewModel>>(doctors);


            return Result<List<DoctorViewModel>>.Success(result);
        }

    }
}
