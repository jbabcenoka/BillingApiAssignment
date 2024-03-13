using System.Runtime.Serialization;

namespace BillingServiceApi.PaymentGateways.Enums
{
    public enum PaymentGatewayEnum
    {
        [EnumMember(Value = "PayPal")]
        PayPal,
        [EnumMember(Value = "GatewayY")]
        GatewayY
    }
}
