using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Commands.Doctor
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public async Task<Result<Guid>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        { 
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(request.Id);
            
            if (doctor is null)
                return Result<Guid>.NotFound("Doctor not found.");

            await _unitOfWork.Doctors.DeleteAsync(doctor);

            await _unitOfWork.CompleteAsync();

            return Result<Guid>.Success(doctor.Id);
        }
    }
}
