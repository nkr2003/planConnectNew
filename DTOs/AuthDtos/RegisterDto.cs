using System.ComponentModel.DataAnnotations;

namespace EventManagement.DTOs.AuthDtos
{
    public class RegisterDto
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Stores hashed password

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int RoleId { get; set; } // Foreign key for Role
    }
}
