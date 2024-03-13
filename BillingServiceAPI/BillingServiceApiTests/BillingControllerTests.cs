using BillingServiceApi.Billings.Classes;
using BillingServiceApi.Billings.Services;
using BillingServiceApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BillingServiceApiTests
{
    [TestClass]
    public class BillingControllerTests
    {
        private readonly BillingService _billingService;

        public BillingControllerTests(
            BillingService billingService
        )
        {
            _billingService = billingService;
        }

        /* Test for successful order processing in billing controller */
        [TestMethod]
        public async Task BillingController_OrderProcessing_ValidOrder_ValidReceiptAsync()
        {
            // Arrange
            var controller = new BillingController(_billingService);
            var order = new Order
            {
                OrderNumber = "orderNumber1",
                PayableAmount = 0.1m,
                PaymentGateway = "PayPal",
                UserId = 12041,
                Description = "description",
            };

            // Act
            var result = await controller.ProcessOrder(order);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(SuccessResponse));
        }

        [TestMethod]
        public async Task BillingController_ProcessOrder_InvalidPaymentGateway_BadRequest()
        {
            // Arrange
            var controller = new BillingController(_billingService);

            var invalidOrder = new Order
            {
                OrderNumber = "orderNumber1",
                PayableAmount = 0.1m,
                PaymentGateway = "UnexistantPaymentGateway",
                UserId = 12041,
                Description = "description",
            };

            // Act
            var result = await controller.ProcessOrder(invalidOrder);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.AreEqual(400, badRequestResult?.StatusCode);
        }
    }
}