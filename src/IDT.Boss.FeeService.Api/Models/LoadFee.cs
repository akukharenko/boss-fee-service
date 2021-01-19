namespace IDT.Boss.FeeService.Api.Models
{
    public sealed class Fee
    {
        /// <summary>
        /// Load fee
        /// </summary>
        public LoadFee LoadFee { get; set; }

        /// <summary>
        /// Sales incentive. Always a negative in relation to load fee.
        /// </summary>
        public SalesIncentive SalesIncentive { get; set; }
    }

    public sealed class LoadFee
    {
        /// <summary>
        /// Load fee value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Load fee unit
        /// </summary>
        //public Unit LoadFeeUnit { get; set; }
    }

    public sealed class SalesIncentive
    {
        /// <summary>
        /// Incentive value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Incentive unit
        /// </summary>
        //public Unit IncentiveUnit { get; set; }
    }
}
