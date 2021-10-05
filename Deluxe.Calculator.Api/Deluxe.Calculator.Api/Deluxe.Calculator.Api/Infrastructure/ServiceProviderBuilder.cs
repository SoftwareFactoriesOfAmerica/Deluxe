using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

using Deluxe.Calculator.Api.Models;

namespace Deluxe.Calculator.Api.Infrastructure
{
    public static class ServiceProviderBuilder
    {
        public static CalculatorConfiguration GetServiceProvider (CalculatorConfiguration calculator, 
            IConfiguration Configuration, IWebHostEnvironment env)
        {
            ConfigurationBuilder builder = GetConfiguration(env);
            var configuration = builder.Build();

            calculator.EnvironmentName = configuration["ASPNETCORE_ENVIRONMENT"] != null
                ? configuration["ASPNETCORE_ENVIRONMENT"] : "Development";

            //TODO...Determine here to use either the Environment variables or secrets
            //       then load those values so that we can inject them into the controllers
            if (Convert.ToBoolean(calculator.UseEnvironment) == true)
            {
                //calculator.ConnectionStrings.Default = configuration["appName_DefaultConnection"] != null
                //    ? configuration["appName_DefaultConnection"].Trim() : calculator.ConnectionStrings.Default;
            }
            else
            {
                // get this out of a vault
            }

            return calculator;
        }

        private static ConfigurationBuilder GetConfiguration(IWebHostEnvironment env)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables("prefix: ASPNETCORE_")
                .AddEnvironmentVariables()
                .AddUserSecrets(typeof(Program).Assembly, optional: true);

            return (ConfigurationBuilder)config;
        }
    }
}
