using System.ComponentModel.DataAnnotations;

namespace FinalAPI.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(2), MaxLength(21)]
        public string Password { get; set; }
    }
}
