using System.ComponentModel.DataAnnotations;

namespace EventManagement.DTOs.AuthDtos
{
    public class LoginDto
    {
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Stores hashed password
    }
}
