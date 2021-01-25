namespace IDT.Boss.FeeService.Domain.Entities
{
    /// <summary>
    /// Details for Retailer sales incentives for each level.
    /// </summary>
    public sealed class RetailerSalesIncentives
    {
        /// <summary>
        /// Incentive for Platinum level.
        /// </summary>
        public AuditableValue PlatinumIncentive { get; set; }

        /// <summary>
        /// Incentive for Gold level.
        /// </summary>
        public AuditableValue GoldIncentive { get; set; }

        /// <summary>
        /// Incentive for Silver level.
        /// </summary>
        public AuditableValue SilverIncentive { get; set; }

        /// <summary>
        /// Incentive for Bronze level.
        /// </summary>
        public AuditableValue BronzeIncentive { get; set; }

        /// <summary>
        /// Incentive for no level (default).
        /// </summary>
        public AuditableValue NoLevelIncentive { get; set; }
    }
}