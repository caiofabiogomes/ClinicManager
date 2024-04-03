using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Infrastructure.Persistence.Configurations
{
    public class ServiceNoteConfigurations : IEntityTypeConfiguration<ServiceNote>
    {
        public void Configure(EntityTypeBuilder<ServiceNote> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
