using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IDT.Boss.FeeService.Api.Infrastructure.Configuration
{
    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    /// <remarks>This allows API versioning to define a Swagger document per API version after the
    /// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
    public sealed class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        /// <summary>
        /// Provided to work with API versions.
        /// </summary>
        private readonly IApiVersionDescriptionProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this._provider = provider;

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        /// <summary>
        /// Configure information for API.
        /// </summary>
        /// <param name="description">Api version description.</param>
        /// <returns>Returns API info object with data.</returns>
        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            // TODO: configure value for API description!

            var info = new OpenApiInfo
            {
                Title = "Fee Service API",
                Version = description.ApiVersion.ToString(),
                Description = "Simple service with API for support of the Retailer and Distributor Load Fees and Sales Incentives",
                Contact = new OpenApiContact
                {
                    Name = "Andrey Kukharenko",
                    Email = "andrey.kukharenko@idt.net"
                },
                License = new OpenApiLicense
                {
                    Name = "Copyright (c) 2021, IDT",
                    Url = new Uri("http://www.idt.net")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
