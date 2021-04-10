using HORTI.CORE.CROSSCUTTING.ENUM;
using HORTI.CORE.CROSSCUTTING.LOG;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HORTI.CORE.CROSSCUTTING.MIDDLEWARE
{
    public class ValidationExceptionMiddleware : _BaseMiddleware
    {
        public ValidationExceptionMiddleware(RequestDelegate requestDelegate) : base(requestDelegate) { }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (ValidationException ex)
            {
                LogExtension.CreateLog(new LogObject
                {
                    Id = Guid.NewGuid().ToString(),
                    UserLog = httpContext.User.Identity.Name,
                    InfoLog = ex.ToString(),
                    LevelLog = EnumLogLevel.Warning,
                    TimeLog = DateTime.Now,
                    IPAddress = httpContext.Connection.RemoteIpAddress
                });

                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await httpContext.Response.WriteAsync(string.Empty);
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
