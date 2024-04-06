using ClinicManager.Core.Entities;
using ClinicManager.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence
{
    public class ClinicManagerDbContext : DbContext
    {
        public ClinicManagerDbContext(DbContextOptions<ClinicManagerDbContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalAppointment> MedicalAppointments { get; set; }
        public DbSet<ServiceNote> ServiceNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DoctorConfigurations());
            modelBuilder.ApplyConfiguration(new PatientConfigurations());
            modelBuilder.ApplyConfiguration(new MedicalAppointmentConfigurations());
            modelBuilder.ApplyConfiguration(new ServiceNoteConfigurations());
        }
    }
}
