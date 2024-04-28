using ClinicManager.Application.Abstractions;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.Patient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePatientCommandHandler(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }

        public async Task<Result<Guid>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(request.Id);

            if (patient is null)
                return Result<Guid>.NotFound("Patient not found.");

            await _unitOfWork.Patients.DeleteAsync(patient);

            await _unitOfWork.CompleteAsync();

            return Result<Guid>.Success(patient.Id);
        }
    }
}
