namespace IDT.Boss.FeeService.Api.Models
{
    /// <summary>
    /// Fee model to use in the external applications.
    /// </summary>
    public sealed class Fee
    {
        /// <summary>
        /// Calculated amount to pay (full with fee and incentive) (in cents).
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Load fee.
        /// </summary>
        public LoadFee LoadFee { get; set; }

        /// <summary>
        /// Loads incentive. Always a negative in relation to load fee.
        /// </summary>
        public LoadIncentive LoadIncentive { get; set; }
    }

    /// <summary>
    /// Load fee model.
    /// </summary>
    public sealed class LoadFee
    {
        /// <summary>
        /// Load fee calculated value (in cents).
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Load fee percentage value.
        /// </summary>
        public decimal Percentage { get; set; }
    }

    /// <summary>
    /// Load incentive model.
    /// </summary>
    public sealed class LoadIncentive
    {
        /// <summary>
        /// Incentive calculated amount (in cents).
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Incentive percentage value.
        /// </summary>
        public decimal Percentage { get; set; }
    }
}
