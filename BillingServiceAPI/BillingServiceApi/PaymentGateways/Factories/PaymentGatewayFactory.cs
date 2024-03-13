using BillingServiceApi.PaymentGateways.Enums;
using BillingServiceApi.PaymentGateways.Interfaces;
using BillingServiceApi.PaymentGateways.Services;
using BillingServiceApi.PaymentGateways.Services.PaymentGatewayServiceX;

namespace BillingServiceApi.PaymentGateways.Factories
{
    /*
        The factory contains an example of how payment gateways can be handled and processed.
        To actually intigrate the payment gateway, you need to connect specific payment gateways, use a test account that they provides
        and figure out what needs to be requested to that payment gateway and what contains his response.
    */
    public class PaymentGatewayFactory
    {
        private readonly string _paymentGatewayKey;

        public PaymentGatewayFactory(string paymentGatewayKey)
        {
            _paymentGatewayKey = paymentGatewayKey;
        }

        public IPaymentGatewayService GetPaymentGatewayService()
        {
            if (!Enum.TryParse<PaymentGatewayEnum>(_paymentGatewayKey, true, out var gateway))
            {
                throw new InvalidOperationException($"Payment gateway '{_paymentGatewayKey}' does not exist.");
            }

            return gateway switch
            {
                PaymentGatewayEnum.PayPal => new PayPalGatewayService(),
                PaymentGatewayEnum.GatewayY => new PaymentGatewayServiceY(),
                _ => throw new InvalidOperationException($"Payment gateway '{_paymentGatewayKey}' does not exist.")
            };
        }
    }
}
