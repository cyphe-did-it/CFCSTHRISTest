using HRIS.Domain.Entities.Domain.HRIS;
using HRIS.Domain.Entities.Domain.Lookup;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Infrastructure.Persistence
{
    public class HrisDbContext : DbContext
    {
        public HrisDbContext(DbContextOptions<HrisDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<EmployeeIdentification> EmployeeIdentifications => Set<EmployeeIdentification>();
        public DbSet<CivilStatus> CivilStatuses => Set<CivilStatus>();
        public DbSet<IdentificationType> IdentificationTypes => Set<IdentificationType>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API configurations

            // Employee:
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeID);

                entity.Property(e => e.EmploymentID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ExtensionName)
                    .HasMaxLength(10);


                entity.Property(e => e.BirthDate)
                    .IsRequired();
                entity.Property(e => e.BirthPlace)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.Property(e => e.SexAtBirth)
                    .IsRequired();


                entity.HasOne(e => e.CiviStatus)
                      .WithMany(cs => cs.Employees)
                      .HasForeignKey(e => e.CivilStatusID);

                entity.HasMany(e => e.EmployeeIdentifications)
                      .WithOne(ei => ei.Employee)
                      .HasForeignKey(ei => ei.EmployeeID);
            });

            // EmployeeIdentification:
            modelBuilder.Entity<EmployeeIdentification>(entity =>
            {
                entity.HasKey(ei => ei.EmployeeIdentificationID);

                entity.Property(ei => ei.IdentificationNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(ei => ei.IssuedDate)
                    .IsRequired();

                entity.Property(ei => ei.ExpiredDate)
                    .IsRequired(false);

                entity.Property(ei => ei.IssuedPlace)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(ei => ei.IdentificationType)
                      .WithMany(it => it.EmployeeIdentifications)
                      .HasForeignKey(ei => ei.IdentificationTypeID);
            });

            // CivilStatus:
            modelBuilder.Entity<CivilStatus>(entity =>
            {
                entity.HasKey(cs => cs.CivilStatusID);

                entity.Property(cs => cs.StatusDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(cs => cs.StatusCode)
                    .IsRequired();

            });

            // IdentificationType:
            modelBuilder.Entity<IdentificationType>(entity =>
            {
                entity.HasKey(it => it.IdentificationTypeID);

                entity.Property(it => it.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(it => it.Description)
                    .IsRequired()
                    .HasMaxLength(200);
            });


        }

    }
}
