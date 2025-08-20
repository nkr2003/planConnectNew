using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Models;
using EventManagement.Models.PaymentModel;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentRepository _repo;
    private readonly IMapper _mapper;

    public PaymentsController(IPaymentRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
 

    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<PaymentDto>>> GetPaymentsBetweenDates(
      [FromQuery] int Day,
      [FromQuery] int Month,
      [FromQuery] int Year)
    {
        

        var payments = await _repo.GetPaymentsForDatesAsync(Day, Month, Year);
        return Ok(_mapper.Map<IEnumerable<PaymentDto>>(payments));
    }
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var payments = await _repo.GetAllAsync();
        if (payments == null || !payments.Any()) { return NotFound("No payments"); }
        return Ok(_mapper.Map<List<PaymentDto>>(payments));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentDto>> GetById(int id)
    {
        var payment = await _repo.GetByIdAsync(id);
        if (payment == null) return NotFound();
        return Ok(_mapper.Map<PaymentDto>(payment));
    }

    [HttpPost]
    public async Task<ActionResult<PaymentDto>> Create(PaymentDto dto)
    {
        if (dto == null)
        {
            return BadRequest();
        }
        var entity = _mapper.Map<Payment>(dto);
        entity.PaidAt = DateTime.UtcNow;
        var created = await _repo.CreateAsync(entity);
        // return CreatedAtAction(nameof(GetById), new { id = created.PaymentId }, _mapper.Map<PaymentDto>(created));
        return Ok("Payment created successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _repo.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }
}























//[HttpGet("filter")]
//public async Task<ActionResult<IEnumerable<PaymentDto>>> GetPaymentsBetweenDates(
//   [FromQuery] DateTime startDate,
//   [FromQuery] DateTime endDate)
//{
//    if (startDate == default(DateTime) || endDate == default(DateTime))
//    {
//        return BadRequest("Both startDate and endDate query parameters are required.");
//    }
//    if (startDate > endDate)
//    {
//        return BadRequest("startDate cannot be after endDate.");
//    }

//    var payments = await _repo.GetPaymentsBetweenDatesAsync(startDate, endDate);
//    return Ok(_mapper.Map<IEnumerable<PaymentDto>>(payments));
//}