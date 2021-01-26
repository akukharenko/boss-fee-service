using IDT.Boss.FeeService.SeedTool.Interfaces;
using IDT.Boss.FeeService.SeedTool.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IDT.Boss.FeeService.SeedTool.DI
{
    /// <summary>
    /// Registrator fo dependencies in the application.
    /// </summary>
    public static class DependencyRegistrator
    {
        /// <summary>
        /// Configure DI for Runner module components.
        /// </summary>
        /// <param name="serviceCollection">Services in container.</param>
        /// <param name="configuration">Configuration for application.</param>
        public static void InitializeDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // configure options (settings)
            //serviceCollection.Configure<GeneratorConfiguration>(configuration.GetSection(nameof(GeneratorConfiguration)));

            // configure dependencies
            serviceCollection.AddSingleton<ISeedService, SeedService>();
        }
    }
}
