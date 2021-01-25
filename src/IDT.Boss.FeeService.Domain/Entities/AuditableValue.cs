using System;

namespace IDT.Boss.FeeService.Domain.Entities
{
    /// <summary>
    /// Auditable value to track the changes for individual values.
    /// </summary>
    public sealed class AuditableValue
    {
        /// <summary>
        /// Actual value (can be null if empty).
        /// </summary>
        public decimal? Value { get; set; }

        /// <summary>
        /// Who edit this value last time.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Date and time when the value was updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}