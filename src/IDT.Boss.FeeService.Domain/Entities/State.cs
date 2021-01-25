namespace IDT.Boss.FeeService.Domain.Entities
{
    /// <summary>
    /// Lookup table with list odf states for each channel supported in the Fee Service.
    /// </summary>
    public sealed class State
    {
        /// <summary>
        /// State id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// State code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// State name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Channel.
        /// </summary>
        public string Channel { get; set; }
    }
}