using EventManagement.Models.AdminModel;

namespace EventManagement.Interfaces
{

    public interface IVendorServicesRepository
    {
        Task<VendorService> AddVendorServiceAsync(VendorService vendorService); //(Adds a new service linked to a vendor)
        Task<IEnumerable<VendorService>> GetAllVendorServicesAsync(); //(Retrieves a list of all services across vendors)
        Task<VendorService> UpdateVendorServiceAsync(int id, VendorService updatedService);
        //(Updates an existing service’s details)
        Task<bool> DeleteVendorServiceAsync(int id); //(Soft-deletes a vendor’s specific service)
    }

}
