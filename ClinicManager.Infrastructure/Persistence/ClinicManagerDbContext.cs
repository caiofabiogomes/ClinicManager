using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly());
        }
    }
}
