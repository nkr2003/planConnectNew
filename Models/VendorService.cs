using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models.AdminModel
{
    public class VendorService
    {
        [Key]
        public int VendorServicesId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal Price { get; set; }
        public int VendorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Vendor Vendor { get; set; }
    }
}