using System.Collections.Generic;
using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using IDT.Boss.FeeService.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IDT.Boss.FeeService.Api.Controllers.V3
{
    /// <summary>
    /// Controller to work with load fees.
    /// </summary>
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [SwaggerTag("Working with load fees")]
    [Produces("application/json")]
    public sealed class LoadFeeController : ControllerBase
    {
        private readonly IFeeService _feeService;

        public LoadFeeController(IFeeService feeService)
        {
            _feeService = feeService;
        }

        /// <summary>
        /// Get all Load Fees values.
        /// </summary>
        /// <returns>Returns list of the all Load Fees for each case.</returns>
        [HttpGet]
        [Route("{channel}")]
        [ProducesResponseType(typeof(List<LoadFeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<LoadFeeModel>>> GetAllLoadFees(Channel channel)
        {
            var data = await _feeService.GetAllLoadFeesByChannelAsync(channel);
            return Ok(data);
        }

        /// <summary>
        /// Update default load fee value.
        /// </summary>
        /// <param name="channel">Channel.</param>
        /// <param name="model">Request with the data to update.</param>
        /// <returns>Returns fee model with the data after updates.</returns>
        /// <response code="202">Record successfully updated.</response>
        [HttpPut]
        [Route("{channel}")]
        [ProducesResponseType(typeof(FeeModel), StatusCodes.Status202Accepted)]
        public async Task<ActionResult<FeeModel>> UpdateDefaultLoadFee(Channel channel, [FromBody] UpdateLoadFeeModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _feeService.UpdateDefaultLoadFeeAsync(channel, model);
            return Accepted(result);
        }
    }
}
