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
    public class CivilStatusConfiguration : IEntityTypeConfiguration<CivilStatus>
    {
        public void Configure(EntityTypeBuilder<CivilStatus> builder) {

            builder.ToTable("CivilStatuses", "lookup");

            builder.HasKey(cs => cs.CivilStatusID);

            builder.Property(cs => cs.StatusDescription)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cs => cs.StatusCode)
                .IsRequired()
                .HasMaxLength(10);


            // Seed Values:

            builder.HasData(
                new CivilStatus { 
                    CivilStatusID = 1,
                    StatusCode = 'S',
                    StatusDescription = "Single"
                },

                new CivilStatus
                {
                    CivilStatusID = 2,
                    StatusCode = 'M',
                    StatusDescription = "Married"
                },

                new CivilStatus
                {
                    CivilStatusID = 3,
                    StatusCode = 'W',
                    StatusDescription = "Widowed"
                },

                new CivilStatus {
                    CivilStatusID = 4,
                    StatusCode = 'S',
                    StatusDescription = "Separated"
                }

            );

        }
    }
}
