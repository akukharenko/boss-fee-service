using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Data;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using Microsoft.Extensions.Logging;

namespace IDT.Boss.FeeService.Api.Services
{
    public interface IExceptionStatesService
    {
        Task<List<ExceptionState>> GetExceptionStatesByChannelAsync(Channel channel);
        Task<ExceptionState> AddExceptionStateAsync(ExceptionState data);
        Task DeleteExceptionStateAsync(int stateId);
    }

    /// <summary>
    /// Simple service to work with exception states.
    /// </summary>
    public sealed class ExceptionStatesService : IExceptionStatesService
    {
        private readonly ILogger<ExceptionStatesService> _logger;

        public ExceptionStatesService(ILogger<ExceptionStatesService> logger)
        {
            _logger = logger;
        }

        public Task<List<ExceptionState>> GetExceptionStatesByChannelAsync(Channel channel)
        {
            // combine with the all the states and Exception  states info here!
            var statesData = CollectStatesData(channel);
            return Task.FromResult(statesData);
        }

        public Task<ExceptionState> AddExceptionStateAsync(ExceptionState data)
        {
            return Task.FromResult(data);
        }

        public Task DeleteExceptionStateAsync(int stateId)
        {
            return Task.CompletedTask;
        }

        private List<ExceptionState> CollectStatesData(Channel channel)
        {
            // get list of the all states for the current channel
            var states = StatesData.States.Where(x => x.Channel == channel).ToList();

            // get list of the Exception states
            var excludedStates = StatesData.ExceptionStates;

            // combine result
            var result = CombineStates(states, excludedStates);

            return result;
        }

        private List<ExceptionState> CombineStates(IReadOnlyList<State> states, IReadOnlyList<ExceptionState> excludedStates)
        {
            var result = new List<ExceptionState>();

            foreach (var state in states)
            {
                var tmp = excludedStates.FirstOrDefault(x => x.StateId == state.Id);
                result.Add(new ExceptionState
                {
                    StateId = state.Id,
                    Name = state.Name,
                    Notes = tmp?.Notes,
                    Enabled = tmp != null && tmp.Enabled
                });
            }
            
            return result;
        }
    }
}