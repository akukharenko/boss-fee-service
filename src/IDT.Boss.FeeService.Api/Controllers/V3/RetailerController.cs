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
    /// Controller to work with fees and incentives for retailers.
    /// </summary>
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [SwaggerTag("Working with fees and incentives for Retailers")]
    [Produces("application/json")]
    public sealed class RetailerController : ControllerBase
    {
        private readonly IRetailerFeeService _retailerFeeService;

        public RetailerController(IRetailerFeeService retailerFeeService)
        {
            _retailerFeeService = retailerFeeService;
        }

        /// <summary>
        /// Get fee details for specific retailer.
        /// </summary>
        /// <param name="retailerId">Retailer id (control number).</param>
        /// <param name="feeAction">Specifies charge fee action (auto-recharge or manual recharge (by default)).</param>
        /// <param name="paymentType">Payment type (card type).</param>
        /// <param name="paymentNetwork">Card payment network.</param>
        /// <param name="rewardLevel">Reward level. If not specified, assumed as NoLevel.</param>
        /// <param name="channel">Channel (country).</param>
        /// <param name="state">State (in case of manual recharge).</param>
        /// <param name="amount">Amount to calculate fee and incentive and final amount to pay (in cents).</param>
        /// <returns>Returns the list of the all fees for distributor.</returns>
        [HttpGet]
        [Route("{retailerId:int}/fee/{feeAction}/{paymentType}/{paymentNetwork}")]
        [ProducesResponseType(typeof(Fee), StatusCodes.Status200OK)]
        public async Task<ActionResult<Fee>> GetRetailerFee(int retailerId, FeeAction feeAction, PaymentType paymentType,
            CardPaymentNetwork paymentNetwork,
            [FromQuery] RewardLevel rewardLevel, [FromQuery] Channel channel, [FromQuery] StatesTerritories state,
            [FromQuery] int amount)
        {
            var query = new GetRetailerFeeQuery
            {
                RetailerId = retailerId,
                FeeAction = feeAction,
                PaymentType = paymentType,
                PaymentNetwork = paymentNetwork,
                RewardLevel = rewardLevel,
                Channel = channel,
                State = state,
                Amount = amount
            };

            var result = await _retailerFeeService.GetRetailerFeeAsync(query);
            return Ok(result);
        }

        /// <summary>
        /// Get fee details for specific retailer.
        /// </summary>
        /// <param name="retailerId">Retailer id (control number).</param>
        /// <param name="feeAction">Specifies charge fee action (auto-recharge or manual recharge (by default)).</param>
        /// <param name="ccHandle">Credit card handle.</param>
        /// <param name="rewardLevel">Reward level. If not specified, assumed as NoLevel.</param>
        /// <param name="channel">Channel (country).</param>
        /// <param name="state">State (in case of manual recharge).</param>
        /// <param name="amount">Amount to calculate fee and incentive and final amount to pay (in cents).</param>
        /// <returns>Returns the list of the all fees for distributor.</returns>
        [HttpGet]
        [Route("{retailerId:int}/fee/{feeAction}/{ccHandle}")]
        [ProducesResponseType(typeof(Fee), StatusCodes.Status200OK)]
        public async Task<ActionResult<Fee>> GetRetailerFee2(int retailerId, FeeAction feeAction, string ccHandle,
            [FromQuery] RewardLevel rewardLevel, [FromQuery] Channel channel, [FromQuery] StatesTerritories state,
            [FromQuery] int amount)
        {
            var query = new GetRetailerFeeQuery
            {
                RetailerId = retailerId,
                FeeAction = feeAction,
                CcHandle = ccHandle,
                RewardLevel = rewardLevel,
                Channel = channel,
                State = state,
                Amount = amount
            };

            var result = await _retailerFeeService.GetRetailerFeeAsync(query);
            return Ok(result);
        }


        /// <summary>
        /// Get all fees for specific retailer (included overrides if exists).
        /// </summary>
        /// <param name="retailerId">Retailer id (control number).</param>
        /// <returns>Returns list of fee details for each combination of the payments.</returns>
        [HttpGet]
        [Route("{retailerId:int}/incentives")]
        [ProducesResponseType(typeof(List<RetailerFeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RetailerFeeModel>>> GetAllByRetailer(int retailerId)
        {
            var data = await _retailerFeeService.GetAllByRetailerAsync(retailerId);
            return Ok(data);
        }

        /// <summary>
        /// Update fee for specific retailer.
        /// </summary>
        /// <param name="retailerId">Retailer id (control number).</param>
        /// <param name="model">Model with information to search proper record to update.</param>
        /// <returns>Returns updated distributor fee model.</returns>
        /// <response code="202">Record successfully updated.</response>
        [HttpPut]
        [Route("{retailerId:int}/incentives")]
        [ProducesResponseType(typeof(List<RetailerFeeModel>), StatusCodes.Status202Accepted)]
        public async Task<ActionResult<RetailerFeeModel>> UpdateRetailerIncentive(int retailerId, [FromBody] UpdateRetailerIncentiveModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _retailerFeeService.UpdateRetailerIncentiveAsync(retailerId, model);
            return Accepted(result);
        }

        ///// <summary>
        ///// Delete override for distributor fee.
        ///// </summary>
        ///// <param name="retailerId">Retailer id (control number).</param>
        ///// <param name="model">Model with information to identify the fe to delete.</param>
        ///// <returns>Returns empty result.</returns>
        ///// <response code="204">Record successfully removed.</response>
        //[HttpDelete]
        //[Route("{retailerId:int}/incentives")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<ActionResult> DeleteRetailerIncentiveOverride(int retailerId, [FromBody] DeleteRetailerIncentiveModel model)
        //{
        //    await _retailerFeeService.DeleteRetailerIncentiveAsync(retailerId, model);
        //    return NoContent();
        //}

        /// <summary>
        /// Delete override for retailer fee (all the vales) - reset (return to the default values).
        /// </summary>
        /// <param name="retailerId">Retailer id (control number).</param>
        /// <param name="channel">Channel (country).</param>
        /// <param name="paymentType">Payment type (card type).</param>
        /// <param name="paymentNetwork">Card payment network.</param>
        /// <returns>Returns empty result.</returns>
        /// <response code="204">Record successfully removed.</response>
        [HttpDelete]
        [Route("{retailerId:int}/incentives/{channel}/{paymentType}/{paymentNetwork}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteRetailerIncentiveOverride(int retailerId, Channel channel,
            PaymentType paymentType, CardPaymentNetwork paymentNetwork)
        {
            await _retailerFeeService.DeleteRetailerIncentiveAsync(retailerId, new DeleteRetailerIncentiveModel
            {
                Channel = channel,
                PaymentType = paymentType,
                CardPaymentNetwork = paymentNetwork
            });
            return NoContent();
        }
    }
}