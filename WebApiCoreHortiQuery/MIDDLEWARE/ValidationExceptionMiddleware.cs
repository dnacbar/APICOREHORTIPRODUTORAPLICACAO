using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WEBAPICOREHORTIQUERY.MIDDLEWARE
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        public ValidationExceptionMiddleware(RequestDelegate _requestDelegate)
        {
            requestDelegate = _requestDelegate ?? throw new ArgumentNullException(nameof(requestDelegate));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await requestDelegate(httpContext);
            }
            catch (ValidationException ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await httpContext.Response.WriteAsync(ex.Errors.ToString());
            }
        }
    }

    public static class ValidationExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidationExceptionMiddleware>();
        }
    }
}
