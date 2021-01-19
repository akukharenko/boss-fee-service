using IDT.Boss.FeeService.Api.Enums;

namespace IDT.Boss.FeeService.Api.Models
{
    /// <summary>
    /// State information.
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
        public Channel Channel { get; set; }
    }
}