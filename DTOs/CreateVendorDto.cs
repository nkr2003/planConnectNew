namespace EventManagement.DTOs
{
    public class CreateVendorDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactInfo { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; } = true;
        public int EventCategoryId { get; set; }
    }
}
