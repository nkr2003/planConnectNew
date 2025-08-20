using System.ComponentModel.DataAnnotations;

namespace EventManagement.DTOs.UserDtos
{
    public class UserResponseDto
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int RoleId { get; set; } // Foreign key for Role
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }
    }
}




