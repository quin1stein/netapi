using System.ComponentModel.DataAnnotations;
using UserSchema.Models;
using CommentSchema.Models;
using Microsoft.EntityFrameworkCore;
namespace PostSchema.Models
{
    public class Post

    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Slug { get; set; } = string.Empty;
        public User User { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}