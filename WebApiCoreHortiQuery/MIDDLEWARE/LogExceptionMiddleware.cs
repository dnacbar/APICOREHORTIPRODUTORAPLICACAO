using CrossCuttingCoreHortiCommand.LOG;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WEBAPICOREHORTIQUERY.MIDDLEWARE
{
    public sealed class LogExceptionMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        public LogExceptionMiddleware(RequestDelegate _requestDelegate)
        {
            requestDelegate = _requestDelegate ?? throw new ArgumentNullException(nameof(requestDelegate));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                LogExtension.CreateLog(new LogObject
                {
                    Id = Guid.NewGuid().ToString(),
                    UserLog = httpContext.User.Identity.Name,
                    InfoLog = ex.ToString(),
                    LevelLog = CrossCuttingCoreHortiCommand.ENUM.EnumLogLevel.Error,
                    TimeLog = DateTime.Now,
                    IPAddress = httpContext.Connection.RemoteIpAddress
                });

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await httpContext.Response.WriteAsync("{Status: 500}");
            }
        }
    }

    public static class LogExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogExceptionMiddleware>();
        }
    }
}
