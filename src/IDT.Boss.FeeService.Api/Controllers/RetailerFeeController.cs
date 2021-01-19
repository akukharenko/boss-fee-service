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
    // TODO: move here all the action for retailers (or remove controller)

    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Working with fees for Retailers")]
    [Produces("application/json")]
    public sealed class RetailerFeeController : ControllerBase
    {
        private readonly IFeesService _feesService;

        public RetailerFeeController(IFeesService feesService)
        {
            _feesService = feesService;
        }

        [HttpGet]
        [Route("{retailerId:int}")]
        [ProducesResponseType(typeof(List<RetailerFeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllByRetailer(int retailerId)
        {
            var data = await _feesService.GetAllByRetailerAsync(retailerId);
            return Ok(data);
        }


        [HttpPut]
        [Route("{retailerId:int}")]
        public async Task<ActionResult> UpdateRetailerIncentive(int retailerId, [FromBody] UpdateRetailerIncentiveModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _feesService.UpdateRetailerIncentiveAsync(retailerId, model);
            return Accepted(result);
        }

        [HttpDelete]
        [Route("{retailerId:int}")]
        public async Task<ActionResult> DeleteRetailerIncentiveOverride(int retailerId, [FromBody] DeleteRetailerIncentiveModel model)
        {
            await _feesService.DeleteRetailerIncentiveAsync(retailerId, model);
            return NoContent();
        }

        [HttpGet]
        [Route("{retailerId:int}/{feeAction}/{paymentType}/{paymentNetwork}")]
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
    }
}