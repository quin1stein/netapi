using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetApi.Data;
using UserDto;
namespace NetApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUser datas)
        {
            var user = await _context.User
            .FirstOrDefaultAsync(u => u.Password == datas.Password
             && u.Name == datas.Name);

            if (user == null)
            {
                return NotFound("User not found...");
            }
            return Ok(new
            {
                message = "Successfully logged in!",
                status = true,
                userId = user.Id,
            });
        }

    }
}