using IDT.Boss.FeeService.Api.Enums;

namespace IDT.Boss.FeeService.Api.Models
{
    public sealed class GetDistributorFeeQuery
    {
        public int DistributorId { get; set; }
        public FeeAction FeeAction { get; set; }
        public PaymentType PaymentType { get; set; }
        public CardPaymentNetwork PaymentNetwork { get; set; }
        public Channel Channel { get; set; }
        public StatesTerritories State { get; set; }
    }

    public sealed class GetRetailerFeeQuery
    {
        public int RetailerId { get; set; }
        public FeeAction FeeAction { get; set; }
        public PaymentType PaymentType { get; set; }
        public CardPaymentNetwork PaymentNetwork { get; set; }
        public RewardLevel RewardLevel { get; set; }
        public Channel Channel { get; set; }
        public StatesTerritories State { get; set; }
    }

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
    }
}
