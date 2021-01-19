using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace IDT.Boss.FeeService.Api.Infrastructure.Configuration
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure Swagger UI for web application with versions support.
        /// </summary>
        /// <param name="app">Application builder.</param>
        /// <param name="provider">Provider for API versions.</param>
        /// <returns>Returns updated object with application builder.</returns>
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {

                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    var apiName = $"Fee Service API {description.GroupName.ToUpperInvariant()}";
                    options.SwaggerEndpoint($"{description.GroupName}/swagger.json", apiName);
                }

                options.DocumentTitle = "Fee Service API - Swagger UI";

                options.DocExpansion(DocExpansion.None);
            });

            return app;
        }
    }
}
