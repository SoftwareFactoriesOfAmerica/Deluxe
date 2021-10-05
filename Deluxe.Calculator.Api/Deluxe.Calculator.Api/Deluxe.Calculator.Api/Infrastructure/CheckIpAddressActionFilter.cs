using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Deluxe.Calculator.Api.Infrastructure
{
    public class CheckIpAddressActionFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;
        private readonly List<string> _safeList;
        private readonly string _connectionString;

        public CheckIpAddressActionFilter(string safeList, ILogger logger, string connectionString)
        {
            var ips = safeList.Split(";");
            _safeList = new List<string>();

            for (var i = 0; i < ips.Length; i++)
            {
                _safeList.Add(ips[i]);
            }

            if (_safeList.Count == 0)
            {
                throw new Exception("The AdminSafeList IP Address must contain either a specific IP address or IP Ranges");
            }

            _logger = logger;
            _connectionString = connectionString;
        }

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            var remoteIp = context.HttpContext.Connection.RemoteIpAddress;
            var badIp = true;
            var whichCatch = "none";

            if (remoteIp.IsIPv4MappedToIPv6)
            {
                remoteIp = remoteIp.MapToIPv4();
            }

            foreach (var address in _safeList)
            {
                try
                {
                    if (address.Contains("-") || address.Contains("/") || address.ToLower().Contains("to"))
                    {
                        whichCatch = "IP Address Range";
                        var range = NetTools.IPAddressRange.Parse(address);
                        if (range.Contains(remoteIp))
                        {
                            badIp = false;
                            break;
                        }
                    }
                    else
                    {
                        whichCatch = "Specific IP Address";
                        if (NetTools.IPAddressRange.Parse(address).Contains(IPAddress.Parse(remoteIp.ToString())))
                        {
                            badIp = false;
                            break;
                        }
                    }
                }
                catch (Exception ex) when (whichCatch.ToLower().Contains("range"))
                {

                }
                catch (Exception ex) when (whichCatch.ToLower().Contains("specific"))
                {

                }

                if (badIp)
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);

                    // TODO...
                    //var optionBuilder = new DbContextOptionsBuilder<CalculatorContext>();
                    //optionBuilder.UseSqlServer(_connectionString);

                    //Exception ex = new Exception($"Forbidden Request from IP: {remoteIp.ToString()}");

                    //using (CalculatorContext dbContext = new CalculatorContext(optionBuilder.Options)
                    //{
                    //      SAVE This DATA
                    //}
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
