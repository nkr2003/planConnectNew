using EventManagement.Models;
using EventManagement.Models.BookingModel;

namespace EventManagement.Interface.Repository
{
    public interface IBookingRequest
    {
        Task<List<BookingRequest>> GetAllBookingRequests();
         Task<BookingRequest> CreateBookingRequest(BookingRequest bookingRequest);
        Task<BookingRequest> UpdateBookingRequest(BookingRequest bookingRequest);
        Task<BookingRequest> DeleteBookingRequestById(int id);
        Task<BookingRequest> GetBookingRequest(int id);

        Task<List<BookingRequest>> ByFilter_status(string status);
        Task<IEnumerable<BookingRequest>> GetBookingRequestsByUserId(int userId);

        Task<List<BookingRequest>> FilterByDate(int month,int year);
    }
}
