using System.ComponentModel.DataAnnotations;
using UserSchema.Models;
using PostSchema.Models;

namespace CommentSchema.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MinLength(1)]
        public string Content { get; set; } = string.Empty!;
        [Required]
        public DateTime CommentedAt { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        [Required]
        public Guid PostId { get; set; }
        public Post Post { get; set; } = null!;

    }
}