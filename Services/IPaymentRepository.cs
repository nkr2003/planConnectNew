using EventManagement.Models;
using EventManagement.Models.PaymentModel;

public interface IPaymentRepository
{
    Task<List<Payment>> GetAllAsync();
    Task<Payment?> GetByIdAsync(int id);
    Task<Payment> CreateAsync(Payment payment);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Payment>> GetPaymentsForDatesAsync(int Day, int Month , int Year);
}
