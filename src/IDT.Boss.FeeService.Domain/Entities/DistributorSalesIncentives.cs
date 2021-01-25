namespace IDT.Boss.FeeService.Domain.Entities
{
    /// <summary>
    /// Model for specific distributor with overrides.
    /// </summary>
    public sealed class DistributorSalesIncentives : BaseEntity
    {
        public int DistributorId { get; set; }
        public AuditableValue SalesIncentive { get; set; }
    }
}
