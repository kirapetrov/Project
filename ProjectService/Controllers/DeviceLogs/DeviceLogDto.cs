using System;

namespace ProjectService.Controllers.DeviceLogs
{
    public class DeviceLogDto
    {
        public DateTime DateTimeOccurrence { get; set; }

        public int Type { get; set; }

        public string Message { get; set; }

        public DeviceLogDto() { }

        public DeviceLogDto(string message, int type, DateTime dateTimeOccurrence)
        {
            Message = message;
            Type = type;
            DateTimeOccurrence = dateTimeOccurrence;
        }
    }
}
