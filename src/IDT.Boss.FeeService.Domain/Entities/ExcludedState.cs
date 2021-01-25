namespace IDT.Boss.FeeService.Domain.Entities
{
    public sealed class ExcludedState : AuditableEntity
    {
        public int Id { get; set; }
        public string StateId { get; set; }
        public string Note { get; set; }
    }
}
