namespace IDT.Boss.FeeService.Domain.Entities
{
    /// <summary>
    /// Model with specific retailer override.
    /// Complex model with all the levels in one model and 3 level model (Retailer->Incentives->Inventive Value).
    /// </summary>
    public sealed class RetailerSalesIncentive : BaseEntity
    {
        public int RetailerId { get; set; }
        public RetailerSalesIncentives RetailerIncentives { get; set; }
    }

    /// <summary>
    /// Model with simple record to store the incentive for retailer by reward level.
    /// </summary>
    public sealed class RetailerSalesIncentiveV2 : BaseEntity
    {
        public int RetailerId { get; set; }
        public string RewardLevel { get; set; }
        public AuditableValue Incentive { get; set; }
    }
}