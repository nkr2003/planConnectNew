using Microsoft.AspNetCore.Mvc;
using EventManagement.Services;

namespace EventManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // Change the action method to be async and await the Task<List<EventCategory>> result
        [HttpGet("events-categories")]
        public async Task<IActionResult> GetEventsAll()
        {
            var events = await _cartService.GetEventsAll();
            if (events == null || !events.Any())
                return NotFound("No events found");
            return Ok(events);
        }

        // GET: api/cart/events/{id}
        [HttpGet("events/{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var eventCategory = await _cartService.GetEventById(id);
            if (eventCategory == null)
                return NotFound($"No event found with ID {id}");

            return Ok(eventCategory);
        }

        // GET: api/cart/vendors
        [HttpGet("vendors")]
        public IActionResult GetVendors()
        {
            var vendors = _cartService.GetVendorsAll();
            return Ok(vendors);
        }

        // GET: api/cart/vendors/byevent/{eventId}
        [HttpGet("vendors/byevent/{eventId}")]
        public IActionResult GetVendorByEventId(int eventId)
        {
            var vendors = _cartService.GetVendors(eventId);
            return Ok(vendors);
        }

        // GET: api/cart/vendorservices
        [HttpGet("vendorservices")]
        public IActionResult GetVendorServicesAll()
        {
            var services = _cartService.GetVendorServicesAll();
            return Ok(services);
        }

        // GET: api/cart/vendorservices/{id}
        [HttpGet("vendorservices/{id}")]
        public IActionResult GetVendorServicesById(int id)
        {
            var service = _cartService.GetVendorServicesById(id);
            if (service == null)
                return NotFound($"No vendor service found with ID {id}");

            return Ok(service);
        }

        // GET: api/cart/vendorservices/byevent/{eventId}
        [HttpGet("vendorservices/byevent/{eventId}")]
        public IActionResult GetVendorServicesByEventId(int eventId)
        {
            var services = _cartService.GetVendorServicesByEventId(eventId);
            return Ok(services);
        }
    }
}