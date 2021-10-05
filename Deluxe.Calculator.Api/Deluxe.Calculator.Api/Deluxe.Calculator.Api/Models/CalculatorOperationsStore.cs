using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deluxe.Calculator.Api.Models
{
	public class CalculatorOperationsStore
	{
		public Guid Id { get; set; }
		public string EmailAddress { get; set; }
		public string JsonData { get; set; }
		public DateTime InsertDateTime { get; set; }
		public DateTime ModifiedDateTime { get; set; }
	}
}
