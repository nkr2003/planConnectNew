namespace EventManagement.DTOs
{
    public class UpdateBookingDto
    {
        public int BookingId { get; set; } // required to identify record
        public double ExpectedAmount { get; set; }
        public string BookingStatus { get; set; } // Pending, Confirmed, Cancelled
    }
}
