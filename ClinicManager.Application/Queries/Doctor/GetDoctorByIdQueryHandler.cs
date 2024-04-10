using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Queries.Doctor
{
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Result<DoctorViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDoctorByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<DoctorViewModel>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(request.Id);

            if (doctor == null)
            {
                return Result<DoctorViewModel>.NotFound("Doutor não encontrado!");
            }

            return Result<DoctorViewModel>.Success(_mapper.Map<DoctorViewModel>(doctor));
        }
    }
}
