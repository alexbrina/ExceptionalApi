using CoreDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ExceptionalApi
{
    public class ExceptionHandlerFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var result = context.Exception switch
            {
                DomainException => DomainExceptionHandler(context),
                _ => InternalServerErrorExceptionHandler(context)
            };

            if (result != null)
            {
                context.Result = result;
                context.ExceptionHandled = true;
            }
        }

        private static ObjectResult DomainExceptionHandler(ExceptionContext context)
        {
            var problemDetails = CreateBasicProblemDetails(context);

            if (context.Exception.Data.Count > 0)
            {
                problemDetails.Extensions["data"] = context.Exception.Data;
            }

            return new BadRequestObjectResult(problemDetails);
        }

        private static ObjectResult InternalServerErrorExceptionHandler(ExceptionContext context)
        {
            var problemDetails = CreateBasicProblemDetails(context);
            problemDetails.Status = StatusCodes.Status500InternalServerError;
            return new ObjectResult(problemDetails);
        }

        private static ProblemDetails CreateBasicProblemDetails(ExceptionContext context)
        {
            var problemDetails = new ProblemDetails
            {
                Title = context.Exception.GetType().Name,
                Instance = context.HttpContext.Request.Path.Value,
                Detail = context.Exception.Message
            };

            var traceId = Activity.Current?.Id
                ?? context.HttpContext.TraceIdentifier;

            if (traceId != null)
            {
                problemDetails.Extensions["traceId"] = traceId;
            }

            return problemDetails;
        }
    }
}
