using BillingServiceApi.Receipts.Classes;

namespace BillingServiceApi.PaymentGateways.Classes
{
    public class OrderProcessingResult
    {
        public bool Success { get; set; }
        public Receipt Receipt { get; set; }
    }
}
