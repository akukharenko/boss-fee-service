namespace IDT.Boss.FeeService.Domain.Entities
{
    /// <summary>
    /// Load fee.
    /// </summary>
    public sealed class LoadFee : BaseEntity
    {
        /// <summary>
        /// Value for he Load fee.
        /// </summary>
        public AuditableValue Value { get; set; }
    }
}
