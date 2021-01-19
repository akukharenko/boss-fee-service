using IDT.Boss.FeeService.Api.Enums;

namespace IDT.Boss.FeeService.Api.Models
{
    /// <summary>
    /// Full model with the fee data for specific request - default values.
    /// </summary>
    public sealed class FeeModel
    {
        /// <summary>
        /// Id of the record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Channel.
        /// </summary>
        public Channel Channel { get; set; }

        /// <summary>
        /// Payment type (CreditCard, DebitCard, Bank).
        /// </summary>
        public PaymentType PaymentType { get; set; }
        
        /// <summary>
        /// Card payment network.
        /// </summary>
        public CardPaymentNetwork CardPaymentNetwork { get; set; }
       
        /// <summary>
        /// Load fee value (positive).
        /// </summary>
        public decimal LoadFee { get; set; }
        
        /// <summary>
        /// Distributor sales incentive.
        /// </summary>
        public decimal DistributorIncentive { get; set; }

        /// <summary>
        /// Retailer sales incentives per VIP level.
        /// </summary>
        public RetailerSalesIncentive RetailerIncentive { get; set; }
    }
    
    /// <summary>
    /// Details for Retailer sales incentives for each level.
    /// </summary>
    public sealed class RetailerSalesIncentive
    {
        /// <summary>
        /// Incentive for Platinum level.
        /// </summary>
        public decimal PlatinumIncentive { get; set; }

        /// <summary>
        /// Incentive for Gold level.
        /// </summary>
        public decimal GoldIncentive { get; set; }

        /// <summary>
        /// Incentive for Silver level.
        /// </summary>
        public decimal SilverIncentive { get; set; }

        /// <summary>
        /// Incentive for Bronze level.
        /// </summary>
        public decimal BronzeIncentive { get; set; }

        /// <summary>
        /// Incentive for no level (default).
        /// </summary>
        public decimal NoLevelIncentive { get; set; }
    }

    /// <summary>
    /// Model described fee for distributor.
    /// </summary>
    public sealed class DistributorFeeModel
    {
        /// <summary>
        /// Distributor id.
        /// </summary>
        public int DistributorId { get; set; }

        /// <summary>
        /// Channel.
        /// </summary>
        public Channel Channel { get; set; }

        /// <summary>
        /// Payment type (card type).
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Card network.
        /// </summary>
        public CardPaymentNetwork CardPaymentNetwork { get; set; }

        /// <summary>
        /// Load fee value (positive).
        /// </summary>
        public decimal LoadFee { get; set; }

        /// <summary>
        /// Distributor default incentive
        /// </summary>
        public decimal DefaultIncentive { get; set; }

        /// <summary>
        /// Distributor override incentive
        /// </summary>
        public decimal OverrideIncentive { get; set; }

        /// <summary>
        /// Is incentive overridden.
        /// </summary>
        public bool IsIncentiveOverridden { get; set; }
    }

    /// <summary>
    /// Model described fee for retailer.
    /// </summary>
    public sealed class RetailerFeeModel
    {
        /// <summary>
        /// Retailer id.
        /// </summary>
        public int RetailerId { get; set; }

        /// <summary>
        /// Channel.
        /// </summary>
        public Channel Channel { get; set; }

        /// <summary>
        /// Payment type (CreditCard, DebitCard, Bank).
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Card payment network.
        /// </summary>
        public CardPaymentNetwork CardPaymentNetwork { get; set; }

        /// <summary>
        /// Load fee value (positive).
        /// </summary>
        public decimal LoadFeeValue { get; set; }

        /// <summary>
        /// Retailer sales incentives per VIP level.
        /// </summary>
        public RetailerSalesIncentive RetailerDefaultIncentive { get; set; }

        /// <summary>
        /// Retailer sales incentives per VIP level - overrides.
        /// </summary>
        public RetailerSalesIncentive RetailerIncentiveOverride { get; set; }

        /// <summary>
        /// Is incentive overridden - at least one value.
        /// </summary>
        public bool IsIncentiveOverridden { get; set; }
    }
}