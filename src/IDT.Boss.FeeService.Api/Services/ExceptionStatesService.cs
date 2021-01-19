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
        /// <summary>
        /// Get list of the states with information about exceptions for the channel.
        /// </summary>
        /// <param name="channel">Channel (country).</param>
        /// <returns>Returns the list of the all states in the channels with the details.</returns>
        Task<List<ExceptionState>> GetExceptionStatesByChannelAsync(Channel channel);

        /// <summary>
        /// Add a new record with information about state to exclude.
        /// </summary>
        /// <param name="data">Exception state date to add the record.</param>
        /// <returns>Returns added record.</returns>
        Task<ExceptionState> AddExceptionStateAsync(ExceptionState data);

        /// <summary>
        /// Delete specific state from the exceptions.
        /// </summary>
        /// <param name="stateId">State id.</param>
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

        /// <inheritdoc />
        public Task<List<ExceptionState>> GetExceptionStatesByChannelAsync(Channel channel)
        {
            // combine with the all the states and Exception  states info here!
            var statesData = CollectStatesData(channel);
            return Task.FromResult(statesData);
        }

        /// <inheritdoc />
        public Task<ExceptionState> AddExceptionStateAsync(ExceptionState data)
        {
            // TODO: add the record to exception states storage
            return Task.FromResult(data);
        }

        /// <inheritdoc />
        public Task DeleteExceptionStateAsync(int stateId)
        {
            // TODO: remove the record from exception states storage
            return Task.CompletedTask;
        }

        #region Helpers.

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
                    Code = state.Code,
                    Name = state.Name,
                    Notes = tmp?.Notes,
                    IsExcluded = tmp != null && tmp.IsExcluded
                });
            }
            
            return result;
        }

        #endregion
    }
}