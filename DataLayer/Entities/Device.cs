using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        public string SerialNumber { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<DeviceLog> DeviceLogs { get; set; }

        public Device() 
        {
            DeviceLogs = new List<DeviceLog>();
        }

        public Device(string serialNumber) : this()
        {
            SerialNumber = serialNumber;
        }
    }
}