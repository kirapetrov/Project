using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using ProjectService.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ProjectContext context;

        public UsersController(ProjectContext context)
        {
            this.context = context;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<UserDto>> GetUser(string name)
        {
            var userEntity = await context.Users.FirstOrDefaultAsync(x => x.Name == name);
            if (userEntity != null)
                return new ActionResult<UserDto>(new UserDto(userEntity));

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserDto newUser)
        {
            context.Add(newUser.GetEntity());
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostUser), newUser);
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<UserDto>> DeleteUser(string name)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Name == name);
            if (user == null)
                return NotFound();

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return new UserDto(user);
        }
    }
}