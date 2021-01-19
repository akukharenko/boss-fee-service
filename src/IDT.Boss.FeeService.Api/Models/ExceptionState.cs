namespace IDT.Boss.FeeService.Api.Models
{
    /// <summary>
    /// Complete information about state and exception status.
    /// </summary>
    public sealed class ExceptionState
    {
        /// <summary>
        /// State id.
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// State code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// State name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Is the state excluded?
        /// </summary>
        public bool IsExcluded { get; set; }
    }
}