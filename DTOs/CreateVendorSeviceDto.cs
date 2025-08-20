using System.ComponentModel.DataAnnotations;

namespace EventManagement.DTOs
{
    public class CreateVendorSeviceDto
    {
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public string ServiceDescription { get; set; }
        [Required]
        
        public decimal Price { get; set; }
        [Required]
        public int VendorId { get; set; }
    }
}
