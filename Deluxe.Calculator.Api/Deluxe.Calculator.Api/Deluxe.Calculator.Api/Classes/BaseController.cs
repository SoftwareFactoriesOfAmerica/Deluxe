using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deluxe.Calculator.Api.Classes
{
    public class BaseController : ControllerBase
    {
        protected CalculatorContext _context;
    }
}
