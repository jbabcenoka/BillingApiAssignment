using BillingServiceApi.PaymentGateways.Enums;

namespace BillingServiceApi
{
    public class PaymentGatewayOptions
    {
        public Dictionary<PaymentGatewayEnum, GatewayConfig> PaymentGateways { get; set; }

        public class GatewayConfig
        {
            public string ApiKey { get; set; }
            public string BaseUrl { get; set; }
            public string PaymentApiUrl { get; set; }
        }
    }
}
