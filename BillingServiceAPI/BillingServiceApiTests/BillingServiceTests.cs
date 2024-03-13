using BillingServiceApi.Billings.Classes;
using BillingServiceApi.Billings.Services;

namespace BillingServiceApiTests
{
    public class BillingServiceTests
    {
        private readonly BillingService _billingService;

        public BillingServiceTests(
            BillingService billingService
        )
        {
            _billingService = billingService;
        }

        /* Test for successful order processing in billing service */
        [TestMethod]
        public async Task BillingService_OrderProcessing_ValidOrder_ValidReceiptAsync()
        {
            // Arrange
            var order = new Order
            {
                OrderNumber = "orderNumber1",
                PayableAmount = 0.1m,
                PaymentGateway = "PayPal",
                UserId = 12041,
                Description = "description",
            };

            // Act
            var result = await _billingService.ProcessOrder(order);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Receipt);
        }
    }
}
