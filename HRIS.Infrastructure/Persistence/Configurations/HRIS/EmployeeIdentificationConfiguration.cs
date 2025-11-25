using HRIS.Domain.Entities.Domain.HRIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Infrastructure.Persistence.Configurations.HRIS
{
    public class EmployeeIdentificationConfiguration : IEntityTypeConfiguration<EmployeeIdentification> 
    {
        public void Configure (EntityTypeBuilder<EmployeeIdentification> builder) 
        {
            builder.ToTable("EmployeeIdentifications", "hris");

            builder.HasKey(ei => ei.EmployeeIdentificationID);

            builder.Property(ei => ei.IdentificationNumber)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ei => ei.IssuedDate)
                .IsRequired();

            builder.Property(ei => ei.ExpiredDate)
                .IsRequired(false);

            builder.Property(ei => ei.IssuedPlace)
                .IsRequired()
                .HasMaxLength(150);

            // Index
            builder.HasIndex(ei => new { ei.EmployeeID, ei.IdentificationTypeID })
                  .IsUnique();

            // FKs/Relationships
            builder.HasOne(ei => ei.IdentificationType)
                  .WithMany(it => it.EmployeeIdentifications)
                  .HasForeignKey(ei => ei.IdentificationTypeID);
        }
    }
}
