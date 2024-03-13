namespace BillingServiceApi.PaymentGateways.Classes
{
    public class PayPalResponse
    {
        public Guid TransactionId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDateTime { get; set; }

        //Other PaymentGatewayX response details
    }
}
