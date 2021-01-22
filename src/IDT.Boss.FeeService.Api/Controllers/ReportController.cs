using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using IDT.Boss.FeeService.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IDT.Boss.FeeService.Api.Controllers
{
    /// <summary>
    /// Controller to work with reports based on the fees in the service.
    /// </summary>
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [SwaggerTag("Work with data to build reports about Fees (Load fees, incentives override).")]
    [Produces("application/json")]
    public sealed class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Get report for distributors with overriden vales for incentives.
        /// </summary>
        /// <param name="channel">Channel (country).</param>
        /// <returns>Returns report with the data.</returns>
        [HttpGet]
        [Route("incentives/distributor")]
        [ProducesResponseType(typeof(DistributorReportModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<DistributorReportModel>> GetDistributorsReport(Channel channel)
        {
            var data = await _reportService.GetDistributorsFeeReportAsync(channel);
            return Ok(data);
        }

        /// <summary>
        /// Get report for retailers with overriden vales for incentives.
        /// </summary>
        /// <param name="channel">Channel (country).</param>
        /// <returns>Returns report with the data.</returns>
        [HttpGet]
        [Route("incentives/retailer")]
        [ProducesResponseType(typeof(RetailerReportModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<RetailerReportModel>> GetRetailersReport(Channel channel)
        {
            var data = await _reportService.GetRetailersFeeReportAsync(channel);
            return Ok(data);
        }
    }
}
