using CleanArchitectureDDD.Infrastructure.Interfaces;
using CleanArchitectureDDD.Core.Common;
using CleanArchitectureDDD.Core.Entities;
using CleanArchitectureDDD.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDDD.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        #region Local Variables
        private readonly IDateTimeService _dateTime;
        public AppDbContext(DbContextOptions<AppDbContext> options, IDateTimeService dateTime) : base(options)
        {
            _dateTime = dateTime;
        }
        #endregion

        #region Methods

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientConfig());
        }
        #endregion

        #region SaveChangesAsync
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTime.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #endregion

        #region DbSets
        public DbSet<Client> Client { get; set; }
        public DbSet<Car> Car { get; set; }
        #endregion
    }
}
