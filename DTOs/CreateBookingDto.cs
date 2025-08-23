using System.ComponentModel;

namespace EventManagement.DTOs
{
     public class CreateBookingDto
    {
 
        public int EventCategoryId { get; set; }
        public int UserId { get; set; }
        public int VendorId { get; set; }
        public double ExpectedAmount { get; set; }
        public DateTime UpdatedAt { get; set; }
        [DefaultValue("Pending")]
        public string BookingStatus { get; set; } = "Pending"; // or Confirmed, Cancelled
 
 
 
        public DateTime BookingDate { get; set; }
    }
 
}
