using IDT.Boss.FeeService.Api.Enums;

namespace IDT.Boss.FeeService.Api.Models
{
    /// <summary>
    /// Full model with the fee data for specific request - default values.
    /// </summary>
    public sealed class FeeModel
    {
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
        public decimal DistributorSalesIncentive { get; set; }

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
        public decimal PlatinumIncentive { get; set; }

        public decimal GoldIncentive { get; set; }

        public decimal SilverIncentive { get; set; }

        public decimal BronzeIncentive { get; set; }

        public decimal NoLevelIncentive { get; set; }
    }

    public sealed class DistributorFeeModel
    {
        public int Id { get; set; }
        
        public Channel Channel { get; set; }

        public PaymentType PaymentType { get; set; }

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

    public sealed class RetailerFeeModel
    {
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