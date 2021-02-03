using System.Collections.Generic;
using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using IDT.Boss.FeeService.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IDT.Boss.FeeService.Api.Controllers.V1
{
    /// <summary>
    /// Main controller to manage the fees (default, retailer, distributor).
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [SwaggerTag("Working with fees")]
    [Produces("application/json")]
    public sealed class FeeController : ControllerBase
    {
        private readonly ISharedFeeService _feesService;

        public FeeController(ISharedFeeService feesService)
        {
            _feesService = feesService;
        }

        #region Get fee lists.

        /// <summary>
        /// Get all Load Fees values.
        /// </summary>
        /// <returns>Returns list of the all Load Fees for each case.</returns>
        [HttpGet]
        [Route("loadfee/{channel}")]
        [ProducesResponseType(typeof(List<LoadFeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<LoadFeeModel>>> GetAllLoadFees(Channel channel)
        {
            var data = await _feesService.GetAllLoadFeesByChannelAsync(channel);
            return Ok(data);
        }

        /// <summary>
        /// Get all Load Fees and Incentives for Retailer and Distributor.
        /// </summary>
        /// <returns>Returns list of the all Load Fees for each case.</returns>
        [HttpGet]
        [Route("default/{channel}")]
        [ProducesResponseType(typeof(List<FeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllFees(Channel channel)
        {
            var data = await _feesService.GetAllDefaultFeesByChannelAsync(channel);
            return Ok(data);
        }

        /// <summary>
        /// Get all fees for specific distributor (included overrides if exists).
        /// </summary>
        /// <param name="distributorId">Distributor id (control number).</param>
        /// <returns>Returns list of fee details for each combination of the payments.</returns>
        [HttpGet]
        [Route("distributor/{distributorId:int}")]
        [ProducesResponseType(typeof(List<DistributorFeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DistributorFeeModel>>> GetAllByDistributor(int distributorId)
        {
            var data = await _feesService.GetAllByDistributorAsync(distributorId);
            return Ok(data);
        }

        /// <summary>
        /// Get all fees for specific retailer (included overrides if exists).
        /// </summary>
        /// <param name="retailerId">Retailer id (control number).</param>
        /// <returns>Returns list of fee details for each combination of the payments.</returns>
        [HttpGet]
        [Route("retailer/{retailerId:int}")]
        [ProducesResponseType(typeof(List<RetailerFeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RetailerFeeModel>>> GetAllByRetailer(int retailerId)
        {
            var data = await _feesService.GetAllByRetailerAsync(retailerId);
            return Ok(data);
        }

        #endregion

        #region Update load fee and create incentives for Retailer and Distributor overrides!

        /// <summary>
        /// Update default load fee value.
        /// </summary>
        /// <param name="channel">Channel.</param>
        /// <param name="model">Model with the data to update.</param>
        /// <returns>Returns fee model with the data after updates.</returns>
        /// <response code="202">Record successfully updated.</response>
        [HttpPut]
        [Route("default/{channel}")]
        [ProducesResponseType(typeof(FeeModel), StatusCodes.Status202Accepted)]
        public async Task<ActionResult<FeeModel>> UpdateDefaultLoadFee(Channel channel, [FromBody] UpdateLoadFeeModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _feesService.UpdateDefaultLoadFeeAsync(channel, model);
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
        [Route("default/incentives/{channel}")]
        [ProducesResponseType(typeof(FeeModel), StatusCodes.Status202Accepted)]
        public async Task<ActionResult<FeeModel>> UpdateDefaultLoadFee(Channel channel, [FromBody] UpdateDefaultIncentiveModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _feesService.UpdateDefaultIncentiveAsync(channel, model);
            return Accepted(result);
        }

        /// <summary>
        /// Update fee for specific distributor.
        /// </summary>
        /// <param name="distributorId">Distributor id (control number).</param>
        /// <param name="model">Model with information to search proper record to update.</param>
        /// <returns>Returns updated distributor fee model.</returns>
        /// <response code="202">Record successfully updated.</response>
        [HttpPut]
        [Route("distributor/{distributorId:int}")]
        [ProducesResponseType(typeof(DistributorFeeModel), StatusCodes.Status202Accepted)]
        public async Task<ActionResult<DistributorFeeModel>> UpdateDistributorIncentive(int distributorId, [FromBody] UpdateDistributorIncentiveModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _feesService.UpdateDistributorIncentiveAsync(distributorId, model);
            return Accepted(result);
        }

        /// <summary>
        /// Update fee for specific retailer.
        /// </summary>
        /// <param name="retailerId">Retailer id (control number).</param>
        /// <param name="model">Model with information to search proper record to update.</param>
        /// <returns>Returns updated distributor fee model.</returns>
        /// <response code="202">Record successfully updated.</response>
        [HttpPut]
        [Route("retailer/{retailerId:int}")]
        [ProducesResponseType(typeof(List<RetailerFeeModel>), StatusCodes.Status202Accepted)]
        public async Task<ActionResult<RetailerFeeModel>> UpdateRetailerIncentive(int retailerId, [FromBody] UpdateRetailerIncentiveModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _feesService.UpdateRetailerIncentiveAsync(retailerId, model);
            return Accepted(result);
        }

        #endregion

        #region Delete for Retailer and Distributor overrides!

        /// <summary>
        /// Delete override for distributor fee.
        /// </summary>
        /// <param name="distributorId">Distributor id (control number).</param>
        /// <param name="model">Model with information to identify the fe to delete.</param>
        /// <returns>Returns empty result.</returns>
        /// <response code="204">Record successfully removed.</response>
        [HttpDelete]
        [Route("distributor/{distributorId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteDistributorIncentiveOverride(int distributorId, [FromBody] DeleteDistributorIncentiveModel model)
        {
            await _feesService.DeleteDistributorIncentiveAsync(distributorId, model);
            return NoContent();
        }

        /// <summary>
        /// Delete override for distributor fee.
        /// </summary>
        /// <param name="distributorId">Distributor id (control number).</param>
        /// <param name="channel">Channel (country).</param>
        /// <param name="paymentType">Payment type (card type).</param>
        /// <param name="paymentNetwork">Card payment network.</param>
        /// <returns>Returns empty result.</returns>
        /// <response code="204">Record successfully removed.</response>
        [HttpDelete]
        [Route("distributor/{distributorId:int}/{channel}/{paymentType}/{paymentNetwork}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteDistributorIncentiveOverride(int distributorId, Channel channel,
            PaymentType paymentType, CardPaymentNetwork paymentNetwork)
        {
            await _feesService.DeleteDistributorIncentiveAsync(distributorId, new DeleteDistributorIncentiveModel
            {
                Channel = channel,
                PaymentType = paymentType,
                CardPaymentNetwork = paymentNetwork
            });
            return NoContent();
        }

        /// <summary>
        /// Delete override for distributor fee.
        /// </summary>
        /// <param name="retailerId">Retailer id (control number).</param>
        /// <param name="model">Model with information to identify the fe to delete.</param>
        /// <returns>Returns empty result.</returns>
        /// <response code="204">Record successfully removed.</response>
        [HttpDelete]
        [Route("retailer/{retailerId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteRetailerIncentiveOverride(int retailerId, [FromBody] DeleteRetailerIncentiveModel model)
        {
            await _feesService.DeleteRetailerIncentiveAsync(retailerId, model);
            return NoContent();
        }

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
        [Route("retailer/{retailerId:int}/{channel}/{paymentType}/{paymentNetwork}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteRetailerIncentiveOverride(int retailerId, Channel channel,
            PaymentType paymentType, CardPaymentNetwork paymentNetwork)
        {
            await _feesService.DeleteRetailerIncentiveAsync(retailerId, new DeleteRetailerIncentiveModel
            {
                Channel = channel,
                PaymentType = paymentType,
                CardPaymentNetwork = paymentNetwork
            });
            return NoContent();
        }

        #endregion

        #region Get fee spefic by each criteria (for the end applications).

        /// <summary>
        /// Get fee details for specific distributor.
        /// </summary>
        /// <param name="distributorId">Distributor id (control number).</param>
        /// <param name="feeAction">Specifies charge fee action (auto-recharge or manual recharge (by default)).</param>
        /// <param name="paymentType">Payment type (card type).</param>
        /// <param name="paymentNetwork">Card payment network.</param>
        /// <param name="channel">Channel (country).</param>
        /// <param name="state">State (in case of manual recharge).</param>
        /// <param name="amount">Amount to calculate fee and incentive and final amount to pay.</param>
        /// <returns>Returns the list of the all fees for distributor.</returns>
        [HttpGet]
        [Route("distributor/{distributorId:int}/{feeAction}/{paymentType}/{paymentNetwork}")]
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

            var result = await _feesService.GetDistributorFeeAsync(query);
            return Ok(result);
        }

        /// <summary>
        /// Get fee details for specific distributor.
        /// </summary>
        /// <param name="distributorId">Distributor id (control number).</param>
        /// <param name="feeAction">Specifies charge fee action (auto-recharge or manual recharge (by default)).</param>
        /// <param name="ccHandle">Credit card handle.</param>
        /// <param name="channel">Channel (country).</param>
        /// <param name="state">State (in case of manual recharge).</param>
        /// <param name="amount">Amount to calculate fee and incentive and final amount to pay.</param>
        /// <returns>Returns the list of the all fees for distributor.</returns>
        [HttpGet]
        [Route("distributor/{distributorId:int}/{feeAction}/{ccHandle}")]
        [ProducesResponseType(typeof(Fee), StatusCodes.Status200OK)]
        public async Task<ActionResult<Fee>> GetDistributorFee(int distributorId, FeeAction feeAction, string ccHandle,
            [FromQuery] Channel channel, [FromQuery] StatesTerritories state, [FromQuery] int amount)
        {
            var query = new GetDistributorFeeQuery
            {
                DistributorId = distributorId,
                FeeAction = feeAction,
                CcHandle = ccHandle,
                Channel = channel,
                State = state,
                Amount = amount
            };

            var result = await _feesService.GetDistributorFeeAsync(query);
            return Ok(result);
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
        /// <param name="amount">Amount to calculate fee and incentive and final amount to pay.</param>
        /// <returns>Returns the list of the all fees for distributor.</returns>
        [HttpGet]
        [Route("retailer/{retailerId:int}/{feeAction}/{paymentType}/{paymentNetwork}")]
        [ProducesResponseType(typeof(Fee), StatusCodes.Status200OK)]
        public async Task<ActionResult<Fee>> GetRetailerFee(int retailerId, FeeAction feeAction, PaymentType paymentType,
            CardPaymentNetwork paymentNetwork,
            [FromQuery] RewardLevel rewardLevel, [FromQuery] Channel channel, [FromQuery] StatesTerritories state, [FromQuery] int amount)
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
                Amount  = amount
            };

            var result = await _feesService.GetRetailerFeeAsync(query);
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
        /// <param name="amount">Amount to calculate fee and incentive and final amount to pay.</param>
        /// <returns>Returns the list of the all fees for distributor.</returns>
        [HttpGet]
        [Route("retailer/{retailerId:int}/{feeAction}/{ccHandle}")]
        [ProducesResponseType(typeof(Fee), StatusCodes.Status200OK)]
        public async Task<ActionResult<Fee>> GetRetailerFee(int retailerId, FeeAction feeAction, string ccHandle,
            [FromQuery] RewardLevel rewardLevel, [FromQuery] Channel channel, [FromQuery] StatesTerritories state, [FromQuery] int amount)
        {
            var query = new GetRetailerFeeQuery
            {
                RetailerId = retailerId,
                FeeAction = feeAction,
                CcHandle =  ccHandle,
                RewardLevel = rewardLevel,
                Channel = channel,
                State = state,
                Amount  = amount
            };

            var result = await _feesService.GetRetailerFeeAsync(query);
            return Ok(result);
        }

        /// <summary>
        /// Get fee details for specific user type (retailer ot distributor).
        /// </summary>
        /// <param name="userType">Specifies fee consumer type such as Retailer or Distributor.</param>
        /// <param name="userId">Retailer or Distributor id (control number).</param>
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

            var result = await _feesService.GetFeeAsync(query);
            return Ok(result);
        }

        /// <summary>
        /// Get fee details for specific user type (retailer ot distributor).
        /// </summary>
        /// <param name="userType">Specifies fee consumer type such as Retailer or Distributor.</param>
        /// <param name="userId">Retailer or Distributor id (control number).</param>
        /// <param name="feeAction">Specifies charge fee action (auto-recharge or manual recharge (by default)).</param>
        /// <param name="ccHandle">Credit card handle.</param>
        /// <param name="rewardLevel">Reward level. If not specified, assumed as NoLevel.</param>
        /// <param name="channel">Channel (country).</param>
        /// <param name="state">State (in case of manual recharge).</param>
        /// <param name="amount">Amount to calculate fee and incentive and final amount to pay.</param>
        /// <returns>Returns the list of the all fees for distributor.</returns>
        [HttpGet]
        [Route("{userType}/{userId:int}/{feeAction}/{ccHandle}")]
        [ProducesResponseType(typeof(Fee), StatusCodes.Status200OK)]
        public async Task<ActionResult<Fee>> GetFee(UserType userType, int userId, FeeAction feeAction, string ccHandle,
            [FromQuery] RewardLevel rewardLevel, [FromQuery] Channel channel, [FromQuery] StatesTerritories state, [FromQuery] int amount)
        {
            var query = new GetFeeQuery
            {
                UserType = userType,
                UserId = userId,
                FeeAction = feeAction,
                CcHandle = ccHandle,
                RewardLevel = rewardLevel,
                Channel = channel,
                State = state,
                Amount = amount
            };

            var result = await _feesService.GetFeeAsync(query);
            return Ok(result);
        }

        #endregion
    }
}
