using System.ComponentModel.DataAnnotations;

namespace UserDto
{
    public class RegisterUser
    {
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Input must be between 5 and 100")]
        public string Username { get; set; } = string.Empty!;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}