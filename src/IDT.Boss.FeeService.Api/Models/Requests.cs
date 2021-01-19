using IDT.Boss.FeeService.Api.Enums;

namespace IDT.Boss.FeeService.Api.Models
{
    // TODO: here can be added more values and data to update the fees data

    /// <summary>
    /// Update model to set the new value for Load fee.
    /// </summary>
    public sealed class UpdateLoadFeeModel
    {
        public PaymentType PaymentType { get; set; }
        public CardPaymentNetwork CardPaymentNetwork { get; set; }
        public decimal LoadFee { get; set; }
    }

    /// <summary>
    /// Model with data to update the distributor incentives - create or update overrides.
    /// </summary>
    public sealed class UpdateDistributorIncentiveModel
    {
        public Channel Channel { get; set; } // ???
        public PaymentType PaymentType { get; set; }
        public CardPaymentNetwork CardPaymentNetwork { get; set; }
        public decimal Incentive { get; set; }
    }
    
    /// <summary>
    /// Model with data to update the retailers incentives - create or update overrides.
    /// </summary>
    public sealed class UpdateRetailerIncentiveModel
    {
        public Channel Channel { get; set; } // ???
        public PaymentType PaymentType { get; set; }
        public CardPaymentNetwork CardPaymentNetwork { get; set; }

        /// <summary>
        /// All the values in one model for ech level.
        /// </summary>
        public RetailerSalesIncentive Incentives { get; set; }
    }

    public sealed class DeleteDistributorIncentiveModel
    {
        public Channel Channel { get; set; } // ???
        public PaymentType PaymentType { get; set; }
        public CardPaymentNetwork CardPaymentNetwork { get; set; }
    }

    public sealed class DeleteRetailerIncentiveModel
    {
        public Channel Channel { get; set; } // ???
        public PaymentType PaymentType { get; set; }
        public CardPaymentNetwork CardPaymentNetwork { get; set; }
    }
}
