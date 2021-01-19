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
    // TODO: move here all the action for Distributors (or remove controller)

    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Working for fees for distributors")]
    [Produces("application/json")]
    public class DistributorFeeController : Controller
    {
        private readonly IFeesService _feesService;

        public DistributorFeeController(IFeesService feesService)
        {
            _feesService = feesService;
        }

        [HttpGet]
        [Route("{distributorId:int}")]
        [ProducesResponseType(typeof(List<DistributorFeeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllByDistributor(int distributorId)
        {
            var data = await _feesService.GetAllByDistributorAsync(distributorId);
            return Ok(data);
        }

        [HttpPut]
        [Route("{distributorId:int}")]
        public async Task<ActionResult> UpdateDistributorIncentive(int distributorId, [FromBody] UpdateDistributorIncentiveModel model)
        {
            // TODO: remove returning result - can be used command in the CQRS implementation
            var result = await _feesService.UpdateDistributorIncentiveAsync(distributorId, model);
            return Accepted(result);
        }

        [HttpDelete]
        [Route("{distributorId:int}")]
        public async Task<ActionResult> DeleteDistributorIncentiveOverride(int distributorId, [FromBody] DeleteDistributorIncentiveModel model)
        {
            await _feesService.DeleteDistributorIncentiveAsync(distributorId, model);
            return NoContent();
        }

        [HttpGet]
        [Route("{distributorId:int}/{feeAction}/{paymentType}/{paymentNetwork}")]
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
    }
}