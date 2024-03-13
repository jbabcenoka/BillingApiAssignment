namespace BillingServiceApi.Receipts.Classes
{
    public class Receipt
    {
        public string OrderNumber { get; set; } = string.Empty;
        public int UserId { get; set; }
        public Guid TransactionId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDateTime { get; set; }
    }
}
