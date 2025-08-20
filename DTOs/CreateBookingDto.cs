using EventManagement.Models;
using System.ComponentModel;

namespace EventManagement.DTOs
{
    public class CreateBookingDto
    {
        //public int BookingId { get; set; }

        public int EventCategoryId { get; set; }
        //public EventCategory EventCategory { get; set; }

        public int UserId { get; set; }
       // public User User { get; set; }//navigation 

        public int VendorId { get; set; }
        //public Vendor Vendor { get; set; }//navigation
        //public double BookingAmount { get; set; }
        public double UserExpectedAmount { get; set; }
        // public string BookingDescription { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        [DefaultValue("Pending")]
        public string BookingStatus { get; set; } = "Pending"; // or Confirmed, Cancelled



        public DateTime BookingDate { get; set; }
    }
}
