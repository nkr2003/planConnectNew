using System.ComponentModel.DataAnnotations;

namespace EventManagement.DTOs
{
    public class UpdateVendorServiceDto
    {

        [Required]
        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

      
        public decimal Price { get; set; }

        public bool IsDeleted { get; set; }
    }
}
