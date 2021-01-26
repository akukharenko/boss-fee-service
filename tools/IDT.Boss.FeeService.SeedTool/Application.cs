using System.Threading.Tasks;
using IDT.Boss.FeeService.SeedTool.Commands;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IDT.Boss.FeeService.SeedTool
{
    /// <summary>
    /// Entry point in application to run default command and also configure sub commands in the app.
    /// </summary>
    [Subcommand(typeof(SeedCommand))]
    public sealed class Application
    {
        /// <summary>
        /// Current class logger.
        /// </summary>
        private readonly ILogger<Application> _logger;

        /// <summary>
        /// Hosting environment provider.
        /// </summary>
        private readonly IHostEnvironment _hostEnvironment;

        public Application(ILogger<Application> logger, IHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Default action after running the application root.
        /// </summary>
        /// <param name="application">Command line application to run and configure.</param>
        /// <param name="console">Wrapper to use console.</param>
        private Task OnExecuteAsync(CommandLineApplication application, IConsole console)
        {
            var message = $"Environment: {_hostEnvironment.EnvironmentName}";

            console.WriteLine("IDT.Boss.FeeService.SeedTool");
            console.WriteLine(message);

            _logger.LogInformation(message);

            application.ShowHelp();

            return Task.CompletedTask;
        }
    }
}
