using BillingServiceApi.Billings.Classes;
using BillingServiceApi.Receipts.Classes;

namespace BillingServiceApi.Receipts.Services
{
    public class ReceiptService
    {
        public Receipt GenerateReceipt(OrderPaymentResult orderResult)
        {
            return new Receipt
            {
                UserId = orderResult.UserId,
                TransactionId = orderResult.TransactionId,
                OrderNumber = orderResult.OrderNumber,
                PaymentAmount = orderResult.PaymentAmount,
                PaymentDateTime = orderResult.PaymentDateTime
            };
        }
    }
}
