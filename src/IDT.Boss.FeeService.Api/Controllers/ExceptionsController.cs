using System.Collections.Generic;
using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using IDT.Boss.FeeService.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IDT.Boss.FeeService.Api.Controllers
{
    /// <summary>
    /// Controller to work with exceptions in the scope of fees.
    /// </summary>
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [SwaggerTag("Work with Exception for fees (states in US).")]
    [Produces("application/json")]
    public sealed class ExceptionsController : ControllerBase
    {
        private readonly IExceptionStatesService _exceptionStatesService;

        public ExceptionsController(IExceptionStatesService exceptionStatesService)
        {
            _exceptionStatesService = exceptionStatesService;
        }

        /// <summary>
        /// Get list of the all states and exception status.
        /// </summary>
        /// <param name="channel">Channel.</param>
        /// <returns>Returns the list of the states for selected channel.</returns>
        [HttpGet]
        [Route("{channel}")]
        [ProducesResponseType(typeof(List<ExceptionState>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ExceptionState>>> GetExceptionStatesByChannel(Channel channel)
        {
            var states = await _exceptionStatesService.GetExceptionStatesByChannelAsync(channel);
            return Ok(states);
        }

        /// <summary>
        /// Add a new exception state to the list.
        /// </summary>
        /// <param name="data">Exception state data.</param>
        /// <returns>Returns added exception state.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ExceptionState), StatusCodes.Status202Accepted)]
        public async Task<ActionResult<ExceptionState>> AddExceptionState([FromBody]ExceptionState data)
        {
            var result = await _exceptionStatesService.AddExceptionStateAsync(data);
            return Accepted(result);
        }

        /// <summary>
        /// Delete information about exception state for specific state.
        /// </summary>
        /// <param name="stateId">State id to remove from exceptions.</param>
        /// <returns>Returns empty result.</returns>
        [HttpDelete]
        [Route("{stateId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteExceptionState(int stateId)
        {
            await _exceptionStatesService.DeleteExceptionStateAsync(stateId);
            return NoContent();
        }
    }
}
