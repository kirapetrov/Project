using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ProjectContext : DbContext {
        public DbSet<UserEntity> Users {get; set;}

        public DbSet<DeviceEntity> Devices {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Host=127.0.0.1;Port=5432;Database=Project;Username=kira;Password=kira5533");
    }

    [Table("Users")]
    public class UserEntity {
        
        [Key]
        public int UserId {get; set;}

        public string Name {get; set;}

        public ICollection<DeviceEntity> Devices {get; set;}

        public UserEntity()
        {
            Devices = new List<DeviceEntity>();
        }

        public UserEntity(string name) : this()
        {
            Name = name;
        }
    }

    [Table("Devices")]
    public class DeviceEntity {

        [Key]
        public int DeviceId {get; set;}

        public string SerialNumber {get; set;}

        public int UserId {get; set;}

        public UserEntity User {get; set;}

        public DeviceEntity() { }

        public DeviceEntity(string serialNumber)
        {
            SerialNumber = serialNumber;
        }
    }
}
