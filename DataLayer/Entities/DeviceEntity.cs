using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    [Table("Devices")]
    public class DeviceEntity
    {
        [Key]
        public int DeviceId { get; set; }

        public string SerialNumber { get; set; }

        public int UserId { get; set; }

        public UserEntity User { get; set; }

        public ICollection<DeviceLogEntity> DeviceLogs { get; set; }

        public DeviceEntity() 
        {
            DeviceLogs = new List<DeviceLogEntity>();
        }

        public DeviceEntity(string serialNumber) : this()
        {
            SerialNumber = serialNumber;
        }
    }
}