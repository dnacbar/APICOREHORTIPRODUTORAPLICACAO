using HORTI.CORE.CROSSCUTTING.ENUM;
using HORTI.CORE.CROSSCUTTING.LOG;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HORTI.CORE.CROSSCUTTING.MIDDLEWARE
{
    public sealed class FatalExceptionMiddleware : _BaseMiddleware
    {
        public FatalExceptionMiddleware(RequestDelegate requestDelegate) : base(requestDelegate) { }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                LogExtension.CreateLog(new LogObject
                {
                    Id = Guid.NewGuid().ToString(),
                    UserLog = httpContext.User.Identity.Name,
                    InfoLog = ex.ToString(),
                    LevelLog = EnumLogLevel.Fatal,
                    TimeLog = DateTime.Now,
                    IPAddress = httpContext.Connection.RemoteIpAddress
                });

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await httpContext.Response.WriteAsync(null);
            }
        }
    }

    public static class FatalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseFatalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FatalExceptionMiddleware>();
        }
    }
}
