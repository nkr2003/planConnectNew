public class PaymentDto
{
    public int PaymentId { get; set; }
    public double Amount { get; set; }
    public string PaymentMethod { get; set; }
    public string TransactionId { get; set; }
    public bool IsSuccessful { get; set; }
    public DateTime PaidAt { get; set; }
    public int UserId { get; set; }
}

