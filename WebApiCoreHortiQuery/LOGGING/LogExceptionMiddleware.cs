using CrossCuttingCoreHortiCommand.EXCEPTION;
using CrossCuttingCoreHortiCommand.LOG;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
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
            catch (HttpStatusCodeException ex)
            {
                if (ex.StatusCode == HttpStatusCode.InternalServerError)
                {
                    LogExtension.CreateLog(new LogObject
                    {
                        Id = new Guid().ToString(),
                        UserLog = "",
                        InfoLog = ex.ToString(),
                        LevelLog = CrossCuttingCoreHortiCommand.ENUM.EnumLevelLog.Fatal,
                        TimeLog = DateTime.Now,
                        IPAddress = httpContext.Connection.RemoteIpAddress
                    });
                }
                else if (ex.StatusCode == HttpStatusCode.BadRequest)
                {
                    LogExtension.CreateLog(new LogObject
                    {
                        Id = new Guid().ToString(),
                        UserLog = "",
                        InfoLog = ex.ToString(),
                        LevelLog = CrossCuttingCoreHortiCommand.ENUM.EnumLevelLog.Error,
                        TimeLog = DateTime.Now,
                        IPAddress = httpContext.Connection.RemoteIpAddress
                    });
                }
                else
                {
                    LogExtension.CreateLog(new LogObject
                    {
                        Id = new Guid().ToString(),
                        UserLog = "",
                        InfoLog = ex.ToString(),
                        LevelLog = CrossCuttingCoreHortiCommand.ENUM.EnumLevelLog.Information,
                        TimeLog = DateTime.Now,
                        IPAddress = httpContext.Connection.RemoteIpAddress
                    });
                }

                httpContext.Response.StatusCode = (int)ex.StatusCode;
                httpContext.Response.ContentType = ex.ContentType;
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
