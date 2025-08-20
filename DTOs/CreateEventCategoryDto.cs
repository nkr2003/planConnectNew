using System.ComponentModel.DataAnnotations;

namespace EventManagement.DTOs
{
    public class CreateEventCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
