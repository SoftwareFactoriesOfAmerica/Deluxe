using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deluxe.Calculator.Api.Classes
{
    public class BrowserInfo
    {
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }

        public string IpAddress { get; set; }

        public string OperatingSystem { get; set; }
    }

    public static class Browser
    {
        private static string ParseTheVersion(string browser, string name)
        {
            var value = browser.ToUpper().Split(name.ToUpper());
            value = value[1].Split(" ");

            return value[0];
        }

        public static string GetIpAddress(HttpContext context)
        {
            var request = context.Request;
            var ip = request.Headers["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrWhiteSpace(ip) || string.Equals(ip, "unknown", StringComparison.OrdinalIgnoreCase))
            {
                ip = request.Headers["REMOTE_ADDR"];
            }
            else
            {
                var index = ip.ToString().IndexOf(',');
                if (index > 0)
                    ip = ip.ToString().Substring(0, index);

                index = ip.ToString().IndexOf(':');
                if (index > 0)
                    ip = ip.ToString().Substring(0, index);
            }

            return ip;
        }

        public static string BrowserName(string userAgent)
        {
            if (!string.IsNullOrWhiteSpace(userAgent))
            {
                switch (userAgent)
                {
                    case var s when userAgent.ToLower().Contains("edg"): return "Microsoft Edge";
                    case var s when userAgent.ToLower().Contains("trident"): return "Microsoft Internet Explorer";
                    case var s when userAgent.ToLower().Contains("firefox"): return "Mozilla Firefox";
                    case var s when userAgent.ToLower().Contains("fxios"): return "Mozilla Firefox";
                    case var s when userAgent.ToLower().Contains("opr"): return "Opera";
                    case var s when userAgent.ToLower().Contains("ucbrowser"): return "UC Browser";
                    case var s when userAgent.ToLower().Contains("samsungbrowser"): return "Samsung Browser";
                    case var s when userAgent.ToLower().Contains("chrome"): return "Google Chrome";
                    case var s when userAgent.ToLower().Contains("chromium"): return "Google Chrome";
                    case var s when userAgent.ToLower().Contains("crios"): return "Google Chrome";
                    case var s when userAgent.ToLower().Contains("safari"): return "Apple Safari";
                    case var s when userAgent.ToLower().Contains("seamonkey"): return "SeaMonkey";
                    case var s when userAgent.ToLower().Contains("silk"): return "Silk";
                    default: return "unknown";
                }
            }

            return "unknown";
        }

        public static string BrowserVersion(string userAgent)
        {
            if (!string.IsNullOrWhiteSpace(userAgent))
            {
                switch (userAgent)
                {
                    case var s when userAgent.ToLower().Contains("edg"): return ParseTheVersion(userAgent, "edg/");
                    case var s when userAgent.ToLower().Contains("trident"): return ParseTheVersion(userAgent, "trident/");
                    case var s when userAgent.ToLower().Contains("firefox"): return ParseTheVersion(userAgent, "firefox/");
                    case var s when userAgent.ToLower().Contains("fxios"): return ParseTheVersion(userAgent, "firefox/");
                    case var s when userAgent.ToLower().Contains("opr"): return ParseTheVersion(userAgent, "opr/");
                    case var s when userAgent.ToLower().Contains("ucbrowser"): return ParseTheVersion(userAgent, "ucbrowser/");
                    case var s when userAgent.ToLower().Contains("samsungbrowser"): return ParseTheVersion(userAgent, "samsungbrowser/");
                    case var s when userAgent.ToLower().Contains("chrome"): return ParseTheVersion(userAgent, "Chrome/");
                    case var s when userAgent.ToLower().Contains("chromium"): return ParseTheVersion(userAgent, "Chrome/");
                    case var s when userAgent.ToLower().Contains("crios"): return ParseTheVersion(userAgent, "Chrome/");
                    case var s when userAgent.ToLower().Contains("safari"): return ParseTheVersion(userAgent, "safari/");
                    case var s when userAgent.ToLower().Contains("seamonkey"): return ParseTheVersion(userAgent, "seamonkey/");
                    case var s when userAgent.ToLower().Contains("silk"): return ParseTheVersion(userAgent, "silk/");
                    default: return "unknown";
                }
            }

            return "unknown";
        }

        public static string OperatingSystem(string userAgent)
        {
            if (string.IsNullOrWhiteSpace(userAgent))
                return "unknown";

            if (userAgent.Contains("Linux"))
                return "Linux";

            if (userAgent.Contains("Macintosh"))
                return "Linux";

            if (userAgent.Contains("iPhone"))
                return "Linux";

            if (userAgent.Contains("Android") && userAgent.Contains("Mobile"))
                return "Android";

            if (userAgent.Contains("Android") && userAgent.Contains("Tablet"))
                return "Android";

            if (userAgent.Contains("Android"))
                return "Android";

            if (userAgent.Contains("Windows"))
                return "Windows";

            return "unknown";
        }

        public static BrowserInfo DetermineBrowser(HttpContext context)
        {
            BrowserInfo info = new BrowserInfo();
            string userAgent = string.Empty;

            info.IpAddress = context.Connection.RemoteIpAddress.ToString();
            info.IpAddress += " Port: " + context.Connection.RemotePort.ToString();

            if (!string.IsNullOrWhiteSpace(context.Request.Headers["User-Agent"].ToString()))
            {
                userAgent = context.Request.Headers["User-Agent"].ToString();

                info.BrowserName = BrowserName(userAgent);
                info.BrowserVersion = BrowserVersion(userAgent);
                info.OperatingSystem = OperatingSystem(userAgent);
            }
            else
            {
                info.BrowserName = "unknown";
                info.BrowserVersion = "unknown";
                info.OperatingSystem = "unknown";
            }

            return info;
        }
    }
}
