using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Login { get; set; }

        public string Name { get; set; }

        public ICollection<DeviceEntity> Devices { get; set; }

        public UserEntity()
        {
            Devices = new List<DeviceEntity>();
        }

        public UserEntity(string name) : this()
        {
            Name = name;
        }
    }
}