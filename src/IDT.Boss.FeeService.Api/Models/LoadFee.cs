namespace IDT.Boss.FeeService.Api.Models
{
    // TODO: extend if needed to have information about unit type.

    /// <summary>
    /// Fee model to use in the external applications.
    /// </summary>
    public sealed class Fee
    {
        /// <summary>
        /// Load fee.
        /// </summary>
        public LoadFee LoadFee { get; set; }

        /// <summary>
        /// Sales incentive. Always a negative in relation to load fee.
        /// </summary>
        public SalesIncentive SalesIncentive { get; set; }
    }

    /// <summary>
    /// Load fee model.
    /// </summary>
    public sealed class LoadFee
    {
        /// <summary>
        /// Load fee value.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Load fee unit
        /// </summary>
        //public Unit LoadFeeUnit { get; set; }
    }

    /// <summary>
    /// Sales incentive model.
    /// </summary>
    public sealed class SalesIncentive
    {
        /// <summary>
        /// Incentive value.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Incentive unit
        /// </summary>
        //public Unit IncentiveUnit { get; set; }
    }
}
