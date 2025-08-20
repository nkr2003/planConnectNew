using EventManagement.Data;
using EventManagement.Models;
using EventManagement.Models.AdminModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EventCategory>> GetEventsAll()
        {
            return await _context.EventCategories.ToListAsync();
        }

        public async Task<EventCategory> GetEventById(int id)
        {
            return  _context.EventCategories.FirstOrDefault(e => e.EventCategoryId == id);
        }

        public IEnumerable<Vendor> GetVendorsAll()
        {
            return _context.Vendors.ToList();
        }

        public IEnumerable<Vendor> GetVendors(int vendorId)
        {
            return _context.Vendors.Where(v => v.VendorId == vendorId).ToList();
        }

        public IEnumerable<VendorService> GetVendorServicesAll()
        {
            return _context.VendorServices.ToList();
        }

        public VendorService GetVendorServicesById(int id)
        {
            return _context.VendorServices
                                          .FirstOrDefault(vs => vs.VendorServicesId == id);
        }

        public IEnumerable<VendorService> GetVendorServicesByEventId(int vendorId)
        {
            return _context.VendorServices
                          
                           .Where(vs => vs.Vendor.VendorId == vendorId)
                           .ToList();
        }
    }
}
