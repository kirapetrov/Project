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

        [HttpGet("{login}")]
        public async Task<ActionResult<UserDto>> GetUser(string login)
        {
            var userEntity = await context.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (userEntity != null)
                return new ActionResult<UserDto>(new UserDto(userEntity));

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserDto newUser)
        {
            if (newUser == null || string.IsNullOrWhiteSpace(newUser.Login))
                return BadRequest();

            var result = await context.Users.AnyAsync(x => x.Login == newUser.Login);
            if (result)
                return BadRequest();

            context.Add(newUser.GetEntity());
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { login = newUser.Login }, newUser);
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<UserDto>> DeleteUser(string login)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Name == login);
            if (user == null)
                return NotFound();

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return new UserDto(user);
        }
    }
}