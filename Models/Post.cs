using System.ComponentModel.DataAnnotations;
using UserSchema.Models;
using CommentSchema.Models;
namespace PostSchema.Models
{
    public class Post

    {
        [Key]
        public string Id { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string UserId { get; set; } = string.Empty;

        public User User { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}