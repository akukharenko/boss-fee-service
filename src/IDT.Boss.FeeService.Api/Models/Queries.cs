using IDT.Boss.FeeService.Api.Enums;

namespace IDT.Boss.FeeService.Api.Models
{
    /// <summary>
    /// Model with information to search the fee values for distributor.
    /// </summary>
    public sealed class GetDistributorFeeQuery
    {
        public int DistributorId { get; set; }
        public FeeAction FeeAction { get; set; }
        public PaymentType PaymentType { get; set; }
        public CardPaymentNetwork PaymentNetwork { get; set; }
        public Channel Channel { get; set; }
        public StatesTerritories State { get; set; }

        /// <summary>
        /// Amount to change to calculate fee and incentives.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Credit Card handler.
        /// </summary>
        public string CcHandle { get; set; }
    }

    /// <summary>
    /// Model with information to search the fee values for retailer.
    /// </summary>
    public sealed class GetRetailerFeeQuery
    {
        public int RetailerId { get; set; }
        public FeeAction FeeAction { get; set; }
        public PaymentType PaymentType { get; set; }
        public CardPaymentNetwork PaymentNetwork { get; set; }
        public RewardLevel RewardLevel { get; set; }
        public Channel Channel { get; set; }
        public StatesTerritories State { get; set; }

        /// <summary>
        /// Amount to change to calculate fee and incentives.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Credit Card handler.
        /// </summary>
        public string CcHandle { get; set; }
    }

    /// <summary>
    /// Model to search fee details based on the specific parameters.
    /// </summary>
    public sealed class GetFeeQuery
    {
        public UserType UserType { get; set; }
        public int UserId { get; set; }
        public FeeAction FeeAction { get; set; }
        public PaymentType PaymentType { get; set; }
        public CardPaymentNetwork PaymentNetwork { get; set; }
        public RewardLevel RewardLevel { get; set; }
        public Channel Channel { get; set; }
        public StatesTerritories State { get; set; }

        /// <summary>
        /// Amount to change to calculate fee and incentives.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Credit Card handler.
        /// </summary>
        public string CcHandle { get; set; }
    }
}
