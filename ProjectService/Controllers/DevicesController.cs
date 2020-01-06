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

            var device = await context.Devices.FirstOrDefaultAsync(
                x => x.SerialNumber == newDevice.DeviceSerialNumber);
            if(device != null)            
                return BadRequest();            

            var user = await context.Users.FirstOrDefaultAsync(x => x.Login == newDevice.UserLogin);
            if (user == null)
                return NotFound();                        

            context.Add(newDevice.GetEntity());
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostDevice), newDevice);
        }
    }
}