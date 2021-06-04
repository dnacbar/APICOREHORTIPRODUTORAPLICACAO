using Flurl.Http;
using HORTI.CORE.CROSSCUTTING.ENUM;
using HORTI.CORE.CROSSCUTTING.LOG;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HORTI.CORE.CROSSCUTTING.MIDDLEWARE
{
    public class BadGatewayExceptionMiddleware : _BaseMiddleware
    {
        public BadGatewayExceptionMiddleware(RequestDelegate requestDelegate) : base(requestDelegate) { }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (FlurlHttpException ex)
            {
                LogExtension.CreateLog(new LogObject
                {
                    Id = Guid.NewGuid().ToString(),
                    UserLog = httpContext.User.Identity.Name,
                    InfoLog = ex.ToString(),
                    LevelLog = EnumLogLevel.Error,
                    TimeLog = DateTime.Now,
                    IPAddress = httpContext.Connection.RemoteIpAddress
                });

                httpContext.Response.StatusCode = (int)HttpStatusCode.BadGateway;

                await httpContext.Response.WriteAsync(string.Empty);
            }
        }
    }

    public static class BadGatewayExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseBadGatewayExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BadGatewayExceptionMiddleware>();
        }
    }
}
