using EventManagement.Models.AdminModel;
using EventManagement.Models.BookingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactInfo { get; set; }
        public bool IsActive { get; set; } = true;
        public string Location { get; set; }  // Add this if missing
        public double Rating { get; set; }    // Optional: Add if not available
        public int EventCategoryId { get; set; }
        public EventCategory EventCategory { get; set; }
        public ICollection<BookingRequest> BookingRequests { get; set; }
        public ICollection<VendorService> VendorServices { get; set; }
    }
}