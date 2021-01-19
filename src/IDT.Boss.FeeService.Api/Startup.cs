using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using IDT.Boss.FeeService.Api.Services;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace IDT.Boss.FeeService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddSwaggerGen(c =>
            {
                // TODO: add here proper settings for Open API definition
                c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Fee Service API",
                        Version = "v1",
                        Description =
                            "Simple service with API for support of the Retailer and Distributor Load Fees and Sales Incentives",
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
                    }
                );

                c.EnableAnnotations();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // register services
            services.AddSingleton<IExceptionStatesService, ExceptionStatesService>();
            services.AddSingleton<IFeesService, FeesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "IDT.Boss.FeeService.Api v1");

                c.DocExpansion(DocExpansion.None);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
