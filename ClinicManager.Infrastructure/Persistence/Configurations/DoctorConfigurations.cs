using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.IO;
using System.Reflection.Emit;

namespace ClinicManager.Infrastructure.Persistence.Configurations
{
    public class DoctorConfigurations : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(p => p.Id);


            builder.OwnsOne(x => x.Address, address =>
            {
                address.Property(x => x.Street).HasColumnName("Street").IsRequired(true);
                address.Property(x => x.City).HasColumnName("City").IsRequired(true);
                address.Property(x => x.State).HasColumnName("State").IsRequired(true);
                address.Property(x => x.ZipCode).HasColumnName("ZipCode").IsRequired(true);
                address.Property(x => x.HouseNumber).HasColumnName("HouseNumber").IsRequired(true);
                address.Property(x => x.HousingComplement).HasColumnName("HousingComplement").IsRequired(false);
            });


            builder.OwnsOne(x => x.PhoneNumber)
                .Property(x => x.Value)
                .HasColumnName("PhoneNumber")
                .IsRequired(true);


            builder.OwnsOne(x => x.Cpf)
                .Property(x => x.Value)
                .HasColumnName("Cpf")
                .IsRequired(true);


            builder.OwnsOne(x => x.Crm)
                .Property(x => x.Value)
                .HasColumnName("Crm")
                .IsRequired(true);


            builder.OwnsOne(x => x.Email)
                .Property(x => x.Value)
                .HasColumnName("Email")
                .IsRequired(true);


        }
    }
}
