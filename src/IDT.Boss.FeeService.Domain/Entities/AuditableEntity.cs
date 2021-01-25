using System;

namespace IDT.Boss.FeeService.Domain.Entities
{
    /// <summary>
    /// Base properties for record with full audit to track the changes.
    /// </summary>
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}