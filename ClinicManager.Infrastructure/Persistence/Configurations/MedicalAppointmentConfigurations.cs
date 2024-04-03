using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations
{
    public class MedicalAppointmentConfigurations : IEntityTypeConfiguration<MedicalAppointment>
    {
        public void Configure(EntityTypeBuilder<MedicalAppointment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Patient)
                .WithMany(x => x.MedicalAppointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Doctor)
               .WithMany(x => x.MedicalAppointments)
               .HasForeignKey(a => a.DoctorId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ServiceNote)
               .WithMany(x => x.MedicalAppointments)
               .HasForeignKey(a => a.ServiceNoteId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
