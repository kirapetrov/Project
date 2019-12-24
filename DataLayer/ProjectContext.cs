using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

namespace DataLayer
{
    public class ProjectContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<DeviceEntity> Devices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Host=127.0.0.1;Port=5432;Database=Project;Username=kira;Password=kira5533");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(
                entity => { entity.HasIndex(e => e.Login).IsUnique(); });
        }
    }
}