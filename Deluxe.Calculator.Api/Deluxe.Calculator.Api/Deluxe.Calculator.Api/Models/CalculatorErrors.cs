using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deluxe.Calculator.Api.Models
{
	public class CalculatorErrors
	{
		public Guid Id { get; set; }
		public string EmailAddress { get; set; }
		public string url { get; set; }
		public string Message { get; set; }
		public string InnerException { get; set; }
		public DateTime InsertionDateTime { get; set; }
		public string IpAddress { get; set; }
		public string Browser { get; set; }
		public string BrowserVersion { get; set; }
		public string OperatingSystem { get; set; }
	}
}
