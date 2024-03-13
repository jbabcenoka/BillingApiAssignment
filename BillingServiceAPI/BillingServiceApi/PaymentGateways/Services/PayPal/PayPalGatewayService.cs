using BillingServiceApi.Billings.Classes;
using BillingServiceApi.PaymentGateways.Classes;
using BillingServiceApi.PaymentGateways.Enums;
using BillingServiceApi.PaymentGateways.Interfaces;
using BillingServiceApi.Properties;
using System.Text.Json;

namespace BillingServiceApi.PaymentGateways.Services.PaymentGatewayServiceX
{
    public class PayPalGatewayService : IPaymentGatewayService
    {
        private readonly string _apiKey = Settings.Default.PaymentGateways[PaymentGatewayEnum.PayPal].ApiKey;
        private readonly string _baseUrl = Settings.Default.PaymentGateways[PaymentGatewayEnum.PayPal].BaseUrl;
        private readonly string _paymentApiUrl = Settings.Default.PaymentGateways[PaymentGatewayEnum.PayPal].PaymentApiUrl;

        public async Task<OrderPaymentResult> PayOrder(Order order)
        {
            try
            {
                var orderJson = JsonSerializer.Serialize(order);
                var requestContent = new StringContent(orderJson, System.Text.Encoding.UTF8, "application/json");

                var responseMessage = await CreateHttpClient().PostAsync(_paymentApiUrl, requestContent);
                responseMessage.EnsureSuccessStatusCode();  

                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<PayPalResponse>(responseJson);
                if (response == null)
                {
                    throw new Exception("Invalid or missing response from the payment gateway.");
                }

                return new OrderPaymentResult
                {
                    Success = true,
                    PaymentDateTime = response.PaymentDateTime,
                    TransactionId = response.TransactionId
                };
            }
            catch (HttpRequestException ex)
            {
                return new OrderPaymentResult
                {
                    ErrorCode = ex.StatusCode,
                    ErrorMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new OrderPaymentResult
                {
                    ErrorMessage = ex.Message
                };
            }
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(30);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            return httpClient;
        }
    }
}
