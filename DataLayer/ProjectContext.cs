using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

namespace DataLayer
{
    public class ProjectContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<DeviceLog> DeviceLogs { get; set; }

        public DbSet<LogRecordType> LogRecordTypes { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(
                entity => { entity.HasIndex(e => e.Login).IsUnique(); });

            modelBuilder.Entity<LogRecordType>().HasData(
                new LogRecordType {Id = 1, Name = "Unknown",  Number = 1},
                new LogRecordType {Id = 2, Name = "Debug",  Number = 2}, 
                new LogRecordType {Id = 3, Name = "Info",  Number = 3},
                new LogRecordType {Id = 4, Name = "Warning",  Number = 4}, 
                new LogRecordType {Id = 5, Name = "Error",  Number = 5});
        }
    }
}