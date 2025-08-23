using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventManagement.DTOs;
using EventManagement.Interface.Repository;
using EventManagement.Interface.services;
using EventManagement.Models;
using EventManagement.Repository;
using EventManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingRequestController : ControllerBase
    {

        private readonly IBookingServicesInterface _services;
        private readonly ApplicationDbContext _context;

        public BookingRequestController(IBookingServicesInterface services, ApplicationDbContext context)
        {

            _services = services;
            _context = context;
        }

        [HttpGet("allBookings")]

        public async Task<IActionResult> GetAllBookings()
        {
            var dto = await _services.GetAllBookings();
            if (dto == null) { return NotFound("No Bookings Found"); }
            return Ok(dto);

        }
        [HttpGet("id")]

        public async Task<IActionResult> GetBookingById(int id)
        {
            var dto = await _services.GetBookingRequestById(id);
            if (dto == null)
                return NotFound("Id not found");
            return Ok(dto);

        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateBookingRequest(CreateBookingDto createBookingDto)
        {
            var dto = await _services.CreateBookingRequest(createBookingDto);
            return Ok(dto);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBookingRequest(int Id)
        {
            var deletedto = await _services.Delete(Id);
            if (deletedto == null)
                return NotFound("Id not found");
            return Ok("Deleted Successfully");
        }

        [HttpGet("filterByStatus")]
        public async Task<IActionResult> FilterByStatus(String status)
        {
            var dto = await _services.GetByFilter(status);
            if (dto == null || dto.Count == 0)
                return NotFound();


            return Ok(dto);
        }

        [HttpGet("filterByDate")]
        public async Task<List<CreateBookingDto>> filterByDate(int Month, int Year)
        {
            var dto = await _services.GetByDate(Month, Year);
            return dto;
        }

        [HttpPut("post")]
        public async Task<IActionResult> UpdateBookingRequest(UpdateBookingDto dto)
        {
            var model = await _services.UpdateBookingRequest(dto);
            return Ok(model);
        }

        [HttpGet("userId")]
        public async Task<IActionResult> GetBookingByUserId( int userId)
        {
            var data = await _context.BookingRequests.Where(r => r.UserId == userId).ToListAsync();
            if (data == null) return BadRequest("No data ");
            return Ok(data);
        }
    }
}
