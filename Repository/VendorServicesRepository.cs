using Microsoft.EntityFrameworkCore;
using EventManagement.Interfaces;
using EventManagement.Models.AdminModel;
using EventManagement.Data;

namespace EventManagement.Repository
{
    public class VendorServicesRepository : IVendorServicesRepository
    {
        private readonly ApplicationDbContext _context;
        public VendorServicesRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<VendorService> AddVendorServiceAsync(VendorService vendorService)
        {
            _context.VendorServices.Add(vendorService);
            await _context.SaveChangesAsync();
            return vendorService;
        }

        public async Task<IEnumerable<VendorService>> GetAllVendorServicesAsync()
        {
            return await _context.VendorServices.Where(e=>e.IsDeleted==false)
                .Include(v => v.Vendor)
                .ToListAsync();
        }

        public async Task<VendorService> UpdateVendorServiceAsync(int id, VendorService updatedService)
        {
            var service = await _context.VendorServices.FindAsync(id);
            if (service == null) return null;

            service.ServiceName = updatedService.ServiceName;
            service.ServiceDescription = updatedService.ServiceDescription;
            service.Price = updatedService.Price;
            service.IsDeleted = updatedService.IsDeleted;
            service.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<bool> DeleteVendorServiceAsync(int id)
        {
            var service = await _context.VendorServices.FindAsync(id);
            if (service == null) return false;

            service.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
