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
    /// Controller to work with fees and incentives for distributors.
    /// </summary>
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [SwaggerTag("Working for fees and incentives for distributors")]
    [Produces("application/json")]
    public sealed class DistributorController : ControllerBase
    {
        private readonly IDistributorFeeService _distributorFeeService;

        public DistributorController(IDistributorFeeService distributorFeeService)
        {
            _distributorFeeService = distributorFeeService;
        }

        /// <summary>
        /// Get fee details for specific distributor.
        /// </summary>
        /// <param name="distributorId">Distributor ir.</param>
        /// <param name="feeAction">Specifies charge fee action (auto-recharge or manual recharge (by default)).</param>
        /// <param name="paymentType">Payment type (card type).</param>
        /// <param name="paymentNetwork">Card payment network.</param>
        /// <param name="channel">Channel (country).</param>
        /// <param name="state">State (in case of manual recharge).</param>
        /// <param name="amount">Amount to calculate fee and incentive and final amount to pay.</param>
        /// <returns>Returns the list of the all fees for distributor.</returns>
        [HttpGet]
        [Route("{distributorId:int}/fee/{feeAction}/{paymentType}/{paymentNetwork}")]
        [ProducesResponseType(typeof(Fee), StatusCodes.Status200OK)]
        public async Task<ActionResult<Fee>> GetDistributorFee(int distributorId, FeeAction feeAction, PaymentType paymentType,
            CardPaymentNetwork paymentNetwork,
            [FromQuery] Channel channel, [FromQuery] StatesTerritories state, [FromQuery] int amount)
        {
            var query = new GetDistributorFeeQuery
            {
                DistributorId = distributorId,
                FeeAction = feeAction,
                PaymentType = paymentType,
                PaymentNetwork = paymentNetwork,
                Channel = channel,
                State = state,
                Amount = amount
            };

            var result = await _distributorFeeService.GetDistributorFeeAsync(query);
            return Ok(result);
        }

        /// <summary>
        /// Get all fees for specific distributor (included overrides if exists).
        /// </summary>
        /// <param name="distributorId">Distributor id.</param>
        /// <returns>Returns list of fee details for each combination of the payments.</returns>
        [HttpGet]
        [Route("{distributorId:int}/incentives")]
        [ProducesResponseType(typeof(List<DistributorFeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DistributorFeeModel>>> GetAllByDistributor(int distributorId)
        {
            var data = await _distributorFeeService.GetAllByDistributorAsync(distributorId);
            return Ok(data);
        }

        /// <summary>
        /// Update fee for specific distributor.
        /// </summary>
        /// <param name="distributorId">Distributor id.</param>
        /// <param name="model">Model with information to search proper record to update.</param>
        /// <returns>Returns updated distributor fee model.</returns>
        /// <response code="202">Record successfully updated.</response>
        [HttpPut]
        [Route("{distributorId:int}/incentives")]
        [ProducesResponseType(typeof(DistributorFeeModel), StatusCodes.Status202Accepted)]
        public async Task<ActionResult<DistributorFeeModel>> UpdateDistributorIncentive(int distributorId, [FromBody] UpdateDistributorIncentiveModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _distributorFeeService.UpdateDistributorIncentiveAsync(distributorId, model);
            return Accepted(result);
        }

        ///// <summary>
        ///// Delete override for distributor fee.
        ///// </summary>
        ///// <param name="distributorId">Distributor id.</param>
        ///// <param name="model">Model with information to identify the fe to delete.</param>
        ///// <returns>Returns empty result.</returns>
        ///// <response code="204">Record successfully removed.</response>
        //[HttpDelete]
        //[Route("{distributorId:int}/incentives")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<ActionResult> DeleteDistributorIncentiveOverride(int distributorId, [FromBody] DeleteDistributorIncentiveModel model)
        //{
        //    await _distributorFeeService.DeleteDistributorIncentiveAsync(distributorId, model);
        //    return NoContent();
        //}

        /// <summary>
        /// Delete override for distributor fee.
        /// </summary>
        /// <param name="distributorId">Distributor id.</param>
        /// <param name="channel">Channel (country).</param>
        /// <param name="paymentType">Payment type (card type).</param>
        /// <param name="paymentNetwork">Card payment network.</param>
        /// <returns>Returns empty result.</returns>
        /// <response code="204">Record successfully removed.</response>
        [HttpDelete]
        [Route("{distributorId:int}/incentives/{channel}/{paymentType}/{paymentNetwork}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteDistributorIncentiveOverride(int distributorId, Channel channel,
            PaymentType paymentType, CardPaymentNetwork paymentNetwork)
        {
            await _distributorFeeService.DeleteDistributorIncentiveAsync(distributorId, new DeleteDistributorIncentiveModel
            {
                Channel = channel,
                PaymentType = paymentType,
                CardPaymentNetwork = paymentNetwork
            });
            return NoContent();
        }
    }
}
