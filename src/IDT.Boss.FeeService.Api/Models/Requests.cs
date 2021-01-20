using IDT.Boss.FeeService.Api.Enums;

namespace IDT.Boss.FeeService.Api.Models
{
    // TODO: here can be added more values and data to update the fees data

    /// <summary>
    /// Update model to set the new value for Load fee.
    /// </summary>
    public sealed class UpdateLoadFeeModel
    {
        /// <summary>
        /// Payment type (card type).
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Card payment network.
        /// </summary>
        public CardPaymentNetwork CardPaymentNetwork { get; set; }

        /// <summary>
        /// Load fee value to set.
        /// </summary>
        public decimal LoadFee { get; set; }
    }

    /// <summary>
    /// Model with values for default incentives (distributor and retailer).
    /// </summary>
    public sealed class UpdateDefaultIncentiveModel
    {
        /// <summary>
        /// Payment type (card type).
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Card payment network.
        /// </summary>
        public CardPaymentNetwork CardPaymentNetwork { get; set; }

        /// <summary>
        /// Distributor sales incentive value to set.
        /// </summary>
        public decimal DistributorIncentive { get; set; }

        /// <summary>
        /// Retailer incentives. All the values in one model for ech level.
        /// </summary>
        public RetailerSalesIncentive RetailerIncentives { get; set; }
    }

    /// <summary>
    /// Model with data to update the distributor incentives - create or update overrides.
    /// </summary>
    public sealed class UpdateDistributorIncentiveModel
    {
        /// <summary>
        /// Channel.
        /// </summary>
        public Channel Channel { get; set; } // ???

        /// <summary>
        /// Payment type (card type).
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Card payment network.
        /// </summary>
        public CardPaymentNetwork CardPaymentNetwork { get; set; }

        /// <summary>
        /// Sales incentive value to set.
        /// </summary>
        public decimal Incentive { get; set; }
    }

    /// <summary>
    /// Model with data to update the retailers incentives - create or update overrides.
    /// </summary>
    public sealed class UpdateRetailerIncentiveModel
    {
        /// <summary>
        /// Channel.
        /// </summary>
        public Channel Channel { get; set; } // ???

        /// <summary>
        /// Payment type (card type).
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Card payment network.
        /// </summary>
        public CardPaymentNetwork CardPaymentNetwork { get; set; }

        /// <summary>
        /// All the values in one model for ech level.
        /// </summary>
        public RetailerSalesIncentive Incentives { get; set; }
    }

    /// <summary>
    /// Model to identify which record with distributor override fee to remove (all the values).
    /// </summary>
    public sealed class DeleteDistributorIncentiveModel
    {
        /// <summary>
        /// Channel.
        /// </summary>
        public Channel Channel { get; set; } // ???

        /// <summary>
        /// Payment type (card type).
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Card payment network.
        /// </summary>
        public CardPaymentNetwork CardPaymentNetwork { get; set; }
    }

    /// <summary>
    /// Model to identify which record with retailer override fee to remove (all the values).
    /// </summary>
    public sealed class DeleteRetailerIncentiveModel
    {
        /// <summary>
        /// Channel.
        /// </summary>
        public Channel Channel { get; set; } // ???

        /// <summary>
        /// Payment type (card type).
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Card payment network.
        /// </summary>
        public CardPaymentNetwork CardPaymentNetwork { get; set; }
    }
}
