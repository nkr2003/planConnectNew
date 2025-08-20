namespace EventManagement.DTOs
{
    public class VendorServiceDto
    {
        public int VendorServiceId { get; set; }
        public int VendorId { get; set; }
        public string? ServiceName { get; set; }
        public decimal Price { get; set; }

        // Optional nested data
        public string VendorName { get; set; }
    }
}
