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
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(request.DoctorId);

            if (doctor is null)
                return Result<Guid>.NotFound("Doctor not found.");

            var patient = await _unitOfWork.Patients.GetByIdAsync(request.PatientId);
            
            if (patient is null)
                return Result<Guid>.NotFound("Patient not found.");

            var serviceNote = await _unitOfWork.ServiceNotes.GetByIdAsync(request.ServiceNoteId);
            
            if (serviceNote is null)
                return Result<Guid>.NotFound("ServiceNote not found.");

            var medicalAppointment = new Core.Entities.MedicalAppointment(request.PatientId, request.DoctorId, request.ServiceNoteId, request.MedicalInsurance, request.StartDate, request.EndDate, request.MedicalAppointmentType);

            await _unitOfWork.MedicalAppointments.AddAsync(medicalAppointment);

            await _unitOfWork.CompleteAsync();

            return Result<Guid>.Success(medicalAppointment.Id);

        }
    }
}
