using Microsoft.EntityFrameworkCore;
using EventManagement.Interfaces;
using EventManagement.Models;
using EventManagement.Models.AdminModel;
using EventManagement.Data;

namespace EventManagement.Repository
{
    public class VendorRepository : IVendorRepository
    {

        private readonly ApplicationDbContext _context;

        public VendorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

public async Task<Vendor> GetVendorByNameAsync(string name)
{
    return await _context.Vendors
                        .Where(v => v.IsActive)
                        .FirstOrDefaultAsync(v => v.Name.ToLower() == name.ToLower());
}



        public async Task<Vendor> AddVendorAsync(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();
            return vendor;
        }

        public async Task<IEnumerable<Vendor>> GetAllVendorsAsync()
        {
            return await _context.Vendors.Where(v=>v.IsActive==true)
                         .ToListAsync();
        }

        public async Task<Vendor> UpdateVendorAsync(int id, Vendor updatedVendor)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null) return null;

            vendor.Name = updatedVendor.Name;
            vendor.Description = updatedVendor.Description;
            vendor.ContactInfo = updatedVendor.ContactInfo;
            vendor.IsActive = updatedVendor.IsActive;
            vendor.EventCategoryId = updatedVendor.EventCategoryId;

            await _context.SaveChangesAsync();
            return vendor;
        }

        public async Task<bool> DeleteVendorAsync(int id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null) 
            return false;

            _context.Vendors.Remove(vendor); 
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
