using System.ComponentModel.DataAnnotations;
using PostSchema.Models;
using CommentSchema.Models;

namespace UserSchema.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 Characters.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}