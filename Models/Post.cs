using System.ComponentModel.DataAnnotations;
using UserSchema.Models;
using CommentSchema.Models;
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

        public User User { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}