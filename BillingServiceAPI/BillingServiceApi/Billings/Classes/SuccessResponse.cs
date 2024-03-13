using BillingServiceApi.Receipts.Classes;

namespace BillingServiceApi.Billings.Classes
{
    public class SuccessResponse
    {
        public SuccessResponse(Receipt receipt)
        { 
            Receipt = receipt;
        }

        public Receipt Receipt { get; set; }
    }
}
