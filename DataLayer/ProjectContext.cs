using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

namespace DataLayer
{
    public class ProjectContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<DeviceEntity> Devices { get; set; }

        public DbSet<DeviceLogEntity> DeviceLogs { get; set; }

        public DbSet<LogRecordType> LogRecordTypes { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(
                entity => { entity.HasIndex(e => e.Login).IsUnique(); });

            modelBuilder.Entity<LogRecordType>().HasData(
                new LogRecordType {LogRecordTypeId = 1, Name = "Unknown",  Number = 1},
                new LogRecordType {LogRecordTypeId = 2, Name = "Debug",  Number = 2}, 
                new LogRecordType {LogRecordTypeId = 3, Name = "Info",  Number = 3},
                new LogRecordType {LogRecordTypeId = 4, Name = "Warning",  Number = 4}, 
                new LogRecordType {LogRecordTypeId = 5, Name = "Error",  Number = 5});
        }
    }
}