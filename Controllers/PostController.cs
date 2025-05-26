using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetApi.Data;
using PostSchema.Models;
using PostDto;

namespace NetApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetAllPost()
        {
            var posts = await _context.Post
         .Select(p => new
         {
             p.Title,
             p.Description,
             AuthorName = p.User.Name,
             Comments = p.Comments.Select(c => new
             {
                 c.Content,
                 CommentedAt = c.CommentedAt
             }).ToList()
         }).ToListAsync();
            return Ok(posts);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetPost([FromRoute] Guid id)
        {
            var post = await _context.Post
            .Select(p => new
            {
                p.Id,
                p.Title,
                p.Description,
                p.User,
                Comments = p.Comments.Select(c => new
                {
                    c.Content,
                    commentedAt = c.CommentedAt
                }).ToList()

            })

            .FirstOrDefaultAsync(p => p.Id == id);

            return post == null ? BadRequest() : Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            var user = await _context.User.FindAsync(post.UserId);
            if (user == null)
            {
                return BadRequest("Invalid User Id");
            }

            _context.Post.Add(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost([FromRoute] Guid id, [FromBody] UpdatePostDto updatedData)
        {
            var post = await _context.Post.FirstOrDefaultAsync(p => p.Id == id);

            if (post == null) return NotFound();

            post.Title = updatedData.Title;
            post.Description = updatedData.Description;
            await _context.SaveChangesAsync();
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var post = await _context.Post.FirstOrDefaultAsync(p => p.Id == id);

            if (post == null) return NotFound();

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}