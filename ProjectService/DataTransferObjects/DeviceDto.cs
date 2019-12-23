namespace ProjectService.DataTransferObjects
{
    public class DeviceDto
    {
        public string SerialNumber { get; set; }

        public DeviceDto()
        {

        }

        public DeviceDto(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public DeviceEntity GetEntity()
        {
            return new DeviceEntity(SerialNumber);
        }
    }
}