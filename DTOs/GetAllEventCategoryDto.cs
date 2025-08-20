using EventManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.DTOs
{
    public class GetAllEventCategoryDto
    {
        public int EventCategoryId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<VendorDto> Vendors { get; set; } = new List<VendorDto>();
    }

}
