using HRIS.Domain.Entities.Common;
using HRIS.Domain.Entities.Domain.HRIS;
using HRIS.Domain.Entities.Domain.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Infrastructure.Persistence
{
    public class HRISDbContext : DbContext
    {
        public HRISDbContext(DbContextOptions<HRISDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<EmployeeIdentification> EmployeeIdentifications => Set<EmployeeIdentification>();
        public DbSet<CivilStatus> CivilStatuses => Set<CivilStatus>();
        public DbSet<IdentificationType> IdentificationTypes => Set<IdentificationType>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRISDbContext).Assembly);


            // applying entity filters (for transfer if madami na):
            modelBuilder.Entity<Employee>()
                .HasQueryFilter(e => e.IsActive);

            modelBuilder.Entity<EmployeeIdentification>()
                .HasQueryFilter(ei => ei.IsActive);

            

        }


        // Synchronous SaveChanges override to handle audit information
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditInformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            ApplyAuditInformation();
            return base.SaveChanges();
        }


        // Asynchronous SaveChanges override to handle audit information
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return base.SaveChangesAsync(cancellationToken);

        }


        private void ApplyAuditInformation()
        {
            // This method can be used to automatically set audit fields like CreatedDate, ModifiedDate, etc.
            // when entities are added or modified in the DbContext.

            var now = DateTimeOffset.UtcNow;
            var currentUser = "system"; // Replace with actual user context retrieval logic


            foreach (EntityEntry<BaseAuditableEntity> entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    //case EntityState.Added:
                    //    entry.Entity.CreatedDate = now;
                    //    entry.Entity.CreatedBy ??= currentUser; // Replace with actual user ID
                    //    entry.Entity.IsActive = true;
                    //    break;
                    //case EntityState.Modified:
                    //    entry.Entity.UpdatedDate = now;
                    //    entry.Entity.UpdatedBy ??= currentUser; // Replace with actual user ID
                    //    break;
                    //case EntityState.Deleted:
                    //    entry.Entity.DeletedDate = now;
                    //    entry.Entity.DeletedBy ??= currentUser; // Replace with actual user ID
                    //    entry.Entity.IsActive = false;
                    //    entry.State = EntityState.Modified; // Soft delete
                    //    break;

                    case EntityState.Added:
                        entry.Entity.MarkCreated(currentUser);
                        break;

                    case EntityState.Modified:
                        entry.Entity.MarkUpdated(currentUser);
                        break;

                    case EntityState.Deleted:
                        entry.Entity.SoftDelete(currentUser);
                        entry.State = EntityState.Modified;
                        break;
                }

            }

        }
    }
}
