using ClinicManager.Application.Abstractions;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.MedicalAppointment
{
    public class DeleteMedicalAppointmentCommandHandler : IRequestHandler<DeleteMedicalAppointmentCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public DeleteMedicalAppointmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(DeleteMedicalAppointmentCommand request, CancellationToken cancellationToken)
        {
            var medicalAppointment = await _unitOfWork.MedicalAppointments.GetByIdAsync(request.Id);
            
            if (medicalAppointment == null)
                return Result<Guid>.Failure("Consulta não encontrada.");

            await _unitOfWork.MedicalAppointments.DeleteAsync(medicalAppointment);
            await _unitOfWork.CompleteAsync();

            return Result<Guid>.Success(medicalAppointment.Id,"Consulta removida!");
        }
    }
}
