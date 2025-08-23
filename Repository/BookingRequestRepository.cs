using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using EventManagement.Data;
using EventManagement.Interface.Repository;
using EventManagement.Models;
using EventManagement.Models.BookingModel;

namespace EventManagement.Repository
{
    public class BookingRequestRepository : IBookingRequest
    {
        private readonly ApplicationDbContext _context;
        public BookingRequestRepository(ApplicationDbContext contrext)
        {
            _context = contrext;
        }

        public async Task<List<BookingRequest>> ByFilter_status(string status)
        {
            var model = await _context.BookingRequests.Where(a => a.BookingStatus == status).ToListAsync();
            if (model == null)
            {
                return null;
            }
            return model;
        }

        public async Task<BookingRequest> CreateBookingRequest(BookingRequest bookingRequest)
        {
            var BookingRequrests = _context.BookingRequests.Add(bookingRequest);
            await _context.SaveChangesAsync();
            return bookingRequest;
        }

        public async Task<BookingRequest> DeleteBookingRequestById(int id)
        {
            var model = await _context.BookingRequests.FirstOrDefaultAsync(a => a.BookingId == id);
            if (model == null)
            {
                return null;
            }

            _context.BookingRequests.Remove(model);
            await _context.SaveChangesAsync();
            return model;



        }

        public async Task<List<BookingRequest>> FilterByDate(int month, int year)
        {
            var model = await _context.BookingRequests.Where(a => a.BookingDate.Month == month && a.BookingDate.Year == year).ToListAsync();

            if (model == null)
            {
                return null;
            }

            return model;

        }

        public async Task<List<BookingRequest>> GetAllBookingRequests()
        {
            var bookingDomain = await _context.BookingRequests.ToListAsync();
            if (bookingDomain == null) { return null; }
            return bookingDomain;
        }

        public async Task<BookingRequest> GetBookingRequest(int id)
        {
            var getBookingRequest = await _context.BookingRequests.FirstOrDefaultAsync(a => a.BookingId == id);
            if (getBookingRequest == null)
            {
                return null;
            }
            return getBookingRequest;


        }

        // public async Task<List<BookingRequest>> GetBookingRequestsByUserId(int userId)
        // {
        //     // Fetch all bookings where the UserId matches
        //     var bookings = await _context.BookingRequests
        //                                  .Where(br => br.UserId == userId)
        //                                  .ToListAsync();

        //     // You’ll get an empty list if none found
        //     return bookings;
        // }

        public async Task<BookingRequest> UpdateBookingRequest(BookingRequest bookingRequest)
        {
            var updatingBookingRequest = await _context.BookingRequests.FindAsync(bookingRequest.BookingId);
            if (updatingBookingRequest == null) return null;
            // updatingBookingRequest.BookingDescription = bookingRequest.BookingDescription;

            updatingBookingRequest.ExpectedAmount = bookingRequest.ExpectedAmount;
            updatingBookingRequest.BookingId = bookingRequest.BookingId;
            updatingBookingRequest.BookingDate = bookingRequest.BookingDate;
            updatingBookingRequest.BookingStatus = bookingRequest.BookingStatus;

            await _context.SaveChangesAsync();
            return updatingBookingRequest;


        }

        async Task<IEnumerable<BookingRequest>> IBookingRequest.GetBookingRequestsByUserId(int userId)
        {
             var bookings = await _context.BookingRequests
                                         .Where(br => br.UserId == userId)
                                         .ToListAsync();

            // You’ll get an empty list if none found
            return bookings;
        }
    }
}
