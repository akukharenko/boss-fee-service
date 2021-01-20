using System.Threading.Tasks;
using IDT.Boss.FeeService.Api.Data;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;
using Microsoft.Extensions.Logging;

namespace IDT.Boss.FeeService.Api.Services
{
    public interface IReportService
    {
        Task<DistributorReportModel> GetDistributorsFeeReportAsync(Channel channel);
        Task<RetailerReportModel> GetRetailersFeeReportAsync(Channel channel);
    }

    /// <summary>
    /// Simple service to work with data for reports.
    /// </summary>
    public sealed class ReportService : IReportService
    {
        private readonly ILogger<ReportService> _logger;

        public ReportService(ILogger<ReportService> logger)
        {
            _logger = logger;
        }

        public Task<DistributorReportModel> GetDistributorsFeeReportAsync(Channel channel)
        {
            var data = FeeDataGenerator.GenerateDistributorReport(channel, 10);
            return Task.FromResult(data);
        }

        public Task<RetailerReportModel> GetRetailersFeeReportAsync(Channel channel)
        {
            var data = FeeDataGenerator.GenerateRetailerReport(channel, 10);
            return Task.FromResult(data);
        }
    }
}
