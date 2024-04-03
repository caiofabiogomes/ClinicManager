using ClinicManager.Core.Enums;

namespace ClinicManager.Core.Entities
{
    public class MedicalAppointment : BaseEntity
    {
        public MedicalAppointment()
        {
            
        }

        public MedicalAppointment(Guid patientId, Guid doctorId, Guid serviceNoteId, string medicalInsurance, DateTime startDate, DateTime endDate, EMedicalAppointmentType medicalAppointmentType)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            ServiceNoteId = serviceNoteId;
            MedicalInsurance = medicalInsurance;
            StartDate = startDate;
            EndDate = endDate;
            MedicalAppointmentType = medicalAppointmentType;
        }

        public Guid PatientId { get; private set; }

        public Patient Patient { get; private set; }

        public Guid DoctorId { get; private set; }

        public Doctor Doctor { get; private set; }

        public Guid ServiceNoteId { get; private set; }

        public ServiceNote ServiceNote { get; private set; }

        public string MedicalInsurance { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public EMedicalAppointmentType MedicalAppointmentType { get; private set; }
    }
}
