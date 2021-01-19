using System.Collections.Generic;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;

namespace IDT.Boss.FeeService.Api.Data
{
    /// <summary>
    /// Static test data for States and Exception States.
    /// </summary>
    public static class StatesData
    {
        /// <summary>
        /// Lookup with all the states
        /// </summary>
        public static readonly IReadOnlyList<State> States = new List<State>
        {
            new State {Id = 1, Name = "CO", Channel = Channel.US},
            new State {Id = 2, Name = "CA", Channel = Channel.US},
            new State {Id = 3, Name = "WI", Channel = Channel.US},
            new State {Id = 4, Name = "NY", Channel = Channel.US},
            new State {Id = 5, Name = "NJ", Channel = Channel.US}
        };

        public static readonly IReadOnlyList<ExceptionState> ExceptionStates = new List<ExceptionState>
        {
            new ExceptionState {StateId = 1, Enabled = true, Notes = "Test exception state"}
        };
    }
}