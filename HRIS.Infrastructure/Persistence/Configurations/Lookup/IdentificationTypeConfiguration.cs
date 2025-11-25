using HRIS.Domain.Entities.Domain.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Infrastructure.Persistence.Configurations.Lookup
{
    public class IdentificationTypeConfiguration : IEntityTypeConfiguration<IdentificationType>
    {
        public void Configure(EntityTypeBuilder<IdentificationType> builder)
        {
            builder.ToTable("IdentificationTypes", "lookup");

            builder.HasKey(it => it.IdentificationTypeID);

            builder.Property(it => it.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(it => it.Description)
                .IsRequired()
                .HasMaxLength(200);


            // Seed Values

            builder.HasData(
                new IdentificationType {
                    IdentificationTypeID = 1,
                    Type = "TIN",
                    Description = "Tax Identification Number"
                },

                new IdentificationType
                {
                    IdentificationTypeID = 2,
                    Type = "PhilHealth",
                    Description = "PhilHealth ID"
                },

                new IdentificationType
                {
                    IdentificationTypeID = 3,
                    Type = "SSS",
                    Description = "Social Security System ID"
                },

                new IdentificationType
                {
                    IdentificationTypeID = 4,
                    Type = "GSIS",
                    Description = "Government Service Insurance System ID"
                },

                new IdentificationType
                {
                    IdentificationTypeID = 5,
                    Type = "National ID",
                    Description = "Philippine National ID"
                },

                new IdentificationType
                {
                    IdentificationTypeID = 6,
                    Type = "PRC License",
                    Description = "PRC License"
                },

                new IdentificationType
                {
                    IdentificationTypeID = 7,
                    Type = "Driver's License",
                    Description = "Driver's License ID"
                }
            );
        }

    }
}
