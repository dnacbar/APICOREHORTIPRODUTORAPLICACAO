using HORTI.CORE.CROSSCUTTING.ENUM;
using HORTI.CORE.CROSSCUTTING.LOG;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HORTI.CORE.CROSSCUTTING.MIDDLEWARE
{
    public class EntityFrameworkExceptionMiddleware : _BaseMiddleware
    {
        public EntityFrameworkExceptionMiddleware(RequestDelegate requestDelegate) : base(requestDelegate) { }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (DbUpdateException ex)
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

                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await httpContext.Response.WriteAsync(string.Empty);
            }
        }
    }

    public static class EntityFrameworkExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseEntityFrameworkExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EntityFrameworkExceptionMiddleware>();
        }
    }
}
