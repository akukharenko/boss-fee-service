using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using IDT.Boss.FeeService.Api.Services;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

namespace IDT.Boss.FeeService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Work with Exception States")]
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
        public async Task<ActionResult> GetExceptionStatesByChannel(Channel channel)
        {
            var states = await _exceptionStatesService.GetExceptionStatesByChannelAsync(channel);
            return Ok(states);
        }

        [HttpPost]
        public async Task<ActionResult> AddExceptionState([FromBody]ExceptionState data)
        {
            var result = await _exceptionStatesService.AddExceptionStateAsync(data);
            return Accepted(result);
        }

        [HttpDelete]
        [Route("{stateId:int}")]
        public async Task<ActionResult> DeleteExceptionState(int stateId)
        {
            await _exceptionStatesService.DeleteExceptionStateAsync(stateId);
            return NoContent();
        }
    }
}
