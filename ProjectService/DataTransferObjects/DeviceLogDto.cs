using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectService.DataTransferObjects
{
    public class DeviceLogDto
    {
        public DateTime DateTimeOccurrence { get; set; }

        public string Message { get; set; }

        public DeviceLogDto() { }

        public DeviceLogDto(string message, DateTime dateTimeOccurrence)
        {
            Message = message;
            DateTimeOccurrence = dateTimeOccurrence;
        }
    }
}
