using DataLayer.Entities;

namespace ProjectService.DataTransferObjects
{
    public class DeviceDto
    {
        public string DeviceSerialNumber { get; set; }

        public DeviceDto()
        {

        }

        public DeviceDto(string serialNumber)
        {
            DeviceSerialNumber = serialNumber;
        }

        public Device GetEntity()
        {
            return new Device(DeviceSerialNumber);
        }
    }
}