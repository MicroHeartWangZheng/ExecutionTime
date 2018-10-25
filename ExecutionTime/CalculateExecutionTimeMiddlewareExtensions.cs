using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExecutionTime
{
    public static class CalculateExecutionTimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseCalculateExecutionTime(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<CalculateExecutionTimeMiddleware>();
        }
    }
}
