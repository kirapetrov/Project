using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using ProjectService.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly ProjectContext context;

        public DevicesController(ProjectContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<DeviceDto>> PostDevice(DeviceDto newDevice)
        {
            if (string.IsNullOrWhiteSpace(newDevice?.DeviceSerialNumber))            
                return BadRequest();            

            var hasDevice = await context.Devices.AnyAsync(x => x.SerialNumber == newDevice.DeviceSerialNumber);
            if(hasDevice)            
                return BadRequest();                               

            var deviceEntity = newDevice.GetEntity();
            context.Add(deviceEntity);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostDevice), newDevice);
        }
    }
}