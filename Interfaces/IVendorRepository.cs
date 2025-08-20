using EventManagement.Models;
using EventManagement.Models.AdminModel;

namespace EventManagement.Interfaces
{
    public interface IVendorRepository
    {

        Task<Vendor> AddVendorAsync(Vendor vendor); //c(Adds a new vendor to the system)

        Task<IEnumerable<Vendor>> GetAllVendorsAsync(); //r(Retrieves a list of all registered vendors)
        Task<Vendor> UpdateVendorAsync(int id, Vendor updatedVendor); //u(Updates the vendor details for the given ID)
        Task<bool> DeleteVendorAsync(int id); //r(Soft or hard deletes the vendor record based on implementation)
    }
}
