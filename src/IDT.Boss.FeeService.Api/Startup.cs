using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IDT.Boss.FeeService.Api.Infrastructure.Extensions;
using IDT.Boss.FeeService.Api.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;

namespace IDT.Boss.FeeService.Api
{
    public class Startup
    {
        /// <summary>
        /// Configuration for application loaded from the files.
        /// </summary>
        private IConfiguration Configuration { get; }

        /// <summary>
        /// Environment settings and configuration.
        /// </summary>
        private IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureApiService(Configuration, Environment, true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // configure Swagger UI
            app.ConfigureSwagger(apiProvider);

            app.UseHttpsRedirection();

            // add logger for all requests in the web server
            app.UseSerilogRequestLogging(options =>
            {
                options.EnrichDiagnosticContext = LogHelper.EnrichFromRequest;
            });

            // Use routing middleware to handle requests to the controllers
            app.UseRouting();

            app.UseAuthorization();

            // configure routing
            app.UseEndpoints(endpoints =>
            {
                // map API controllers here
                endpoints.MapControllers();
            });
        }
    }
}
