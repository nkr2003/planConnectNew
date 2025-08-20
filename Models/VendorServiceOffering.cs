using PlanConnectAPI.Api.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventManagement.Models;
using EventManagement.Models.AdminModel;

namespace PlanConnectAPI.Api.Models
{
    public class VendorServiceOffering
    {
        [Key]
        public int OfferingId { get; set; }

        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; } // Navigation property

        [ForeignKey("VendorService")]
        public int ServiceId { get; set; } // Points to general VendorService
        public VendorService VendorService { get; set; } // Navigation property

        [Required]
        [StringLength(255)]
        public string OfferingName { get; set; } // Specific name for this offering

        public string Description { get; set; } // NVARCHAR(MAX)

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        // public ICollection<BookingItem> BookingItems { get; set; }
    }
}