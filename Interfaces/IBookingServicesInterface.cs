using EventManagement.DTOs;
using EventManagement.Services;
using EventManagement.DTOs;

namespace EventManagement.Interface.services
{
    public interface IBookingServicesInterface
    {
        Task<List<CreateBookingDto>> GetAllBookings();
        Task<CreateBookingDto> Delete(int id);
        Task<CreateBookingDto> CreateBookingRequest(CreateBookingDto createBookingDto);
        Task<CreateBookingDto> GetBookingRequestById(int id);
        // Task<IEnumerable<CreateBookingDto>> GetBookingRequestsByUserId(int userId);
        Task<List<CreateBookingDto>> GetByFilter(string status);

        Task<List<CreateBookingDto>> GetByDate(int month,int year);
        Task<UpdateBookingDto> UpdateBookingRequest(UpdateBookingDto Dto);
    }
}  