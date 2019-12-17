using DataLayer;

namespace ProjectService.Models
{
    public class Device 
    {
        public string SerialNumber {get;set;}

        public Device()
        {
            
        }

        public Device(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public DeviceEntity GetEntity()
        {
            return new DeviceEntity(SerialNumber);
        }
    }
}