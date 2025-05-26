using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetApi.Data;

namespace NetApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;


    }
}