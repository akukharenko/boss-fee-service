namespace IDT.Boss.FeeService.Api.Models
{
    /// <summary>
    /// Complete information about state and exception status.
    /// </summary>
    public sealed class ExceptionState
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Enabled { get; set; }
    }
}