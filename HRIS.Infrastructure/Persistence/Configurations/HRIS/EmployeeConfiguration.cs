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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees", "hris");

            builder.HasKey(e => e.EmployeeID);

            builder.Property(e => e.EmploymentID)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.MiddleName)
                .HasMaxLength(100);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ExtensionName)
                .HasMaxLength(10);


            builder.Property(e => e.BirthDate)
                .IsRequired();

            builder.Property(e => e.BirthPlace)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.SexAtBirth)
                .IsRequired()
                .HasMaxLength(1);

            // Index
            builder.HasIndex(e => e.EmploymentID)
                .IsUnique();

            // FKs/Relationships
            builder.HasOne(e => e.CivilStatus)
                  .WithMany(cs => cs.Employees)
                  .HasForeignKey(e => e.CivilStatusID);

            builder.HasMany(e => e.EmployeeIdentifications)
                  .WithOne(ei => ei.Employee)
                  .HasForeignKey(ei => ei.EmployeeID);
        }
    }
}
