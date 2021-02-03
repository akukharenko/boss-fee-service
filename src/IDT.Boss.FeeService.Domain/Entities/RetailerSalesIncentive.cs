namespace IDT.Boss.FeeService.Domain.Entities
{
    /// <summary>
    /// Model with specific retailer override.
    /// Complex model with all the levels in one model and 3 level model (Retailer->Incentives->Inventive Value).
    /// </summary>
    public sealed class RetailerLoadIncentive : BaseEntity
    {
        public int RetailerId { get; set; }
        public RetailerLoadIncentives RetailerIncentives { get; set; }
    }

    /// <summary>
    /// Model with simple record to store the incentive for retailer by reward level.
    /// </summary>
    public sealed class RetailerLoadIncentiveV2 : BaseEntity
    {
        public int RetailerId { get; set; }
        public string RewardLevel { get; set; }
        public AuditableValue Incentive { get; set; }
    }
}