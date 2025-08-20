using EventManagement.Api.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models.BookingModel
{
    public class Quotation
    {
        [Key]
        public int QuotationId { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string ServiceDetails { get; set; }

        public double EstimatedCost { get; set; }

        public bool IsApproved { get; set; } = false;

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedAt { get; set; }
    }
}