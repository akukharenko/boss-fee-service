using System.Collections.Generic;
using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using IDT.Boss.FeeService.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IDT.Boss.FeeService.Api.Controllers.V2
{
    /// <summary>
    /// Controller to work with default load fees.
    /// </summary>
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [SwaggerTag("Working with fees")]
    [Produces("application/json")]
    public sealed class FeeController : ControllerBase
    {
        private readonly IFeeService _feeService;

        public FeeController(IFeeService feeService)
        {
            _feeService = feeService;
        }

        /// <summary>
        /// Get all Load Fees values.
        /// </summary>
        /// <returns>Returns list of the all Load Fees for each case.</returns>
        [HttpGet]
        [Route("loadfee/{channel}")]
        [ProducesResponseType(typeof(List<LoadFeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<LoadFeeModel>>> GetAllLoadFees(Channel channel)
        {
            var data = await _feeService.GetAllLoadFeesByChannelAsync(channel);
            return Ok(data);
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
        /// Update default load fee value.
        /// </summary>
        /// <param name="channel">Channel.</param>
        /// <param name="model">Request with the data to update.</param>
        /// <returns>Returns fee model with the data after updates.</returns>
        /// <response code="202">Record successfully updated.</response>
        [HttpPut]
        [Route("loadfee/{channel}")]
        [ProducesResponseType(typeof(FeeModel), StatusCodes.Status202Accepted)]
        public async Task<ActionResult<FeeModel>> UpdateDefaultLoadFee(Channel channel, [FromBody] UpdateLoadFeeModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _feeService.UpdateDefaultLoadFeeAsync(channel, model);
            return Accepted(result);
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

        /// <summary>
        /// Get fee details for specific user type (retailer ot distributor).
        /// </summary>
        /// <param name="userType">Specifies fee consumer type such as Retailer or Distributor.</param>
        /// <param name="userId">Retailer or Distributor ir.</param>
        /// <param name="feeAction">Specifies charge fee action (auto-recharge or manual recharge (by default)).</param>
        /// <param name="paymentType">Payment type (card type).</param>
        /// <param name="paymentNetwork">Card payment network.</param>
        /// <param name="rewardLevel">Reward level. If not specified, assumed as NoLevel.</param>
        /// <param name="channel">Channel (country).</param>
        /// <param name="state">State (in case of manual recharge).</param>
        /// <param name="amount">Amount to calculate fee and incentive and final amount to pay.</param>
        /// <returns>Returns the list of the all fees for distributor.</returns>
        [HttpGet]
        [Route("{userType}/{userId:int}/{feeAction}/{paymentType}/{paymentNetwork}")]
        [ProducesResponseType(typeof(Fee), StatusCodes.Status200OK)]
        public async Task<ActionResult<Fee>> GetFee(UserType userType, int userId, FeeAction feeAction, PaymentType paymentType,
            CardPaymentNetwork paymentNetwork,
            [FromQuery] RewardLevel rewardLevel, [FromQuery] Channel channel, [FromQuery] StatesTerritories state, [FromQuery] int amount)
        {
            var query = new GetFeeQuery
            {
                UserType = userType,
                UserId = userId,
                FeeAction = feeAction,
                PaymentType = paymentType,
                PaymentNetwork = paymentNetwork,
                RewardLevel = rewardLevel,
                Channel = channel,
                State = state,
                Amount = amount
            };

            var result = await _feeService.GetFeeAsync(query);
            return Ok(result);
        }
    }
}
