using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deluxe.Calculator.Api.Models;
using Deluxe.Calculator.Api.Classes;
using Deluxe.Calculator.Api.Infrastructure;

namespace Deluxe.Calculator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : BaseController, ICalculatorController
    {
        private static readonly string[] Summaries = new[]
        {
            "Welcome to Deluxe"
        };

        private static readonly string[] Documents = new[]
{
            "https://www.deluxe.com/"
        };

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger, CalculatorContext context)
        {
            _logger = logger;
            base._context = context;
        }

        /// <summary>
        /// example: https://localhost:49155/Calculator
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[ServiceFilter(typeof(CheckIpAddressActionFilter))]
        public IEnumerable<CalculatorSummaries> Get()
        {
            return Enumerable.Range(1, Summaries.Length).Select(index => new CalculatorSummaries
            {
                Document = Documents[index - 1],
                Summary = Summaries[index - 1]
            })
            .ToArray();
        }
    }
}
