using System;
using System.Threading.Tasks;
using IDT.Boss.FeeService.SeedTool.Interfaces;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace IDT.Boss.FeeService.SeedTool.Commands
{
    /// <summary>
    /// Command to call logic to seed the database with initial data.
    /// </summary>
    [Command("seed", Description = "Fill the database with initial data.", ShowInHelpText = true)]
    public sealed class SeedCommand : ICustomCommand
    {
        private readonly ILogger<SeedCommand> _logger;
        private readonly ISeedService _seedService;
        
        public SeedCommand(ILogger<SeedCommand> logger, ISeedService seedService)
        {
            _logger = logger;
            _seedService = seedService;
        }

        public async Task OnExecuteAsync(CommandLineApplication command, IConsole console)
        {
            _logger.LogInformation("Generate data and fill the database with initial data");

            try
            {
                // TODO: add main logic here to run teh seeding
                await _seedService.InitializeDatabaseAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred during database initialization!", ex);

                //throw;
            }
        }
    }
}
