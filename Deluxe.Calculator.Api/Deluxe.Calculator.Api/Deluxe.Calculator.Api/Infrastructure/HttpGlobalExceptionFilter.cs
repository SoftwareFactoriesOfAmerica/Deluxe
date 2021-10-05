using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Net;
using Deluxe.Calculator.Api.Classes;

namespace Deluxe.Calculator.Api.Infrastructure
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;
        private readonly CalculatorContext _context;

        public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger, CalculatorContext context)
        {
            _env = env;
            _logger = logger;
            _context = context;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            BrowserInfo browser = Browser.DetermineBrowser(context.HttpContext);

            if (context.Exception.GetType() == typeof(DomainExceptions))
            {
                var listOfErrors = ((ValidationException)context.Exception.InnerException)?.Errors ?? Array.Empty< ValidationFailure>();
                var problemDetails = new ValidationProblemDetails()
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = listOfErrors.Any() ? "Please refer to the errors for additional details." : context.Exception.Message
                };

                problemDetails.Errors.Add("DomainValidations", listOfErrors.Select(d => d.ErrorMessage).ToArray());

                context.Result = new BadRequestObjectResult(problemDetails);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { "An unexpected error occurred. Pleae try again." }
                };

                if (_env.IsEnvironment("Local") || _env.IsDevelopment())
                {
                    json.DeveloperMessage = context.Exception;
                }

                context.Result = new InternalServerErrorObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            Common.SaveCalculatorErrors(_context, context, browser);

            context.ExceptionHandled = true;
        }

        private class JsonErrorResponse
        {
            public string[] Messages { get; set; }
            public object DeveloperMessage { get; set; }
        }
    }
}
