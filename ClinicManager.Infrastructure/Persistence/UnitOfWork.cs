using ClinicManager.Core.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClinicManager.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly ClinicManagerDbContext _context;

        public UnitOfWork(
            ClinicManagerDbContext context,
            IDoctorRepository doctors,
            IPatientRepository patients,
            IMedicalAppointmentRepository medicalAppointments,
            IServiceNoteRepository serviceNotes)
        {
            _context = context;
            Doctors = doctors;
            Patients = patients;
            MedicalAppointments = medicalAppointments;
            ServiceNotes = serviceNotes;
        }

        public IDoctorRepository Doctors { get; }

        public IPatientRepository Patients { get; }

        public IMedicalAppointmentRepository MedicalAppointments { get; }

        public IServiceNoteRepository ServiceNotes { get; }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw ex;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
