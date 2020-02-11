using CrossCuttingCoreHortiCommand.LOG;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WebApiCoreHortiQuery
{
    public class LogExceptionMiddleware
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
                    LevelLog = CrossCuttingCoreHortiCommand.ENUM.EnumLevelLog.Error,
                    TimeLog = DateTime.Now,
                    IPAddress = httpContext.Connection.RemoteIpAddress
                });

                httpContext.Response.ContentType = httpContext.Request.ContentType;
                await httpContext.Response.WriteAsync(ex.Message);
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
