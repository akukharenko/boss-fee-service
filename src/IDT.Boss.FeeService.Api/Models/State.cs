using IDT.Boss.FeeService.Api.Enums;

namespace IDT.Boss.FeeService.Api.Models
{
    /// <summary>
    /// State information.
    /// </summary>
    public sealed class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Channel Channel { get; set; }
    }
}