namespace BillingServiceApi
{
    public class PaymentGatewayOptionsConfiguration
    {
        public string ConfigSectionName => "PaymentGateways";

        public static readonly PaymentGatewayOptionsConfiguration Instance = new PaymentGatewayOptionsConfiguration();

        public PaymentGatewayOptions Options { get; protected set; }
        public IConfiguration Configuration { get; protected set; }

        public void Set(PaymentGatewayOptions options, IConfiguration config)
        {
            Configuration = config;
            Bind(options, config);
            Options = options;
        }

        public void Bind(PaymentGatewayOptions options, IConfiguration config)
        {
            config.GetSection(ConfigSectionName).Bind(options, c => c.BindNonPublicProperties = true);
        }
    }
}

namespace BillingServiceApi.Properties
{
    public partial class Settings
    {
        public static PaymentGatewayOptions Default => PaymentGatewayOptionsConfiguration.Instance.Options;
    }
}
