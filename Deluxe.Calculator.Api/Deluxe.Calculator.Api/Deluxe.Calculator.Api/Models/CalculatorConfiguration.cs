using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Deluxe.Calculator.Api.Models
{
    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
        public string MicrosoftHostingLifetime { get; set; }
    }
    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class ConnectionStrings
    {
        public string Default { get; set; }
    }

    public class CalculatorConfiguration
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public Logging Logging { get; set; }

        public string AllowedHosts { get; set; }

        public bool UseEnvironment { get; set; }

        public string EnvironmentName { get; set; }

        public string AdminSafeList { get; set; }
    }
}
