using Microsoft.Extensions.Logging;

namespace IDT.Boss.FeeService.Api.Services
{
    public interface ILoadFeeService
    {
        // Task GetAll();
        // Task Update();
    }

    public sealed class LoadFeeService : ILoadFeeService
    {
        private readonly ILogger<LoadFeeService> _logger;

        public LoadFeeService(ILogger<LoadFeeService> logger)
        {
            _logger = logger;
        }
    }
}