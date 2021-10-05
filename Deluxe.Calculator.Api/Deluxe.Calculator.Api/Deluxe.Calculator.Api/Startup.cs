using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Deluxe.Calculator.Api.Infrastructure;
using Deluxe.Calculator.Api.Models;
using Deluxe.Calculator.Api;
using Microsoft.EntityFrameworkCore;

namespace Deluxe.Calculator.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            CalculatorConfiguration configurationModel = new CalculatorConfiguration();
            Configuration.Bind(configurationModel);

            configurationModel = ServiceProviderBuilder.GetServiceProvider(configurationModel, Configuration,
                HostingEnvironment);

            if (string.IsNullOrWhiteSpace(configurationModel.ConnectionStrings.Default))
                throw new Exception($"connection string is not configured for Envronment {configurationModel.EnvironmentName}");

            //if (string.IsNullOrWhiteSpace(configurationModel.AdminSafeList))
            //    throw new Exception($"SafeList is not configured for Envronment {configurationModel.EnvironmentName}");

            services.AddDbContext<CalculatorContext>(options =>
                options.UseSqlServer(configurationModel.ConnectionStrings.Default));

            // inject exception handler filter
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddNewtonsoftJson(options =>
            { 
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Deluxe.Calculator.Api", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAll",
                    builder =>
                    {
                        builder.SetIsOriginAllowed((host) => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.AddOptions();
            services.AddScoped<CheckIpAddressActionFilter>(container =>
                {
                    var loggerFactory = container.GetRequiredService<ILoggerFactory>();
                    var logger = loggerFactory.CreateLogger<CheckIpAddressActionFilter>();

                    return new CheckIpAddressActionFilter(Configuration["AdminSafeList"], logger
                        , configurationModel.ConnectionStrings.Default);
                }
            );

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<CalculatorConfiguration>(configurationModel);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Deluxe.Calculator.Api v1"));
            }

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
