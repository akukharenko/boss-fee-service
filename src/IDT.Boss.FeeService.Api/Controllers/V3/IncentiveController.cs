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
    /// Controller to work with default incentives.
    /// </summary>
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [SwaggerTag("Working with default sales incentives.")]
    [Produces("application/json")]
    public sealed class IncentiveController : ControllerBase
    {
        private readonly IFeeService _feeService;

        public IncentiveController(IFeeService feeService)
        {
            _feeService = feeService;
        }

        /// <summary>
        /// Get all Load Fees and Incentives for Retailer and Distributor.
        /// </summary>
        /// <returns>Returns list of the all Load Fees and Incentives for each case.</returns>
        [HttpGet]
        [Route("default/{channel}")]
        [ProducesResponseType(typeof(List<FeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<FeeModel>>> GetAllFees(Channel channel)
        {
            var data = await _feeService.GetAllDefaultFeesByChannelAsync(channel);
            return Ok(data);
        }

        /// <summary>
        /// Update default incentives for Distributor (one value) and Retailer (5 values by levels).
        /// </summary>
        /// <param name="channel">Channel (country).</param>
        /// <param name="model">Model with values for default incentives (distributor and retailer).</param>
        /// <returns>Returns updated model.</returns>
        /// <response code="202">Record successfully updated.</response>
        [HttpPut]
        [Route("default/{channel}")]
        [ProducesResponseType(typeof(FeeModel), StatusCodes.Status202Accepted)]
        public async Task<ActionResult<FeeModel>> UpdateDefaultLoadFee(Channel channel, [FromBody] UpdateDefaultIncentiveModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _feeService.UpdateDefaultIncentiveAsync(channel, model);
            return Accepted(result);
        }
    }
}
