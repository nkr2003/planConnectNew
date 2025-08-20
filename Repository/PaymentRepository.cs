using Microsoft.EntityFrameworkCore;
using EventManagement.Models;
using EventManagement.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using EventManagement.Models.PaymentModel;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _context;

    public PaymentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Payment>> GetAllAsync() =>
        await _context.Payments.ToListAsync();

    public async Task<Payment?> GetByIdAsync(int id) =>
        await _context.Payments.FindAsync(id);

    public async Task<Payment> CreateAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null) return false;
        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
        return true;

    }
    public async Task<IEnumerable<Payment>> GetPaymentsForDatesAsync(int  Day, int  Month , int Year)
    {
        var data =  _context.Payments.AsQueryable();
        if(Day>0 && Day <= 31)
        {
            data = data.Where(p => p.PaidAt.Day == Day);
        }


        if (Month > 0 && Month <= 12)
        {
            data = data.Where(p => p.PaidAt.Month == Month);
        }
        if(Year > 0)
        {
            data = data.Where(p => p.PaidAt.Year == Year);
        }

        return await  data.ToListAsync();

    }
}
