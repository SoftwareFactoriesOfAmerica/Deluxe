using Deluxe.Calculator.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deluxe.Calculator.Api.Controllers
{
    public interface ICalculatorController
    {
        IEnumerable<CalculatorSummaries> Get();
    }
}
