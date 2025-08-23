using EventManagement.Api.Models;
using EventManagement.Models.PaymentModel;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models.BookingModel
{
    public class BookingRequest
    {

        [Key]
        public int BookingId { get; set; }
        public int EventCategoryId { get; set; }
        public EventCategory EventCategory { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public double BookingAmount { get; set; }
        public double ExpectedAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingStatus { get; set; } = "Pending"; // or Confirmed, Cancelled
        public ICollection<Payment> Payments { get; set; }
    }
}