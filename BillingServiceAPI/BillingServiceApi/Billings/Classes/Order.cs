using BillingServiceApi.PaymentGateways.Validators;
using System.ComponentModel.DataAnnotations;

namespace BillingServiceApi.Billings.Classes
{
    public class Order
    {
        [Required(ErrorMessage = "Order number is required.")]
        public string OrderNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Payable amount must be greater than 0.")]
        public decimal PayableAmount { get; set; }

        [Required(ErrorMessage = "Payment gateway is required.")]
        [PaymentGatewayValidator]
        public string PaymentGateway { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
