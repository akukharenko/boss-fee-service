using System.Threading.Tasks;
using IDT.Boss.FeeService.SeedTool.Interfaces;
using Microsoft.Extensions.Logging;

namespace IDT.Boss.FeeService.SeedTool.Services
{
    // TODO: implement here the logic to seed the database
    // TODO: maybe later move to the infrastructure services

    /// <summary>
    /// Simple service to initialize database with initial data.
    /// </summary>
    public sealed class SeedService : ISeedService
    {
        private readonly ILogger<SeedService> _logger;

        public SeedService(ILogger<SeedService> logger)
        {
            _logger = logger;
        }

        public Task InitializeDatabaseAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
