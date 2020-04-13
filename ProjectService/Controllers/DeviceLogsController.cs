using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectService.DataTransferObjects;

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceLogsController : ControllerBase
    {
        private readonly ProjectContext context;

        public DeviceLogsController(ProjectContext context)
        {
            this.context = context;
        }

        [HttpGet("{deviceSerialNumber}")]
        public async Task<ActionResult<IEnumerable<DeviceLogDto>>> GetLogs(string deviceSerialNumber)
        {
            if (string.IsNullOrWhiteSpace(deviceSerialNumber))
                return NotFound(deviceSerialNumber);

            int? deviceId = await context.Devices
                .Where(x => x.SerialNumber == deviceSerialNumber)
                .Select(x => x.DeviceId)
                .FirstOrDefaultAsync();

            if(deviceId == null)
                return NotFound(deviceSerialNumber);

            var log = await context.DeviceLogs
                .Where(x => x.DeviceId == deviceId)
                .ToArrayAsync();

            var logsDto = log.Select(x => new DeviceLogDto(x.Message, x.DateTimeOccurrence));
            return new ActionResult<IEnumerable<DeviceLogDto>>(logsDto);
        }
    }
}
