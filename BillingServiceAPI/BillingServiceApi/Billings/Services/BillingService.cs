using BillingServiceApi.Billings.Classes;
using BillingServiceApi.PaymentGateways.Factories;
using BillingServiceApi.Receipts.Services;
using BillingServiceApi.PaymentGateways.Classes;

namespace BillingServiceApi.Billings.Services
{
    public class BillingService
    {
        private readonly ILogger _logger;
        private readonly ReceiptService _receiptService;

        public BillingService(
            ILogger<BillingService> logger,
            ReceiptService receiptService
        )
        {
            _logger = logger;
            _receiptService = receiptService;
        }

        public async Task<OrderProcessingResult> ProcessOrder(Order order)
        {
            try
            {
                var factory = new PaymentGatewayFactory(order.PaymentGateway.Trim());
                var paymentGatewayService = factory.GetPaymentGatewayService();

                var orderResult = await paymentGatewayService.PayOrder(order);
                if (!orderResult.Success)
                {
                    _logger.LogError($"Order processing failed: {orderResult.ErrorCode} - {orderResult.ErrorMessage}", orderResult.ErrorCode, orderResult.ErrorMessage);
                    return new OrderProcessingResult { Success = false };
                }

                var receipt = _receiptService.GenerateReceipt(orderResult);
                if (receipt == null)
                {
                    _logger.LogError("Receipt generation failed.");
                    return new OrderProcessingResult { Success = false };
                }

                return new OrderProcessingResult
                {
                    Success = true,
                    Receipt = receipt
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during order processing.");
                return new OrderProcessingResult { Success = false };
            }
        }
    }
}