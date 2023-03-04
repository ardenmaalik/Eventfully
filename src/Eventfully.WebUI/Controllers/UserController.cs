using Eventfully.Domain.Entities;
using Eventfully.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventfully.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")] // api/user
    [ApiController]
    public class UserController : ControllerBase
    {
        private static AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> Get()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return BadRequest("Invalid Id");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", user.Id, user);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return BadRequest("Invalid Id");
            }

            user.Email = email;
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return BadRequest("Invalid Id");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
