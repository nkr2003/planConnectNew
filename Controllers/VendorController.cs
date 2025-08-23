using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventManagement.DTOs;
using EventManagement.Interfaces;
using EventManagement.Models;
using EventManagement.Models.AdminModel;

namespace EventManagement.Controllers.AdminDashboardModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {

        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public VendorController(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

       [HttpPost("create-vendor")]
public async Task<IActionResult> CreateVendor([FromBody] CreateVendorDto vendorDto)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    // Check for duplicates based on Name (or any unique field you want)
    var existingVendor = await _vendorRepository.GetVendorByNameAsync(vendorDto.Name);
    if (existingVendor != null)
    {
        return Conflict(new { message = "A vendor with the same name already exists." });
    }

    var vendor = _mapper.Map<Vendor>(vendorDto);
    var result = await _vendorRepository.AddVendorAsync(vendor);
    return Ok(result);
}
        [HttpGet("get-all-vendors")]
        public async Task<IActionResult> GetAllVendors()
        {
            var vendors = await _vendorRepository.GetAllVendorsAsync();
            return Ok(vendors);
        }

        [HttpPut("update-vendor/{id}")]
        public async Task<IActionResult> UpdateVendor(int id, [FromBody] UpdateVendorDto vendorDto)
        {
            var vendor = _mapper.Map<Vendor>(vendorDto);
            var updatedVendor = await _vendorRepository.UpdateVendorAsync(id, vendor);
            if (updatedVendor == null)
                return NotFound();

            return Ok(updatedVendor);
        }

        [HttpDelete("delete-vendor/{id}")]
        public async Task<IActionResult> DeleteVendor([FromRoute]int id)
        {
            var success = await _vendorRepository.DeleteVendorAsync(id);
            if (!success)
                return NotFound(new { message = $"Vendor with ID {id} not found." });

            return Ok(new { message = "Vendor deleted successfully." });
        }


    }
}
