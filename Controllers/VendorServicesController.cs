using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventManagement.DTOs;
using EventManagement.Interfaces;
using EventManagement.Models.AdminModel;


namespace EventManagement.Controllers.AdminDashboardModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorServicesController : ControllerBase
    {
        private readonly IVendorServicesRepository _vendorServicesRepository;
        public VendorServicesController(IVendorServicesRepository vendorServicesRepository) {
            _vendorServicesRepository = vendorServicesRepository;   
        }

            [HttpPost("create")]
            public async Task<IActionResult> CreateVendorService([FromBody] CreateVendorSeviceDto dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = new VendorService
                {
                    ServiceName = dto.ServiceName,
                    ServiceDescription = dto.ServiceDescription,
                    Price = dto.Price,
                    VendorId = dto.VendorId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                var result = await _vendorServicesRepository.AddVendorServiceAsync(service);
                return Ok(result);
            }

            [HttpGet("all")]
            public async Task<IActionResult> GetAllVendorServices()
            {
                var services = await _vendorServicesRepository.GetAllVendorServicesAsync();
                return Ok(services);
            }

            [HttpPut("update/{id}")]
            public async Task<IActionResult> UpdateVendorService(int id, [FromBody] UpdateVendorServiceDto dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updatedService = new VendorService
                {
                    ServiceName = dto.ServiceName,
                    ServiceDescription = dto.ServiceDescription,
                    Price = dto.Price,
                    IsDeleted = dto.IsDeleted,
                    UpdatedAt = DateTime.Now
                };

                var result = await _vendorServicesRepository.UpdateVendorServiceAsync(id, updatedService);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }

            [HttpDelete("delete/{id}")]
            public async Task<IActionResult> DeleteVendorService ([FromRoute] int id)
            {
                var success = await _vendorServicesRepository.DeleteVendorServiceAsync(id);
                if (!success)
                    return NotFound();

                return Ok(new { message = "Vendor service deleted successfully." });
            }


        }
    }
