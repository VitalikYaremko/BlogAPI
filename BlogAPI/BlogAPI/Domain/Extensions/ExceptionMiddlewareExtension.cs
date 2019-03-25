using BlogAPI.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder HandleErrors(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
