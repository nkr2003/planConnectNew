using EventManagement.Models;
using EventManagement.Models.BookingModel;
using EventManagement.Models.PaymentModel;
using EventManagement.Models.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Api.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

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
        public string? RefreshToken { get; set; } // Token used for refreshing access tokens
        public DateTime? RefreshTokenExpiry { get; set; } // Expiry date for the refresh token


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public Role Role { get; set; } // One Role per User
        public ICollection<Vendor> Vendors { get; set; } // If a user can be a vendor
        public ICollection<Quotation> Quotations { get; set; }
        public ICollection<BookingRequest> BookingRequests { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}