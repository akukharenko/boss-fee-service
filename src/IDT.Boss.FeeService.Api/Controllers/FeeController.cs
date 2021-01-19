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
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Working with load fees")]
    [Produces("application/json")]
    public sealed class FeeController : ControllerBase
    {
        private readonly IFeesService _feesService;

        public FeeController(IFeesService feesService)
        {
            _feesService = feesService;
        }
        
        /// <summary>
        /// Get all Load Fees values.
        /// </summary>
        /// <returns>Returns list of the all Load Fees for each case.</returns>
        [HttpGet]
        [Route("default/{channel}")]
        [ProducesResponseType(typeof(List<FeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllLoadFees(Channel channel)
        {
            var data = await _feesService.GetAllDefaultFeesByChannelAsync(channel);
            return Ok(data);
        }

        [HttpGet]
        [Route("distributor/{distributorId:int}")]
        [ProducesResponseType(typeof(List<DistributorFeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllByDistributor(int distributorId)
        {
            var data = await _feesService.GetAllByDistributorAsync(distributorId);
            return Ok(data);
        }

        [HttpGet]
        [Route("retailer/{retailerId:int}")]
        [ProducesResponseType(typeof(List<RetailerFeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllByRetailer(int retailerId)
        {
            var data = await _feesService.GetAllByRetailerAsync(retailerId);
            return Ok(data);
        }

        /// <summary>
        /// Update default load fee value.
        /// </summary>
        /// <param name="channel">Channel.</param>
        /// <param name="model">Request with the data to update.</param>
        /// <returns>Returns fee model with the data after updates.</returns>
        [HttpPut]
        [Route("default/{channel}")]
        public async Task<ActionResult> UpdateDefaultLoadFee(Channel channel, [FromBody]UpdateLoadFeeModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _feesService.UpdateDefaultLoadFeeAsync(channel, model);
            return Accepted(result);
        }

        #region Update (create) incentives Retailer and Distributor overrides!

        [HttpPut]
        [Route("distributor/{distributorId:int}")]
        public async Task<ActionResult> UpdateDistributorIncentive(int distributorId, [FromBody] UpdateDistributorIncentiveModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _feesService.UpdateDistributorIncentiveAsync(distributorId, model);
            return Accepted(result);
        }

        [HttpPut]
        [Route("retailer/{retailerId:int}")]
        public async Task<ActionResult> UpdateRetailerIncentive(int retailerId, [FromBody] UpdateRetailerIncentiveModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _feesService.UpdateRetailerIncentiveAsync(retailerId, model);
            return Accepted(result);
        }

        #endregion

        #region Delete for Retailer and Distributor overrides!

        [HttpDelete]
        [Route("distributor/{distributorId:int}")]
        public async Task<ActionResult> DeleteDistributorIncentiveOverride(int distributorId, [FromBody] DeleteDistributorIncentiveModel model)
        {
            await _feesService.DeleteDistributorIncentiveAsync(distributorId, model);
            return NoContent();
        }

        [HttpDelete]
        [Route("retailer/{retailerId:int}")]
        public async Task<ActionResult> DeleteRetailerIncentiveOverride(int retailerId, [FromBody] DeleteRetailerIncentiveModel model)
        {
            await _feesService.DeleteRetailerIncentiveAsync(retailerId, model);
            return NoContent();
        }

        #endregion

        [HttpGet]
        [Route("distributor/{distributorId:int}/{feeAction}/{paymentType}/{paymentNetwork}")]
        public async Task<ActionResult> GetDistributorFee(int distributorId, FeeAction feeAction, PaymentType paymentType,
            CardPaymentNetwork paymentNetwork, 
            [FromQuery] Channel channel, [FromQuery] StatesTerritories state)
        {
            var query = new GetDistributorFeeQuery
            {
                DistributorId = distributorId,
                FeeAction = feeAction,
                PaymentType = paymentType,
                PaymentNetwork = paymentNetwork,
                Channel = channel,
                State = state
            };

            var result = await _feesService.GetDistributorFeeAsync(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("retailer/{retailerId:int}/{feeAction}/{paymentType}/{paymentNetwork}")]
        public async Task<ActionResult> GetRetailerFee(int retailerId, FeeAction feeAction, PaymentType paymentType,
            CardPaymentNetwork paymentNetwork,
            [FromQuery] RewardLevel rewardLevel, [FromQuery] Channel channel, [FromQuery] StatesTerritories state)
        {
            var query = new GetRetailerFeeQuery
            {
                RetailerId = retailerId,
                FeeAction = feeAction,
                PaymentType = paymentType,
                PaymentNetwork = paymentNetwork,
                RewardLevel = rewardLevel,
                Channel = channel,
                State = state
            };

            var result = await _feesService.GetRetailerFeeAsync(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{userType}/{userId:int}/{feeAction}/{paymentType}/{paymentNetwork}")]
        public async Task<ActionResult> GetDistributorFee(UserType userType, int userId, FeeAction feeAction, PaymentType paymentType,
            CardPaymentNetwork paymentNetwork,
            [FromQuery] RewardLevel rewardLevel, [FromQuery] Channel channel, [FromQuery] StatesTerritories state)
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
                State = state
            };

            var result = await _feesService.GetFeeAsync(query);
            return Ok(result);
        }
    }
}
