using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventManagement.Api.Models; // For User


namespace EventManagement.Models.PaymentModel
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } // e.g. UPI, Card, Wallet

        public string TransactionId { get; set; }

        public bool IsSuccessful { get; set; } = true;

        public DateTime PaidAt { get; set; } = DateTime.UtcNow;

        // Foreign key relationships
        public int UserId { get; set; }
        public User User { get; set; }
    }
    }


