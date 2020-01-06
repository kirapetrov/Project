using DataLayer.Entities;

namespace ProjectService.DataTransferObjects
{
    public class UserDeviceDto
    {
        public string UserLogin { get; set; }

        public string DeviceSerialNumber { get; set; }
    }
}