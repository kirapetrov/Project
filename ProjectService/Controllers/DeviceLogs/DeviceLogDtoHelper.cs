using DataLayer.Entities;

namespace ProjectService.Controllers.DeviceLogs
{
    public static class DeviceLogDtoHelper
    {
        public static DeviceLogDto ToDto(this DeviceLog e) =>
            new DeviceLogDto(e.Message, e.LogRecordType.Number, e.DateTimeOccurrence);
    }
}
