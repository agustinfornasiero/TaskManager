using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;
using TaskManager.Infrastructure.Persistence.Configurations;

namespace TaskManager.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<TaskItem> Tasks { get; set; } = null!;
        public DbSet<TaskEvent> TaskEvents { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new TaskItemEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new TaskEventEntityTypeConfiguration());

        }
        public override Task<int> SaveChangesAsync(CancellationToken ct = default) => base.SaveChangesAsync(ct);

    }
}
