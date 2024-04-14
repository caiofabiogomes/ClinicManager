using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.MedicalAppointment
{
    public class UpdateMedicalAppointmentCommandHandler : IRequestHandler<UpdateMedicalAppointmentCommand, Result<MedicalAppointmentViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMedicalAppointmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<MedicalAppointmentViewModel>> Handle(UpdateMedicalAppointmentCommand request, CancellationToken cancellationToken)
        {
            var medicalAppointment = await _unitOfWork.MedicalAppointments.GetByIdAsync(request.Id);

            if (medicalAppointment is null)
                return Result<MedicalAppointmentViewModel>.NotFound("Medical appointment not found");

            var patient = await _unitOfWork.Patients.GetByIdAsync(request.PatientId);

            if (patient is null)
                return Result<MedicalAppointmentViewModel>.NotFound("Patient not found");

            var doctor = await _unitOfWork.Doctors.GetByIdAsync(request.DoctorId);

            if (doctor is null)
                return Result<MedicalAppointmentViewModel>.NotFound("Doctor not found");

            medicalAppointment.Update(request.PatientId, request.DoctorId, request.ServiceNoteId, request.MedicalInsurance, request.StartDate, request.EndDate, request.MedicalAppointmentType);

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<MedicalAppointmentViewModel>(medicalAppointment);

            return Result<MedicalAppointmentViewModel>.Success(result);
        }
    }
}
