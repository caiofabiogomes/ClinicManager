using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations
{
    public class PatientConfigurations : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(x => x.Address)
                .Property(x => x.Street)
                .HasColumnName("Street")
                .IsRequired(true);

            builder.OwnsOne(x => x.Address)
                .Property(x => x.City)
                .HasColumnName("City")
                .IsRequired(true);

            builder.OwnsOne(x => x.Address)
                .Property(x => x.State)
                .HasColumnName("State")
                .IsRequired(true);

            builder.OwnsOne(x => x.Address)
                .Property(x => x.ZipCode)
                .HasColumnName("ZipCode")
                .IsRequired(true);

            builder.OwnsOne(x => x.Address)
                .Property(x => x.HouseNumber)
                .HasColumnName("HouseNumber")
                .IsRequired(true);

            builder.OwnsOne(x => x.Address)
                .Property(x => x.HousingComplement)
                .HasColumnName("HousingComplement")
                .IsRequired(false);


            builder.OwnsOne(x => x.PhoneNumber)
                .Property(x => x.Value)
                .HasColumnName("PhoneNumber")
                .IsRequired(true);


            builder.OwnsOne(x => x.Cpf)
                .Property(x => x.Value)
                .HasColumnName("Cpf")
                .IsRequired(true);


            builder.OwnsOne(x => x.Email)
                .Property(x => x.Value)
                .HasColumnName("Email")
                .IsRequired(true);
        }
    }
}
