namespace IDT.Boss.FeeService.Domain.Entities
{
    /// <summary>
    /// Base entity for main data records with fees and incentives as main identifier.
    /// Unique combination of the Channel + CardType + CardNetwork.
    /// </summary>
    public class BaseEntity : AuditableEntity
    {
        /// <summary>
        /// Record id (unique in the database).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Card type.
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// Card payment network.
        /// </summary>
        public string CardNetwork { get; set; }

        /// <summary>
        /// Channel (country).
        /// </summary>
        public string Channel { get; set; }
    }
}