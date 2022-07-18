using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.Api.Filter
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var problemDetail = new ProblemDetails
            {
                Title = "An error ocurred while processing your request",
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message
             };
            context.Result = new ObjectResult(problemDetail);
            context.ExceptionHandled = true;
        }
    }
}
