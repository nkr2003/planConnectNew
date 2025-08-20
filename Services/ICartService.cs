using EventManagement.Models;
using EventManagement.Models.AdminModel;

namespace EventManagement.Services
{
    public interface ICartService
    {
        Task<List<EventCategory>> GetEventsAll();
        Task<EventCategory> GetEventById(int id);

        IEnumerable<Vendor> GetVendorsAll();
        IEnumerable<Vendor> GetVendors(int eventId);

        IEnumerable<VendorService> GetVendorServicesAll();
        VendorService GetVendorServicesById(int id);
        IEnumerable<VendorService> GetVendorServicesByEventId(int eventId);
    }
}
