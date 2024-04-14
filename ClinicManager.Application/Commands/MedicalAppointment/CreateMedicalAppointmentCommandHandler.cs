using ClinicManager.Application.Abstractions;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.MedicalAppointment
{
    public class CreateMedicalAppointmentCommandHandler : IRequestHandler<CreateMedicalAppointmentCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateMedicalAppointmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Guid>> Handle(CreateMedicalAppointmentCommand request, CancellationToken cancellationToken)
        { 
            var medicalAppointment = new Core.Entities.MedicalAppointment(request.PatientId, request.DoctorId, request.ServiceNoteId,request.MedicalInsurance,request.StartDate,request.EndDate,request.MedicalAppointmentType);
            //validacoes
            await _unitOfWork.MedicalAppointments.AddAsync(medicalAppointment);

            await _unitOfWork.CompleteAsync();

            return Result<Guid>.Success(medicalAppointment.Id);

        }
    }
}
