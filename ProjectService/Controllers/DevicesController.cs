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
            if (newDevice == null ||
                string.IsNullOrWhiteSpace(newDevice.UserLogin) ||
                string.IsNullOrWhiteSpace(newDevice.DeviceSerialNumber))
            {
                return BadRequest();
            }

            var user = await context.Users.FirstOrDefaultAsync(x => x.Login == newDevice.UserLogin);
            if (user == null)
                return NotFound(); 

            var hasDevice = await context.Devices.AnyAsync(x => x.SerialNumber == newDevice.DeviceSerialNumber);
            if(hasDevice)            
                return BadRequest();                               

            var deviceEntity = newDevice.GetEntity();
            deviceEntity.User = user;
            context.Add(deviceEntity);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostDevice), newDevice);
        }
    }
}