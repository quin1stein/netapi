using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetApi.Data;
using PostSchema.Models;

namespace NetApi.Controllers
{
    [Route("api/taskItem")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly AppDbContext _context;

        //constructor for dependency injection
        public TaskItemController(AppDbContext context)
        {
            _context = context;
        }

        // GET all Items
        // Example: GET all TaskItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetTaskItems()
        {
            return await _context.Posts.ToListAsync();
        }
    }
}