using System.Net;

namespace BillingServiceApi.Billings.Classes
{
    public class OrderPaymentResult
    {
        public bool Success { get; set; }
        public HttpStatusCode? ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public Guid TransactionId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDateTime { get; set; }
    }
}
