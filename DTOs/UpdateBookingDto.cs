namespace EventManagement.DTOs
{
    public class UpdateBookingDto
    {
       
        public int BookingId { get; set; } 
        public int UserId { get; set; }
        // public User User { get; set; }//navigation 

        public int VendorId { get; set; }
        //public Vendor Vendor { get; set; }//navigation
        //public double BookingAmount { get; set; }
        public double UserExpectedAmount { get; set; }
        public string BookingDescription { get; set; }
      

       


        
    }
}
