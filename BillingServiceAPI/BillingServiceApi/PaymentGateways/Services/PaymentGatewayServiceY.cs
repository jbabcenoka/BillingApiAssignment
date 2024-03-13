using BillingServiceApi.Billings.Classes;
using BillingServiceApi.PaymentGateways.Enums;
using BillingServiceApi.PaymentGateways.Interfaces;
using BillingServiceApi.Properties;

namespace BillingServiceApi.PaymentGateways.Services
{
    public class PaymentGatewayServiceY : IPaymentGatewayService
    {
        private readonly string _apiKey = Settings.Default.PaymentGateways[PaymentGatewayEnum.GatewayY].ApiKey;
        private readonly string _baseUrl = Settings.Default.PaymentGateways[PaymentGatewayEnum.GatewayY].BaseUrl;
        private readonly string _paymentApiUrl = Settings.Default.PaymentGateways[PaymentGatewayEnum.GatewayY].PaymentApiUrl;

        public async Task<OrderPaymentResult> PayOrder(Order order)
        {
            // Y payment gateway request and response
            return new OrderPaymentResult() { };
        }

        private HttpClient CreateHttpClient()
        {
            // Y http client configuration
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(30);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            return httpClient;
        }
    }
}
