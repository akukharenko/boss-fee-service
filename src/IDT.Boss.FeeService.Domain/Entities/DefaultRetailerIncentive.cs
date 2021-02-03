namespace IDT.Boss.FeeService.Domain.Entities
{
    public sealed class DefaultRetailerIncentive : BaseEntity
    {
        public RetailerLoadIncentives RetailerIncentives { get; set; }
    }

    public sealed class DefaultRetailerIncentiveV2 : BaseEntity
    {
        public string RewardLevel { get; set; }
        public AuditableValue Incentive { get; set; }
    }
}
