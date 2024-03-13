using BillingServiceApi.PaymentGateways.Enums;
using System.ComponentModel.DataAnnotations;

namespace BillingServiceApi.PaymentGateways.Validators
{
    public class PaymentGatewayValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var paymentGatewayId = value?.ToString();
            if (string.IsNullOrEmpty(paymentGatewayId))
            {
                return new ValidationResult("Payment gateway must not be empty.");
            }

            var paymentGateway = value?.ToString();
            if (!Enum.TryParse<PaymentGatewayEnum>(paymentGateway, true, out var gateway))
            {
                return new ValidationResult("Invalid payment gateway.");
            }

            return ValidationResult.Success;
        }
    }
}
