namespace IDT.Boss.FeeService.Domain.Entities
{
    public sealed class DefaultDistributorIncentive : BaseEntity
    {
        public AuditableValue SalesIncentive { get; set; }
    }
}