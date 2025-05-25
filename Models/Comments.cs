using System.ComponentModel.DataAnnotations;
using UserSchema.Models;
using PostSchema.Models;

namespace CommentSchema.Models
{
    public class Comment
    {
        [Key]
        public string Id { get; set; } = string.Empty!;
        [Required]
        [MinLength(1)]
        public string Content { get; set; } = string.Empty.ToString();
        [Required]
        public DateTime CommentedAt { get; set; } = DateTime.Now;
        [Required]
        public string UserId { get; set; } = string.Empty!;
        public User User { get; set; } = null!;
        [Required]
        public string PostId { get; set; } = string.Empty!;
        public Post Post { get; set; } = null!;

    }
}