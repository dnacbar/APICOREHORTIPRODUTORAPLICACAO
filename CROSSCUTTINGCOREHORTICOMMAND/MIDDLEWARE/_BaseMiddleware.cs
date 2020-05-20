using Microsoft.AspNetCore.Http;
using System;

namespace CROSSCUTTINGCOREHORTI.MIDDLEWARE
{
    public abstract class _BaseMiddleware
    {
        protected readonly RequestDelegate _requestDelegate;

        protected _BaseMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate ?? throw new ArgumentNullException(nameof(requestDelegate));
        }
    }
}
