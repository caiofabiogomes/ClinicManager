using ClinicManager.Core.IRepositories;

namespace ClinicManager.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        IDoctorRepository Doctors { get; }

        IPatientRepository Patients { get; }

        IMedicalAppointmentRepository MedicalAppointments { get; }

        IServiceNoteRepository ServiceNotes { get; }

        Task<int> CompleteAsync();

        Task BeginTransactionAsync();

        Task CommitAsync();
    }
}
