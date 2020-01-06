using DataLayer.Entities;

namespace ProjectService.DataTransferObjects
{
    public class DeviceDto
    {
        public string UserLogin { get; set; }
        public string DeviceSerialNumber { get; set; }

        public DeviceDto()
        {

        }

        public DeviceDto(string serialNumber)
        {
            DeviceSerialNumber = serialNumber;
        }

        public DeviceEntity GetEntity()
        {
            return new DeviceEntity(DeviceSerialNumber);
        }
    }
}