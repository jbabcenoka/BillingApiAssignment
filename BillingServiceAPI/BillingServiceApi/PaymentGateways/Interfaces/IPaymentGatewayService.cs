using BillingServiceApi.Billings.Classes;

namespace BillingServiceApi.PaymentGateways.Interfaces
{
    public interface IPaymentGatewayService
    {
        Task<OrderPaymentResult> PayOrder(Order order);
    }
}
