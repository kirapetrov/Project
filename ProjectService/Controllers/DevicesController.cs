using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Models;

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(Device newDevice)
        {
            using(var context = new ProjectContext())
            {
                context.Add(newDevice.GetEntity());
                await context.SaveChangesAsync();
                return CreatedAtAction(nameof(PostDevice), newDevice);
            }
        }
    }
}