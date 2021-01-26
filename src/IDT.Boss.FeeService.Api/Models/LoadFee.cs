namespace IDT.Boss.FeeService.Api.Models
{
    /// <summary>
    /// Fee model to use in the external applications.
    /// </summary>
    public sealed class Fee
    {
        /// <summary>
        /// Calculated amount to pay (full with fee and incentive).
        /// </summary>
        public decimal Amount { get; set; }

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
        /// Load fee calculated value.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Load fee percentage value.
        /// </summary>
        public decimal Percentage { get; set; }
    }

    /// <summary>
    /// Sales incentive model.
    /// </summary>
    public sealed class SalesIncentive
    {
        /// <summary>
        /// Incentive calculated amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Incentive percentage value.
        /// </summary>
        public decimal Percentage { get; set; }
    }
}
