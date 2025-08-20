using System.ComponentModel.DataAnnotations;

namespace EventManagement.DTOs
{
    public class UpdateVendorDto
    {

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactInfo { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public int EventCategoryId { get; set; }

    }
}
