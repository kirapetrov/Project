using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectService.DataTransferObjects;

namespace ProjectService.Controllers.DeviceLogs
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
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            if(deviceId == null)
                return NotFound(deviceSerialNumber);

            var log = await context.DeviceLogs
                .Where(x => x.DeviceId == deviceId)
                .Include(x => x.LogRecordType)
                .ToArrayAsync();

            return new ActionResult<IEnumerable<DeviceLogDto>>(log.Select(x => x.ToDto()));
        }
    }
}
