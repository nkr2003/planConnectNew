using EventManagement.Data;
using EventManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorFilterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendorFilterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Vendors(
            [FromQuery] string? location,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] double? minRating,
            [FromQuery] bool? isActive)
        {
            var query = _context.Vendors
               
                .AsQueryable();

            if (!string.IsNullOrEmpty(location))
                query = query.Where(v => v.Location.Contains(location));

            if (isActive.HasValue)
                query = query.Where(v => v.IsActive == isActive.Value);

            if (minRating.HasValue)
                query = query.Where(v => v.Rating >= minRating.Value);

            if (minPrice.HasValue || maxPrice.HasValue)
            {
                query = query.Where(v =>
                    v.VendorServices.Any(s =>
                        (!minPrice.HasValue || s.Price >= minPrice.Value) &&
                        (!maxPrice.HasValue || s.Price <= maxPrice.Value)));
            }

            var result = await query.ToListAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No vendors found matching the criteria.");
            }
            return Ok(result);
        }
    }
}
